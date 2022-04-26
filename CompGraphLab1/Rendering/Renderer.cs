using CompGraphLab1.Data;
using CompGraphLab1.Scene;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace CompGraphLab1.Rendering
{
	public class Renderer
	{
		ITriangleSelector triangleSelector = new TriangleSelector();
		IMeshProjector meshProjector = new MeshProjector();
		IRasterizer rasterizer = new AltRasterizer();
		public float[,] RenderZBufferFillPoly(Vector2Int screenSize, IEnumerable<MeshTransform> sceneMeshes,
			DirectionalLight light, Camera camera, Color[,] render)
		{
			Stopwatch sw = new Stopwatch();
			sw.Start();
			var planared = new ConcurrentBag<(ObjPlanaredData planaredData, MeshTransform mesh)>();
			//project meshes to [(0,0); (1,1)] renderPlane space
			meshProjector.InitCameraState(camera);
			var worldSpaceMeshes = new ConcurrentBag<(ObjData worldSpaceData, MeshTransform mesh)>();
			Parallel.ForEach(sceneMeshes, (mesh) =>
			{
				worldSpaceMeshes.Add((mesh.DataToWorldSpace(true, camera.Position, camera.Normal), mesh));
			});
			Parallel.ForEach(worldSpaceMeshes, (mesh) =>
			{
				planared.Add((meshProjector.Project(mesh.worldSpaceData), mesh.mesh));
			});

			//raster planared meshes to bitmasks
			var rasteredMeshes = new ConcurrentBag<(ConcurrentBag<(RasterTriangleData rasterData, Triangle3D tri)>, MeshTransform)>();
			Parallel.ForEach(planared, (planar) =>
			{
				var rasteredPlanarTris = new ConcurrentBag<(RasterTriangleData, Triangle3D)>();
				Parallel.ForEach(planar.planaredData.tris, (tri) =>
					rasteredPlanarTris.Add((rasterizer.RasterTriangle(tri, screenSize.x, screenSize.y), tri.original)));
				rasteredMeshes.Add((rasteredPlanarTris, planar.mesh));
			});

			float[,] zbuffer = new float[screenSize.x, screenSize.y];
			Parallel.For(0, screenSize.x, (x) =>
		   {
			   for (int y = 0; y < screenSize.x; y++)
				   zbuffer[x, y] = float.MaxValue;
		   });

			foreach (var rasterMesh in rasteredMeshes)
				foreach (var triData in rasterMesh.Item1)
					ProcessTriangle(triData.rasterData, screenSize, zbuffer, light, rasterMesh.Item2, triData.tri, render);
			sw.Stop();
			var t = sw.ElapsedMilliseconds;

			return zbuffer;
		}

		public float[,] BezierSurfaceRenderZBufferFillPoly(Vector2Int screenSize, BezierSurfaceData bezierSurfaceData,
			 IEnumerable<MeshTransform> axes, DirectionalLight light, Camera camera, Color[,] render)
        {
			meshProjector.InitCameraState(camera);
			var planared = new ConcurrentBag<(ObjPlanaredData planaredData, MeshTransform mesh)>();
			//project meshes to [(0,0); (1,1)] renderPlane space
			meshProjector.InitCameraState(camera);
			var worldSpaceMeshes = new ConcurrentBag<(ObjData worldSpaceData, MeshTransform mesh)>();
			Parallel.ForEach(axes, (mesh) =>
			{
				worldSpaceMeshes.Add((mesh.DataToWorldSpace(true, camera.Position, camera.Normal), mesh));
			});
			Parallel.ForEach(worldSpaceMeshes, (mesh) =>
			{
				planared.Add((meshProjector.Project(mesh.worldSpaceData), mesh.mesh));
			});

			//raster planared meshes to bitmasks
			var rasteredMeshes = new ConcurrentBag<(ConcurrentBag<(RasterTriangleData rasterData, Triangle3D tri)>, MeshTransform)>();
			Parallel.ForEach(planared, (planar) =>
			{
				var rasteredPlanarTris = new ConcurrentBag<(RasterTriangleData, Triangle3D)>();
				Parallel.ForEach(planar.planaredData.tris, (tri) =>
					rasteredPlanarTris.Add((rasterizer.RasterTriangle(tri, screenSize.x, screenSize.y), tri.original)));
				rasteredMeshes.Add((rasteredPlanarTris, planar.mesh));
			});

			// bezier surface
			ObjData bezierSurfaceObjData = bezierSurfaceData.mesh.DataToWorldSpace(false, camera.Position, camera.Normal);
			ObjPlanaredData bezierSurfacePlanaredData = meshProjector.Project(bezierSurfaceObjData);
			var bezierRasteredPlanarTris = new ConcurrentBag<(RasterTriangleData, Triangle3D)>();
			Parallel.ForEach(bezierSurfacePlanaredData.tris, (tri) =>
					bezierRasteredPlanarTris.Add((bezierSurfaceData.rasterizer.RasterTriangle(tri, screenSize.x, screenSize.y), tri.original)));

			float[,] zbuffer = new float[screenSize.x, screenSize.y];
			Parallel.For(0, screenSize.x, (x) =>
			{
				for (int y = 0; y < screenSize.x; y++)
					zbuffer[x, y] = float.MaxValue;
			});
			foreach (var rasterMesh in rasteredMeshes)
				foreach (var triData in rasterMesh.Item1)
					ProcessTriangle(triData.rasterData, screenSize, zbuffer, light, rasterMesh.Item2, triData.tri, render);
			foreach (var triData in bezierRasteredPlanarTris)
				ProcessTriangle(triData.Item1, screenSize, zbuffer, light, bezierSurfaceData.mesh, triData.Item2, render);
			return zbuffer;
		}

		void ProcessTriangle(RasterTriangleData rastTri, Vector2Int screenSize, float[,] zbuffer, DirectionalLight light,
			MeshTransform mesh, Triangle3D tri, Color[,] render)
		{
			var color = mesh.triangleShader(mesh, tri, light);
			InitZCalc(rastTri);
			for (int x = 0; x < rastTri.bitMask.GetLength(0); x++)
				for (int y = 0; y < rastTri.bitMask.GetLength(1); y++)
				{
					if (rastTri.bitMask[x, y])
					{
						int zx = x + rastTri.x;
						int zy = y + rastTri.y;
						if (zx >= render.GetLength(0) || zy >= render.GetLength(1) || zx < 0 || zy < 0)
							continue;
						var z = CalcZ(rastTri, (float)(zx) / screenSize.x, (float)(zy) / screenSize.y);
						if (z < zbuffer[zx, zy])
						{
							zbuffer[zx, zy] = z;
							render[zx, zy] = color;
						}
					}
				}
		}

		float Area(float ptx, float pty, in Vector2 p2, in Vector2 p3)
		{
			return MathF.Abs((ptx * (p2.y - p3.y) + p2.x * (p3.y - pty) + p3.x * (pty - p2.y)) / 2f);
		}

		float currentTotalArea = 0;
		void InitZCalc(RasterTriangleData rastTri)
		{
			currentTotalArea = Area(rastTri.source.verts[0].x, rastTri.source.verts[0].y,
				rastTri.source.verts[1],
				rastTri.source.verts[2]);
		}

		float CalcZ(RasterTriangleData rastTri, float x, float y)
		{
			float z1 = rastTri.source.vertDists[0];
			float z2 = rastTri.source.vertDists[1];
			float z3 = rastTri.source.vertDists[2];
			float a1 = Area(x, y, rastTri.source.verts[1], rastTri.source.verts[2]);
			float a2 = Area(x, y, rastTri.source.verts[0], rastTri.source.verts[2]);
			float a3 = Area(x, y, rastTri.source.verts[0], rastTri.source.verts[1]);
			return (z1 * a1 + z2 * a2 + z3 * a3) / currentTotalArea;
		}
	}
}

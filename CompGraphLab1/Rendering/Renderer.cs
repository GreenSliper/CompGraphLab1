using CompGraphLab1.Data;
using CompGraphLab1.Scene;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
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
		public float[,] RenderZBufferFillPoly(Vector2Int screenSize, IEnumerable<MeshTransform> sceneMeshes, Camera camera,
			Func<MeshTransform, Triangle3D, Color> renderFunction, Color[,] render)
		{
			var planared = new ConcurrentBag<(ObjPlanaredData planaredData, MeshTransform mesh)>();
			//project meshes to [(0,0); (1,1)] renderPlane space
			Parallel.ForEach(sceneMeshes, (mesh) =>
			{
				planared.Add((meshProjector.Project(triangleSelector.SelectVisibleData(mesh, camera.Position, camera.Normal), camera), mesh));
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
			for (int x = 0; x < screenSize.x; x++)
				for (int y = 0; y < screenSize.x; y++)
					zbuffer[x,y] = float.MaxValue;

			foreach (var rasterMesh in rasteredMeshes)
				foreach (var triData in rasterMesh.Item1)
					ProcessTriangle(triData.rasterData, screenSize, zbuffer, renderFunction, rasterMesh.Item2, triData.tri, render);
			return zbuffer;
		}

		void ProcessTriangle(RasterTriangleData rastTri, Vector2Int screenSize, float[,] zbuffer,
			Func<MeshTransform, Triangle3D, Color> renderFunction, MeshTransform mesh, Triangle3D tri, Color[,] render)
		{
			var color = renderFunction(mesh, tri);
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

		float CalcZ(RasterTriangleData rastTri, float x, float y)
		{
			float z1 = rastTri.source.vertDists[0];
			float z2 = rastTri.source.vertDists[1];
			float z3 = rastTri.source.vertDists[2];
			float a1 = Area(x, y, rastTri.source.verts[1], rastTri.source.verts[2]);
			float a2 = Area(x, y, rastTri.source.verts[0], rastTri.source.verts[2]);
			float a3 = Area(x, y, rastTri.source.verts[0], rastTri.source.verts[1]);
			return (z1 * a1 + z2 * a2 + z3 * a3) / (a1+a2+a3);
		}
	}
}

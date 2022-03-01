using CompGraphLab1.Data;
using CompGraphLab1.Scene;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompGraphLab1.Rendering
{
	public class ZBufferBuilder
	{
		IMeshProjector meshProjector = new MeshProjector();
		IRasterizer rasterizer = new Rasterizer();
		public float[,] BuildBuffer(Vector2Int screenSize, IEnumerable<MeshTransform> sceneMeshes, Camera camera)
		{
			var planared = new ConcurrentBag<ObjPlanaredData>();
			//project meshes to [(0,0); (1,1)] renderPlane space
			Parallel.ForEach(sceneMeshes, (mesh) =>
			{
				planared.Add(meshProjector.Project(mesh.DataToWorldSpace(), camera));
			});
			//raster planared meshes to bitmasks
			var rasteredMeshes = new ConcurrentBag<ConcurrentBag<RasterTriangleData>>();
			Parallel.ForEach(planared, (planar) =>
			{
				var rasteredPlanarTris = new ConcurrentBag<RasterTriangleData>();
				Parallel.ForEach(planar.tris, (tri) =>
					rasteredPlanarTris.Add(rasterizer.RasterTriangle(tri, screenSize.x, screenSize.y)));
				rasteredMeshes.Add(rasteredPlanarTris);
			});

			float[,] zbuffer = new float[screenSize.x, screenSize.y];
			for (int x = 0; x < screenSize.x; x++)
				for (int y = 0; y < screenSize.x; y++)
					zbuffer[x,y] = float.MaxValue;

			foreach (var rasterMesh in rasteredMeshes)
				foreach (var tri in rasterMesh)
					ProcessTriangle(tri, screenSize, zbuffer);
			
			return zbuffer;
		}

		void ProcessTriangle(RasterTriangleData rastTri, Vector2Int screenSize, float[,] zbuffer)
		{
			for (int x = 0; x < rastTri.bitMask.GetLength(0); x++)
				for (int y = 0; y < rastTri.bitMask.GetLength(1); y++)
				{
					if (rastTri.bitMask[x, y])
					{
						int zx = x + rastTri.x;
						int zy = y + rastTri.y;
						//var z = CalcZ(rastTri, (float)(zx) / screenSize.x, (float)(zy) / screenSize.y);
						//if (z < zbuffer[zx, zy])
							zbuffer[zx, zy] = 1;
					}
				}
		}

		float CalcZ(RasterTriangleData rastTri, float x, float y)
		{
			float d0 = MathF.Sqrt(MathF.Pow(rastTri.source.verts[0].x - x, 2) + MathF.Pow(rastTri.source.verts[0].y - y, 2));
			float d1 = MathF.Sqrt(MathF.Pow(rastTri.source.verts[1].x - x, 2) + MathF.Pow(rastTri.source.verts[1].y - y, 2));
			float d2 = MathF.Sqrt(MathF.Pow(rastTri.source.verts[2].x - x, 2) + MathF.Pow(rastTri.source.verts[2].y - y, 2));
			return (rastTri.source.vertDists[0] * d0 + rastTri.source.vertDists[1] * d1 + rastTri.source.vertDists[2] * d2) / (d0 + d1 + d2);
		}
	}
}

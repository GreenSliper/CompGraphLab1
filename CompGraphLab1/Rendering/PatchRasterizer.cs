using CompGraphLab1.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompGraphLab1.Rendering
{
	public class PatchRasterizer : IRasterizer
	{
		float Min(params float[] vals)
		{
			var min = vals[0];
			for (int i = 1; i < vals.Length; i++)
				if (vals[i] < min)
					min = vals[i];
			return min;
		}

		float Max(params float[] vals)
		{
			var min = vals[0];
			for (int i = 1; i < vals.Length; i++)
				if (vals[i] > min)
					min = vals[i];
			return min;
		}
		public RasterTriangleData RasterTriangle(Triangle2D triangle, float pxWidth, float pxHeight)
		{
			Vector2Int lbc = new Vector2Int((int)MathF.Round(pxWidth * Min(triangle.verts[0].x, triangle.verts[1].x, triangle.verts[2].x)),
										 (int)MathF.Round(pxHeight * Min(triangle.verts[0].y, triangle.verts[1].y, triangle.verts[2].y)));
			Vector2Int rtc = new Vector2Int((int)MathF.Round(pxWidth * Max(triangle.verts[0].x, triangle.verts[1].x, triangle.verts[2].x)),
										 (int)MathF.Round(pxHeight * Max(triangle.verts[0].y, triangle.verts[1].y, triangle.verts[2].y)));

			var rtd = new RasterTriangleData()
			{
				x = lbc.x,
				y = lbc.y,
				bitMask = new bool[rtc.x - lbc.x + 1, rtc.y - lbc.y + 1],
				source = triangle
			};

			Vector2 scaler = new Vector2(pxWidth, pxHeight);
			Vector2 v0 = triangle.verts[0].Multiply(scaler);
			Vector2 v1 = triangle.verts[1].Multiply(scaler);
			Vector2 v2 = triangle.verts[2].Multiply(scaler);

			//Rasterize(v0, v1, rtd);
			Rasterize(v1, v2, rtd);
			Rasterize(v0, v2, rtd);


			return rtd;
		}

		private void Rasterize(Vector2 v0_, Vector2 v1_, RasterTriangleData rtd)
        {
			Vector2Int v0 = new Vector2Int((int)MathF.Round(v0_.x), (int)MathF.Round(v0_.y));
			Vector2Int v1 = new Vector2Int((int)MathF.Round(v1_.x), (int)MathF.Round(v1_.y));
			int dx = Math.Abs(v1.x - v0.x), sx = v0.x < v1.x ? 1 : -1;
			int dy = Math.Abs(v1.y - v0.y), sy = v0.y < v1.y ? 1 : -1;
			int err = (dx > dy ? dx : -dy) / 2, e2;
			while (true)
			{
				rtd.bitMask[v0.x - rtd.x, v0.y - rtd.y] = true;
				if (v0.x == v1.x && v0.y == v1.y) break;
				e2 = err;
				if (e2 > -dx) { err -= dy; v0.x += sx; }
				if (e2 < dy) { err += dx; v0.y += sy; }
			}
		}
	}
}

using CompGraphLab1.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompGraphLab1.Rendering
{
	class AltRasterizer : IRasterizer
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
				bitMask = new bool[rtc.x - lbc.x + 1, rtc.y - lbc.y+1],
				source = triangle
			};

			Vector2 scaler = new Vector2(pxWidth, pxHeight);
			Vector2 v0 = triangle.verts[0].Multiply(scaler);
			Vector2 v1 = triangle.verts[1].Multiply(scaler);
			Vector2 v2 = triangle.verts[2].Multiply(scaler);

			float startArea = Area(v0.x, v0.y, v1, v2);
			for (int x = 0; x < rtd.bitMask.GetLength(0); x++)
				for (int y = 0; y < rtd.bitMask.GetLength(1); y++)
					rtd.bitMask[x, y] = PointInTriangle(x + lbc.x, y + lbc.y, v0, v1, v2, startArea); 
			return rtd;
		}

		float Area(float ptx, float pty, in Vector2 p2, in Vector2 p3)
		{
			return MathF.Abs((ptx * (p2.y - p3.y) + p2.x * (p3.y - pty) + p3.x * (pty - p2.y)) / 2f);
		}

		bool PointInTriangle(int ptx, int pty, in Vector2 v1, in Vector2 v2, in Vector2 v3, float startArea)
		{
			float a1 = Area(ptx, pty, v1, v2);
			float a2 = Area(ptx, pty, v2, v3);
			float a3 = Area(ptx, pty, v1, v3);
			return MathF.Abs(startArea - a1 - a2 - a3) < 1f;
		}
	}
}

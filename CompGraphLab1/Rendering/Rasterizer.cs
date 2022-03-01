using CompGraphLab1.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompGraphLab1.Rendering
{
	public class Rasterizer : IRasterizer
	{
		public RasterTriangleData RasterTriangle(Triangle2D triangle, float pxWidth, float pxHeight)
		{
			// coordinates in raster space
			Vector2Int vertex1 = ConvertToRaster(triangle.verts[0], pxWidth, pxHeight);
			Vector2Int vertex2 = ConvertToRaster(triangle.verts[1], pxWidth, pxHeight);
			Vector2Int vertex3 = ConvertToRaster(triangle.verts[2], pxWidth, pxHeight);

			// coordinates of the upper left corner of the rectangle
			Vector2Int upperLeftCorner = new Vector2Int(
				Math.Min(vertex1.x, Math.Min(vertex2.x, vertex3.x)),
				Math.Max(vertex1.y, Math.Max(vertex2.y, vertex3.y)));

			// coordinates of the lower right corner of the rectangle
			Vector2Int lowerRightCorner = new Vector2Int(
				Math.Max(vertex1.x, Math.Max(vertex2.x, vertex3.x)),
				Math.Min(vertex1.y, Math.Min(vertex2.y, vertex3.y)));

			// coordinates of the lower left corner of the rectangle
			Vector2Int lowerLeftCorner = new Vector2Int(upperLeftCorner.x, lowerRightCorner.y);

			// triangle bitmask
			bool[,] bitMask = new bool[
				upperLeftCorner.y - lowerRightCorner.y + 1,
				lowerRightCorner.x - upperLeftCorner.x + 1];

			Rasterize(
				new Vector2Int(vertex1.x - lowerLeftCorner.x, vertex1.y - lowerLeftCorner.y),
				new Vector2Int(vertex2.x - lowerLeftCorner.x, vertex2.y - lowerLeftCorner.y),
				new Vector2Int(vertex3.x - lowerLeftCorner.x, vertex3.y - lowerLeftCorner.y),
				bitMask);

			return new RasterTriangleData
			{
				x = lowerLeftCorner.x,
				y = lowerLeftCorner.y,
				bitMask = bitMask,
				source = triangle
			};
		}

		private Vector2Int ConvertToRaster(Vector2 point, float pxWidth, float pxHeight)
        {
			return new Vector2Int(
				(int)MathF.Round(point.x * (pxWidth - 1)),
				(int)MathF.Round((1 - point.y) * (pxHeight - 1)));
        }

		static void Swap<T>(ref T lhs, ref T rhs)
		{
			T temp = lhs;
			lhs = rhs;
			rhs = temp;
		}

		private void Rasterize(Vector2Int v1, Vector2Int v2, Vector2Int v3, bool[,] bitMask)
		{
			if (v2.y < v1.y)
				Swap(ref v1, ref v2);
			if (v3.y < v1.y)
				Swap(ref v1, ref v3);
			if (v2.y > v3.y)
				Swap(ref v2, ref v3);

			float dx13 = (v3.y != v1.y) ? ((float)(v3.x - v1.x)) / (v3.y - v1.y) : 0;
			float dx12 = (v2.y != v1.y) ? ((float)(v2.x - v1.x)) / (v2.y - v1.y) : 0;
			float dx23 = (v3.y != v2.y) ? ((float)(v3.x - v2.x)) / (v3.y - v2.y) : 0;
			float _dx13 = dx13;
			float wx1 = v1.x;
			float wx2 = wx1;
			
			if (dx13 > dx12)
				Swap(ref dx13, ref dx12);

			for (int i = v1.y; i < v2.y; ++i)
			{
				for (int j = Convert.ToInt32(wx1); j <= Convert.ToInt32(wx2); ++j)
					bitMask[i, j] = true;
				wx1 += dx13;
				wx2 += dx12;
			}

			if (v1.y == v2.y)
			{
				wx1 = v1.x;
				wx2 = v2.x;
			}
			if (_dx13 < dx23)
				Swap(ref _dx13, ref dx23);

			for (int i = v2.y; i <= v3.y; i++)
			{
				for (int j = Convert.ToInt32(wx1); j <= Convert.ToInt32(wx2); j++)
					bitMask[i, j] = true;
				wx1 += _dx13;
				wx2 += dx23;
			}
		}
	}
}

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

			// coordinates of the lower left corner of the rectangle
			Vector2Int lowerLeftCorner = new Vector2Int(
				Math.Min(vertex1.x, Math.Min(vertex2.x, vertex3.x)),
				Math.Max(vertex1.y, Math.Max(vertex2.y, vertex3.y)));

			// coordinates of the upper right corner of the rectangle
			Vector2Int upperRightCorner = new Vector2Int(
				Math.Max(vertex1.x, Math.Max(vertex2.x, vertex3.x)),
				Math.Min(vertex1.y, Math.Min(vertex2.y, vertex3.y)));

			// coordinates of the upper left corner of the rectangle
			Vector2Int upperLeftCorner = new Vector2Int(lowerLeftCorner.x, upperRightCorner.y);

			// triangle bitmask
			bool[,] bitMask = new bool[
				lowerLeftCorner.y - upperRightCorner.y,
				upperRightCorner.x - lowerLeftCorner.x];

			// starts and ends of the lines to fill the triangle
			int[,] ranges = new int[bitMask.GetLength(0), 2];

			// flags indicating whether the given line was processed before
			bool[] flags = new bool[bitMask.GetLength(0)];

			BresenhamLine(vertex1, vertex2, upperLeftCorner, bitMask, ranges, flags);
			BresenhamLine(vertex2, vertex3, upperLeftCorner, bitMask, ranges, flags);
			BresenhamLine(vertex3, vertex1, upperLeftCorner, bitMask, ranges, flags);

			FillTriangleBitMask(bitMask, ranges);

			return new RasterTriangleData
			{
				x = lowerLeftCorner.x,
				y = lowerLeftCorner.y,
				bitMask = bitMask
			};
			// throw new NotImplementedException();
		}

		private Vector2Int ConvertToRaster(Vector2 point, float pxWidth, float pxHeight)
        {
			return new Vector2Int(
				(int)MathF.Round(point.x * pxWidth),
				(int)MathF.Round((1 - point.y) * pxHeight));
        }

		// in this case, the Bresenham algorithm is used to fill
        // in the bitmask of the lines of the triangle
		private void BresenhamLine(Vector2Int v1, Vector2Int v2, Vector2Int bitMaskStart, bool[,] bitMask, int[,] ranges, bool[] flags)
        {
			int deltaX = Math.Abs(v2.x - v1.x);
			int deltaY = Math.Abs(v2.y - v1.y);
			int signX = v1.x < v2.x ? 1 : -1;
			int signY = v1.y < v2.y ? 1 : -1;
			int error = deltaX - deltaY;
			int posX = v2.x - bitMaskStart.x;
			int posY = v2.y - bitMaskStart.y;

			bitMask[posY, posX] = true;
			if (flags[posY])
			{
				ranges[posY, 0] = Math.Min(ranges[posY, 0], posX);
			}
			else
            {
				ranges[posY, 0] = posX;
				flags[posY] = true;
			}
			ranges[posY, 1] = Math.Max(ranges[posY, 1], posX);

			while (v1.x != v2.x || v1.y != v2.y)
            {
				int tmp_error = error * 2;
				posX = v1.x - bitMaskStart.x;
				posY = v1.y - bitMaskStart.y;

				bitMask[posY, posX] = true;
				if (flags[posY])
				{
					ranges[posY, 0] = Math.Min(ranges[posY, 0], posX);
				}
				else
				{
					ranges[posY, 0] = posX;
					flags[posY] = true;
				}
				ranges[posY, 1] = Math.Max(ranges[posY, 1], posX);

				if (tmp_error > -deltaY)
                {
					error -= deltaY;
					v1.x += signX;
                }
				if (tmp_error < deltaX)
                {
					error += deltaX;
					v2.y += signY;
                }
            }
        }

		private void FillTriangleBitMask(bool[,] bitMask, int[,] ranges)
		{
			for (int i = 0; i < ranges.GetLength(0); ++i)
			{
				for (int j = ranges[i, 0]; j < ranges[i, 1]; ++j)
				{
					bitMask[i, j] = true;
				}
			}
		}
	}
}

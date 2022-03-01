using CompGraphLab1.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompGraphLab1.Rendering
{
	public interface IRasterizer
	{
		RasterTriangleData RasterTriangle(Triangle2D triangle, float pxWidth, float pxHeight);
	}
}

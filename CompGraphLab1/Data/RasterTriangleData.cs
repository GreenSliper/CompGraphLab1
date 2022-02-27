using System;
using System.Collections.Generic;
using System.Text;

namespace CompGraphLab1.Data
{
	public class RasterTriangleData
	{
		/// <summary>
		/// left bottom angle in pixels
		/// </summary>
		public int x, y;
		/// <summary>
		/// True, if the pixel is a part of triangle, otherwise - false
		/// </summary>
		public bool[] bitMask;
	}
}

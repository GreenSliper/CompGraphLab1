using System;
using System.Collections.Generic;
using System.Text;

namespace CompGraphLab1.Data
{
	/// <summary>
	/// Projected on the renderPlane triangle data
	/// </summary>
	public struct Triangle2D
	{
		public Vector2[] verts;

		public Triangle2D(Vector2 v1, Vector2 v2, Vector2 v3)
		{
			verts = new Vector2[3] { v1, v2, v3 };
		}
	}
}

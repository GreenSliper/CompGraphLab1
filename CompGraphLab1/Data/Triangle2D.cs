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
		Triangle3D original;

		public float DistTo3D(Vector3 cameraPosition, Vector2 pointOnTriangle2D)
		{
			//distance to origin of the point in 3d to camera position
			throw new NotImplementedException();
		}

		public Triangle2D(Vector2 v1, Vector2 v2, Vector2 v3, Triangle3D original)
		{
			this.original = original;
			verts = new Vector2[3] { v1, v2, v3 };
		}
	}
}

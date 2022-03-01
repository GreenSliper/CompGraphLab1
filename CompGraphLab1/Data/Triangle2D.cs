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
		public float[] vertDists;
		public Triangle3D original;

		public float DistTo3D(Vector3 cameraPosition, Vector2 pointOnTriangle2D)
		{
			//distance to origin of the point in 3d to camera position
			throw new NotImplementedException();
		}

		public Triangle2D(Vector2 v1, Vector2 v2, Vector2 v3, float v1Z, float v2Z, float v3Z, Triangle3D original)
		{
			verts = new Vector2[3] { v1, v2, v3 };
			vertDists = new float[3] { v1Z, v2Z, v3Z };
			this.original = original;
		}
	}
}

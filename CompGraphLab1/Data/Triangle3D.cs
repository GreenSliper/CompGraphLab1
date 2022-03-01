using System;
using System.Collections.Generic;
using System.Text;

namespace CompGraphLab1.Data
{
	public struct Triangle3D
	{
		public Triangle3D(Vector3 v1, Vector3 v2, Vector3 v3)
		{
			verts = new Vector3[3] { v1, v2, v3 };
		}

		public Vector3[] verts;
		//TODO
		public Vector3 Normal
		{
			get 
			{
				Vector3 A = verts[1] - verts[0];
				Vector3 B = verts[2] - verts[1];
				return new Vector3(A.y * B.z - A.z * B.y, A.z * B.x - A.x * B.z, A.x * B.y - A.y * B.x);
			}
		}
	}
}

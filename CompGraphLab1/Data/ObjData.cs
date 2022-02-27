using System;
using System.Collections.Generic;
using System.Text;

namespace CompGraphLab1.Data
{
	public class ObjData
	{
		//Triangles. Sufficient obj data
		public List<Triangle3D> tris = new List<Triangle3D>();

		/// <summary>
		/// Get all verticies
		/// </summary>
		public IEnumerable<Vector3> GetVerts()
		{
			foreach (var tr in tris)
			{
				for (int i = 0; i < 3; i++)
					yield return tr.verts[i];
			}
		}
	}
}

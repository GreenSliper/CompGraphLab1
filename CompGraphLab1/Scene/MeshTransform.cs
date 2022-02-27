using CompGraphLab1.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompGraphLab1.Scene
{
	/// <summary>
	/// Transform to be rendered
	/// </summary>
	public class MeshTransform : Transform
	{
		public ObjData objData;

		public ObjData DataToWorldSpace()
		{
			var offs = Position;
			var rot = Rotation;
			//copy data
			ObjData result = new ObjData() { tris = new List<Triangle3D>(objData.tris) };

			for(int i = 0; i < result.tris.Count; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					result.tris[i].verts[j] += offs;
					result.tris[i].verts[j] = result.tris[i].verts[j].Rotate(Rotation);
				}
			}
			return result;
		}
	}
}

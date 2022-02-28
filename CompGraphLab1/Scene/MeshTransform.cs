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
			ObjData result = new ObjData();

			for(int i = 0; i < objData.tris.Count; i++)
			{
				result.tris.Add(new Triangle3D(objData.tris[i].verts[0], objData.tris[i].verts[1], objData.tris[i].verts[2]));
				for (int j = 0; j < 3; j++)
				{
					result.tris[i].verts[j] = result.tris[i].verts[j].Rotate(Rotation);
					result.tris[i].verts[j] += offs;
				}
			}
			return result;
		}
	}
}

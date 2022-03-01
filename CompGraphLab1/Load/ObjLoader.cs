using CompGraphLab1.Data;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace CompGraphLab1.Load
{
	public class ObjLoader : IObjLoader
	{
		public ObjData LoadFile(string path)
		{
			ObjData result = new ObjData();
			List<Vector3> verts = new List<Vector3>();
			using (var sr = new StreamReader(path))
			{
				string line = "";
				//skip meta
				while ((line = sr.ReadLine()) != null && line[0] != 'v') ;
				//read verts
				do
				{
					line = line.Replace('.', ',');
					var splt = line.Split();
					Vector3 vert = new Vector3(float.Parse(splt[1]), float.Parse(splt[2]), float.Parse(splt[3]));
					verts.Add(vert);
				}
				while ((line = sr.ReadLine()) != null && line[0] == 'v');
				
				//skip meta
				while ((line = sr.ReadLine()) != null && line[0] != 'f') ;
				//read tris
				do
				{
					var splt = line.Split();
					Triangle3D triangle = new Triangle3D(verts[int.Parse(splt[1]) - 1],
						verts[int.Parse(splt[2]) - 1],
						verts[int.Parse(splt[3]) - 1]);
					result.tris.Add(triangle);
				}
				while ((line = sr.ReadLine()) != null && line[0] == 'f');
			}
			return result;
		}
	}
}

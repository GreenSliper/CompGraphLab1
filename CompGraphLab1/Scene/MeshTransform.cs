using CompGraphLab1.Data;
using CompGraphLab1.Rendering;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CompGraphLab1.Scene
{
	/// <summary>
	/// Transform to be rendered
	/// </summary>
	public class MeshTransform : Transform
	{
		public Vector3 baseColor = new Vector3(Color.White)/255;
		public ObjData objData;
		public Func<MeshTransform, Triangle3D, PointLight, Color> triangleShader = Shaders.DiffuseColor;

		public ObjData DataToWorldSpace(bool removeInvertedTris = true, Vector3 eyePosition = default, Vector3 eyeNormal = default)
		{
			var offs = Position;
			var rot = Vector3.GetRotationMatrix(Rotation);
			var scale = Scale;
			//copy data
			ObjData result = new ObjData() { tris = new List<Triangle3D>(objData.tris.Count / (removeInvertedTris ? 2 : 1)) };
			for(int i = 0; i < objData.tris.Count; i++)
			{
				var tri = new Triangle3D(objData.tris[i].verts[0], objData.tris[i].verts[1], objData.tris[i].verts[2]);
				for (int j = 0; j < 3; j++)
				{
					tri.verts[j] = tri.verts[j].Rotate(rot);
					tri.verts[j] = tri.verts[j].Multiply(scale);
					tri.verts[j] += offs;
				}
				if (removeInvertedTris && tri.Normal.Angle(eyeNormal) < MathF.PI / 2)
					continue;
				else
					result.tris.Add(tri);
			}
			return result;
		}
	}
}

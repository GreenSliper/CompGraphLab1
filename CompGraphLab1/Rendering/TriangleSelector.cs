using CompGraphLab1.Data;
using CompGraphLab1.Load;
using CompGraphLab1.Scene;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompGraphLab1.Rendering
{
	class TriangleSelector : ITriangleSelector
	{
		public ObjData SelectVisibleData(MeshTransform obj, Vector3 eyePosition, Vector3 eyeNormal)
		{
			//TODO calc
			var data = obj.DataToWorldSpace();
			for (int i = 0; i < data.tris.Count; i++)
			{
				if (data.tris[i].Normal.Angle(eyeNormal) < MathF.PI/2)
					data.tris.RemoveAt(i--);
			}
			return data;
		}
	}
}

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
			return obj.DataToWorldSpace();
		}
	}
}

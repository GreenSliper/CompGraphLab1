using CompGraphLab1.Data;
using CompGraphLab1.Load;
using CompGraphLab1.Scene;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompGraphLab1.Rendering
{
	public interface ITriangleSelector
	{
		/// <summary>
		/// Returns objData with triangles in world space, which should be rendered
		/// </summary>
		/// <param name="obj">Object (contains mesh data & transform data)</param>
		/// <param name="eyePosition">Camera eye position vector</param>
		/// <param name="eyeNormal">Camera look direction vector</param>
		/// <returns>ObjData with triangles in world space</returns>
		ObjData SelectVisibleData(MeshTransform obj, Vector3 eyePosition, Vector3 eyeNormal);
	}
}

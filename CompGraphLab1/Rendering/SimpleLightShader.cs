using CompGraphLab1.Data;
using CompGraphLab1.Scene;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CompGraphLab1.Rendering
{
	public static class SimpleLightShader
	{
		public static Color GetTriangleColor(MeshTransform mesh, Triangle3D triangle, DirectionalLight light)
		{
			var cos = MathF.Cos(triangle.Normal.Angle(light.Normal));
			if (cos >= 0)
				return (mesh.baseColor.Multiply(light.baseColor) * cos * 255).ToColor();
			else
				return Color.Black;
		}
	}
}

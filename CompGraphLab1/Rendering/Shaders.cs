using CompGraphLab1.Data;
using CompGraphLab1.Scene;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CompGraphLab1.Rendering
{
	public static class Shaders
	{
		public static Color DiffuseColor(MeshTransform mesh, Triangle3D triangle, PointLight light)
		{
			Vector3 vec = Vector3.Zero;
			foreach (var v in triangle.verts)
				vec += v;
			vec /= 3f;
			vec = light.Position - vec;
			var cos = triangle.Normal.AngleCos(vec);
			float dist = vec.Magnitude();
			if (cos >= 0 && dist < light.radius)
				return (mesh.baseColor.Multiply(light.baseColor) * cos * 255 * light.intensity * MathF.Pow(1 - light.radius / dist, 2)).ToColor();
			else
				return Color.Black;
		}
		public static Color UnlitColor(MeshTransform mesh, Triangle3D triangle, PointLight light)
		{
			return (mesh.baseColor*255).ToColor();
		}
	}
}

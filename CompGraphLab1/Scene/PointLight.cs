using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CompGraphLab1.Scene
{
	public class PointLight : Transform
	{
		public float radius = 5f;
		public float intensity = 1f;
		public Vector3 baseColor = new Vector3(Color.White) / 255;
	}
}

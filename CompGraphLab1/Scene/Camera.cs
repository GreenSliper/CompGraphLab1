using System;
using System.Collections.Generic;
using System.Text;

namespace CompGraphLab1.Scene
{
	public class Camera : Transform
	{
		public float renderPlaneDistance = 1f;
		public float horizontalAngle = 90f;
		public float verticalAngle = 60f;
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CompGraphLab1.Scene
{
	public class Camera : Transform
	{
		private float height;
		private float length;
		private float distanceEye;
		public Camera(float height, float length, float distanceEye)// только примерно определил необходимые величины
        {
			this.height = height;
			this.height = length;
			this.height = distanceEye;
		}
		
		public float getHeight()
        {
			return height;
        }

		public float getLength()
		{
			return length;
		}

		public float getDistanceEye()
		{
			return distanceEye;
		}
	}
}

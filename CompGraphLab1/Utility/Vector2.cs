using System;
using System.Collections.Generic;
using System.Text;

namespace CompGraphLab1
{
	//TODO implement all vector3 methods here as well
	public struct Vector2
	{
		public float x, y;

		public Vector2(float x, float y)
		{
			this.x = x;
			this.y = y;
		}

		public Vector2 Multiply(Vector2 other)
		{
			return new Vector2(x * other.x, y * other.y);
		}

		public static Vector2 operator +(Vector2 first, Vector2 second)
		{
			return new Vector2(first.x + second.x, first.y + second.y);
		}

		public static Vector2 operator -(Vector2 first, Vector2 second)
		{
			return new Vector2(first.x - second.x, first.y - second.y);
		}
	}
}

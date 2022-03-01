using System;

namespace CompGraphLab1
{
	public struct Vector2Int
	{
		public int x, y;

		public Vector2Int(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public static Vector2Int operator +(Vector2Int first, Vector2Int second)
		{
			return new Vector2Int(first.x + second.x, first.y + second.y);
		}

		public static Vector2Int operator -(Vector2Int first, Vector2Int second)
		{
			return new Vector2Int(first.x - second.x, first.y - second.y);
		}
	}
}

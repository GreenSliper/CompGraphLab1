using System;
using System.Collections.Generic;
using System.Text;

namespace CompGraphLab1
{
	//TODO test all the functions
	public struct Vector3
	{
		public float x, y, z;
		public Vector3(float x, float y, float z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		/// <summary>
		/// Squared length of the vector
		/// </summary>
		public float SqrMagnitude()
		{
			return x * x + y * y + z * z;
		}

		/// <summary>
		/// Length of the vector
		/// </summary>
		public float Magnitude()
		{
			return MathF.Pow(SqrMagnitude(), 0.5f);
		}

		/// <summary>
		/// Dot product of two vectors
		/// </summary>
		/// <param name="other">Second vector</param>
		public float Dot(Vector3 other)
		{
			return x * other.x + y * other.y + z * other.z;
		}

		/// <summary>
		/// Angle between two vectors in radians
		/// </summary>
		/// <param name="other">Second vector</param>
		/// <returns>Result in radians</returns>
		public float Angle(Vector3 other)
		{
			return MathF.Acos(Dot(other) / (Magnitude() * other.Magnitude()));
		}

		/// <summary>
		/// Angle between two vectors in degrees
		/// </summary>
		/// <param name="other">Second vector</param>
		/// <returns>Result in degrees</returns>
		public float DegreeAngle(Vector3 other)
		{
			return Angle(other) * 180 / MathF.PI;
		}

		//Rotate the vector around zero point by given eulerAngles
		public Vector3 Rotate(Vector3 eulerAngles)
		{
			Matrix rx = new Matrix(new float[,] 
				{
				  {1, 0, 0 },
				  {0, MathF.Cos(eulerAngles.x), -MathF.Sin(eulerAngles.x) },
				  {0, MathF.Sin(eulerAngles.x), MathF.Cos(eulerAngles.x) }
				});
			Matrix ry = new Matrix(new float[,]
				{
				  {MathF.Cos(eulerAngles.y), 0, MathF.Sin(eulerAngles.y) },
				  {0, 1, 0 },
				  {-MathF.Sin(eulerAngles.y), 0, MathF.Cos(eulerAngles.y) }
				});
			Matrix rz = new Matrix(new float[,]
				{
				  {MathF.Cos(eulerAngles.z), -MathF.Sin(eulerAngles.z), 0 },
				  {MathF.Sin(eulerAngles.z), MathF.Cos(eulerAngles.z), 0 },
				  {0, 0, 1 }
				});
			var result = rx * ry * rz * new Matrix(new float[,] { { eulerAngles.x }, { eulerAngles.y }, { eulerAngles.z } });
			return new Vector3(result[0, 0], result[1, 0], result[2, 0]);
		}

		public Vector3 Multiply(Vector3 other)
		{
			return new Vector3(x * other.x, y * other.y, z * other.z);
		}

		public static Vector3 operator +(Vector3 first, Vector3 second)
		{
			return new Vector3(first.x + second.x, first.y + second.y, first.z + second.z);
		}

		public static Vector3 operator -(Vector3 first, Vector3 second)
		{
			return new Vector3(first.x - second.x, first.y - second.y, first.z - second.z);
		}
	}
}

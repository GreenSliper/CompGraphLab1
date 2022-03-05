using System;
using System.Collections.Generic;
using System.Drawing;
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

		public Vector3(Color color)
		{
			x = color.R;
			y = color.G;
			z = color.B;
		}

		public Color ToColor()
		{
			return Color.FromArgb((int)MathF.Round(x), (int)MathF.Round(y), (int)MathF.Round(z));
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

		public Vector3 Normalized => this / Magnitude();

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

		public float AngleCos(Vector3 other)
		{
			return Dot(other) / (Magnitude() * other.Magnitude());
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

		/// <summary>
		/// Rotate the vector around zero point by given eulerAngles (in degrees)
		/// </summary>
		/// <param name="eulerAngles">Euler angles in degrees</param>
		/// <returns>Rotated vector</returns>
		public Vector3 Rotate(Vector3 eulerAngles)
		{
			eulerAngles *= MathF.PI / 180f;
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
			var result = rx * ry * rz * new Matrix(new float[,] { { x }, { y }, { z } });
			return new Vector3(result[0, 0], result[1, 0], result[2, 0]);
		}

		public static Matrix GetRotationMatrix(Vector3 eulerAngles)
		{
			eulerAngles *= MathF.PI / 180f;
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
			return rx * ry * rz;
		}

		public Vector3 Rotate(Matrix rotationMatrix)
		{
			var result = rotationMatrix * new Matrix(new float[,] { { x }, { y }, { z } });
			return new Vector3(result[0, 0], result[1, 0], result[2, 0]);
		}

		public Vector3 Multiply(Vector3 other)
		{
			return new Vector3(x * other.x, y * other.y, z * other.z);
		}
		public Vector3 Project(Vector3 other)
		{
			return MathF.Cos(Angle(other)) * Magnitude() / other.Magnitude() * other;
		}

		public Vector3 Project(Vector3 other, out bool isNegativeDirection)
		{
			var angle = Angle(other);
			isNegativeDirection = angle > 0.5f * MathF.PI;
			return MathF.Cos(angle) * Magnitude() / other.Magnitude() * other;
		}

		public static Vector3 operator +(Vector3 first, Vector3 second)
		{
			return new Vector3(first.x + second.x, first.y + second.y, first.z + second.z);
		}

		public static Vector3 operator -(Vector3 first, Vector3 second)
		{
			return new Vector3(first.x - second.x, first.y - second.y, first.z - second.z);
		}

		public static Vector3 operator *(Vector3 vector, float magnitude)
		{
			return new Vector3(vector.x * magnitude, vector.y * magnitude, vector.z * magnitude);
		}
		public static Vector3 operator *(float magnitude, Vector3 vector)
		{
			return new Vector3(vector.x * magnitude, vector.y * magnitude, vector.z * magnitude);
		}

		public static Vector3 operator /(Vector3 vector, float magnitude)
		{
			return new Vector3(vector.x / magnitude, vector.y / magnitude, vector.z / magnitude);
		}

		public static Vector3 Forward => new Vector3(0, 0, 1);
		public static Vector3 Backward => new Vector3(0, 0, -1);
		public static Vector3 Right => new Vector3(1, 0, 0);
		public static Vector3 Left => new Vector3(-1, 0, 0);
		public static Vector3 Up => new Vector3(0, 1, 0);
		public static Vector3 Down => new Vector3(0, -1, 0);
		public static Vector3 Zero => new Vector3();
		public static Vector3 One => new Vector3(1, 1, 1);
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CompGraphLab1.Scene
{
	public class Transform
	{
		//local-space position
		public Vector3 localPosition;
		//local-space Euler angles
		public Vector3 localRotation;
		//local-space scale
		public Vector3 localScale;
		//parent object
		public Transform parent;

		/// <summary>
		/// World-space position
		/// </summary>
		public Vector3 Position
		{
			get
			{
				if (parent == null)
					return localPosition;
				else
					return parent.Position + localPosition.Multiply(Scale);
			}
		}

		/// <summary>
		/// World-space scale
		/// </summary>
		public Vector3 Scale
		{
			get
			{
				if (parent == null)
					return localScale;
				else
					return parent.Scale.Multiply(localScale);
			}
		}

		/// <summary>
		/// World-space rotation (Euler angles)
		/// </summary>
		public Vector3 Rotation
		{
			get
			{
				if (parent == null)
					return localRotation;
				else
					return parent.Rotation + localRotation;
			}
		}

		public Vector3 Normal
		{
			get 
			{
				return Vector3.Forward.Rotate(Rotation);
			}
		}

		public Vector3 Up
		{
			get 
			{
				return Vector3.Up.Rotate(Rotation);
			}
		}

		public Vector3 Right
		{
			get
			{
				return Vector3.Right.Rotate(Rotation);
			}
		}
	}
}

using CompGraphLab1.Data;
using CompGraphLab1.Scene;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompGraphLab1.Rendering
{
	class MeshProjector : IMeshProjector
	{
		public ObjPlanaredData Project(ObjData mesh, Camera camera)
		{
			var camNorm = camera.Normal;
			var camPos = camera.Position;
			Vector3 canvasUp = camera.Up * MathF.Tan(camera.verticalAngle/360f*MathF.PI) * 2f * camera.renderPlaneDistance;
			Vector3 canvasRight = camera.Right * MathF.Tan(camera.horizontalAngle / 360f * MathF.PI) * 2f * camera.renderPlaneDistance;
			Vector3 canvasLeftBottomCorner = camera.Normal - canvasRight / 2 - canvasUp / 2 + camPos;
			ConcurrentBag<Triangle2D> resultTris = new ConcurrentBag<Triangle2D>();
			Parallel.ForEach(mesh.tris,
				(tri) =>
				{
					var v1 = ConvertRenderPlaneCoordToViewRect(
								ProjectOnRenderPlane3D(tri.verts[0], camPos, camNorm, camera.renderPlaneDistance),
								canvasLeftBottomCorner, canvasUp, canvasRight);
					var v2 = ConvertRenderPlaneCoordToViewRect(
								ProjectOnRenderPlane3D(tri.verts[1], camPos, camNorm, camera.renderPlaneDistance),
								canvasLeftBottomCorner, canvasUp, canvasRight);
					var v3 = ConvertRenderPlaneCoordToViewRect(
								ProjectOnRenderPlane3D(tri.verts[2], camPos, camNorm, camera.renderPlaneDistance),
								canvasLeftBottomCorner, canvasUp, canvasRight);
					resultTris.Add(new Triangle2D(v1, v2, v3, tri));
				});
			return new ObjPlanaredData() { tris = new List<Triangle2D>(resultTris)};
		}

		public static Vector3 ProjectOnRenderPlane3D(Vector3 sourcePoint, Vector3 cameraPos, Vector3 cameraNormal, float renderPlaneDist)
		{
			var delta = sourcePoint - cameraPos;
			var normal = cameraNormal;
			return cameraPos + delta.Normalized * renderPlaneDist / MathF.Cos(delta.Angle(normal));
		}

		public static Vector2 ConvertRenderPlaneCoordToViewRect(Vector3 pointOnRenderPlane, Vector3 canvasLeftBottomCorner, 
			Vector3 canvasUp, Vector3 canvasRight)
		{
			Vector3 delta = pointOnRenderPlane - canvasLeftBottomCorner;
			var x = delta.Project(canvasRight, out bool negX).Magnitude() / canvasRight.Magnitude();
			var y = delta.Project(canvasUp, out bool negY).Magnitude() / canvasUp.Magnitude();
			return new Vector2(negX ? -x : x, negY ? -y : y);
		}
	}
}

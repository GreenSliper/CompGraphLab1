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
		Vector3 camNorm, camPos, canvasUp, canvasRight, canvasLeftBottomCorner;
		float renderPlaneDist, canvasRightMagnitude, canvasUpMagnitude;
		public void InitCameraState(Camera camera)
		{
			camNorm = camera.Normal;
			camPos = camera.Position;
			canvasUp = camera.Up * MathF.Tan(camera.verticalAngle / 360f * MathF.PI) * 2f * camera.renderPlaneDistance;
			canvasRight = camera.Right * MathF.Tan(camera.horizontalAngle / 360f * MathF.PI) * 2f * camera.renderPlaneDistance;
			canvasLeftBottomCorner = camera.Normal - canvasRight / 2 - canvasUp / 2 + camPos;
			canvasRightMagnitude = canvasRight.Magnitude();
			canvasUpMagnitude = canvasUp.Magnitude();
			renderPlaneDist = camera.renderPlaneDistance;
		}

		public ObjPlanaredData Project(ObjData mesh)
		{
			
			ConcurrentBag<Triangle2D> resultTris = new ConcurrentBag<Triangle2D>();
			Triangle2D[] resultTrs = new Triangle2D[mesh.tris.Count];
			Parallel.For(0, mesh.tris.Count, (x) =>
			{
				var v1 = ConvertRenderPlaneCoordToViewRect(
								ProjectOnRenderPlane3D(mesh.tris[x].verts[0], out var v1Z),
								canvasLeftBottomCorner, canvasUp, canvasRight);
				var v2 = ConvertRenderPlaneCoordToViewRect(
							ProjectOnRenderPlane3D(mesh.tris[x].verts[1], out var v2Z),
							canvasLeftBottomCorner, canvasUp, canvasRight);
				var v3 = ConvertRenderPlaneCoordToViewRect(
							ProjectOnRenderPlane3D(mesh.tris[x].verts[2], out var v3Z),
							canvasLeftBottomCorner, canvasUp, canvasRight);
				resultTrs[x] = new Triangle2D(v1, v2, v3, v1Z, v2Z, v3Z, mesh.tris[x]);
			});
			return new ObjPlanaredData() { tris = new List<Triangle2D>(resultTrs) };
		}

		public Vector3 ProjectOnRenderPlane3D(Vector3 sourcePoint, out float distance)
		{
			var delta = sourcePoint - camPos;
			distance = delta.Magnitude();
			return camPos + delta / distance * renderPlaneDist / delta.AngleCos(camNorm);
		}

		public Vector2 ConvertRenderPlaneCoordToViewRect(Vector3 pointOnRenderPlane, Vector3 canvasLeftBottomCorner, 
			Vector3 canvasUp, Vector3 canvasRight)
		{
			Vector3 delta = pointOnRenderPlane - canvasLeftBottomCorner;
			var x = delta.Project(canvasRight, out bool negX).Magnitude() / canvasRightMagnitude;
			var y = delta.Project(canvasUp, out bool negY).Magnitude() / canvasUpMagnitude;
			return new Vector2(negX ? -x : x, negY ? -y : y);
		}
	}
}

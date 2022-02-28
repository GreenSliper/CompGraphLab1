using CompGraphLab1.Data;
using CompGraphLab1.Scene;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompGraphLab1.Rendering
{
	class MeshProjector : IMeshProjector
	{
		public ObjPlanaredData placePoint(ObjData mesh, Camera camera)// делал по статье
        {
			int countTris = 0;
			int countVerts = 0;
			ObjPlanaredData planarData = new ObjPlanaredData();// нормализованные координаты
			foreach(Triangle3D triangle3D in mesh.tris)
			{
				foreach(Vector3 vect3 in triangle3D.verts)// использовал формулы, указанные во 2 главе
				{
					planarData.tris[countTris].verts[countVerts].x = (float)((vect3.x / -vect3.z) + camera.getLength() * 0.5) / camera.getLength();
					planarData.tris[countTris].verts[countVerts].y = (float)((vect3.y / -vect3.z) + camera.getHeight() * 0.5) / camera.getHeight();
					countVerts++;
				}
				countTris++;
			}
			return planarData;
		}
	}
}

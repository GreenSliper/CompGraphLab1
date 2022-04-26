using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using CompGraphLab1.Data;
using CompGraphLab1.Scene;

namespace CompGraphLab1.Rendering
{
    class BezierSurfaceObjCreator
    {
        // public int gridResolCont = 8;
        //public Vector3[] controlPoints = new Vector3[16] { 
        //    new Vector3(-1.5f, 0, -3f).Rotate(rot),  new Vector3(-1.5f, 0.5f, -3f).Rotate(rot),  new Vector3(-1.5f, 0.5f, 0f).Rotate(rot),  new Vector3(-1.5f, 0, 0f).Rotate(rot),
        //    new Vector3(-1.5f, 0.5f, -3f).Rotate(rot),  new Vector3(-0.5f, -3f, -2f).Rotate(rot),  new Vector3(-0.5f, 0.5f, -1f).Rotate(rot),  new Vector3(-0.5f, 0.5f, 0f).Rotate(rot),
        //    new Vector3(0.5f, 0.5f, -3f).Rotate(rot),  new Vector3(0.5f, 0.5f, -2f).Rotate(rot),  new Vector3(0.5f, 3f, -1f).Rotate(rot),  new Vector3(0.5f, 0.5f, 0f).Rotate(rot),
        //    new Vector3(1.5f, 0, -3f).Rotate(rot),  new Vector3(1.5f, 0.5f, -2f).Rotate(rot),  new Vector3(1.5f, 0.5f, -1f).Rotate(rot),  new Vector3(1.5f, 0, 0f).Rotate(rot)
        //};

        static public void Create(BezierSurfaceData data)
        {
            Vector3 rot = new Vector3(0, 0, 180);
            ObjData obj = new ObjData();
            Vector3[] controlPoints = new Vector3[16];
            for (int i = 0; i < 16; ++i)
            {
                controlPoints[i] = data.controlPoints[i].Rotate(rot);
                controlPoints[i].z = -controlPoints[i].z;
            }

            for (int j = 0; j < data.gridResolution - 1; ++j)
            {
                for (int i = 0; i < data.gridResolution - 1; ++i)
                {
                    obj.tris.Add(
                        new Triangle3D(
                            evalBezierPatch(controlPoints, (i + 1) / (float)data.gridResolution, j / (float)data.gridResolution),
                            evalBezierPatch(controlPoints, i / (float)data.gridResolution, (j + 1) / (float)data.gridResolution),
                            evalBezierPatch(controlPoints, i / (float)data.gridResolution, j / (float)data.gridResolution)
                            )
                        );
                    obj.tris.Add(
                        new Triangle3D(
                            evalBezierPatch(controlPoints, i / (float)data.gridResolution, (j + 1) / (float)data.gridResolution),
                            evalBezierPatch(controlPoints, (i + 1) / (float)data.gridResolution, j / (float)data.gridResolution),
                            evalBezierPatch(controlPoints, (i + 1) / (float)data.gridResolution, (j + 1) / (float)data.gridResolution)
                            )
                        );
                }
            }

            float offset = 0.015f;
            for (int i = 0; i < 16; ++i)
            {
                // 1
                obj.tris.Add(
                    new Triangle3D(
                        controlPoints[i] + new Vector3(offset, offset, offset),
                        controlPoints[i] + new Vector3(-offset, -offset, offset),
                        controlPoints[i] + new Vector3(offset, -offset, offset)
                        )
                    );
                obj.tris.Add(
                    new Triangle3D(
                        controlPoints[i] + new Vector3(-offset, -offset, offset),
                        controlPoints[i] + new Vector3(offset, offset, offset),
                        controlPoints[i] + new Vector3(-offset, offset, offset)
                        )
                    );

                // 2
                obj.tris.Add(
                    new Triangle3D(
                        controlPoints[i] + new Vector3(-offset, offset, offset),
                        controlPoints[i] + new Vector3(-offset, -offset, -offset),
                        controlPoints[i] + new Vector3(-offset, -offset, offset)
                        )
                    );
                obj.tris.Add(
                    new Triangle3D(
                        controlPoints[i] + new Vector3(-offset, -offset, -offset),
                        controlPoints[i] + new Vector3(-offset, offset, offset),
                        controlPoints[i] + new Vector3(-offset, offset, -offset)
                        )
                    );

                // 3
                obj.tris.Add(
                    new Triangle3D(
                        controlPoints[i] + new Vector3(offset, offset, -offset),
                        controlPoints[i] + new Vector3(-offset, -offset, -offset),
                        controlPoints[i] + new Vector3(offset, -offset, -offset)
                        )
                    );
                obj.tris.Add(
                    new Triangle3D(
                        controlPoints[i] + new Vector3(-offset, -offset, -offset),
                        controlPoints[i] + new Vector3(offset, offset, -offset),
                        controlPoints[i] + new Vector3(-offset, offset, -offset)
                        )
                    );
                // 4
                obj.tris.Add(
                    new Triangle3D(
                        controlPoints[i] + new Vector3(offset, offset, offset),
                        controlPoints[i] + new Vector3(offset, -offset, -offset),
                        controlPoints[i] + new Vector3(offset, -offset, offset)
                        )
                    );
                obj.tris.Add(
                    new Triangle3D(
                        controlPoints[i] + new Vector3(offset, -offset, -offset),
                        controlPoints[i] + new Vector3(offset, offset, offset),
                        controlPoints[i] + new Vector3(offset, offset, -offset)
                        )
                    );
                // 5
                obj.tris.Add(
                    new Triangle3D(
                        controlPoints[i] + new Vector3(offset, offset, -offset),
                        controlPoints[i] + new Vector3(-offset, offset, offset),
                        controlPoints[i] + new Vector3(offset, offset, offset)
                        )
                    );
                obj.tris.Add(
                    new Triangle3D(
                        controlPoints[i] + new Vector3(-offset, offset, offset),
                        controlPoints[i] + new Vector3(offset, offset, -offset),
                        controlPoints[i] + new Vector3(-offset, offset, -offset)
                        )
                    );
                // 6
                obj.tris.Add(
                    new Triangle3D(
                        controlPoints[i] + new Vector3(offset, -offset, -offset),
                        controlPoints[i] + new Vector3(-offset, -offset, offset),
                        controlPoints[i] + new Vector3(offset, -offset, offset)
                        )
                    );
                obj.tris.Add(
                    new Triangle3D(
                        controlPoints[i] + new Vector3(-offset, -offset, offset),
                        controlPoints[i] + new Vector3(offset, -offset, -offset),
                        controlPoints[i] + new Vector3(-offset, -offset, -offset)
                        )
                    );

            }

            data.mesh.objData = obj;
        }

        static private Vector3 evalBezierPatch(Vector3[] controlPoints, float u, float v)
        {
            Vector3[] uCurve = new Vector3[4];
            for (int i = 0; i < 4; ++i)
            {
                Vector3[] vecs = new Vector3[4] {
                    controlPoints[4 * i], controlPoints[4 * i + 1], controlPoints[4 * i + 2], controlPoints[4 * i + 3]
                };
                uCurve[i] = evalBezierCurve(vecs, u);
            }
            return evalBezierCurve(uCurve, v);
        }

        static private Vector3 evalBezierCurve(Vector3[] vecs, float t)
        {
            float b0 = (1 - t) * (1 - t) * (1 - t);
            float b1 = 3 * t * (1 - t) * (1 - t);
            float b2 = 3 * t * t * (1 - t);
            float b3 = t * t * t;
            return vecs[0] * b0 + vecs[1] * b1 + vecs[2] * b2 + vecs[3] * b3;
        }


    }
}

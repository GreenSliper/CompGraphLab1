using CompGraphLab1.Data;
using CompGraphLab1.Scene;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompGraphLab1.Rendering
{
	public interface IMeshProjector
	{
		ObjPlanaredData placePoint(ObjData mesh, Camera camera);
	}
}

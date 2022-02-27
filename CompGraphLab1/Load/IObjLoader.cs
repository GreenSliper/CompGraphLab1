using CompGraphLab1.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompGraphLab1.Load
{
	public interface IObjLoader
	{
		ObjData LoadFile(string path);
	}
}

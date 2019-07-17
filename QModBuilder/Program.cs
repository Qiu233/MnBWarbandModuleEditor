using ModuleUnserializer.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QModBuilder
{
	class Program
	{
		//static string Target;
		static string Target = "G:\\Mount&blade Warband 1.168";
		static string Module = "Native Addins";
		static void Main(string[] args)
		{
			ModuleInfo minfo = new ModuleInfo(Target, Module, "es");

		}
	}
}

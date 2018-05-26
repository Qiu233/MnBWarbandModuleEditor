using ModuleUnserializer.Entities;
using MSCompiler.Parse;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCompiler
{
	public class Function
	{
		public string Name
		{
			get;
		}

		public Function(string Name)
		{
			this.Name = Name;
		}

	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSCompiler.Parse
{
	public class Stmt_Assign : Statement
	{
		public string Name;
		public Expression Value;
	}
}

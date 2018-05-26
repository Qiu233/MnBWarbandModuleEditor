using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSCompiler.Parse
{
	public class Stmt_ForRange : Statement
	{
		public string Name;
		public Expression Lower_Bound;
		public Expression Upper_Bound;
		public List<Statement> Body;
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSCompiler.Parse
{
	public class Expr_Call : Expression
	{
		public string Name;
		public List<Expression> Arguments;
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSCompiler.Parse
{
	public class Expr_Binary : Expression
	{
		public Expression Left, Right;
		public string Operator;
	}
}

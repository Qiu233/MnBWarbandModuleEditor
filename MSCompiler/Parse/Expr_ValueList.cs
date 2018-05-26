using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSCompiler.Parse
{
	public class Expr_ValueList : Expression
	{
		public List<Expression> ValueList = new List<Expression>();
	}
}

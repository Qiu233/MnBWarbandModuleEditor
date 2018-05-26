using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSCompiler.Parse
{
	public class Stmt_IF : Statement
	{
		public class IFStructure
		{
			public Expression Condition;
			public List<Statement> Statements;
			public IFStructure(Expression c, List<Statement> s)
			{
				Condition = c;
				Statements = s;
			}
		}
		public List<IFStructure> IF;
		public List<Statement> Else;
	}
}

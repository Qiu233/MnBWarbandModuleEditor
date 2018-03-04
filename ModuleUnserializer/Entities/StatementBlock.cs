using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModuleUnserializer.Entities
{
	public class Statement_Block
	{
		public List<Statement> Statements;
		private Statement_Block()
		{

		}
		public static Statement_Block FromString(string[] s, ref int j)
		{
			Statement_Block block = new Statement_Block();
			block.Statements = new List<Statement>(Convert.ToInt32(s[j++]));
			for (int i = 0; i < block.Statements.Capacity; i++)
			{
				var stmt = Statement.FromString(s, ref j);
				block.Statements.Add(stmt);
			}
			return block;
		}
	}
}

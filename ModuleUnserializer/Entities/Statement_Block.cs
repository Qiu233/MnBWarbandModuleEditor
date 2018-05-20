using ModuleUnserializer.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModuleUnserializer.Entities
{
	public class Statement_Block
	{
		public ModuleInfo Module;
		public List<Statement> Statements;
		private Statement_Block()
		{

		}
		public static Statement_Block FromString(ModuleInfo mInfo, string[] s, ref int j)
		{
			Statement_Block block = new Statement_Block();
			block.Module = mInfo;
			block.Statements = new List<Statement>(Convert.ToInt32(s[j++]));
			for (int i = 0; i < block.Statements.Capacity; i++)
			{
				var stmt = Statement.FromString(mInfo, s, ref j);
				block.Statements.Add(stmt);
			}
			return block;
		}
		/// <summary>
		/// 未完成
		/// </summary>
		/// <returns></returns>
		public string Decompile()
		{
			StringBuilder result = new StringBuilder();
			result.Append("[\n");
			int layer = 1;
			foreach (var stmt in Statements)
			{
				int t = 0;
				string s = stmt.Decompile(ref t);
				if ((t & 1) == 1)
					layer += 1;
				else if ((t & 2) == 2)
					layer -= 1;

				for (int i = 0; i < layer; i++)
					result.Append("\t");

				if ((t & 4) == 4)
					layer += 1;
				else if ((t & 8) == 8)
					layer -= 1;
				result.Append(s + ",\n");
			}
			result.Append("]");
			return result.ToString();
		}
	}
}

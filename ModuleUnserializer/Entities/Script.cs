using ModuleUnserializer.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModuleUnserializer.Entities
{
	public class Script
	{
		public string Name;
		public int v;
		public Statement_Block Statements;
		public static Script FromString(ModuleInfo minfo, string[] s, ref int j)
		{
			Script script = new Script();

			script.Name = s[j++];
			script.v = Convert.ToInt32(s[j++]);

			script.Statements = Statement_Block.FromString(s, ref j);

			return script;
		}
		/// <summary>
		/// 未完成
		/// </summary>
		/// <returns></returns>
		public string Decompile()
		{
			StringBuilder result = new StringBuilder();
			result.Append("(\"" + Name + "\",\n");
			result.Append(Statements.Decompile());
			result.Append("),");
			return result.ToString();
		}
	}
}

using ModuleUnserializer.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModuleUnserializer.Entities
{
	public class Script
	{
		public ModuleInfo Module;
		public string Name;
		public double v;
		public Statement_Block Statements;
		public static Script FromString(ModuleInfo minfo, string[] s, ref int j)
		{
			Script script = new Script();
			script.Module = minfo;
			script.Name = s[j++];
			script.v = Convert.ToDouble(s[j++]);

			script.Statements = Statement_Block.FromString(minfo, s, ref j);

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

		public string Compile(CompilationContext ctx)
		{
			StringBuilder result = new StringBuilder();
			result.Append($"{Name} {v}");
			result.AppendLine();
			result.Append(Statements.Compile(ctx));
			result.AppendLine();
			return result.ToString();
		}
	}
}

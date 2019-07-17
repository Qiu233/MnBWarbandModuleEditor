using ModuleUnserializer.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModuleUnserializer.Entities
{
	public class QuickString
	{
		public ModuleInfo Module;
		public string ValueEn;
		public string Value;

		public static QuickString FromString(ModuleInfo mInfo, string[] s, ref int j)
		{
			QuickString p = new QuickString();
			p.Module = mInfo;
			string id = s[j++];
			p.ValueEn = s[j++];
			if (mInfo.F_Language["quick_strings"].ContainsKey(id))
				p.Value = mInfo.F_Language["quick_strings"][id];
			return p;
		}

		public string Compile(CompilationContext ctx)
		{
			throw new NotImplementedException();
		}
	}
}

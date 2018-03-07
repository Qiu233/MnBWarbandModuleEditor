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

		public static QuickString FromString(ModuleInfo mInfo,Dictionary<string, string> qs, string[] s, ref int j)
		{
			QuickString p = new QuickString();
			p.Module = mInfo;
			string id = s[j++];
			p.ValueEn = s[j++];
			if (qs.ContainsKey(id))
				p.Value = qs[id];
			return p;
		}
	}
}

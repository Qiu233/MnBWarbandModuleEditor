using ModuleUnserializer.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModuleUnserializer.Entities
{
	public class Skill
	{
		public string Index;
		public string Name;
		public int Flags;
		public int MaxLevel;
		public string Description;

		private Skill()
		{

		}
		public static Skill FromString(ModuleInfo mInfo, string[] s, ref int j)
		{
			Skill tab = new Skill();
			tab.Index = s[j++];
			tab.Index = tab.Index.Substring(tab.Index.IndexOf("_") + 1);
			tab.Name = s[j++];
			tab.Flags = Convert.ToInt32(s[j++]);
			tab.MaxLevel = Convert.ToInt32(s[j++]);
			tab.Description = s[j++];
			return tab;
		}
	}
}

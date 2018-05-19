using ModuleUnserializer.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModuleUnserializer.Entities
{
	public class Presentation
	{
		public string Index;
		public int Flags;
		public int Background;
		public List<SimpleTrigger> Triggers;
		private Presentation()
		{

		}
		public static Presentation FromString(ModuleInfo mInfo, string[] s, ref int j)
		{
			Presentation ps = new Presentation();
			ps.Index = s[j++];
			ps.Index = ps.Index.Substring(ps.Index.IndexOf("_") + 1);
			ps.Flags = Convert.ToInt32(s[j++]);
			ps.Background = Convert.ToInt32(s[j++]);
			ps.Triggers = new List<SimpleTrigger>(Convert.ToInt32(s[j++]));
			for (int i = 0; i < ps.Triggers.Capacity; i++)
				ps.Triggers.Add(SimpleTrigger.FromString(mInfo, s, ref j));
			return ps;
		}
	}
}

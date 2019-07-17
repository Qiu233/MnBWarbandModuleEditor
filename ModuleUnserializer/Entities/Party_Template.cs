using ModuleUnserializer.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ModuleUnserializer.Entities
{
	public class PTStack
	{
		public Troop Troop;
		public int Minimum;
		public int Maximum;
		public BigInteger Flags;
		public PTStack(Troop trp, int min, int max, BigInteger flags)
		{
			Troop = trp;
			Minimum = min;
			Maximum = max;
			Flags = flags;
		}
	}
	public class Party_Template
	{
		public ModuleInfo Module;
		public string Index;
		public string Name;
		public BigInteger Flags;
		public Menu Menu;
		public Faction Faction;
		public BigInteger Personality;
		public List<PTStack> Stacks;

		private Party_Template()
		{

		}
		public static Party_Template FromString(ModuleInfo mInfo, string[] s, ref int j)
		{
			Party_Template pt = new Party_Template();

			pt.Index = s[j++];
			pt.Index = pt.Index.Substring(pt.Index.IndexOf("_") + 1);
			pt.Name = s[j++];
			pt.Flags = BigInteger.Parse(s[j++]);
			pt.Menu = mInfo.F_Menus.Menus[Convert.ToInt32(s[j++])];
			pt.Faction = mInfo.F_Factions.Factions[Convert.ToInt32(s[j++])];
			pt.Personality = BigInteger.Parse(s[j++]);

			pt.Stacks = new List<PTStack>(6);
			for (int i = 0; i < pt.Stacks.Capacity; i++)
			{
				int v = Convert.ToInt32(s[j++]);
				if (v == -1)
				{
					pt.Stacks.Add(null);
					continue;
				}
				pt.Stacks.Add(
					new PTStack(mInfo.F_Troops.Troops[v], 
					Convert.ToInt32(s[j++]), 
					Convert.ToInt32(s[j++]), 
					BigInteger.Parse(s[j++])
					));
			}

			return pt;
		}

		public string Compile(CompilationContext ctx)
		{
			throw new NotImplementedException();
		}
	}
}

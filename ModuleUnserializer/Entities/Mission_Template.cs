using ModuleUnserializer.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ModuleUnserializer.Entities
{
	public class Trigger
	{
		public ModuleInfo Module;

		public float Check;
		public float Delay;
		public float Rearm;

		public Statement_Block Conditions;
		public Statement_Block Consequences;

		private Trigger()
		{

		}
		public static Trigger FromString(ModuleInfo mInfo, string[] s, ref int j)
		{
			Trigger trg = new Trigger();
			trg.Module = mInfo;

			trg.Check = Convert.ToSingle(s[j++]);
			trg.Delay = Convert.ToSingle(s[j++]);
			trg.Rearm = Convert.ToSingle(s[j++]);
			trg.Conditions = Statement_Block.FromString(mInfo, s, ref j);
			trg.Consequences = Statement_Block.FromString(mInfo, s, ref j);


			return trg;
		}

		public string Compile(CompilationContext ctx)
		{
			throw new NotImplementedException();
		}
	}
	public class MTEntry
	{
		public int Index;
		public BigInteger Flags;
		public BigInteger AlterFlags;
		public BigInteger AIFlags;
		public int NumberOfTroops;
		public List<Item> Equipments;
	}
	public class Mission_Template
	{
		public ModuleInfo Module;
		public string Index;
		public BigInteger Flags;
		public BigInteger Type;
		public string Description;
		public List<MTEntry> Entries;
		public List<Trigger> Triggers;

		private Mission_Template()
		{

		}
		public static Mission_Template FromString(ModuleInfo mInfo, string[] s, ref int j)
		{
			Mission_Template mt = new Mission_Template();
			mt.Module = mInfo;
			mt.Index = s[j++];
			mt.Index = mt.Index.Substring(mt.Index.IndexOf("_") + 1);
			j++;
			mt.Flags = BigInteger.Parse(s[j++]);
			mt.Type = BigInteger.Parse(s[j++]);
			mt.Description = s[j++].Replace('_', ' ');

			mt.Entries = new List<MTEntry>(Convert.ToInt32(s[j++]));
			for (int i = 0; i < mt.Entries.Capacity; i++)
			{
				var e = new MTEntry();
				mt.Entries.Add(e);
				e.Index = Convert.ToInt32(s[j++]);
				e.Flags = BigInteger.Parse(s[j++]);
				e.AlterFlags = BigInteger.Parse(s[j++]);
				e.AIFlags = BigInteger.Parse(s[j++]);
				e.NumberOfTroops = Convert.ToInt32(s[j++]);

				e.Equipments = new List<Item>(Convert.ToInt32(s[j++]));
				for (int k = 0; k < e.Equipments.Capacity; k++)
					e.Equipments.Add(mInfo.F_Items.Items[Convert.ToInt32(s[j++])]);
			}

			mt.Triggers = new List<Trigger>(Convert.ToInt32(s[j++]));
			for (int i = 0; i < mt.Triggers.Capacity; i++)
			{
				mt.Triggers.Add(Trigger.FromString(mInfo, s, ref j));
			}

			return mt;
		}

		public string Compile(CompilationContext ctx)
		{
			throw new NotImplementedException();
		}
	}
}

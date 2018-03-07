using ModuleUnserializer.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModuleUnserializer.Entities
{
	public class SimpleTrigger
	{
		public ModuleInfo Module;
		public float Interval;
		public Statement_Block Block;

		private SimpleTrigger()
		{

		}
		public static SimpleTrigger FromString(ModuleInfo mInfo, string[] c, ref int j)
		{
			SimpleTrigger trigger = new SimpleTrigger();
			trigger.Module = mInfo;
			trigger.Interval = Convert.ToSingle(c[j++]);
			trigger.Block = Statement_Block.FromString(mInfo, c, ref j);
			return trigger;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModuleUnserializer.Entities
{
	public class SimpleTrigger
	{
		public float Interval;
		public Statement_Block Block;

		private SimpleTrigger()
		{

		}
		public static SimpleTrigger FromString(string[] c, ref int j)
		{
			SimpleTrigger trigger = new SimpleTrigger();
			trigger.Interval = Convert.ToSingle(c[j++]);
			trigger.Block = Statement_Block.FromString(c, ref j);
			return trigger;
		}
	}
}

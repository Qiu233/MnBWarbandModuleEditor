using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ModuleEditor.Entities;

namespace ModuleEditor.Files
{
	
	public class F_SimpleTriggers
	{

		public ModuleInfo Module;
		public List<SimpleTrigger> SimpleTriggers;
		private F_SimpleTriggers()
		{

		}
		public static F_SimpleTriggers LoadFromFile(ModuleInfo minfo, string MnBPath, string module)
		{
			F_SimpleTriggers obj = new F_SimpleTriggers();
			obj.Module = minfo;
			StreamReader reader = new StreamReader(File.Open(MnBPath + "\\modules\\" + module + "\\simple_triggers.txt", FileMode.Open));
			obj.FromStream(reader);

			reader.Close();
			return obj;
		}
		private void FromStream(StreamReader reader)
		{
			if (reader.ReadLine() != "simple_triggers_file version 1")
				throw new Exception("可能不支持当前mod或该mod已损坏");
			SimpleTriggers = new List<SimpleTrigger>(Convert.ToInt32(reader.ReadLine()));
			for (int i = 0; i < SimpleTriggers.Capacity;)
			{
				var s = reader.ReadLine();
				if (s.Trim() == "") continue;
				int j = 0;
				SimpleTriggers.Add(SimpleTrigger.FromString(s.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries), ref j));
				i++;
			}
		}
	}
}

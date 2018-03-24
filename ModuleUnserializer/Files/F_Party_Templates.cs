using ModuleUnserializer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ModuleUnserializer.Files
{
	public class F_Party_Templates
	{
		public ModuleInfo Module;
		public List<Party_Template> Party_Templates;
		private F_Party_Templates()
		{

		}
		public static F_Party_Templates LoadFromFile(ModuleInfo minfo, string MnBPath, string module)
		{
			F_Party_Templates obj = new F_Party_Templates();
			obj.Module = minfo;
			StreamReader reader = new StreamReader(File.Open(MnBPath + "\\modules\\" + module + "\\party_templates.txt", FileMode.Open));
			obj.FromStream(reader);

			reader.Close();
			return obj;
		}
		private void FromStream(StreamReader reader)
		{
			if (reader.ReadLine() != "partytemplatesfile version 1")
				throw new Exception("可能不支持当前mod或该mod已损坏");
			Party_Templates = new List<Party_Template>(Convert.ToInt32(reader.ReadLine()));
			string[] s = reader.ReadToEnd().Split(new string[] { " ", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
			int j = 0;
			for (int i = 0; i < Party_Templates.Capacity; i++)
			{
				var tmp = Party_Template.FromString(Module, s, ref j);
				Party_Templates.Add(tmp);
			}
		}
	}
}

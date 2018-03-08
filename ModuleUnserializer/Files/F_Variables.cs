using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ModuleUnserializer.Files
{
	public class F_Variables
	{
		public ModuleInfo Module;
		public List<string> Variables;

		private F_Variables()
		{

		}
		public static F_Variables LoadFromFile(ModuleInfo minfo, string MnBPath, string module)
		{
			F_Variables obj = new F_Variables();
			obj.Module = minfo;
			StreamReader reader = new StreamReader(File.Open(MnBPath + "\\modules\\" + module + "\\variables.txt", FileMode.Open));
			obj.FromStream(reader);

			reader.Close();
			return obj;
		}
		private void FromStream(StreamReader reader)
		{
			Variables = new List<string>();
			string[] s = reader.ReadToEnd().Split(new string[] { " ", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < s.Length; i++)
				Variables.Add(s[i]);
		}
	}
}

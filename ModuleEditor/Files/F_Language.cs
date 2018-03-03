using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ModuleEditor.Files
{
	public class F_Language
	{
		private string Src;
		private Dictionary<string, Dictionary<string, string>> Values;

		public Dictionary<string, string> this[string file]
		{
			get => Values[file];
		}
		public F_Language(string MnBPath, string module, string language)
		{
			Values = new Dictionary<string, Dictionary<string, string>>();

			Src = MnBPath + "\\modules\\" + module + "\\languages\\" + language + "\\";
			foreach (var d in Directory.EnumerateFiles(Src))
			{
				var p = Path.GetFileNameWithoutExtension(d);
				Values[p] = new Dictionary<string, string>();
				var o = Values[p];
				StreamReader reader = new StreamReader(File.Open(d, FileMode.Open));
				string str = null;
				while ((str = reader.ReadLine()) != null)
				{
					if (str.Trim() == "") continue;
					string[] s = str.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
					if (s.Count() > 1)
						o[s[0]] = s[1];
				}
				reader.Close();
			}
		}
		public void Save(string file)
		{
			StreamWriter sw = new StreamWriter(File.Open(Src + file + ".csv", FileMode.Open));
			foreach (var v in Values[file])
			{
				sw.WriteLine(v.Key + "|" + v.Value);
			}
			sw.Close();
		}
	}
}

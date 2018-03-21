using ModuleUnserializer.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModuleUnserializer.Entities
{
	public class MnBString
	{
		public ModuleInfo Module;
		public string Index;
		public string TextEn;
		public string Text;
		private MnBString()
		{

		}
		public static MnBString FromString(ModuleInfo mInfo, string[] s, ref int j)
		{
			MnBString str = new MnBString();
			str.Index = s[j++];
			str.Index = str.Index.Substring(str.Index.IndexOf("_") + 1);
			str.TextEn = s[j++];
			if (mInfo.F_Language["game_strings"].ContainsKey(str.Index))
				str.Text = mInfo.F_Language["game_strings"][str.Index];
			return str;
		}
	}
}

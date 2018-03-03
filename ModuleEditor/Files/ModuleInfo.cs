using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModuleEditor.Files
{
	public class ModuleInfo
	{
		public F_Language F_Language;

		public F_Factions F_Factions;
		public F_Items F_Items;
		public F_SimpleTriggers F_SimpleTriggers;
		public ModuleInfo(string MnBPath, string module, string language)
		{
			F_Language = new F_Language(MnBPath, module, language);
			F_Factions = F_Factions.LoadFromFile(this, MnBPath, module);
			F_SimpleTriggers = F_SimpleTriggers.LoadFromFile(this, MnBPath, module);
			F_Items = F_Items.LoadFromFile(this, MnBPath, module);
		}
	}
}

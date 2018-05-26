using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModuleUnserializer.Files
{
	public class ModuleInfo
	{
		public F_Language F_Language { get; }

		public F_Strings F_Strings { get; }
		public F_Menus F_Menus { get; }
		public F_Variables F_Variables { get; }
		public F_QuickStrings F_QuickStrings { get; }
		public F_Factions F_Factions { get; }
		public F_Items F_Items { get; }
		public F_SimpleTriggers F_SimpleTriggers { get; }
		public F_Scripts F_Scripts { get; }
		public F_Parties F_Parties { get; }
		public F_Troops F_Troops { get; }
		public F_Sounds F_Sounds { get; }
		public F_Quests F_Quests { get; }
		public F_Party_Templates F_Party_Templates { get; }
		public F_Scenes F_Scenes { get; }
		public F_Mission_Templates F_Mission_Templates { get; }
		public F_Particle_Systems F_Particle_Systems { get; }
		public F_Scene_Props F_Scene_Props { get; }
		public F_Meshes F_Meshes { get; }
		public F_Tableau_Mats F_Tableau_Mats { get; }
		public F_Skills F_Skills { get; }
		public F_Presentations F_Presentations { get; }
		public F_MapIcons F_MapIcons { get; }
		public F_Animations F_Animations { get; }
		public ModuleInfo(string MnBPath, string module, string language)
		{
			F_Language = new F_Language(MnBPath, module, language);
			F_Animations = F_Animations.LoadFromFile(this, MnBPath, module);
			F_MapIcons = F_MapIcons.LoadFromFile(this, MnBPath, module);
			F_Presentations = F_Presentations.LoadFromFile(this, MnBPath, module);
			F_Tableau_Mats = F_Tableau_Mats.LoadFromFile(this, MnBPath, module);
			F_Skills = F_Skills.LoadFromFile(this, MnBPath, module);
			F_Meshes = F_Meshes.LoadFromFile(this, MnBPath, module);
			F_Strings = F_Strings.LoadFromFile(this, MnBPath, module);
			F_Variables = F_Variables.LoadFromFile(this, MnBPath, module);
			F_QuickStrings = F_QuickStrings.LoadFromFile(this, MnBPath, module);
			F_Factions = F_Factions.LoadFromFile(this, MnBPath, module);
			F_Scripts = F_Scripts.LoadFromFile(this, MnBPath, module);
			F_SimpleTriggers = F_SimpleTriggers.LoadFromFile(this, MnBPath, module);


			F_Items = F_Items.LoadFromFile(this, MnBPath, module);
			F_Menus = F_Menus.LoadFromFile(this, MnBPath, module);
			F_Parties = F_Parties.LoadFromFile(this, MnBPath, module);
			F_Troops = F_Troops.LoadFromFile(this, MnBPath, module);
			F_Sounds = F_Sounds.LoadFromFile(this, MnBPath, module);
			F_Quests = F_Quests.LoadFromFile(this, MnBPath, module);
			F_Party_Templates = F_Party_Templates.LoadFromFile(this, MnBPath, module);
			F_Scenes = F_Scenes.LoadFromFile(this, MnBPath, module);
			F_Mission_Templates = F_Mission_Templates.LoadFromFile(this, MnBPath, module);
			F_Particle_Systems = F_Particle_Systems.LoadFromFile(this, MnBPath, module);
			F_Scene_Props = F_Scene_Props.LoadFromFile(this, MnBPath, module);
		}
	}
}

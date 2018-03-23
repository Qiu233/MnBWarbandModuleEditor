using ModuleUnserializer.Files;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ModuleUnserializer.Entities
{
	/// <summary>
	/// 指出指令参数的类型
	/// 表来自模组"Native"的源码
	/// </summary>
	public enum ParamType : uint
	{
		[Description("")]
		Number = 0,
		[Description("reg")]
		Register = 1,
		[Description("$")]
		Variable = 2,
		[Description("str_")]
		String = 3,
		[Description("itm_")]
		Item = 4,
		[Description("trp_")]
		Troop = 5,
		[Description("fac_")]
		Faction = 6,
		[Description("qst_")]
		Quest = 7,
		[Description("pt_")]
		Party_Tpl = 8,
		[Description("p_")]
		Party = 9,
		[Description("scn_")]
		Scene = 10,
		[Description("mt_")]
		Mission_Tpl = 11,
		[Description("mnu_")]
		Menu = 12,
		[Description("script_")]
		Script = 13,
		[Description("psys_")]
		Particle_Sys = 14,
		[Description("spr_")]
		Scene_Prop = 15,
		[Description("snd_")]
		Sound = 16,

		[Description(":")]
		Local_Variable = 17,

		[Description("icon_")]
		Map_Icon = 18,
		[Description("skl_")]
		Skill = 19,
		[Description("mesh_")]
		Mesh = 20,
		[Description("prsnt_")]
		Presentation = 21,

		[Description("@")]
		Quick_String = 22,

		[Description("track_")]
		Track = 23,
		[Description("tableau_")]
		Tableau = 24,
		[Description("anim_")]
		Animation = 25,
		End = 26
	}

	/// <summary>
	/// 骑砍使用一个大于32+24位的数据来保存指令的参数
	/// 其中低32+24位保存的数据是Index
	/// 比32+24位更高的位置储存类型
	/// 在用来做测试的版本(1.168)中，整个数据只有60位，也就是只有最高四位用来保存类型
	/// </summary>
	public class Param
	{
		public ModuleInfo Module;
		public ParamType Type;
		public BigInteger Value;
		private Param()
		{

		}
		public static Param FromString(ModuleInfo mInfo, string s)
		{
			Param p = new Param();
			p.Module = mInfo;
			long l = Convert.ToInt64(s);
			long tag = l >> 56;
			if ((tag | 0x00) != 0)
			{
				if (Enum.IsDefined(typeof(ParamType), (ParamType)tag))
				{
					p.Type = (ParamType)tag;
					long a = 0xFF_FFFF_FFFF_FFFF;
					p.Value = a & l;
				}
				else
				{
					p.Type = 0;
					p.Value = l;
				}
			}


			return p;
		}

		/// <summary>
		/// 未完成
		/// </summary>
		/// <returns></returns>
		public string Decompile()
		{
			StringBuilder result = new StringBuilder();
			if (Type == 0)
				result.Append(Value);
			else if (Type == ParamType.Quick_String)
				result.Append(("\"@" + Module.F_QuickStrings.QuickStrings[(int)Value].ValueEn + "\"").Replace('_', ' '));
			else if (Type == ParamType.Local_Variable)
				result.Append("\":local_" + Value + "\"");
			else if (Type == ParamType.Variable)
				result.Append("\"$" + Module.F_Variables.Variables[(int)Value] + "\"");
			else if (Type == ParamType.Register)
				result.Append("reg" + Value + "");
			else if (Type == ParamType.Faction)
				result.Append("\"fac_" + Module.F_Factions.Factions[(int)Value].Index + "\"");
			else if (Type == ParamType.Script)
				result.Append("\"script_" + Module.F_Scripts.Scripts[(int)Value].Name + "\"");
			else if (Type == ParamType.Party)
				result.Append("\"p_" + Module.F_Parties.Parties[(int)Value].Iden + "\"");
			else if (Type == ParamType.Menu)
				result.Append("\"mnu_" + Module.F_Menus.Menus[(int)Value].Index + "\"");
			else if (Type == ParamType.String)
				result.Append("\"str_" + Module.F_Strings.Strings[(int)Value].Index + "\"");
			else if (Type == ParamType.Troop)
				result.Append("\"trp_" + Module.F_Troops.Troops[(int)Value].Index + "\"");
			else if (Type == ParamType.Sound)
				result.Append("\"snd_" + Module.F_Sounds.Sounds[(int)Value].Index + "\"");
			else if (Type == ParamType.Quest)
				result.Append("\"qst_" + Module.F_Quests.Quests[(int)Value].Index + "\"");
			else
				result.Append(Type.ToString());
			return result.ToString();
		}
	}

	/// <summary>
	/// 骑砍储存一条语句的结构是：
	/// opcode paramlength params....
	/// 其中opcode为操作码
	/// paramlength指出这条指令共有多少个参数
	/// 而后的params就是指令的参数表
	/// 此结构多次叠加，再在头部加上语句数量便可组成语句块
	/// 有特例，即neg和this_or_next，指令本身就是由参数和指令标识组成的
	/// </summary>
	public class Statement
	{
		public ModuleInfo Module;
		public Operations Opcode;
		public List<Param> Params;
		private Statement()
		{

		}
		/// <summary>
		/// 可能会加载到neg或者this_or_next，这两条指令的参数在指令的低七位，而最高位标识了是neg还是this_or_next
		/// </summary>
		/// <param name="s"></param>
		/// <param name="j"></param>
		/// <returns></returns>
		public static Statement FromString(ModuleInfo mInfo, string[] s, ref int j)
		{
			Statement stmt = new Statement();
			stmt.Module = mInfo;
			stmt.Opcode = (Operations)Convert.ToInt64(s[j++]);
			int m = Convert.ToInt32(s[j++]);
			stmt.Params = new List<Param>(m);
			for (int i = 0; i < m; i++)
			{
				var t = Param.FromString(mInfo, s[j++]);
				stmt.Params.Add(t);
			}
			return stmt;
		}
		/// <summary>
		/// 未完成
		/// </summary>
		/// <returns></returns>
		public string Decompile(ref int j)
		{
			StringBuilder result = new StringBuilder();
			result.Append("(");
			if (Enum.IsDefined(typeof(Operations), (long)Opcode))
				result.Append(Opcode.ToString());
			else if ((Opcode & Operations.neg) == Operations.neg)
				result.Append(Operations.neg.ToString() + "|" + (~((~Opcode) | Operations.neg)).ToString());
			else if ((Opcode & Operations.this_or_next) == Operations.this_or_next)
				result.Append(Operations.this_or_next.ToString() + "|" + (~((~Opcode) | Operations.this_or_next)).ToString());
			else
				Console.WriteLine("警告：有未知的指令码出现");
			switch (Opcode)
			{
				case Operations.try_begin:
				case Operations.try_for_range:
				case Operations.try_for_agents:
				case Operations.try_for_parties:
				case Operations.try_for_players:
				case Operations.try_for_prop_instances:
				case Operations.try_for_range_backwards:
					j = 4;
					break;
				case Operations.else_try:
					j = 2 | 4;
					break;
				case Operations.try_end:
					j = 2;
					break;
				default:
					j = 0;
					break;
			}
			foreach (var param in Params)
				result.Append("," + param.Decompile());
			result.Append(")");
			return result.ToString();
		}
	}
}

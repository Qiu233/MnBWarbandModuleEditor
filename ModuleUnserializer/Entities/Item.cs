using ModuleUnserializer.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ModuleUnserializer.Entities
{
	/// <summary>
	/// Item的Capabilities属性备选，用于指出物品的能力
	/// </summary>
	public enum ItemCapabilitiesFlags : ulong
	{
		itcf_thrust_onehanded = 0x0000000000000001,
		itcf_overswing_onehanded = 0x0000000000000002,
		itcf_slashright_onehanded = 0x0000000000000004,
		itcf_slashleft_onehanded = 0x0000000000000008,

		itcf_thrust_twohanded = 0x0000000000000010,
		itcf_overswing_twohanded = 0x0000000000000020,
		itcf_slashright_twohanded = 0x0000000000000040,
		itcf_slashleft_twohanded = 0x0000000000000080,

		itcf_thrust_polearm = 0x0000000000000100,
		itcf_overswing_polearm = 0x0000000000000200,
		itcf_slashright_polearm = 0x0000000000000400,
		itcf_slashleft_polearm = 0x0000000000000800,

		itcf_shoot_bow = 0x0000000000001000,
		itcf_shoot_javelin = 0x0000000000002000,
		itcf_shoot_crossbow = 0x0000000000004000,

		itcf_throw_stone = 0x0000000000010000,
		itcf_throw_knife = 0x0000000000020000,
		itcf_throw_axe = 0x0000000000030000,
		itcf_throw_javelin = 0x0000000000040000,
		itcf_shoot_pistol = 0x0000000000070000,
		itcf_shoot_musket = 0x0000000000080000,
		itcf_shoot_mask = 0x00000000000ff000,

		itcf_horseback_thrust_onehanded = 0x0000000000100000,
		itcf_horseback_overswing_right_onehanded = 0x0000000000200000,
		itcf_horseback_overswing_left_onehanded = 0x0000000000400000,
		itcf_horseback_slashright_onehanded = 0x0000000000800000,
		itcf_horseback_slashleft_onehanded = 0x0000000001000000,
		itcf_thrust_onehanded_lance = 0x0000000004000000,
		itcf_thrust_onehanded_lance_horseback = 0x0000000008000000,

		itcf_carry_mask = 0x00000007f0000000,
		itcf_carry_sword_left_hip = 0x0000000010000000,
		itcf_carry_axe_left_hip = 0x0000000020000000,
		itcf_carry_dagger_front_left = 0x0000000030000000,
		itcf_carry_dagger_front_right = 0x0000000040000000,
		itcf_carry_quiver_front_right = 0x0000000050000000,
		itcf_carry_quiver_back_right = 0x0000000060000000,
		itcf_carry_quiver_right_vertical = 0x0000000070000000,
		itcf_carry_quiver_back = 0x0000000080000000,
		itcf_carry_revolver_right = 0x0000000090000000,
		itcf_carry_pistol_front_left = 0x00000000a0000000,
		itcf_carry_bowcase_left = 0x00000000b0000000,
		itcf_carry_mace_left_hip = 0x00000000c0000000,

		itcf_carry_axe_back = 0x0000000100000000,
		itcf_carry_sword_back = 0x0000000110000000,
		itcf_carry_kite_shield = 0x0000000120000000,
		itcf_carry_round_shield = 0x0000000130000000,
		itcf_carry_buckler_left = 0x0000000140000000,
		itcf_carry_crossbow_back = 0x0000000150000000,
		itcf_carry_bow_back = 0x0000000160000000,
		itcf_carry_spear = 0x0000000170000000,
		itcf_carry_board_shield = 0x0000000180000000,

		itcf_carry_katana = 0x0000000210000000,
		itcf_carry_wakizashi = 0x0000000220000000,


		itcf_show_holster_when_drawn = 0x0000000800000000,

		itcf_reload_pistol = 0x0000007000000000,
		itcf_reload_musket = 0x0000008000000000,
		itcf_reload_mask = 0x000000f000000000,

		itcf_parry_forward_onehanded = 0x0000010000000000,
		itcf_parry_up_onehanded = 0x0000020000000000,
		itcf_parry_right_onehanded = 0x0000040000000000,
		itcf_parry_left_onehanded = 0x0000080000000000,

		itcf_parry_forward_twohanded = 0x0000100000000000,
		itcf_parry_up_twohanded = 0x0000200000000000,
		itcf_parry_right_twohanded = 0x0000400000000000,
		itcf_parry_left_twohanded = 0x0000800000000000,

		itcf_parry_forward_polearm = 0x0001000000000000,
		itcf_parry_up_polearm = 0x0002000000000000,
		itcf_parry_right_polearm = 0x0004000000000000,
		itcf_parry_left_polearm = 0x0008000000000000,

		itcf_horseback_slash_polearm = 0x0010000000000000,
		itcf_overswing_spear = 0x0020000000000000,
		itcf_overswing_musket = 0x0040000000000000,
		itcf_thrust_musket = 0x0080000000000000,

		itcf_force_64_bits = 0x8000000000000000,
	}
	public enum ItemCapabilities : ulong
	{
		itc_cleaver = ItemCapabilitiesFlags.itcf_force_64_bits | (ItemCapabilitiesFlags.itcf_overswing_onehanded | ItemCapabilitiesFlags.itcf_slashright_onehanded | ItemCapabilitiesFlags.itcf_slashleft_onehanded |
									ItemCapabilitiesFlags.itcf_horseback_slashright_onehanded | ItemCapabilitiesFlags.itcf_horseback_slashleft_onehanded),
		itc_dagger = itc_cleaver | ItemCapabilitiesFlags.itcf_thrust_onehanded,

		itc_parry_onehanded = ItemCapabilitiesFlags.itcf_force_64_bits | ItemCapabilitiesFlags.itcf_parry_forward_onehanded | ItemCapabilitiesFlags.itcf_parry_up_onehanded | ItemCapabilitiesFlags.itcf_parry_right_onehanded | ItemCapabilitiesFlags.itcf_parry_left_onehanded,
		itc_longsword = itc_dagger | itc_parry_onehanded,
		itc_scimitar = itc_cleaver | itc_parry_onehanded,

		itc_parry_two_handed = ItemCapabilitiesFlags.itcf_force_64_bits | ItemCapabilitiesFlags.itcf_parry_forward_twohanded | ItemCapabilitiesFlags.itcf_parry_up_twohanded | ItemCapabilitiesFlags.itcf_parry_right_twohanded | ItemCapabilitiesFlags.itcf_parry_left_twohanded,
		itc_cut_two_handed = ItemCapabilitiesFlags.itcf_force_64_bits | (ItemCapabilitiesFlags.itcf_slashright_twohanded | ItemCapabilitiesFlags.itcf_slashleft_twohanded | ItemCapabilitiesFlags.itcf_overswing_twohanded |
												   ItemCapabilitiesFlags.itcf_horseback_slashright_onehanded | ItemCapabilitiesFlags.itcf_horseback_slashleft_onehanded),
		itc_greatsword = itc_cut_two_handed | ItemCapabilitiesFlags.itcf_thrust_twohanded | itc_parry_two_handed | ItemCapabilitiesFlags.itcf_thrust_onehanded_lance,
		itc_nodachi = itc_cut_two_handed | itc_parry_two_handed,

		itc_bastardsword = itc_cut_two_handed | ItemCapabilitiesFlags.itcf_thrust_twohanded | itc_parry_two_handed | itc_dagger,
		itc_morningstar = itc_cut_two_handed | itc_parry_two_handed | itc_cleaver,

		itc_parry_polearm = ItemCapabilitiesFlags.itcf_parry_forward_polearm | ItemCapabilitiesFlags.itcf_parry_up_polearm | ItemCapabilitiesFlags.itcf_parry_right_polearm | ItemCapabilitiesFlags.itcf_parry_left_polearm,
		itc_poleaxe = itc_parry_polearm | ItemCapabilitiesFlags.itcf_overswing_polearm | ItemCapabilitiesFlags.itcf_thrust_polearm | ItemCapabilitiesFlags.itcf_slashright_polearm | ItemCapabilitiesFlags.itcf_slashleft_polearm,
		itc_staff = itc_parry_polearm | ItemCapabilitiesFlags.itcf_thrust_onehanded_lance | ItemCapabilitiesFlags.itcf_thrust_onehanded_lance_horseback | ItemCapabilitiesFlags.itcf_overswing_polearm | ItemCapabilitiesFlags.itcf_thrust_polearm | ItemCapabilitiesFlags.itcf_slashright_polearm | ItemCapabilitiesFlags.itcf_slashleft_polearm,
		itc_spear = itc_parry_polearm | ItemCapabilitiesFlags.itcf_thrust_onehanded_lance | ItemCapabilitiesFlags.itcf_thrust_onehanded_lance_horseback | ItemCapabilitiesFlags.itcf_thrust_polearm,
		itc_cutting_spear = itc_spear | ItemCapabilitiesFlags.itcf_overswing_polearm,
		itc_pike = ItemCapabilitiesFlags.itcf_thrust_onehanded_lance | ItemCapabilitiesFlags.itcf_thrust_onehanded_lance_horseback | ItemCapabilitiesFlags.itcf_thrust_polearm,
		itc_guandao = itc_parry_polearm | ItemCapabilitiesFlags.itcf_overswing_polearm | ItemCapabilitiesFlags.itcf_thrust_polearm | ItemCapabilitiesFlags.itcf_slashright_polearm | ItemCapabilitiesFlags.itcf_slashleft_polearm | ItemCapabilitiesFlags.itcf_horseback_slashright_onehanded | ItemCapabilitiesFlags.itcf_horseback_slashleft_onehanded | ItemCapabilitiesFlags.itcf_horseback_slash_polearm,

		itc_greatlance = ItemCapabilitiesFlags.itcf_thrust_onehanded_lance | ItemCapabilitiesFlags.itcf_thrust_onehanded_lance_horseback | ItemCapabilitiesFlags.itcf_thrust_polearm,
		itc_musket_melee = itc_parry_polearm | ItemCapabilitiesFlags.itcf_overswing_musket | ItemCapabilitiesFlags.itcf_thrust_musket | ItemCapabilitiesFlags.itcf_slashright_twohanded | ItemCapabilitiesFlags.itcf_slashleft_twohanded,
	}
	public enum ItemModifiersBit
	{
		imod_plain = 0,
		imod_cracked = 1,
		imod_rusty = 2,
		imod_bent = 3,
		imod_chipped = 4,
		imod_battered = 5,
		imod_poor = 6,
		imod_crude = 7,
		imod_old = 8,
		imod_cheap = 9,
		imod_fine = 10,
		imod_well_made = 11,
		imod_sharp = 12,
		imod_balanced = 13,
		imod_tempered = 14,
		imod_deadly = 15,
		imod_exquisite = 16,
		imod_masterwork = 17,
		imod_heavy = 18,
		imod_strong = 19,
		imod_powerful = 20,
		imod_tattered = 21,
		imod_ragged = 22,
		imod_rough = 23,
		imod_sturdy = 24,
		imod_thick = 25,
		imod_hardened = 26,
		imod_reinforced = 27,
		imod_superb = 28,
		imod_lordly = 29,
		imod_lame = 30,
		imod_swaybacked = 31,
		imod_stubborn = 32,
		imod_timid = 33,
		imod_meek = 34,
		imod_spirited = 35,
		imod_champion = 36,
		imod_fresh = 37,
		imod_day_old = 38,
		imod_two_day_old = 39,
		imod_smelling = 40,
		imod_rotten = 41,
		imod_large_bag = 42,
	}
	/// <summary>
	/// 物品的Properties属性备选项
	/// </summary>
	public enum ItemProperties : long
	{
		itp_type_horse = 0x0000000000000001,
		itp_type_one_handed_wpn = 0x0000000000000002,
		itp_type_two_handed_wpn = 0x0000000000000003,
		itp_type_polearm = 0x0000000000000004,
		itp_type_arrows = 0x0000000000000005,
		itp_type_bolts = 0x0000000000000006,
		itp_type_shield = 0x0000000000000007,
		itp_type_bow = 0x0000000000000008,
		itp_type_crossbow = 0x0000000000000009,
		itp_type_thrown = 0x000000000000000a,
		itp_type_goods = 0x000000000000000b,
		itp_type_head_armor = 0x000000000000000c,
		itp_type_body_armor = 0x000000000000000d,
		itp_type_foot_armor = 0x000000000000000e,
		itp_type_hand_armor = 0x000000000000000f,
		itp_type_pistol = 0x0000000000000010,
		itp_type_musket = 0x0000000000000011,
		itp_type_bullets = 0x0000000000000012,
		itp_type_animal = 0x0000000000000013,
		itp_type_book = 0x0000000000000014,


		itp_force_attach_left_hand = 0x0000000000000100,
		itp_force_attach_right_hand = 0x0000000000000200,
		itp_force_attach_left_forearm = 0x0000000000000300,
		itp_attach_armature = 0x0000000000000f00,
		itp_attachment_mask = 0x0000000000000f00,

		itp_unique = 0x0000000000001000,
		itp_always_loot = 0x0000000000002000,
		itp_no_parry = 0x0000000000004000,
		itp_default_ammo = 0x0000000000008000,
		itp_merchandise = 0x0000000000010000,
		itp_wooden_attack = 0x0000000000020000,
		itp_wooden_parry = 0x0000000000040000,
		itp_food = 0x0000000000080000,
		itp_cant_reload_on_horseback = 0x0000000000100000,
		itp_two_handed = 0x0000000000200000,
		itp_primary = 0x0000000000400000,
		itp_secondary = 0x0000000000800000,
		itp_covers_legs = 0x0000000001000000,
		itp_doesnt_cover_hair = 0x0000000001000000,
		itp_can_penetrate_shield = 0x0000000001000000,
		itp_consumable = 0x0000000002000000,
		itp_bonus_against_shield = 0x0000000004000000,
		itp_penalty_with_shield = 0x0000000008000000,
		itp_cant_use_on_horseback = 0x0000000010000000,
		itp_civilian = 0x0000000020000000,
		itp_next_item_as_melee = 0x0000000020000000,
		itp_fit_to_head = 0x0000000040000000,
		itp_offset_lance = 0x0000000040000000,
		itp_covers_head = 0x0000000080000000,
		itp_couchable = 0x0000000080000000,
		itp_crush_through = 0x0000000100000000,
		itp_remove_item_on_use = 0x0000000400000000,
		itp_unbalanced = 0x0000000800000000,

		itp_covers_beard = 0x0000001000000000,
		itp_no_pick_up_from_ground = 0x0000002000000000,
		itp_can_knock_down = 0x0000004000000000,
		itp_covers_hair = 0x0000008000000000,

		itp_force_show_body = 0x0000010000000000,
		itp_force_show_left_hand = 0x0000020000000000,
		itp_force_show_right_hand = 0x0000040000000000,

		itp_extra_penetration = 0x0000100000000000,
		itp_has_bayonet = 0x0000200000000000,
		itp_cant_reload_while_moving = 0x0000400000000000,
		itp_ignore_gravity = 0x0000800000000000,
		itp_ignore_friction = 0x0001000000000000,
		itp_is_pike = 0x0002000000000000,
		itp_offset_musket = 0x0004000000000000,
		itp_no_blur = 0x0008000000000000,

		itp_cant_reload_while_moving_mounted = 0x0010000000000000,
		itp_has_upper_stab = 0x0020000000000000,
		itp_kill_info_mask = 0x0700000000000000,
		itp_kill_info_bits = 56,
	}
	public enum ItemDamageType
	{
		Cut = 0x0,
		Pierce = 0x100,
		Blunt = 0x200,
	}
	public enum ItemMeshID : long
	{
		ixmesh_none = 0,
		ixmesh_inventory = 1,
		ixmesh_flying_ammo = 2,
		ixmesh_carry = 3,
	}
	public class Item : ICloneable
	{
		public static Dictionary<string, ItemCapabilities> ItemCombinedCapabilities = new Dictionary<string, ItemCapabilities>
		{
			{ "cleaver", ItemCapabilities.itc_cleaver} ,

			{ "dagger", ItemCapabilities.itc_dagger},

			{ "parry_onehanded", ItemCapabilities.itc_parry_onehanded},
			{ "longsword", ItemCapabilities.itc_longsword},
			{ "scimitar", ItemCapabilities.itc_scimitar},

			{ "parry_twohanded", ItemCapabilities.itc_parry_two_handed},
			{ "cut_twohanded", ItemCapabilities.itc_cut_two_handed},

			{ "greatsword", ItemCapabilities.itc_greatsword},
			{ "nodachi", ItemCapabilities.itc_nodachi},

			{ "bastardsword", ItemCapabilities.itc_bastardsword},
			{ "morningstar", ItemCapabilities.itc_morningstar},

			{ "parry_polearm", ItemCapabilities.itc_parry_polearm},
			{ "poleaxe", ItemCapabilities.itc_poleaxe},
			{ "staff", ItemCapabilities.itc_staff},
			{ "spear", ItemCapabilities.itc_spear},
			{ "cutting_spear", ItemCapabilities.itc_cutting_spear},
			{ "pike", ItemCapabilities.itc_pike},
			{ "guandao", ItemCapabilities.itc_guandao},

			{ "greatlance", ItemCapabilities.itc_greatlance},
			{ "musket_melee", ItemCapabilities.itc_musket_melee},
		};
		/// <summary>
		/// 请勿修改，这是根据对应前缀所占二进制位所需移位的数量进行排序的
		/// 用我们人话来说，就是物品的数据从右往左数第i个二进制位，置1，那么ItemModfiers[i]对应的前缀就是可用的
		/// </summary>
		public static string[] ItemModifiers =
			new string[] {
				"plain", "cracked", "rusty", "bent",
				"chipped", "battered", "poor", "crude",
				"old", "cheap", "fine", "well_made",
				"sharp", "balanced", "tempered",
				"deadly", "exquisite", "masterwork",
				"heavy", "strong", "powerful", "tattered",
				"ragged", "rough", "sturdy", "thick",
				"hardened", "reinforced", "superb",
				"lordly", "lame", "swaybacked",
				"stubborn", "timid", "meek", "spirited",
				"champion", "fresh", "day_old",
				"two_day_old", "smelling", "rotten",
				"large_bag", };

		public string Index;
		public string NameEn;
		public string Name;
		public string NamePL;
		public BigInteger Properties
		{
			get;
			set;
		}
		public BigInteger Capabilities;
		public int Price;
		public BigInteger Modifiers;
		public List<KeyValuePair<string, BigInteger>> Meshes;
		public List<Faction> Factions;
		public List<SimpleTrigger> SimpleTriggers;
		public double Weight;
		public int
			Abundance,
			Head_Armor,
			Body_Armor,
			Leg_Armor,
			Difficulty,
			Hit_Points,
			Speed_Rating,
			Missile_Speed,
			Weapon_Length,
			Max_Ammo,
			Thrust_Damage,
			Swing_Damage;

		private Item()
		{

		}
		public bool NextItemAsMelee
		{
			get => (Properties & (long)ItemProperties.itp_next_item_as_melee) == (long)ItemProperties.itp_next_item_as_melee;
			set => Properties |= (long)ItemProperties.itp_next_item_as_melee;
		}
		public bool IsWeapon
		{
			get
			{
				ItemProperties p = ItemType;
				return p == ItemProperties.itp_type_one_handed_wpn ||
					p == ItemProperties.itp_type_two_handed_wpn ||
					p == ItemProperties.itp_type_polearm ||
					p == ItemProperties.itp_type_bow ||
					p == ItemProperties.itp_type_crossbow ||
					p == ItemProperties.itp_type_thrown ||
					p == ItemProperties.itp_type_pistol ||
					p == ItemProperties.itp_type_musket ||
					p == ItemProperties.itp_type_two_handed_wpn;
			}
		}
		public bool IsShield
		{
			get
			{
				ItemProperties p = ItemType;
				return p == ItemProperties.itp_type_shield;
			}
		}
		public bool IsArmor
		{
			get
			{
				ItemProperties p = ItemType;
				return p == ItemProperties.itp_type_head_armor ||
					p == ItemProperties.itp_type_body_armor ||
					p == ItemProperties.itp_type_foot_armor ||
					p == ItemProperties.itp_type_hand_armor;
			}
		}
		public bool NextItemAsMeleeEnabled
		{
			get; set;
		}
		public ItemProperties ItemType
		{
			get => (ItemProperties)Convert.ToInt32((Properties & 0xFF).ToString());
			set
			{
				Properties = (Properties & BigInteger.Parse("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFF00", System.Globalization.NumberStyles.HexNumber)) + (int)value;
			}
		}
		private static BigInteger GetBigInt(string str)
		{
			BigInteger.TryParse(str, out BigInteger bi);
			return bi;
		}
		public static Item FromString(ModuleInfo minfo, string[] s, ref int j)
		{
			Dictionary<string, string> itemNames = minfo.F_Language["item_kinds"];
			Item item = new Item();
			item.Index = s[j++];
			item.NameEn = s[j++];
			item.Name = item.NameEn;
			item.NamePL = item.Name;
			j++;
			if (itemNames.ContainsKey(item.Index) && itemNames.ContainsKey(item.Index + "_pl"))
			{
				item.Name = itemNames[item.Index];
				item.NamePL = itemNames[item.Index + "_pl"];
			}
			item.Meshes = new List<KeyValuePair<string, BigInteger>>(Convert.ToInt32(s[j++]));
			for (int i = 0; i < item.Meshes.Capacity; i++)
				item.Meshes.Add(new KeyValuePair<string, BigInteger>(s[j++], GetBigInt(s[j++])));
			item.Properties = GetBigInt(s[j++]);
			item.Capabilities = GetBigInt(s[j++]);
			item.Price = Convert.ToInt32(s[j++]);
			item.Modifiers = GetBigInt(s[j++]);

			item.Weight = Convert.ToDouble(s[j++]);
			item.Abundance = Convert.ToInt32(s[j++]);
			item.Head_Armor = Convert.ToInt32(s[j++]);
			item.Body_Armor = Convert.ToInt32(s[j++]);
			item.Leg_Armor = Convert.ToInt32(s[j++]);
			item.Difficulty = Convert.ToInt32(s[j++]);
			item.Hit_Points = Convert.ToInt32(s[j++]);
			item.Speed_Rating = Convert.ToInt32(s[j++]);
			item.Missile_Speed = Convert.ToInt32(s[j++]);
			item.Weapon_Length = Convert.ToInt32(s[j++]);
			item.Max_Ammo = Convert.ToInt32(s[j++]);
			item.Thrust_Damage = Convert.ToInt32(s[j++]);
			item.Swing_Damage = Convert.ToInt32(s[j++]);

			item.Factions = new List<Faction>(Convert.ToInt32(s[j++]));
			for (int i = 0; i < item.Factions.Capacity; i++)
				item.Factions.Add(minfo.F_Factions.Factions[Convert.ToInt32(s[j++])]);
			item.SimpleTriggers = new List<SimpleTrigger>(Convert.ToInt32(s[j++]));
			for (int i = 0; i < item.SimpleTriggers.Capacity; i++)
				item.SimpleTriggers.Add(SimpleTrigger.FromString(s, ref j));
			return item;
		}

		public object Clone()
		{
			var item = new Item()
			{
				Index = Index,
				NameEn = NameEn,
				Name = Name,
				NamePL = NamePL,
				Properties = Properties,
				Capabilities = Capabilities,
				Price = Price,
				Modifiers = Modifiers,
				Weight = Weight,
				Abundance = Abundance,
				Head_Armor = Head_Armor,
				Body_Armor = Body_Armor,
				Leg_Armor = Leg_Armor,
				Difficulty = Difficulty,
				Hit_Points = Hit_Points,
				Speed_Rating = Speed_Rating,
				Missile_Speed = Missile_Speed,
				Weapon_Length = Weapon_Length,
				Max_Ammo = Max_Ammo,
				Thrust_Damage = Thrust_Damage,
				Swing_Damage = Swing_Damage,
				NextItemAsMelee = NextItemAsMelee,
				NextItemAsMeleeEnabled = NextItemAsMeleeEnabled,
				Meshes = new List<KeyValuePair<string, BigInteger>>(Meshes.Capacity),
				Factions = new List<Faction>(Factions.Capacity),
				SimpleTriggers = new List<SimpleTrigger>(SimpleTriggers.Capacity)
			};
			foreach (var m in Meshes)
				item.Meshes.Add(new KeyValuePair<string, BigInteger>(m.Key, m.Value));
			foreach (var f in Factions)
				item.Factions.Add(f);
			foreach (var st in SimpleTriggers)
				item.SimpleTriggers.Add(st);
			return item;
		}
	}
}

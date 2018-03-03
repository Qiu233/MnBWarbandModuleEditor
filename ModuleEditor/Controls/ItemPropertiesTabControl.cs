using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Windows.Forms;
using ModuleEditor.Entities;

namespace ModuleEditor.Controls
{
	public class ItemPropertiesTabControl : MTabControl
	{
		public GroupBox ItemTypeGroupBox, ItemAttributeGroupBox;
		public TabPage BasicProperties, Properties, Model, Triggers;
		public LabelTextBox ItemIndex, ItemNameEn, ItemName, ItemNamePl;
		public LabelTextBox Price, Abundance;
		public TextBox ItemID;
		public CheckBox NextItemAsMelee;
		public CheckedListBox FactionCheckedListBox, PrefixCheckedListBox;
		public ItemPage ItemPage;
		public Panel MeleeAttributePanel, RangedAttributePanel, HorseAttributePanel, AmmoAttributePanel, ShieldAttributePanel, ArmorAttributePanel, GoodsAttributePanel;
		public DamageLabelTextBox MeleeSwingDamageLabelTextBox, MeleeThrustDamageLabelTextBox, AmmoDamageLabelTextBox, RangedDamageLabelTextBox;
		public LabelTextBox MeleeWeightLabelTextBox, MeleeDifficultyLabelTextBox, MeleeLengthLabelTextBox, MeleeSpeedLabelTextBox;
		public LabelTextBox RangedWeightLabelTextBox, RangedSpeedLabelTextBox, RangedMissileSpeedLabelTextBox, RangedDifficultyLabelTextBox, RangedLengthLabelTextBox, RangedAmmoLabelTextBox, RangedAccuracyLabelTextBox;
		public LabelTextBox HorseHealthLabelTextBox, HorseProtectionLabelTextBox, HorseSprintLabelTextBox, HorseSizeLabelTextBox, HorseSpeedLabelTextBox, HorseControlLabelTextBox, HorseDifficultyLabelTextBox;
		public LabelTextBox AmmoLengthLabelTextBox, AmmoWeightLabelTextBox, AmmoCountLabelTextBox;
		public LabelTextBox ShieldWeightLabelTextBox, ShieldStengthLabelTextBox, ShieldSpeedLabelTextBox, ShieldSizeLabelTextBox, ShieldDefenseLabelTextBox, ShieldDifficultyLabelTextBox;
		public LabelTextBox ArmorWeightLabelTextBox, ArmorHeadLabelTextBox, ArmorLegLabelTextBox, ArmorDifficultyLabelTextBox, ArmorBodyLabelTextBox;
		public LabelTextBox GoodsWeightLabelTextBox, GoodsNumberLabelTextBox, GoodsQuality;
		public MListBox ModelsListBox;
		public LabelTextBox ModelName;
		public ComboBox ModelLocation;
		public CheckedListBox ModelPrefixListBox;
		public GroupBox ItemBindGroupBox;
		public event Action<ItemProperties> OnItemTypeChange = (p) => { };

		private static Dictionary<string, List<ItemModifiersBit>> IModBitPreseted = new Dictionary<string, List<ItemModifiersBit>>
		{
			{"horse",new List<ItemModifiersBit>{
				ItemModifiersBit.imod_swaybacked,
				ItemModifiersBit.imod_lame,
				ItemModifiersBit.imod_spirited,
				ItemModifiersBit.imod_heavy,
				ItemModifiersBit.imod_stubborn,
			} },
			{"cloth", new List<ItemModifiersBit>{
				ItemModifiersBit.imod_tattered,
				ItemModifiersBit.imod_ragged,
				ItemModifiersBit.imod_sturdy,
				ItemModifiersBit.imod_thick,
				ItemModifiersBit.imod_hardened,
			} },
			{"armor", new List<ItemModifiersBit>{
				ItemModifiersBit.imod_rusty,
				ItemModifiersBit.imod_battered,
				ItemModifiersBit.imod_crude,
				ItemModifiersBit.imod_thick,
				ItemModifiersBit.imod_reinforced,
				ItemModifiersBit.imod_lordly,
			} },
			{"plate", new List<ItemModifiersBit>{
				ItemModifiersBit.imod_cracked,
				ItemModifiersBit.imod_rusty,
				ItemModifiersBit.imod_battered,
				ItemModifiersBit.imod_crude,
				ItemModifiersBit.imod_thick,
				ItemModifiersBit.imod_reinforced,
				ItemModifiersBit.imod_lordly,
			} },
			{"polearm", new List<ItemModifiersBit>{
				ItemModifiersBit.imod_cracked,
				ItemModifiersBit.imod_bent,
				ItemModifiersBit.imod_balanced,
			} },
			{"shield", new List<ItemModifiersBit>{
				ItemModifiersBit.imod_cracked,
				ItemModifiersBit.imod_battered,
				ItemModifiersBit.imod_thick,
				ItemModifiersBit.imod_reinforced,
			} },
			{"sword", new List<ItemModifiersBit>{
				ItemModifiersBit.imod_rusty,
				ItemModifiersBit.imod_chipped,
				ItemModifiersBit.imod_balanced,
				ItemModifiersBit.imod_tempered,
			} },
			{"sword_high", new List<ItemModifiersBit>{
				ItemModifiersBit.imod_rusty,
				ItemModifiersBit.imod_chipped,
				ItemModifiersBit.imod_balanced,
				ItemModifiersBit.imod_tempered,
				ItemModifiersBit.imod_masterwork,
			} },
			{"axe", new List<ItemModifiersBit>{
				ItemModifiersBit.imod_rusty,
				ItemModifiersBit.imod_chipped,
				ItemModifiersBit.imod_heavy,
			} },
			{"mace", new List<ItemModifiersBit>{
				ItemModifiersBit.imod_rusty,
				ItemModifiersBit.imod_chipped,
				ItemModifiersBit.imod_heavy,
			} },
			{"pick", new List<ItemModifiersBit>{
				ItemModifiersBit.imod_rusty,
				ItemModifiersBit.imod_chipped,
				ItemModifiersBit.imod_balanced,
				ItemModifiersBit.imod_heavy,
			} },
			{"bow", new List<ItemModifiersBit>{
				ItemModifiersBit.imod_cracked,
				ItemModifiersBit.imod_bent,
				ItemModifiersBit.imod_strong,
				ItemModifiersBit.imod_masterwork,
			} },
			{"crossbow", new List<ItemModifiersBit>{
				ItemModifiersBit.imod_cracked,
				ItemModifiersBit.imod_bent,
				ItemModifiersBit.imod_masterwork,
			} },
			{"missile", new List<ItemModifiersBit>{
				ItemModifiersBit.imod_bent,
				ItemModifiersBit.imod_large_bag,
			} },
			{"thrown", new List<ItemModifiersBit>{
				ItemModifiersBit.imod_bent,
				ItemModifiersBit.imod_heavy,
				ItemModifiersBit.imod_balanced,
				ItemModifiersBit.imod_large_bag,
			} },
			{"thrown_minus_heavy", new List<ItemModifiersBit>{
				ItemModifiersBit.imod_bent,
				ItemModifiersBit.imod_balanced,
				ItemModifiersBit.imod_large_bag,
			} },
			{"horse_good", new List<ItemModifiersBit>{
				ItemModifiersBit.imod_spirited,
				ItemModifiersBit.imod_heavy,
			} },
			{"good", new List<ItemModifiersBit>{
				ItemModifiersBit.imod_sturdy,
				ItemModifiersBit.imod_thick,
				ItemModifiersBit.imod_hardened,
				ItemModifiersBit.imod_reinforced,
			} },
			{"bad", new List<ItemModifiersBit>{
				ItemModifiersBit.imod_rusty,
				ItemModifiersBit.imod_chipped,
				ItemModifiersBit.imod_tattered,
				ItemModifiersBit.imod_ragged,
				ItemModifiersBit.imod_cracked,
				ItemModifiersBit.imod_bent,
			} },
		};
		public ItemPropertiesTabControl(ItemPage Page)
		{
			ItemPage = Page;
			BasicProperties = new TabPage("基本信息")
			{
				BackColor = Color.FromArgb(30, 30, 36),
			};
			#region 识别
			{
				GroupBox idenGroupBox = new GroupBox()
				{
					ForeColor = Color.White,
					Text = "识别",
					Location = new Point(15, 15),
					Size = new Size(545, 140)
				};
				ItemIndex = new LabelTextBox(120, 350, 20, "物品ID:")
				{
					Location = new Point(10, 15),
				};
				ItemNameEn = new LabelTextBox(120, 350, 20, "物品名(EN):")
				{
					Location = new Point(10, 45),
				};
				ItemName = new LabelTextBox(120, 350, 20, "物品名(" + MainForm.LanguageName.ToUpper() + "):")
				{
					Location = new Point(10, 75),
				};
				ItemNamePl = new LabelTextBox(120, 350, 20, "物品复数名(" + MainForm.LanguageName.ToUpper() + "):")
				{
					Location = new Point(10, 105),
				};
				idenGroupBox.Controls.Add(ItemIndex);
				idenGroupBox.Controls.Add(ItemNameEn);
				idenGroupBox.Controls.Add(ItemName);
				idenGroupBox.Controls.Add(ItemNamePl);

				BasicProperties.Controls.Add(idenGroupBox);
			}
			#endregion

			#region 物品类型
			{
				ItemTypeGroupBox = new GroupBox()
				{
					ForeColor = Color.White,
					Text = "物品类型",
					Location = new Point(15, 170),
					Size = new Size(545, 140)
				};
				ItemTypeGroupBox.Controls.Add(new RadioButton() { Text = "无", Location = new Point(30, 15), Size = new Size(80, 20) });

				ItemTypeGroupBox.Controls.Add(new RadioButton() { Text = "马匹", Location = new Point(30, 40), Size = new Size(80, 20) });
				ItemTypeGroupBox.Controls.Add(new RadioButton() { Text = "单手武器", Location = new Point(125, 40), Size = new Size(80, 20) });
				ItemTypeGroupBox.Controls.Add(new RadioButton() { Text = "双手武器", Location = new Point(220, 40), Size = new Size(80, 20) });
				ItemTypeGroupBox.Controls.Add(new RadioButton() { Text = "长杆", Location = new Point(315, 40), Size = new Size(80, 20) });
				ItemTypeGroupBox.Controls.Add(new RadioButton() { Text = "箭", Location = new Point(410, 40), Size = new Size(80, 20) });

				ItemTypeGroupBox.Controls.Add(new RadioButton() { Text = "弩箭", Location = new Point(30, 65), Size = new Size(80, 20) });
				ItemTypeGroupBox.Controls.Add(new RadioButton() { Text = "盾牌", Location = new Point(125, 65), Size = new Size(80, 20) });
				ItemTypeGroupBox.Controls.Add(new RadioButton() { Text = "弓", Location = new Point(220, 65), Size = new Size(80, 20) });
				ItemTypeGroupBox.Controls.Add(new RadioButton() { Text = "弩", Location = new Point(315, 65), Size = new Size(80, 20) });
				ItemTypeGroupBox.Controls.Add(new RadioButton() { Text = "投掷武器", Location = new Point(410, 65), Size = new Size(80, 20) });

				ItemTypeGroupBox.Controls.Add(new RadioButton() { Text = "货物", Location = new Point(30, 90), Size = new Size(80, 20) });
				ItemTypeGroupBox.Controls.Add(new RadioButton() { Text = "头盔", Location = new Point(125, 90), Size = new Size(80, 20) });
				ItemTypeGroupBox.Controls.Add(new RadioButton() { Text = "盔甲", Location = new Point(220, 90), Size = new Size(80, 20) });
				ItemTypeGroupBox.Controls.Add(new RadioButton() { Text = "护腿", Location = new Point(315, 90), Size = new Size(80, 20) });
				ItemTypeGroupBox.Controls.Add(new RadioButton() { Text = "护手", Location = new Point(410, 90), Size = new Size(80, 20) });

				ItemTypeGroupBox.Controls.Add(new RadioButton() { Text = "手枪", Location = new Point(30, 115), Size = new Size(80, 20) });
				ItemTypeGroupBox.Controls.Add(new RadioButton() { Text = "滑膛枪", Location = new Point(125, 115), Size = new Size(80, 20) });
				ItemTypeGroupBox.Controls.Add(new RadioButton() { Text = "子弹", Location = new Point(220, 115), Size = new Size(80, 20) });
				ItemTypeGroupBox.Controls.Add(new RadioButton() { Text = "动物", Location = new Point(315, 115), Size = new Size(80, 20) });
				ItemTypeGroupBox.Controls.Add(new RadioButton() { Text = "书籍", Location = new Point(410, 115), Size = new Size(80, 20) });
				BasicProperties.Controls.Add(ItemTypeGroupBox);
				foreach (var c in ItemTypeGroupBox.Controls)
				{
					(c as RadioButton).CheckedChanged += (s, e) =>
					{
						var btn = s as RadioButton;
						if (btn.Checked)
						{
							ItemPage.SelectedItem.ItemType = (ItemProperties)ItemTypeGroupBox.Controls.IndexOf(btn);
							OnItemTypeChange(ItemPage.SelectedItem.ItemType);
						}
					};
				}
			}
			#endregion

			#region 杂项
			{
				GroupBox sundryGroupBox = new GroupBox()
				{
					ForeColor = Color.White,
					Text = "杂项",
					Location = new Point(15, 330),
					Size = new Size(545, 220)
				};
				NextItemAsMelee = new CheckBox()
				{
					Text = "下一个武器作为第二种模式",
					Location = new Point(20, 95),
					Size = new Size(180, 20)
				};

				Price = new LabelTextBox(60, 100, 20, "价格:")
				{
					Location = new Point(10, 120),
				};
				Abundance = new LabelTextBox(60, 100, 20, "充裕度:")
				{
					Location = new Point(10, 145),
				};
				sundryGroupBox.Controls.Add(NextItemAsMelee);
				sundryGroupBox.Controls.Add(Price);
				sundryGroupBox.Controls.Add(Abundance);

				GroupBox factionGroupBox = new GroupBox()
				{
					ForeColor = Color.White,
					Text = "阵营",
					Location = new Point(330, 20),
					Size = new Size(200, 180)
				};
				FactionCheckedListBox = new CheckedListBox()
				{
					Location = new Point(5, 15),
					Size = new Size(190, 165),
					BackColor = Color.FromArgb(30, 30, 36),
					BorderStyle = BorderStyle.None,
					MultiColumn = false,
					ForeColor = Color.White
				};
				UpdateFactions();
				ItemPage.OnUpdate += UpdateFactions;

				factionGroupBox.Controls.Add(FactionCheckedListBox);
				sundryGroupBox.Controls.Add(factionGroupBox);

				BasicProperties.Controls.Add(sundryGroupBox);
			}
			#endregion


			Properties = new TabPage("属性")
			{
				BackColor = Color.FromArgb(30, 30, 36)
			};
			#region 前缀
			{
				GroupBox prefixGroupBox = new GroupBox()
				{
					ForeColor = Color.White,
					Text = "前缀",
					Location = new Point(5, 5),
					Size = new Size(250, 540)
				};
				PrefixCheckedListBox = new CheckedListBox()
				{
					Location = new Point(5, 15),
					Size = new Size(240, 250),
					BackColor = Color.FromArgb(30, 30, 36),
					BorderStyle = BorderStyle.None,
					MultiColumn = false,
					ForeColor = Color.White
				};
				foreach (var prefix in Item.ItemModifiers)
					PrefixCheckedListBox.Items.Add(prefix);

				GroupBox presetedGroupBox = new GroupBox()
				{
					ForeColor = Color.White,
					Text = "预设",
					Location = new Point(5, 270),
					Size = new Size(240, 260)
				};

				RadioButton presetCustom = new RadioButton
				{
					Checked = true,
					Location = new Point(40, 40),
					Size = new Size(80, 20),
					Text = "自定义"
				};
				//如果被改动(点击)就变为自定义
				PrefixCheckedListBox.MouseClick += (s, e) => presetCustom.Checked = true;



				RadioButton presetHorse = new RadioButton
				{
					Location = new Point(40, 60),
					Size = new Size(80, 20),
					Text = "马匹"
				};
				presetHorse.CheckedChanged += (s, e) => SetPrefix(IModBitPreseted["horse"]);

				RadioButton presetHorseGood = new RadioButton
				{
					Location = new Point(130, 60),
					Size = new Size(80, 20),
					Text = "宝马"
				};
				presetHorseGood.CheckedChanged += (s, e) => SetPrefix(IModBitPreseted["horse_good"]);

				RadioButton presetCloth = new RadioButton
				{
					Location = new Point(40, 80),
					Size = new Size(80, 20),
					Text = "衣服"
				};
				presetCloth.CheckedChanged += (s, e) => SetPrefix(IModBitPreseted["cloth"]);

				RadioButton presetArmor = new RadioButton
				{
					Location = new Point(130, 80),
					Size = new Size(80, 20),
					Text = "护甲"
				};
				presetArmor.CheckedChanged += (s, e) => SetPrefix(IModBitPreseted["armor"]);

				RadioButton presetPlate = new RadioButton
				{
					Location = new Point(40, 100),
					Size = new Size(80, 20),
					Text = "金属"
				};
				presetPlate.CheckedChanged += (s, e) => SetPrefix(IModBitPreseted["plate"]);

				RadioButton presetShield = new RadioButton
				{
					Location = new Point(130, 100),
					Size = new Size(80, 20),
					Text = "盾牌"
				};
				presetShield.CheckedChanged += (s, e) => SetPrefix(IModBitPreseted["shield"]);

				RadioButton presetPolearm = new RadioButton
				{
					Location = new Point(40, 120),
					Size = new Size(80, 20),
					Text = "长杆"
				};
				presetPolearm.CheckedChanged += (s, e) => SetPrefix(IModBitPreseted["polearm"]);

				RadioButton presetAxe = new RadioButton
				{
					Location = new Point(130, 120),
					Size = new Size(80, 20),
					Text = "斧头"
				};
				presetAxe.CheckedChanged += (s, e) => SetPrefix(IModBitPreseted["axe"]);

				RadioButton presetSword = new RadioButton
				{
					Location = new Point(40, 140),
					Size = new Size(80, 20),
					Text = "剑"
				};
				presetSword.CheckedChanged += (s, e) => SetPrefix(IModBitPreseted["sword"]);

				RadioButton presetSwordHigh = new RadioButton
				{
					Location = new Point(130, 140),
					Size = new Size(80, 20),
					Text = "宝剑"
				};
				presetSwordHigh.CheckedChanged += (s, e) => SetPrefix(IModBitPreseted["sword_high"]);

				RadioButton presetPick = new RadioButton
				{
					Location = new Point(40, 160),
					Size = new Size(80, 20),
					Text = "锄"
				};
				presetPick.CheckedChanged += (s, e) => SetPrefix(IModBitPreseted["pick"]);

				RadioButton presetBow = new RadioButton
				{
					Location = new Point(130, 160),
					Size = new Size(80, 20),
					Text = "弓"
				};
				presetBow.CheckedChanged += (s, e) => SetPrefix(IModBitPreseted["bow"]);

				RadioButton presetCrossBow = new RadioButton
				{
					Location = new Point(40, 180),
					Size = new Size(80, 20),
					Text = "弩"
				};
				presetCrossBow.CheckedChanged += (s, e) => SetPrefix(IModBitPreseted["crossbow"]);

				RadioButton presetMissile = new RadioButton
				{
					Location = new Point(130, 180),
					Size = new Size(80, 20),
					Text = "箭矢"
				};
				presetMissile.CheckedChanged += (s, e) => SetPrefix(IModBitPreseted["missile"]);

				RadioButton presetThrownHeavy = new RadioButton
				{
					Location = new Point(40, 200),
					Size = new Size(80, 20),
					Text = "投掷(重)"
				};
				presetThrownHeavy.CheckedChanged += (s, e) => SetPrefix(IModBitPreseted["thrown"]);

				RadioButton presetThrown = new RadioButton
				{
					Location = new Point(130, 200),
					Size = new Size(80, 20),
					Text = "投掷"
				};
				presetThrown.CheckedChanged += (s, e) => SetPrefix(IModBitPreseted["thrown_minus_heavy"]);



				presetedGroupBox.Controls.Add(presetCustom);
				presetedGroupBox.Controls.Add(presetHorse);
				presetedGroupBox.Controls.Add(presetHorseGood);
				presetedGroupBox.Controls.Add(presetCloth);
				presetedGroupBox.Controls.Add(presetArmor);
				presetedGroupBox.Controls.Add(presetPlate);
				presetedGroupBox.Controls.Add(presetShield);
				presetedGroupBox.Controls.Add(presetPolearm);
				presetedGroupBox.Controls.Add(presetAxe);
				presetedGroupBox.Controls.Add(presetSword);
				presetedGroupBox.Controls.Add(presetSwordHigh);
				presetedGroupBox.Controls.Add(presetPick);
				presetedGroupBox.Controls.Add(presetBow);
				presetedGroupBox.Controls.Add(presetCrossBow);
				presetedGroupBox.Controls.Add(presetMissile);
				presetedGroupBox.Controls.Add(presetThrownHeavy);
				presetedGroupBox.Controls.Add(presetThrown);

				prefixGroupBox.Controls.Add(presetedGroupBox);
				prefixGroupBox.Controls.Add(PrefixCheckedListBox);

				Properties.Controls.Add(prefixGroupBox);
			}
			#endregion
			#region 物品属性
			{
				#region Melee
				{
					MeleeAttributePanel = new Panel
					{
						Location = new Point(5, 15),
						Size = new Size(290, 230),
					};
					MeleeWeightLabelTextBox = new LabelTextBox(60, 60, 20, "重量:")
					{
						Location = new Point(5, 20)
					};
					MeleeDifficultyLabelTextBox = new LabelTextBox(60, 60, 20, "难度:")
					{
						Location = new Point(5, 50)
					};
					MeleeLengthLabelTextBox = new LabelTextBox(60, 60, 20, "长度:")
					{
						Location = new Point(140, 20)
					};
					MeleeSpeedLabelTextBox = new LabelTextBox(60, 60, 20, "速度:")
					{
						Location = new Point(140, 50)
					};
					MeleeSwingDamageLabelTextBox = new DamageLabelTextBox(60, 140, "挥砍:")
					{
						Location = new Point(5, 80)
					};
					MeleeThrustDamageLabelTextBox = new DamageLabelTextBox(60, 140, "穿刺:")
					{
						Location = new Point(5, 140)
					};
					MeleeAttributePanel.Controls.Add(MeleeWeightLabelTextBox);
					MeleeAttributePanel.Controls.Add(MeleeDifficultyLabelTextBox);
					MeleeAttributePanel.Controls.Add(MeleeLengthLabelTextBox);
					MeleeAttributePanel.Controls.Add(MeleeSpeedLabelTextBox);
					MeleeAttributePanel.Controls.Add(MeleeSwingDamageLabelTextBox);
					MeleeAttributePanel.Controls.Add(MeleeThrustDamageLabelTextBox);
				}
				#endregion
				#region Ranged
				{
					RangedAttributePanel = new Panel
					{
						Location = new Point(5, 15),
						Size = new Size(290, 230),
					};
					RangedWeightLabelTextBox = new LabelTextBox(60, 60, 20, "重量:")
					{
						Location = new Point(5, 20)
					};
					RangedSpeedLabelTextBox = new LabelTextBox(60, 60, 20, "速度:")
					{
						Location = new Point(5, 50)
					};
					RangedMissileSpeedLabelTextBox = new LabelTextBox(60, 60, 20, "弹速:")
					{
						Location = new Point(5, 80)
					};
					RangedDifficultyLabelTextBox = new LabelTextBox(60, 60, 20, "难度:")
					{
						Location = new Point(5, 110)
					};
					RangedLengthLabelTextBox = new LabelTextBox(60, 60, 20, "长度:")
					{
						Location = new Point(140, 20)
					};
					RangedAmmoLabelTextBox = new LabelTextBox(60, 60, 20, "弹量:")
					{
						Location = new Point(140, 50)
					};
					RangedAccuracyLabelTextBox = new LabelTextBox(60, 60, 20, "精度:")
					{
						Location = new Point(140, 80)
					};
					RangedDamageLabelTextBox = new DamageLabelTextBox(60, 140, "伤害:")
					{
						Location = new Point(5, 140)
					};
					RangedAttributePanel.Controls.Add(RangedWeightLabelTextBox);
					RangedAttributePanel.Controls.Add(RangedSpeedLabelTextBox);
					RangedAttributePanel.Controls.Add(RangedMissileSpeedLabelTextBox);
					RangedAttributePanel.Controls.Add(RangedDifficultyLabelTextBox);
					RangedAttributePanel.Controls.Add(RangedLengthLabelTextBox);
					RangedAttributePanel.Controls.Add(RangedAmmoLabelTextBox);
					RangedAttributePanel.Controls.Add(RangedAccuracyLabelTextBox);
					RangedAttributePanel.Controls.Add(RangedDamageLabelTextBox);
				}
				#endregion
				#region Horse
				{
					HorseAttributePanel = new Panel
					{
						Location = new Point(5, 15),
						Size = new Size(290, 230),
					};
					HorseHealthLabelTextBox = new LabelTextBox(60, 60, 20, "生命:")
					{
						Location = new Point(5, 20)
					};
					HorseProtectionLabelTextBox = new LabelTextBox(60, 60, 20, "防护:")
					{
						Location = new Point(5, 50)
					};
					HorseSprintLabelTextBox = new LabelTextBox(60, 60, 20, "冲锋:")
					{
						Location = new Point(5, 80)
					};
					HorseSizeLabelTextBox = new LabelTextBox(60, 60, 20, "尺寸:")
					{
						Location = new Point(5, 110)
					};
					HorseSpeedLabelTextBox = new LabelTextBox(60, 60, 20, "速度:")
					{
						Location = new Point(140, 20)
					};
					HorseControlLabelTextBox = new LabelTextBox(60, 60, 20, "操控:")
					{
						Location = new Point(140, 50)
					};
					HorseDifficultyLabelTextBox = new LabelTextBox(60, 60, 20, "难度:")
					{
						Location = new Point(140, 80)
					};
					HorseAttributePanel.Controls.Add(HorseHealthLabelTextBox);
					HorseAttributePanel.Controls.Add(HorseProtectionLabelTextBox);
					HorseAttributePanel.Controls.Add(HorseSprintLabelTextBox);
					HorseAttributePanel.Controls.Add(HorseSizeLabelTextBox);
					HorseAttributePanel.Controls.Add(HorseSpeedLabelTextBox);
					HorseAttributePanel.Controls.Add(HorseControlLabelTextBox);
					HorseAttributePanel.Controls.Add(HorseDifficultyLabelTextBox);
				}
				#endregion
				#region Ammo
				{
					AmmoAttributePanel = new Panel
					{
						Location = new Point(5, 15),
						Size = new Size(290, 230),
					};
					AmmoLengthLabelTextBox = new LabelTextBox(60, 140, 20, "长度:")
					{
						Location = new Point(5, 20)
					};
					AmmoWeightLabelTextBox = new LabelTextBox(60, 140, 20, "重量:")
					{
						Location = new Point(5, 50)
					};
					AmmoCountLabelTextBox = new LabelTextBox(60, 140, 20, "弹量:")
					{
						Location = new Point(5, 80)
					};
					AmmoDamageLabelTextBox = new DamageLabelTextBox(60, 140, "伤害:")
					{
						Location = new Point(5, 110)
					};
					AmmoAttributePanel.Controls.Add(AmmoLengthLabelTextBox);
					AmmoAttributePanel.Controls.Add(AmmoWeightLabelTextBox);
					AmmoAttributePanel.Controls.Add(AmmoCountLabelTextBox);
					AmmoAttributePanel.Controls.Add(AmmoDamageLabelTextBox);
				}
				#endregion
				#region Shield
				{
					ShieldAttributePanel = new Panel
					{
						Location = new Point(5, 15),
						Size = new Size(290, 230),
					};
					ShieldWeightLabelTextBox = new LabelTextBox(60, 60, 20, "重量:")
					{
						Location = new Point(5, 20)
					};
					ShieldStengthLabelTextBox = new LabelTextBox(60, 60, 20, "强度:")
					{
						Location = new Point(5, 50)
					};
					ShieldSpeedLabelTextBox = new LabelTextBox(60, 60, 20, "速度:")
					{
						Location = new Point(5, 80)
					};
					ShieldSizeLabelTextBox = new LabelTextBox(60, 60, 20, "尺寸:")
					{
						Location = new Point(140, 20)
					};
					ShieldDefenseLabelTextBox = new LabelTextBox(60, 60, 20, "抗击:")
					{
						Location = new Point(140, 50)
					};
					ShieldDifficultyLabelTextBox = new LabelTextBox(60, 60, 20, "难度:")
					{
						Location = new Point(140, 80)
					};
					ShieldAttributePanel.Controls.Add(ShieldWeightLabelTextBox);
					ShieldAttributePanel.Controls.Add(ShieldStengthLabelTextBox);
					ShieldAttributePanel.Controls.Add(ShieldSpeedLabelTextBox);
					ShieldAttributePanel.Controls.Add(ShieldSizeLabelTextBox);
					ShieldAttributePanel.Controls.Add(ShieldDefenseLabelTextBox);
					ShieldAttributePanel.Controls.Add(ShieldDifficultyLabelTextBox);
				}
				#endregion
				#region Armor
				{
					ArmorAttributePanel = new Panel
					{
						Location = new Point(5, 15),
						Size = new Size(290, 230),
					};
					ArmorWeightLabelTextBox = new LabelTextBox(60, 60, 20, "重量:")
					{
						Location = new Point(5, 20)
					};
					ArmorHeadLabelTextBox = new LabelTextBox(60, 60, 20, "头防:")
					{
						Location = new Point(5, 50)
					};
					ArmorLegLabelTextBox = new LabelTextBox(60, 60, 20, "腿防:")
					{
						Location = new Point(5, 80)
					};
					ArmorDifficultyLabelTextBox = new LabelTextBox(60, 60, 20, "难度:")
					{
						Location = new Point(140, 20)
					};
					ArmorBodyLabelTextBox = new LabelTextBox(60, 60, 20, "身防:")
					{
						Location = new Point(140, 50)
					};
					ArmorAttributePanel.Controls.Add(ArmorWeightLabelTextBox);
					ArmorAttributePanel.Controls.Add(ArmorHeadLabelTextBox);
					ArmorAttributePanel.Controls.Add(ArmorLegLabelTextBox);
					ArmorAttributePanel.Controls.Add(ArmorDifficultyLabelTextBox);
					ArmorAttributePanel.Controls.Add(ArmorBodyLabelTextBox);
				}
				#endregion
				#region Goods
				{
					GoodsAttributePanel = new Panel
					{
						Location = new Point(5, 15),
						Size = new Size(290, 230),
					};
					GoodsWeightLabelTextBox = new LabelTextBox(60, 120, 20, "重量:")
					{
						Location = new Point(5, 20)
					};
					GoodsNumberLabelTextBox = new LabelTextBox(60, 120, 20, "数量:")
					{
						Location = new Point(5, 50)
					};
					GoodsQuality = new LabelTextBox(80, 100, 20, "食物品质:")
					{
						Location = new Point(5, 80)
					};
					GoodsAttributePanel.Controls.Add(GoodsWeightLabelTextBox);
					GoodsAttributePanel.Controls.Add(GoodsNumberLabelTextBox);
					GoodsAttributePanel.Controls.Add(GoodsQuality);
				}
				#endregion
				ItemAttributeGroupBox = new GroupBox()
				{
					ForeColor = Color.White,
					Text = "物品属性",
					Location = new Point(265, 5),
					Size = new Size(300, 250)
				};
				Properties.Controls.Add(ItemAttributeGroupBox);
				OnItemTypeChange += p => UpdateAttribute();
			}
			#endregion


			Model = new TabPage("模型动作")
			{
				BackColor = Color.FromArgb(30, 30, 36)
			};
			#region 模型
			{
				GroupBox ModelGroupBox = new GroupBox()
				{
					ForeColor = Color.White,
					Text = "模型",
					Location = new Point(5, 5),
					Size = new Size(270, 540)
				};

				ModelsListBox = new MListBox()
				{
					Location = new Point(5, 15),
					Size = new Size(260, 100),
				};
				ModelsListBox.SelectedIndexChanged += ModelsListBox_SelectedIndexChanged;
				Button ModelAdd = new Button()
				{
					Text = "添加",
					BackColor = Color.FromArgb(120, 120, 120),
					Location = new Point(180, 106),
					FlatStyle = FlatStyle.Flat,
					Size = new Size(40, 25)
				};
				Button ModelDelete = new Button()
				{
					Text = "删除",
					BackColor = Color.FromArgb(120, 120, 120),
					Location = new Point(225, 106),
					FlatStyle = FlatStyle.Flat,
					Size = new Size(40, 25)
				};
				ModelName = new LabelTextBox(40, 200, 20, "名称:")
				{
					Location = new Point(10, 135)
				};
				Label labelTip = new Label()
				{
					Text = "位置:",
					Location = new Point(15, 162),
					Size = new Size(40, 20)
				};
				ModelLocation = new ComboBox()
				{
					Location = new Point(55, 160),
					Size = new Size(200, 20),
					DropDownStyle = ComboBoxStyle.DropDownList
				};
				ModelLocation.Items.Add("主位置");
				ModelLocation.Items.Add("物品栏模型");
				ModelLocation.Items.Add("飞行模型");
				ModelLocation.Items.Add("携带模型");

				GroupBox ModelPrefixGroupBox = new GroupBox()
				{
					ForeColor = Color.White,
					Text = "前缀",
					Location = new Point(5, 195),
					Size = new Size(260, 205)
				};
				ModelPrefixListBox = new CheckedListBox()
				{
					Location = new Point(5, 15),
					Size = new Size(250, 190),
					BackColor = Color.FromArgb(30, 30, 36),
					BorderStyle = BorderStyle.None,
					MultiColumn = false,
					ForeColor = Color.White
				};
				foreach (var prefix in Item.ItemModifiers)
				{
					ModelPrefixListBox.Items.Add(prefix);
				}
				ModelPrefixGroupBox.Controls.Add(ModelPrefixListBox);
				ModelGroupBox.Controls.Add(ModelPrefixGroupBox);

				ItemBindGroupBox = new GroupBox()
				{
					ForeColor = Color.White,
					Text = "装备绑定",
					Location = new Point(5, 410),
					Size = new Size(260, 120)
				};
				ItemBindGroupBox.Controls.Add(new RadioButton() { Text = "无", Location = new Point(20, 15), Size = new Size(50, 20) });
				ItemBindGroupBox.Controls.Add(new RadioButton() { Text = "强制绑定到左手", Location = new Point(20, 35), Size = new Size(200, 20) });
				ItemBindGroupBox.Controls.Add(new RadioButton() { Text = "强制绑定到右手", Location = new Point(20, 55), Size = new Size(200, 20) });
				ItemBindGroupBox.Controls.Add(new RadioButton() { Text = "强制绑定到左前臂", Location = new Point(20, 75), Size = new Size(200, 20) });
				ItemBindGroupBox.Controls.Add(new RadioButton() { Text = "强制绑定到盔甲", Location = new Point(20, 95), Size = new Size(200, 20) });

				ModelGroupBox.Controls.Add(ItemBindGroupBox);

				ModelGroupBox.Controls.Add(ModelsListBox);
				ModelGroupBox.Controls.Add(ModelAdd);
				ModelGroupBox.Controls.Add(ModelDelete);
				ModelGroupBox.Controls.Add(ModelName);
				ModelGroupBox.Controls.Add(labelTip);
				ModelGroupBox.Controls.Add(ModelLocation);
				Model.Controls.Add(ModelGroupBox);


				OnItemTypeChange += p => 
				{
					if (ItemPage.SelectedItem.IsWeapon || ItemPage.SelectedItem.IsShield)
					{
						ItemBindGroupBox.Controls[0].Enabled = true;
						for (int i = 1; i < 4; i++)
							ItemBindGroupBox.Controls[i].Enabled = true;
						ItemBindGroupBox.Controls[4].Enabled = false;
					}
					else if (ItemPage.SelectedItem.IsArmor)
					{
						ItemBindGroupBox.Controls[0].Enabled = true;
						for (int i = 1; i < 4; i++)
							ItemBindGroupBox.Controls[i].Enabled = false;
						ItemBindGroupBox.Controls[4].Enabled = true;
					}
					else
					{
						for (int i = 0; i < 5; i++)
							ItemBindGroupBox.Controls[i].Enabled = false;
					}
					var a = (int)((ItemPage.SelectedItem.Properties & 0xF00) >> 8);
					if (a > 0 && a < 4)
						(ItemBindGroupBox.Controls[a] as RadioButton).Checked = true;
					else if (a == 0xF)
						(ItemBindGroupBox.Controls[4] as RadioButton).Checked = true;
					else
						(ItemBindGroupBox.Controls[0] as RadioButton).Checked = true;
				};
			}
			#endregion

			Triggers = new TabPage("触发器")
			{
				BackColor = Color.FromArgb(30, 30, 36)
			};
			Controls.Add(BasicProperties);
			Controls.Add(Properties);
			Controls.Add(Model);
			Controls.Add(Triggers);
		}

		private void ModelsListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			ModelName.Content.Text = ModelsListBox.SelectedItems[0].ToString();
			var Mesh = ItemPage.SelectedItem.Meshes[ModelsListBox.SelectedIndex];
			ModelLocation.SelectedIndex = (int)((Mesh.Value) >> 60);//
			for (int i = 0; i < Item.ItemModifiers.Length; i++)
			{
				long l = 1;
				l <<= i;
				ModelPrefixListBox.SetItemChecked(i, (Mesh.Value & l) == l);
			}
			
		}

		private void UpdateModels()
		{
			ModelsListBox.Items.Clear();
			foreach (var m in ItemPage.SelectedItem.Meshes)
			{
				ModelsListBox.Items.Add(m.Key);
			}
			ModelsListBox.SetSelected(0, true);
		}

		/// <summary>
		/// 更新阵营列表
		/// </summary>
		private void UpdateFactions()
		{
			FactionCheckedListBox.Items.Clear();
			foreach (var faction in MainForm.Module.F_Factions.Factions)
				FactionCheckedListBox.Items.Add(faction.Name);
		}



		public void UpdateItem()
		{
			var item = ItemPage.SelectedItem;
			ItemIndex.Content.Text = item.Index;
			ItemNameEn.Content.Text = item.NameEn;
			ItemName.Content.Text = item.Name;
			ItemNamePl.Content.Text = item.NamePL;
			(ItemTypeGroupBox.Controls[(int)item.ItemType] as RadioButton).Checked = true;
			NextItemAsMelee.Enabled = item.NextItemAsMeleeEnabled;
			NextItemAsMelee.Checked = item.NextItemAsMelee;
			Price.Content.Text = item.Price.ToString();
			Abundance.Content.Text = item.Abundance.ToString();

			UpdateFactionsCheckState();
			UpdatePrefix();
			UpdateModels();
		}

		public void UpdateAttribute()
		{
			var item = ItemPage.SelectedItem;
			switch (item.ItemType)
			{
				case ItemProperties.itp_type_horse:
					ItemAttributeGroupBox.Controls.Clear();
					ItemAttributeGroupBox.Controls.Add(HorseAttributePanel);
					HorseHealthLabelTextBox.Content.Text = item.Hit_Points.ToString();
					HorseProtectionLabelTextBox.Content.Text = item.Body_Armor.ToString();
					HorseSprintLabelTextBox.Content.Text = item.Thrust_Damage.ToString();
					HorseSizeLabelTextBox.Content.Text = item.Weapon_Length.ToString();
					HorseSpeedLabelTextBox.Content.Text = item.Missile_Speed.ToString();
					HorseControlLabelTextBox.Content.Text = item.Speed_Rating.ToString();
					HorseDifficultyLabelTextBox.Content.Text = item.Difficulty.ToString();
					break;
				case ItemProperties.itp_type_one_handed_wpn:
				case ItemProperties.itp_type_two_handed_wpn:
				case ItemProperties.itp_type_polearm:
					ItemAttributeGroupBox.Controls.Clear();
					ItemAttributeGroupBox.Controls.Add(MeleeAttributePanel);
					MeleeWeightLabelTextBox.Content.Text = item.Weight.ToString();
					MeleeDifficultyLabelTextBox.Content.Text = item.Difficulty.ToString();
					MeleeLengthLabelTextBox.Content.Text = item.Weapon_Length.ToString();
					MeleeSpeedLabelTextBox.Content.Text = item.Speed_Rating.ToString();
					MeleeSwingDamageLabelTextBox.Content.Text = (item.Swing_Damage & 0xFF).ToString();
					MeleeThrustDamageLabelTextBox.Content.Text = (item.Thrust_Damage & 0xFF).ToString();
					MeleeSwingDamageLabelTextBox.DamageType = (ItemDamageType)(item.Swing_Damage & 0xF00);
					MeleeThrustDamageLabelTextBox.DamageType = (ItemDamageType)(item.Thrust_Damage & 0xF00);
					break;
				case ItemProperties.itp_type_bullets:
				case ItemProperties.itp_type_arrows:
				case ItemProperties.itp_type_bolts:
					ItemAttributeGroupBox.Controls.Clear();
					ItemAttributeGroupBox.Controls.Add(AmmoAttributePanel);
					AmmoLengthLabelTextBox.Content.Text = item.Weapon_Length.ToString();
					AmmoWeightLabelTextBox.Content.Text = item.Weight.ToString();
					AmmoCountLabelTextBox.Content.Text = item.Max_Ammo.ToString();
					AmmoDamageLabelTextBox.Content.Text = (item.Thrust_Damage & 0xFF).ToString();
					AmmoDamageLabelTextBox.DamageType = (ItemDamageType)(item.Thrust_Damage & 0xF00);
					break;
				case ItemProperties.itp_type_shield:
					ItemAttributeGroupBox.Controls.Clear();
					ItemAttributeGroupBox.Controls.Add(ShieldAttributePanel);
					ShieldWeightLabelTextBox.Content.Text = item.Weight.ToString();
					ShieldStengthLabelTextBox.Content.Text = item.Hit_Points.ToString();
					ShieldSpeedLabelTextBox.Content.Text = item.Speed_Rating.ToString();
					ShieldSizeLabelTextBox.Content.Text = item.Weapon_Length.ToString();
					ShieldDefenseLabelTextBox.Content.Text = item.Body_Armor.ToString();
					ShieldDifficultyLabelTextBox.Content.Text = item.Difficulty.ToString();
					break;
				case ItemProperties.itp_type_pistol:
				case ItemProperties.itp_type_musket:
				case ItemProperties.itp_type_bow:
				case ItemProperties.itp_type_crossbow:
				case ItemProperties.itp_type_thrown:
					ItemAttributeGroupBox.Controls.Clear();
					ItemAttributeGroupBox.Controls.Add(RangedAttributePanel);
					RangedWeightLabelTextBox.Content.Text = item.Weight.ToString();
					RangedSpeedLabelTextBox.Content.Text = item.Speed_Rating.ToString();
					RangedMissileSpeedLabelTextBox.Content.Text = item.Missile_Speed.ToString();
					RangedDifficultyLabelTextBox.Content.Text = item.Difficulty.ToString();
					RangedLengthLabelTextBox.Content.Text = item.Weapon_Length.ToString();
					RangedAmmoLabelTextBox.Content.Text = item.Max_Ammo.ToString();
					RangedAccuracyLabelTextBox.Content.Text = item.Leg_Armor.ToString();
					RangedDamageLabelTextBox.Content.Text = (item.Thrust_Damage & 0xFF).ToString();
					RangedDamageLabelTextBox.DamageType = (ItemDamageType)(item.Thrust_Damage & 0xF00);
					break;
				case ItemProperties.itp_type_goods:
					ItemAttributeGroupBox.Controls.Clear();
					ItemAttributeGroupBox.Controls.Add(GoodsAttributePanel);
					GoodsWeightLabelTextBox.Content.Text = item.Weight.ToString();
					GoodsNumberLabelTextBox.Content.Text = item.Max_Ammo.ToString();
					GoodsQuality.Enabled = true;
					GoodsQuality.Content.Text = item.Head_Armor.ToString();
					break;
				case ItemProperties.itp_type_animal:
				case ItemProperties.itp_type_book:
					ItemAttributeGroupBox.Controls.Clear();
					ItemAttributeGroupBox.Controls.Add(GoodsAttributePanel);
					GoodsWeightLabelTextBox.Content.Text = item.Weight.ToString();
					GoodsNumberLabelTextBox.Content.Text = item.Max_Ammo.ToString();
					GoodsQuality.Enabled = false;
					break;
				case ItemProperties.itp_type_head_armor:
				case ItemProperties.itp_type_body_armor:
				case ItemProperties.itp_type_foot_armor:
				case ItemProperties.itp_type_hand_armor:
					ItemAttributeGroupBox.Controls.Clear();
					ItemAttributeGroupBox.Controls.Add(ArmorAttributePanel);
					ArmorWeightLabelTextBox.Content.Text = item.Weight.ToString();
					ArmorHeadLabelTextBox.Content.Text = item.Head_Armor.ToString();
					ArmorLegLabelTextBox.Content.Text = item.Leg_Armor.ToString();
					ArmorDifficultyLabelTextBox.Content.Text = item.Difficulty.ToString();
					ArmorBodyLabelTextBox.Content.Text = item.Body_Armor.ToString();
					break;
				default:
					break;
			}
		}

		public void UpdatePrefix()
		{
			for (int i = 0; i < Item.ItemModifiers.Length; i++)
			{
				long l = 1;
				l <<= i;
				PrefixCheckedListBox.SetItemChecked(i, (ItemPage.SelectedItem.Modifiers & l) == l);
			}
		}
		public void SetPrefix(List<ItemModifiersBit> e)
		{
			for (int i = 0; i < PrefixCheckedListBox.Items.Count; i++)
				PrefixCheckedListBox.SetItemChecked(i, false);
			foreach (var imod in e)
				PrefixCheckedListBox.SetItemChecked((int)imod, true);
		}

		public void UpdateFactionsCheckState()
		{
			var item = ItemPage.SelectedItem;
			for (int i = 0; i < MainForm.Module.F_Factions.Factions.Count; i++)
			{
				var a = (item.Factions.Contains(MainForm.Module.F_Factions.Factions[i]));
				FactionCheckedListBox.SetItemChecked(i, a);
			}
		}
	}
}

using ModuleUnserializer.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModuleEditor.Controls
{
	public class DamageLabelTextBox : LabelTextBox
	{
		public ItemDamageType DamageType
		{
			get
			{
				if (CutRadioButton.Checked)
					return ItemDamageType.Cut;
				else if (PierceRadioButton.Checked)
					return ItemDamageType.Pierce;
				else
					return ItemDamageType.Blunt;
			}
			set
			{
				switch (value)
				{
					case ItemDamageType.Cut:
						CutRadioButton.Checked = true;
						break;
					case ItemDamageType.Pierce:
						PierceRadioButton.Checked = true;
						break;
					case ItemDamageType.Blunt:
						BluntRadioButton.Checked = true;
						break;
					default:
						break;
				}
			}
		}
		private RadioButton CutRadioButton, PierceRadioButton, BluntRadioButton;
		public DamageLabelTextBox(int labelWidth, int textBoxWidth, string tip) : base(labelWidth, textBoxWidth, 45, tip)
		{
			Width = labelWidth + textBoxWidth + 5 + 70;
			CutRadioButton = new RadioButton()
			{
				Text = "砍伤",
				Location = new Point(labelWidth + textBoxWidth + 15, 0),
				Size = new Size(50, 16)
			};
			PierceRadioButton = new RadioButton()
			{
				Text = "刺伤",
				Location = new Point(labelWidth + textBoxWidth + 15, 15),
				Size = new Size(50, 16)
			};
			BluntRadioButton = new RadioButton()
			{
				Text = "钝伤",
				Location = new Point(labelWidth + textBoxWidth + 15, 30),
				Size = new Size(50, 16)
			};


			Controls.Add(CutRadioButton);
			Controls.Add(PierceRadioButton);
			Controls.Add(BluntRadioButton);
		}

	}
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModuleEditor.Controls
{
	public class LabelTextBox : UserControl
	{
		public TextBox Content;
		public Label Tip;
		public LabelTextBox(int labelWidth, int textBoxWidth, int height, string tip)
		{
			Tip = new Label()
			{
				Size = new Size(labelWidth, height),
				Location = new Point(0, 1),
				Text = tip,
				TextAlign = ContentAlignment.MiddleRight,
			};
			Content = new TextBox()
			{
				//Size = new Size(textBoxWidth, height),
				Width = textBoxWidth,
				Location = new Point(labelWidth + 5, 1 + height / 2 - 10),
				BorderStyle = BorderStyle.FixedSingle,
				ForeColor = Color.White
			};
			Size = new Size(labelWidth + 5 + textBoxWidth, height + 2);
			Controls.Add(Content);
			Controls.Add(Tip);
		}
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			Content.BackColor = BackColor;
		}
	}
}

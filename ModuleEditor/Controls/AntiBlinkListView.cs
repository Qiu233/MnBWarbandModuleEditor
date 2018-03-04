using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModuleEditor
{
	public class AntiBlinkListView : ListView
	{
		public AntiBlinkListView()
		{
			SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.EnableNotifyMessage, true);
			UpdateStyles();
			OwnerDraw = true;
		}
		protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
		{
			e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(60, 60, 60)), e.Bounds);
			var b = e.Bounds;
			b.X -= 2;
			b.Y -= 2;
			b.Height += 4;
			e.Graphics.DrawRectangle(Pens.Gray, b);
			e.Graphics.DrawString(e.Header.Text, e.Font, Brushes.LightGray, e.Bounds.X + 10, e.Bounds.Y + 5);
		}
		protected override void OnDrawSubItem(DrawListViewSubItemEventArgs e)
		{
			if (e.Item.Selected)
				e.Graphics.FillRectangle(Brushes.Gray, e.Bounds);
			else
				e.Graphics.FillRectangle(Brushes.Transparent, e.Bounds);
			var b = e.Bounds;
			b.Y += 2;
			e.Graphics.DrawString(e.SubItem.Text, e.Item.Font, Brushes.LightGray, b);
		}
		protected override void OnNotifyMessage(Message m)
		{
			if (m.Msg != 0x14)
			{
				base.OnNotifyMessage(m);
			}
		}
	}
}

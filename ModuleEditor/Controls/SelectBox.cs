using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModuleEditor.Controls
{
	public class SelectBox : UserControl
	{
		public Label LabelTextSearch, LabelTextCount;
		public TextBox KeyTextBox;
		public AntiBlinkListView ListView;
		public Button ButtonSearchNext, ButtonSearchUp, ButtonMoveUp, ButtonMoveDown, ButtonCreate, ButtonDelete;
		private Dictionary<string, float> Columns;
		public SelectBox(Dictionary<string, float> columns)
		{
			BorderStyle = BorderStyle.None;
			BackColor = Color.FromArgb(80, 80, 80);
			Columns = columns;
			LabelTextSearch = new Label
			{
				Text = "搜索:",
				TextAlign = ContentAlignment.MiddleLeft,
				Width = 40
			};
			LabelTextCount = new Label
			{
				TextAlign = ContentAlignment.MiddleLeft,
				Width = 100
			};
			KeyTextBox = new TextBox()
			{
				BackColor = Color.FromArgb(70, 70, 70),
				BorderStyle = BorderStyle.FixedSingle,
				ForeColor = Color.White
			};
			ButtonSearchNext = new Button()
			{
				Text = "↓",
				BackColor = Color.FromArgb(120, 120, 120),
				FlatStyle = FlatStyle.Flat,
				Size = new Size(20, 20)
			};
			ButtonSearchNext.Click += (s, e) =>
			{
				string str = KeyTextBox.Text;
				int j = 0;
				if (ListView.SelectedIndices.Count > 0)
					j = ListView.SelectedIndices[0] + 1;
				for (int i = j; i < ListView.Items.Count; i++)
				{
					string str1 = "";
					foreach (var it in ListView.Items[i].SubItems)
						str1 += it.ToString();
					if (str1.ToLower().Contains(str.ToLower()))
					{
						ListView.Items[i].Selected = true;
						break;
					}
				}
			};
			ButtonSearchUp = new Button()
			{
				Text = "↑",
				BackColor = Color.FromArgb(120, 120, 120),
				FlatStyle = FlatStyle.Flat,
				Size = new Size(20, 20)
			};
			ButtonSearchUp.Click += (s, e) =>
			{
				string str = KeyTextBox.Text;
				int j = 0;
				if (ListView.SelectedIndices.Count > 0)
					j = ListView.SelectedIndices[0] - 1;
				for (int i = j; i >= 0; i--)
				{
					string str1 = "";
					foreach (var it in ListView.Items[i].SubItems)
						str1 += it.ToString();
					if (str1.ToLower().Contains(str.ToLower()))
					{
						ListView.Items[i].Selected = true;
						break;
					}
				}
			};
			ListView = new AntiBlinkListView()
			{
				BackColor = Color.FromArgb(70, 70, 70),
				MultiSelect = false,
				FullRowSelect = true,
			};
			ButtonMoveUp = new Button()
			{
				Text = "上移",
				BackColor = Color.FromArgb(120, 120, 120),
				FlatStyle = FlatStyle.Flat,
				Size = new Size(60, 25)
			};
			ButtonMoveDown = new Button()
			{
				Text = "下移",
				BackColor = Color.FromArgb(120, 120, 120),
				FlatStyle = FlatStyle.Flat,
				Size = new Size(60, 25)
			};
			ButtonCreate = new Button()
			{
				Text = "新建",
				BackColor = Color.FromArgb(120, 120, 120),
				FlatStyle = FlatStyle.Flat,
				Size = new Size(60, 25)
			};
			ButtonDelete = new Button()
			{
				Text = "删除",
				BackColor = Color.FromArgb(120, 120, 120),
				FlatStyle = FlatStyle.Flat,
				Size = new Size(60, 25)
			};
		}
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			Controls.Add(LabelTextSearch);
			Controls.Add(LabelTextCount);
			Controls.Add(KeyTextBox);
			Controls.Add(ButtonSearchNext);
			Controls.Add(ButtonSearchUp);
			Controls.Add(ListView);
			Controls.Add(ButtonMoveUp);
			Controls.Add(ButtonMoveDown);
			Controls.Add(ButtonCreate);
			Controls.Add(ButtonDelete);
		}
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			LabelTextSearch.Location = new Point(5, 5);
			KeyTextBox.Location = new Point(LabelTextSearch.Width + 5, 5);
			KeyTextBox.Size = new Size(Width - LabelTextSearch.Width - 60, 0);
			ButtonSearchNext.Location = new Point(350, 5);
			ButtonSearchUp.Location = new Point(375, 5);
			ListView.Location = new Point(5, LabelTextSearch.Location.Y + LabelTextSearch.Height);
			ListView.Size = new Size(Width - 10, Height - 65);
			ListView.View = View.Details;
			ListView.BeginUpdate();
			foreach (var column in Columns)
			{
				ListView.Columns.Add(column.Key, (int)((float)ListView.Width * column.Value));
			}
			ListView.EndUpdate();
			LabelTextCount.Location = new Point(5, ListView.Location.Y + ListView.Height + 5);

			ButtonMoveUp.Location = new Point(LabelTextCount.Location.X + LabelTextCount.Width + 20, LabelTextCount.Location.Y);
			ButtonMoveDown.Location = new Point(LabelTextCount.Location.X + LabelTextCount.Width + 25 + 60, LabelTextCount.Location.Y);
			ButtonCreate.Location = new Point(LabelTextCount.Location.X + LabelTextCount.Width + 30 + 120, LabelTextCount.Location.Y);
			ButtonDelete.Location = new Point(LabelTextCount.Location.X + LabelTextCount.Width + 35 + 180, LabelTextCount.Location.Y);
		}
	}
}

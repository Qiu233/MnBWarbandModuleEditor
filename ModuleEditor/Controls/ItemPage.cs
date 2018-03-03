using ModuleEditor.Files;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModuleEditor.Controls
{
	public class ItemPage : TabPage
	{
		public SelectBox ItemSelectBox;
		public ItemPropertiesTabControl PropertiesTabControl;
		public event Action OnUpdate = () => { };
		public Entities.Item SelectedItem
		{
			get;
			private set;
		}
		public ItemPage()
		{
			BackColor = Color.FromArgb(30, 30, 36);
			Text = "物品";
			ItemSelectBox = new SelectBox(columns: new Dictionary<string, float> { { "序号", 0.2f }, { "物品名称", 0.5f }, { "物品ID", 0.5f } })
			{
				Location = new Point(5, 5),
				Size = new Size(400, 637),
			};
			ItemSelectBox.ListView.ItemSelectionChanged += ListView_ItemSelectionChanged;
			MainForm.OnKeyDataChanged += () => { OnUpdate(); SetSelectedItem(); };
			UpdateItems();
			Controls.Add(ItemSelectBox);

			PropertiesTabControl = new ItemPropertiesTabControl(this)
			{
				Location = new Point(406, 5),
				Size = new Size(584, 600)
			};

			Controls.Add(PropertiesTabControl);
		}
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			ItemSelectBox.ListView.Items[0].Selected = true;
		}

		private void ListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			if (ItemSelectBox.ListView.SelectedIndices.Count > 0)
				SetSelectedItem();
		}
		private void SetSelectedItem()
		{
			SelectedItem = (Entities.Item)MainForm.Module.F_Items.Items[ItemSelectBox.ListView.SelectedIndices[0]].Clone();
			PropertiesTabControl.UpdateItem();
		}

		public void UpdateItems()
		{
			ItemSelectBox.ListView.Items.Clear();
			int m = 0;
			foreach (var item in MainForm.Module.F_Items.Items)
				ItemSelectBox.ListView.Items.Add(new ListViewItem(new string[] { (m++).ToString(), item.Name, item.Index }));
			ItemSelectBox.LabelTextCount.Text = "物品数:" + MainForm.Module.F_Items.Items.Count;
		}
	}
}

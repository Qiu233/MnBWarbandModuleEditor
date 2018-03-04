using ModuleEditor.Controls;
using ModuleUnserializer.Files;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModuleEditor
{
	public partial class MainForm : Form
	{
		private class MenuColorTable : ProfessionalColorTable
		{
			public override Color MenuItemSelected => sColor;
			public override Color MenuBorder => sColor;
			public override Color MenuItemSelectedGradientBegin => sColor;
			public override Color MenuItemSelectedGradientEnd => sColor;

			public override Color MenuItemPressedGradientBegin => sBlackColor;
			public override Color MenuItemPressedGradientMiddle => sBlackColor;
			public override Color MenuItemPressedGradientEnd => sBlackColor;

			public override Color ToolStripDropDownBackground => sBlackColor;
			public override Color MenuItemBorder => sColor;
		}
		private class MenuStripRender : ToolStripProfessionalRenderer
		{
			public MenuStripRender() : base(new MenuColorTable())
			{

			}
			protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
			{
			}
			protected override void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
			{
				e.Graphics.DrawImage(e.Image, e.ImageRectangle.X + 6, e.ImageRectangle.Y);
			}
		}
		public static Color sColor = Color.FromArgb(62, 62, 64);
		public static Color sBlackColor = Color.FromArgb(27, 27, 28);

		private MTabControl mainTabControl;
		private TabPage Page_Item;
		private TabPage Page_Troop;
		private MenuStrip cms;

		public static string INIFile = "./MnBEditor.ini";
		public static string MnBPath;
		public static string ModuleName;
		public static string LanguageName;
		public static ModuleInfo Module;

		/// <summary>
		/// 这个事件在主选项卡换页时或者界面初始化时被调用，通过给事件挂钩以便在某些关键数据更新之后可以被及时发现和处理，例如阵营数量，物品类型
		/// </summary>
		public static event Action OnKeyDataChanged = () => { };

		public MainForm()
		{
			if (new StartForm().ShowDialog(this) != DialogResult.OK)
				Environment.Exit(0);
			Module = new ModuleInfo(MnBPath, ModuleName, LanguageName);
			/*foreach (var t in F_SimpleTriggers.SimpleTriggers)
			{
				System.Diagnostics.Debug.WriteLine(t.Interval);
				foreach (var s in t.Block.Statements)
				{
					System.Diagnostics.Debug.WriteLine("\t" + s.Opcode);
				}
			}*/

			InitializeComponent();

			cms = new MenuStrip()
			{
				BackColor = Color.FromArgb(37, 37, 38),
				ForeColor = Color.White,
				RenderMode = ToolStripRenderMode.System,
				Renderer = new MenuStripRender()
			};
			ToolStripMenuItem FileMenuItem = new ToolStripMenuItem("文件")
			{
				ForeColor = Color.White,
			};
			AddMenuItem(FileMenuItem, "保存Module", null);
			AddMenuItem(FileMenuItem, "退出", null, (s, e) => Environment.Exit(0));
			cms.Items.Add(FileMenuItem);
			Controls.Add(cms);

			Panel tabPanel = new Panel()
			{
				Location = new Point(0, cms.Height),
				Size = new Size(ClientSize.Width, ClientSize.Height - cms.Height)
			};

			mainTabControl = new MTabControl()
			{
				Location = new Point(0, 0),
				Dock = DockStyle.Fill,
			};
			mainTabControl.SelectedIndexChanged += MainTabControl_SelectedIndexChanged;
			Page_Item = new ItemPage();

			mainTabControl.Controls.Add(Page_Item);

			Page_Troop = new TabPage("兵种")
			{
				BackColor = Color.FromArgb(30, 30, 36),
			};
			mainTabControl.Controls.Add(Page_Troop);

			tabPanel.Controls.Add(mainTabControl);
			Controls.Add(tabPanel);
			
		}
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			OnKeyDataChanged();
		}
		private void MainTabControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			OnKeyDataChanged();
		}

		private static void AddMenuItem(ToolStripMenuItem menu, string text, Image image, Action<object, EventArgs> click = null)
		{
			var item = new ToolStripMenuItem(text, image)
			{
				BackColor = sBlackColor,
				ForeColor = Color.White
			};
			if (click != null)
				item.Click += new EventHandler(click);
			menu.DropDownItems.Add(item);
		}
	}
}

using ModuleEditor.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModuleEditor
{
	public class StartForm : Form
	{
		private MListBox moduleBox;
		private TextBox languageBox;
		public StartForm()
		{
			StartPosition = FormStartPosition.CenterScreen;
			ClientSize = new Size(400, 135);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			Text = "选择要编辑的剧本";
			BackColor = Color.FromArgb(80, 80, 80);
			ControlBox = false;
			moduleBox = new MListBox()
			{
				Size = new Size(400, 105),
			};
			Label languageLabel = new Label()
			{
				Text = "语言:",
				Location = new Point(5, 110),
				Size = new Size(40, 20),
				TextAlign = ContentAlignment.MiddleCenter
			};
			languageBox = new TextBox()
			{
				BorderStyle = BorderStyle.FixedSingle,
				Location = new Point(50, 110),
				BackColor = BackColor,
				Width = 250
			};
			Button OK = new Button()
			{
				Text = "确定",
				BackColor = Color.FromArgb(120, 120, 120),
				Location = new Point(320, 105),
				FlatStyle = FlatStyle.Flat,
				Size = new Size(80, 30)
			};
			OK.Click += (s, e) =>
			{
				if (moduleBox.SelectedIndex != -1)
				{
					if (!Directory.Exists(MainForm.MnBPath + "\\languages\\" + languageBox.Text))
					{
						MessageBox.Show("该语言文件夹未找到，请核对后输入");
					}
					else
					{
						MainForm.ModuleName = (string)moduleBox.Items[moduleBox.SelectedIndex];
						MainForm.LanguageName = languageBox.Text;
						DialogResult = DialogResult.OK;
						INI.WriteIniKeys("MnB", "Module", moduleBox.SelectedItem.ToString(), MainForm.INIFile);
						INI.WriteIniKeys("MnB", "Language", languageBox.Text, MainForm.INIFile);
						Dispose();
					}
				}
			};
			Controls.Add(moduleBox);
			Controls.Add(languageLabel);
			Controls.Add(languageBox);
			Controls.Add(OK);
		}
		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			if ((MainForm.MnBPath = INI.ReadIniKeys("MnB", "Path", MainForm.INIFile)) == "")
			{
				do
				{
					MessageBox.Show(this, "请选择正确的MnB Warband安装文件夹", "骑砍:战团剧本编辑器");
					FolderBrowserDialog fb = new FolderBrowserDialog
					{
						ShowNewFolderButton = false,
					};
					if (fb.ShowDialog() == DialogResult.Cancel)
						Environment.Exit(0);
					MainForm.MnBPath = fb.SelectedPath;
					INI.WriteIniKeys("MnB", "Path", fb.SelectedPath, MainForm.INIFile);
				} while (!Directory.Exists(MainForm.MnBPath + "\\Modules\\"));
			}
			foreach (var f in Directory.EnumerateDirectories(MainForm.MnBPath + "\\Modules\\"))
				moduleBox.Items.Add(Path.GetFileName(f));
			string iniValue = "";
			if ((iniValue = INI.ReadIniKeys("MnB", "Module", MainForm.INIFile)) != "")
				if (moduleBox.Items.Contains(iniValue))
					moduleBox.SelectedIndex = moduleBox.Items.IndexOf(iniValue);

			if ((iniValue = INI.ReadIniKeys("MnB", "Language", MainForm.INIFile)) != "")
				languageBox.Text = iniValue;
		}
	}
}

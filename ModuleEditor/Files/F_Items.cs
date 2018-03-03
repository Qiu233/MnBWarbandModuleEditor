using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Numerics;
using ModuleEditor.Entities;

namespace ModuleEditor.Files
{
	/// <summary>
	/// 骑砍中保存一个物品的属性采用以下结构：
	/// item_id item_name item_name_pl attributes...
	/// number_of_factions
	/// [list_of_factions]
	/// number_of_simple_triggers
	/// [list_of_simple_trigger\n]+
	/// 带中括号的项非必选，即可能不存在
	/// 而具体是否存在取决于上一项
	/// 当上一项的值大于0时，可选项便存在，反之不存在
	/// 
	/// factions指出物品的势力，具体意义暂时未知，可能是所属势力?
	/// simple_trigger指出物品的简单触发器
	/// 例如使用ti_on_init_item(值为-50.00)的触发器
	/// 在物品被加载时就可以执行一段代码
	/// 在header_triggers.py中有所有约定好的触发器
	/// 但并不是所有的触发器都可以在物品中使用
	/// 而这样做会引发什么暂时还不清楚
	/// </summary>

	public class F_Items
	{
		public ModuleInfo Module;
		public List<Item> Items;
		private F_Items()
		{

		}
		public static F_Items LoadFromFile(ModuleInfo minfo, string MnBPath, string module)
		{
			F_Items obj = new F_Items();
			obj.Module = minfo;
			StreamReader reader = new StreamReader(File.Open(MnBPath + "\\modules\\" + module + "\\item_kinds1.txt", FileMode.Open));
			obj.FromStream(reader);

			reader.Close();
			return obj;
		}
		private void Handler_Trigger(string[] trigger)
		{

		}
		private void FromStream(StreamReader reader)
		{
			if (reader.ReadLine() != "itemsfile version 3")
				throw new Exception("可能不支持当前mod或该mod已损坏");
			Items = new List<Item>(Convert.ToInt32(reader.ReadLine()));
			string[] s = reader.ReadToEnd().Split(new string[] { " ", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
			int j = 0;
			for (int i = 0; i < Items.Capacity; i++)
			{
				var item = Item.FromString(Module, s, ref j);
				Items.Add(item);
				if (i >= 1)
					Items[i - 1].NextItemAsMeleeEnabled = Items[i - 1].IsWeapon && Items[i].IsWeapon;
			}
		}
	}
}

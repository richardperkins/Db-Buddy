using System;
using System.Data;
using System.Collections.Generic;
using SqliteTest;

using namespace DbBuddy
{
	public class ItemLoader : Database
	{
		public ItemLoader (string path) : base (path)
		{

		}

		public Item GetItemById(int id)
		{
			Dictionary<string, object> keys = new Dictionary<string, object>();
			keys["id"] = id;
			string sql = "select name, description, price, stack_max from items where id=?";

			DataTable data = Execute(sql, keys);


			return new Item(
				data.Rows[0]["name"].ToString(),
				data.Rows[0]["description"].ToString(),
				(long)data.Rows[0]["price"],
				(long)data.Rows[0]["stack_max"]
			);
		}

	}
}

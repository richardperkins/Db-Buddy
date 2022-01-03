using System;
using System.Data;
using System.Reflection;
using System.Collections.Generic;

namespace DbBuddy
{
	public class ItemLoader : DbBuddy<ItemData>
	{
		string sql;
		
		Dictionary<string, object> args;

		public ItemLoader (string path) : base (path)
		{
			sql = "";
			args = new Dictionary<string, object>();
		}

		
		public Item GetItemById(int id)
		{
			// Create SQL statement
			sql = "select name, description, price, stack_max from items where id=?";
			// Bind arguments to statement
			args.Clear();
			args["id"] = id;

			DataTable data = Execute(sql, args);


			return new Item(
				data.Rows[0]["name"].ToString(),
				data.Rows[0]["description"].ToString()
			);
		}

		/// <summary>Load all items from table "items"</summary>
		/// <returns>List of items</return>
		public List<Item> GetAllItems()
		{
			sql = "SELECT * FROM items;";
			args.Clear();

			DataTable itemData = Execute(sql, args);

			List<Item> items = new List<Item>();

			foreach (DataRow row in itemData.Rows)
			{
				Item newItem = new Item(row["name"].ToString(), row["description"].ToString());
				items.Add(newItem);
			}

			return items;
		}

		public List<ItemData> Test()
		{
			sql = "SELECT * FROM items;";
			args.Clear();
			
			DataTable data = Execute(sql, args);

			/*
			foreach(DataColumn col in data.Columns)
			{
				Console.WriteLine("{0} ({1})", col.ColumnName, col.DataType);
				colNames.Add(col.ColumnName);

			}
			*/
			List<ItemData> items = new List<ItemData>();
			foreach (DataRow row in data.Rows)
			{
				ItemData newItem = new ItemData();
				//newItem.id = (long)row["id"];
				//newItem.name = row["name"].ToString();
				//newItem.description = row["description"].ToString();
				//typeof(ItemData).GetField("name").SetValue(newItem, "LOL");

				Type itemType = typeof(ItemData);
				FieldInfo[] itemFields = itemType.GetFields();
				
				foreach (FieldInfo field in itemFields)
				{
					field.SetValue(newItem, row[field.Name]);
				}

				items.Add(newItem);
			}
			return items;
		}

	}
}
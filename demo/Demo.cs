using System;
using System.Collections.Generic;
using DbBuddy;

public class Demo
{
	public Demo ()
	{

	}

	public static void Main()
	{
		SqliteBuddy<ItemData> itemLoader = new SqliteBuddy<ItemData>("data.db", "items");
		List<ItemData> items = itemLoader.GetAll();
		if (items == null)
		{
			Console.WriteLine("No items loaded.");
			return;
		}

		foreach (ItemData item in items)
		{
			Console.WriteLine("{0} : {1}", item.name, item.description);
		}
		
	}

}

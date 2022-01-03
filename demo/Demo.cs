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
		SqliteBuddy<ItemData> items = new SqliteBuddy<ItemData>("data.db", "items");
		ItemData item = items.GetByID(1);
		if (item != null)
			Console.WriteLine("Item: {0}", item.name);
		else
			Console.WriteLine("No items loaded.");
		
	}

}

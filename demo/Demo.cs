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
		ItemLoader itemLoader = new ItemLoader("data.db");
		List<Item> myItem = itemLoader.GetAllItems();

		/*
		Console.WriteLine("Items:");
		foreach (Item item in myItem)
		{
			Console.WriteLine("{0}: {1}", item.name, item.description);
		}
		*/
		List<ItemData> items= itemLoader.Test();

		foreach (ItemData item in items)
		{
			Console.WriteLine("{0}: {1}", item.name, item.description);
		}
		
	}

}

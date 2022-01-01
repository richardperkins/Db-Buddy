using System;
using SqliteTest;

public class Demo
{
	public Demo ()
	{

	}

	public static void Main()
	{
		ItemLoader itemLoader = new ItemLoader("data.db");
		Item myItem = itemLoader.GetItemById(1);

		Console.WriteLine("Loaded {0}.", myItem.name);
	}

}

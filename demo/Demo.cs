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
		Console.WriteLine("Items:");
		foreach (ItemData item in items)
		{
			Console.WriteLine("{0} : {1}", item.name, item.description);
		}

		Console.WriteLine("Loading places...");
		// Loading place data.
		SqliteBuddy<PlaceData> placeLoader = new SqliteBuddy<PlaceData>("data.db", "places");
		List<PlaceData> places = placeLoader.GetAll();
		Console.WriteLine("Performing checks...");
		Console.WriteLine("Check 1");
		if (places == null)
		{
			Console.WriteLine("No places loaded.");
			return;
		}
		Console.WriteLine("OK");
		Console.WriteLine("Check 2");
		if (places.Count <= 0)
		{
			Console.WriteLine("No places loaded.");
			return;
		}
		Console.WriteLine("OK");
		
		Console.WriteLine("Getting field");
		PlaceData p = placeLoader.GetByField(10);
		if (p == null)
		{
			Console.WriteLine("No place to call home");
		}
		Console.WriteLine("OK");
		try
		{
			Console.WriteLine("Places:");
			if (places != null)
			{
				foreach (PlaceData place in places)
				{
					Console.WriteLine("{0} : {1}", place.name, place.description);
				}
			}
		}
		catch (Exception e)
		{
			Console.WriteLine("An exception occurred: {0}", e.Message);
		}
	}

}

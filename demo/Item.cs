using System;
using SqliteTest;

public class Item
{
	public string name;
	public string description;
	public int price;
	public int stackMax;

	public Item(string _name, string _description, int _price, int _stackMax)
	{
		name = _name;
		description = _description;
		price = _price;
		stackMax = _stackMax;

	}

}


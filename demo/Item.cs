namespace DbBuddy
{
	public class Item
	{
		public string name;
		public string description;
		public long price;
		public long stackMax;

		public Item(string _name, string _description, long _price, long _stackMax)
		{
			name = _name;
			description = _description;
			price = _price;
			stackMax = _stackMax;

		}

	}
}

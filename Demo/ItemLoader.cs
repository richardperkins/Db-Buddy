using SqliteTest;

public class ItemLoader : Database
{
	public ItemLoader (string path) : base (path)
	{

	}

	public GetItemById(int id)
	{
		Dictionary<string, object> keys = new Dictionary<string, object>();
		keys["id"] = id;
		string sql = "select name from items where id=?";

		DataTable data = Execute(sql, keys);

		return new Item(
			data[0]["name"],
			data[0]["description"],
			data[0]["price"],
			data[0]["stack_max"]
		);
	}

}

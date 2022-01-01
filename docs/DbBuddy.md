# DbBuddy

DbBuddy is the base class used to communicate to SQLite.

## Properties

**connectionPath** - *string*


## Methods

### *System.Data.DataTable* **Execute** (*string* sql, *Dictionary<string, object>* args)

Executes SQL query, returning any result as a *System.Data.DataTable*.

**Arguments**

 `sql` - SQL text to be executed
 
 `args` - Key-value *Dictionary* of arguments to bind
  
**Return**

*System.Data.DataTable* - Resulting data from query

## Example

```cs
using System.Data;
using DbBuddy;

public class ItemLoader : DbBuddy
{
    // Constructor
    public ItemLoader (string path) : base (path)
    {
        // Initialize here
    }

    /*
     * Loads item from table "items" by "id
     *
     * int id - Id of item to load
     *
     * Returns
     * DataTable - SQL query result
     */
    public DataTable LoadItemById (int id)
    {
        // The SQL query to execute
        string sql = "SELECT * FROM items WHERE id=?";
        // The key-value dictionary to bind
        Dictionary<string, object> args = new Dictionary<string, object>();
        // Bind "id"
        args["id"] = id;

        // Execute and return the query
        return Execute(sql, args);
    }
}

```
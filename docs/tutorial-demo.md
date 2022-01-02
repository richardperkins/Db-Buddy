# Demo Tutorial

This tutorial will guide you through the process of connecting and interfacing with an SQLite database using **Db Buddy**. 

## About this tutorial

This tutorial assumes you have familiarity with C# and SQLite.

## Before we begin

Before we begin, we must install dependencies.

### Windows

[Install Mono]()

[Install .Net]()


### Linux

Install Sqlite3

```bash
sudo apt install sqlite3
```

[Install Mono](https://www.mono-project.com/download/stable/#download-lin)

[Install dotnet CLI](https://docs.microsoft.com/en-us/dotnet/core/install/linux)

Run the following command in the terminal to install System.Data and Mono.Data.Sqlite:

```bash
dotnet install System.Data Mono.Data.Sqlite
```

## Installation

Copy and paste `DbBuddy.cs` into your project directory. 

That's it!

## Creating a database

Create a new (empty) file named `data.db` in your project directory.

Create a new file named `create_items.sql`. Copy & paste the following code into the file:

```sql
CREATE TABLE items
(
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL,
    description TEXT
);

INSERT INTO items
(name, description)
VALUES
("Suspicious Mushroom", "I wouldn't eat it if I were you"),
("Cubic Zirconium Ring", "Sounds expensive. Is not"),
("Saltpeter", "Saltiest of the Dynamite Three"),
("Sulfur", "Smelliest of the Dynamite Three"),
("Charcoal", "Dirtiest of the Dynamite Three"),
("Gunpowder", "Make things go BOOM."),
("Stave", "Probably belongs to a king or a wizard.");
```

Enter SQLite3 CLI in the terminal.
```bash
sqlite3 data.db
```

Run our SQL file to both create and populate our "items" table.

```bash
.read create_items.sql
```

Check to see if we were successful by running a quick SQL statement.
```sql
SELECT * FROM items;
```

A table of all the values we input should display in the terminal.

Exit SQLite3 CLI
```bash
.exit
```

We now have a populated database to interface with.

## Creating an interface

DbBuddy supplies two private methods that make interfacing a breeze.

**[Execute](DbBuddy.md#systemdatadatatable-execute-string-sql-dictionarystring-object-args)** runs SQL statements and returns a *DataTable* of any results we recieved.

**[ExecuteWrite](DbBuddy.md#ExecuteWrite)** runs a SQL statement and returns the number of affected rows as an *int*

We can start by extending the **DbBuddy** class.

```cs
// Use System.Data for DataTable
using System.Data;
using DbBuddy;

public class ItemLoader : DbBuddy
{
    // Constructor
    public ItemLoader(string path) : base (path)
    {
        // Initialization code here.
    }
```

To get an item from table "items" in our database, `data.db`, we will create a method.

```cs
    /* Get all items from "items" table
     *
     * Params:
     * None
     *
     * Returns:
     * DataTable - Resulting data from SQL query
     */
    public DataTable GetAllItems()
    {
        // Ready our SQL statement
        string sql = "SELECT * FROM items;";

        // Execute and return our query
        return Execute(sql);
    }
```

That's all there is to that! We can use some error handling but this will do for now.

Let's look into how to select just a single row using, say, the `id` field. 

```cs
    /* Get an item from "items" table by "id"
     * 
     * Params:
     * int id - Id to find
     *
     * Returns:
     * DataTable - Result
     */
    public DataTable GetItemById(int id)
    {
        // Ready our SQL query
        string sql = "SELECT * FROM items WHERE id=?;";
        // Binding params
        Dictionary<string, object> args = new Dictionary<string, object>();
        args["id"] = id;

        // Execute SQL and return result
        return Execute(sql, args);
    }
```

Next, let's delve into some other [CRUD](https://en.wikipedia.org/wiki/Create,_read,_update_and_delete) methods.

We can use **ExecuteWrite** to `UPDATE` to change values.
```cs
    public int UpdateItemById(int id, string name, string description)
    {
        // Ready our SQL statement
        string sql = "UPDATE items SET name=?, description=? WHERE id=?";
        // Bind arguments
        Dictionary<string, object> args = new Dictionary<string, object>();
        args["id"] = id;
        args["name"] = name;
        args["description"] = description;

        // Execute SQL and return result
        return ExecuteWrite(sql, args);
    }
```

We can read and now update from our "items" table. Let us now create a method to `INSERT` rows.

```cs
    public int AddItem(string name, string description)
    {
        // Ready SQL statement
        string sql = "INSERT INTO items (name, description) VALUES (?,?);";
        // Bind arguments
        Dictionary<string, object> args = new Dictionary<string, object>();
        args["name"] = name;
        args["description"] = description;

        // Execute SQL statement and return result
        return ExecuteWrite(sql, args);
    }
```

The last CRUD functionality we have left to implement is `DELETE`. It is not dissimilar to every other method we have created thus far.

```cs
    public int DeleteItemById(int id)
    {
        // Ready SQL statement
        string sql = "DELETE FROM items WHERE id=?";
        // Bind arguments
        Dictionary<string, object> args = new Dictionary<string, object>();

        // Execute SQL statement and return result
        return ExecuteWrite(sql, args);
    }
}
```

We finally have enough functionality to test our methods.

## Displaying results

Create a new file named `Demo.cs` and edit. We will begin by creating the Demo class we will be using to test our `ItemLoader`.

```cs
// Use System.Data for DataTable
using System.Data;
using DbBuddy;

public class Demo
{
    public Demo()
    {
        // Filepath to data.db
        string connectionPath = "data.db";

        // Initiate our ItemLoader
        ItemLoader itemLoader = new ItemLoader(connectionPath);

        // Get all items from table "items"
        DataTable items = itemLoader.LoadAllItems();

        // Get name of second item
        string secondItemName = items.Rows[1]["name"];

        // Output name of second item
        Console.WriteLine("Second item is: %s", secondItemName);

    }
}
```

Compile and run. The terminal should output:

```
Second item is: Cubic Zirconium Ring
```
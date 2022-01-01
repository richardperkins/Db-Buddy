# DbBuddy

DbBuddy is the base class used to communicate to SQLite.

## Properties

**connectionPath** - *string*


## Methods

### *System.Data.DataTable* **Execute** (*string* sql, *Dictionary<string, object>* args)

Executes SQL query, returning any result as a *System.Data.DataTable*.

 `sql` - SQL text to be executed
 
 `args` - Key-value *Dictionary* of arguments to bind
  
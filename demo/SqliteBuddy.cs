using System;
using System.Data;
using System.Reflection;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace DbBuddy
{
    public class SqliteBuddy <T>
    {
        string _dbPath;
        Type _dataType;
        List<T> _items;
        string _sql;
        Dictionary<string, object> _args;

        public SqliteBuddy (string dbPath)
        {
            // Initialize vars
            _dbPath = path;
            _dataType = typeof(T);
            _sql = "";
            _args = new Dictionary<string, object>();
        }


    }
}
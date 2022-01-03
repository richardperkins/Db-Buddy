using System;
using System.Data;
using System.Reflection;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace DbBuddy
{
    public class SqliteBuddy <T> where T:DataBuddy, new()
    {
        string _dbPathPrefix = "Data Source=";
        string _dbPath = "data.db";
        string _tableName;
        Type _dataType;
        List<T> _items;
        string _sql;
        Dictionary<string, object> _args;
        DataTable _result;

        public SqliteBuddy (string dbPath, string tableName)
        {
            // Initialize vars
            _dbPath = dbPath;
            _tableName = tableName;
            _dataType = typeof(T);
            _sql = "";
            _args = new Dictionary<string, object>();
        }

        public T GetByID(int id)
        {
            _sql = "SELECT * FROM ? WHERE id=?";
            _args.Clear();
            _args["tableName"] = _tableName;
            _args["id"] = id;

            try
            {
                _result = Execute(_sql, _args);
            }
            catch(Exception e)
            {
                Console.WriteLine("An exception occurred: {0}", e.Message);
                return default(T);
            }

            return DataToClass<T>()[0];
        }

        List<T> DataToClass<T>() where T:DataBuddy, new()
        {
            DataTable dt = _result;
            List<T> items = new List<T>();

			foreach (DataRow row in dt.Rows)
			{
				T newItem = new T();

				FieldInfo[] itemFields = _dataType.GetFields();
				
				foreach (FieldInfo field in itemFields)
				{
					field.SetValue(newItem, row[field.Name]);
				}
				items.Add(newItem);
			}

			return items;
        }

        /// <summary> Executes SQL query. </summary>
		/// <param name="query">SQL query</param>
		/// <param name="args">Key-value list of arguments to bind.</param>
		/// <returns>Results from query</returns>
        DataTable Execute(string sql, Dictionary<string, object> args)
        {
            if (string.IsNullOrEmpty(sql.Trim()))
            {
                return null;
            }

            using (var con = new SqliteConnection(_dbPathPrefix + _dbPath))
            {
                con.Open();

                using (var cmd = new SqliteCommand(sql, con))
                {
                    if (args != null)
					{
						foreach (KeyValuePair<string, object> entry in args)
						{
							cmd.Parameters.AddWithValue(entry.Key, entry.Value);
						}
					}

					var da = new SqliteDataAdapter(cmd);

					var dt = new DataTable();
					da.Fill(dt);

					cmd.Dispose();
					da.Dispose();
					con.Close();
					return dt;
                }
            }
        }

        /// <summary> Executes SQL write to database.</summary>
		/// <param name="query">SQL statement</param>
		/// <param name="args">Arguments to bind</param>
		/// <returns>Number of affected rows</returns>
		private int ExecuteWrite(string query, Dictionary<string, object> args)
		{
			int numberOfRowsAffected;

			//setup the connection to the database
			using (var con = new SqliteConnection(_dbPathPrefix + _dbPath))
			{
				con.Open();

				//open a new command
				using (var cmd = new SqliteCommand(query, con))
				{
					//set the arguments given in the query
					foreach (var pair in args)
					{
						cmd.Parameters.AddWithValue(pair.Key, pair.Value);
					}

					//execute the query and get the number of row affected
					numberOfRowsAffected = cmd.ExecuteNonQuery();
					cmd.Dispose();
				}
				con.Close();
				return numberOfRowsAffected;
			}
		}




    }
}
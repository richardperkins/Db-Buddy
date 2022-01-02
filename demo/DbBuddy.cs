using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Mono.Data.Sqlite;

namespace DbBuddy
{

	/// <summary> DbBuddy SQLite3 helper class</summary>
	public class DbBuddy
	{
		private const string connectionString = "Data Source=";
		private string connectionPath;

		/// <summary> Constructor </summary>
		/// <param name="path">filepath to SQLite3 database</param>
		public DbBuddy(string path)
		{
			connectionPath = path;
		}

		/// <summary> Executes SQL write to database.</summary>
		/// <param name="query">SQL statement</param>
		/// <param name="args">Arguments to bind</param>
		/// <returns>Number of affected rows</returns>
		private int ExecuteWrite(string query, Dictionary<string, object> args)
		{
			int numberOfRowsAffected;

			//setup the connection to the database
			using (var con = new SqliteConnection(connectionString + connectionPath))
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

		/// <summary> Executes SQL query. </summary>
		/// <param name="query">SQL query</param>
		/// <param name="args">Key-value list of arguments to bind.</param>
		/// <returns>Results from query</returns>
		public DataTable Execute(string query, Dictionary<string, object> args=null)
		{
			if (string.IsNullOrEmpty(query.Trim()))
				return null;

			using (var con = new SqliteConnection(connectionString + connectionPath))
			{
				con.Open();
				using (var cmd = new SqliteCommand(query, con))
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
	}
}

using System;
using System.Data;
using Npgsql;

namespace dbconnect
{
	public class dbConnect_pg
	{
		private string sQuery;
		private string sServer = "localhost";
		private string sPort = "5432";
		private string sUser = "sa_sysodonto";
		private string sPass = "saciperere";
		private string sDb = "sysodonto";

		private DataSet ds = new DataSet();
		private DataTable dt = new DataTable();

		public dbConnect_pg(string sQuery)
		{
			///initializing...
			this.sQuery = sQuery;
			Connect();
		}

		private void Connect()
		{
			try
			{
				string mystring = conString();
				var conn = new NpgsqlConnection(mystring);
				conn.Open();
				var da = new NpgsqlDataAdapter(sQuery, conn);
				ds.Reset();
				da.Fill(ds);
				if (ds.Tables.Count != 0)
				dt = ds.Tables[0];
			}
			catch (Exception msg)
			{
				Console.WriteLine(msg);
				throw;
			}
		}
		private string conString()
		{
			var cons = string.Format(
							  "Server={0};" +
							  "Port={1};" +
							  "User Id={2};" +
							  "Password={3};" +
							  "Database={4};",
							  sServer,
							  sPort,
							  sUser,
							  sPass,
							  sDb);
			return cons;
		}
		public DataTable  get_table()
		{
			return dt;
		}
	}
}


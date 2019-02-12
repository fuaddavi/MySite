using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication.Repository
{
	public class UsersRepository : IUsersRepository
	{
		private readonly string _connectionString;
		public UsersRepository(string connectionString)
		{
			_connectionString = connectionString;
		}

		public User GetUser(string username)
		{
			// Here you are free to do whatever data access code you like
			// You can invoke direct SQL queries, stored procedures, whatever 

			using (var conn = new SqlConnection(_connectionString))
			using (var cmd = conn.CreateCommand())
			{
				conn.Open();
				cmd.CommandText = "SELECT Id, HashedPassword, name FROM users WHERE UserName = @username";
				cmd.Parameters.AddWithValue("@username", username);
				using (var reader = cmd.ExecuteReader())
				{
					if (!reader.Read())
					{
						return null;
					}
					return new User()
					{
						Id = reader.GetInt32(reader.GetOrdinal("Id")),
						Username = username,
						Name = reader.GetString(reader.GetOrdinal("name")),
						HashedPassword = reader.GetString(reader.GetOrdinal("HashedPassword")),
					};
				}
			}
		}
	}
}
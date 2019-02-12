using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
	public class User
	{
		public string Username { get; set; }
		public string HashedPassword { get; set; }
		public int Id { get; set; }
		public string Name { get; internal set; }
	}
}
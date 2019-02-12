﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebApplication.Models;
using WebApplication.Repository;

namespace WebApplication
{
	/// <summary>
	/// Summary description for WebService
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	// [System.Web.Script.Services.ScriptService]
	public class WebService : System.Web.Services.WebService
	{

		[WebMethod]
		public string HelloWorld()
		{
			return "Hello World";
		}

		[WebMethod]
		public bool Authenticate(string username, string password)
		{
			var con = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
			var userRepository = new UsersRepository(con);
			var user = userRepository.GetUser(username);

			if (user!=null && user.HashedPassword!=null)
			{
				return PasswordHash.PasswordHash.ValidatePassword(password, user.HashedPassword);
			}
			return false;
		}
		
	}
}

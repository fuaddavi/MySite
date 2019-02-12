using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication.Repository
{
	public interface IUsersRepository
	{
		User GetUser(string username);
	}
}
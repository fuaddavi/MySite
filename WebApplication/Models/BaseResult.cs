using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
	public class BaseResult
	{
		public Boolean Success { get; set; }

		public String Message { get; set; }

		public Guid? RecordId { get; set; }
	}
}
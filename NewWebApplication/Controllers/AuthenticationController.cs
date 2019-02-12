using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace NewWebApplication.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Index()
        {
            return View();
        }

		[HttpPost]
		public async Task<ActionResult> Login(Login Values)
		{
			return await Task.Run<ActionResult>(() =>
			{
				Boolean authenticated = false;

				try
				{
					if (ModelState.IsValid)
					{
						if (!string.IsNullOrEmpty(Values.Username) && !string.IsNullOrEmpty(Values.Password))
						{
							var webService = new WebApplication.WebService();
							authenticated = webService.Authenticate(Values.Username, Values.Password);
						}
					}
				}
				catch (Exception ex)
				{
				}

				if (authenticated)
				{
					if (!String.IsNullOrEmpty(Values.ReturnUrl))
					{
						return Redirect(Values.ReturnUrl);
					}
					return RedirectToAction("Index", "Home");
				}
				return RedirectToAction("Index");
			});
		}


		public async Task<ActionResult> Logout()
		{
			return await Task.Run<ActionResult>(() =>
			{
				Session.Clear();
				return RedirectToAction("Index", "Authentication");
			});
		}

		public async Task<ActionResult> IsLoggedIn()
		{
			return await Task.Run<ActionResult>(() =>
			{
				BaseResult result = new BaseResult();

				try
				{
					//User login information
					var systemUserId = Session["SystemUserId"] as Guid?;
					result.Success = systemUserId.HasValue;
					if (!result.Success)
					{
						result.Message = "Your session is expired, please relogin.";
					}
				}
				catch (Exception ex)
				{
					result.Message = ex.Message;
				}

				return Json(result, JsonRequestBehavior.AllowGet);
			});
		}

	}
}
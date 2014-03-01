using System;
using System.Diagnostics.CodeAnalysis;
using System.Web.Mvc;
using Skylab.Core.Security;
using Skylab.Core.ViewModels.Login;

namespace Skylab.Web.Controllers
{
	[SuppressMessage( "Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login", Justification = "Our naming standard." )]
	public partial class LoginController : Controller
	{
		[SuppressMessage( "Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login", Justification = "Our naming standard." )]
		public virtual ActionResult LoginUser()
		{
			// If the ELMS WebStore redirected the user here because she wants to logout, then redirect her to the logout page.
			// NOTE: Because "action" has a special meaning MVC, it cannot be used as action parameter name, instead the query string must be accessed directly.
			string action = this.Request.QueryString[ "action" ];
			if( !String.IsNullOrEmpty( action ) && action.Equals( "signout", StringComparison.OrdinalIgnoreCase ) )
			{
				return this.RedirectToRoute( RouteNames.Logout );
			}

			// Render the login page.
			LoginUserVM model = new LoginUserVM
			{
				IsServiceAvailable = ShibbolethHelper.IsServiceAvailable()
			};

			return this.View( Views.LoginUser, model );
		}


		[SuppressMessage( "Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Logout", Justification = "Our naming standard." )]
		public virtual ViewResult LogoutUser()
		{
			return this.View();
		}

	}
}
using System.Web.Mvc;
using System.Web.Routing;

namespace Skylab.Web
{
	public static class RouteConfig
	{
		public static void RegisterRoutes( RouteCollection routes )
		{
			routes.IgnoreRoute( "{resource}.axd/{*pathInfo}" );

			// For compatibility reasons, manually map all routes to the previously used URLs.
			routes.MapRoute( RouteNames.Index, "index.html", MVC.Home.Index() );
			routes.MapRoute( RouteNames.Faq, "hu/gyik.htm", MVC.Home.Faq() );
			routes.MapRoute( RouteNames.Contact, "hu/kapcsolatfelvetel.htm", MVC.Home.Contact() );
			routes.MapRoute( RouteNames.Download, "hu/letoltes.htm", MVC.Home.Download() );
			routes.MapRoute( RouteNames.DownloadErrors, "hu/letoltes_hibakodok.htm", MVC.Home.DownloadErrors() );
			routes.MapRoute( RouteNames.Licence, "hu/licenc_feltetelek.htm", MVC.Home.Licence() );
			routes.MapRoute( RouteNames.Program, "hu/msdnaa_program.htm", MVC.Home.Program() );
			routes.MapRoute( RouteNames.DownloadGuide, "hu/utmutato_letolteshez.htm", MVC.Home.DownloadGuide() );
			routes.MapRoute( RouteNames.RegistrationGuide, "hu/utmutato_regisztraciohoz.htm", MVC.Home.RegistrationGuide() );
			routes.MapRoute( RouteNames.AdminGuide, "hu/utmutato_rendszergazdaknak.htm", MVC.Home.AdminGuide() );
			routes.MapRoute( RouteNames.Login, "hu/bejelentkezes.htm", MVC.Login.LoginUser() );
			routes.MapRoute( RouteNames.Logout, "hu/kijelentkezes.htm", MVC.Login.LogoutUser() );
			routes.MapRoute( RouteNames.LoginRedirect, "secure/redirect", MVC.Secure.LoginRedirect() );

			routes.MapRoute(
					name: "Default",
					url: "{controller}/{action}/{id}",
					defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}

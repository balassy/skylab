using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace Skylab.Web
{
	/// <summary>
	/// Helper class that sets up the routes.
	/// </summary>
	public static class RouteConfig
	{
		/// <summary>
		/// Registers the routes for the application.
		/// </summary>
		/// <param name="routes">The collection of existing routes to extend.</param>
		/// <exception cref="ArgumentNullException">If <paramref name="routes"/> is <c>null</c>.</exception>
		public static void RegisterRoutes( RouteCollection routes )
		{
			// Input validation.
			if( routes == null )
			{
				throw new ArgumentNullException( "routes" );
			}

			routes.IgnoreRoute( "{resource}.axd/{*pathInfo}" );

			// This ensures that the order of the handler mappings in the root web.config file does not affect the handling of the Shibboleth.sso path.
			routes.IgnoreRoute( "{resource}.sso/{*pathInfo}" );

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

			// The default route is used to map the "/" URL.
			routes.MapRoute(
					name: "Default",
					url: "{controller}/{action}/{id}",
					defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}

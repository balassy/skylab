using System.Diagnostics.CodeAnalysis;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Skylab.Core.Views;

namespace Skylab.Web
{
	/// <summary>
	/// The global application class which handles application level events.
	/// </summary>
	[SuppressMessage( "Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Mvc", Justification = "De facto standard name for the application class." )]
	public class MvcApplication : System.Web.HttpApplication
	{
		/// <summary>
		/// Event handler that is called when the application is the started.
		/// </summary>
		[SuppressMessage( "Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Convention-based configuration." )]
		protected void Application_Start()
		{
			// Clear all previously registered view engines and register only the Razor view engine with only .cshtml extensions.
			ViewEngines.Engines.Clear();
			ViewEngines.Engines.Add( new CSOnlyRazorViewEngine() );

			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters( GlobalFilters.Filters );
			RouteConfig.RegisterRoutes( RouteTable.Routes );
			BundleConfig.RegisterBundles( BundleTable.Bundles );

			// Security: Remove the X-AspNetMVc-Version: 5.0 HTTP header.
			MvcHandler.DisableMvcResponseHeader = true;
		}


		/// <summary>
		/// Event handler that is called just before ASP.NET sends HTTP headers to the client.
		/// </summary>
		protected void Application_PreSendRequestHeaders()
		{
			// Security: Remove the Server: Microsoft-IIS/8.0 HTTP header.
			this.Response.Headers.Remove( "Server" );
		}
	}
}

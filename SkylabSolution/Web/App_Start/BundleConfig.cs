using System;
using System.Web.Optimization;

namespace Skylab.Web
{
	/// <summary>
	/// Helper class that sets up CSS and JS bundling and minification when the application starts.
	/// </summary>
	/// <remarks>
	/// For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
	/// </remarks>
	public static class BundleConfig
	{
		/// <summary>
		/// Registers the custom bundles of the application.
		/// </summary>
		/// <param name="bundles">The collection of bundles to extend.</param>
		/// <exception cref="System.ArgumentNullException">If <paramref name="bundles"/> is <c>null</c>.</exception>
		public static void RegisterBundles( BundleCollection bundles )
		{
			// Input validation.
			if( bundles == null )
			{
				throw new ArgumentNullException( "bundles" );
			}

			// NOTE: Bundling is forced even in debug mode to ensure that it will not break in production.
			BundleTable.EnableOptimizations = true;

			// Create the CSS bundle.
			bundles.Add( new StyleBundle( "~/Bundles/css/" ).Include(
								"~/Static/css/metro-bootstrap.min.css",
								"~/Static/css/msdnaa.css" ) );

			// Create the JS bundle.
			bundles.Add( new ScriptBundle( "~/Bundles/js/" ).Include(
								"~/Static/lib/jquery-1.8.3.js",
								"~/Static/lib/bootstrap-transition.js",
								"~/Static/lib/bootstrap-collapse.js",
								"~/Static/js/msdnaa.js" ) );
		}
	}
}

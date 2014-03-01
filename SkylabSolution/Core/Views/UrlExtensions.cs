using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Web.Mvc;

namespace Skylab.Core.Views
{
	public static class UrlExtensions
	{
		[SuppressMessage( "Microsoft.Design", "CA1055:UriReturnValuesShouldNotBeStrings", Justification = "Compatibility with the built-in framework methods." )]
		public static string RouteUrl( this UrlHelper url, string routeName, string fragment )
		{
			// Input validation.
			if( url == null )
			{
				throw new ArgumentNullException( "url" );
			}

			if( String.IsNullOrEmpty( routeName ) )
			{
				throw new ArgumentNullException( "routeName" );
			}

			if( String.IsNullOrEmpty( fragment ) )
			{
				throw new ArgumentNullException( "fragment" );
			}

			string routeUrl = url.RouteUrl( routeName );
			return String.Format( CultureInfo.InvariantCulture, "{0}#{1}", routeUrl, fragment );
		}
	}
}
using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Web.Mvc;

namespace Skylab.Core.Views
{
	/// <summary>
	/// Extension methods for the <see cref="UrlHelper"/> class.
	/// </summary>
	public static class UrlExtensions
	{
		/// <summary>
		/// Generates a fully qualified URL for the specified route name, and adds the specified <paramref name="fragment"/> to its end.
		/// </summary>
		/// <param name="url">The <see cref="UrlHelper"/> object this method extends.</param>
		/// <param name="routeName">The name of the route that is used to generate the URL.</param>
		/// <param name="fragment">The name of the fragment that is added to the end of the generated URL after the "#" sign. NOTE: It is appended as it is without additional encoding!</param>
		/// <returns>The fully qualified URL for the route extended with the fragment.</returns>
		/// <exception cref="System.ArgumentNullException">If <paramref name="url"/>, <paramref name="routeName"/> or <paramref name="fragment"/> is <c>null</c> or <see cref="String.Empty"/>.</exception>
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

			// Build the fully qualified URL for the route.
			string routeUrl = url.RouteUrl( routeName );

			// Add the fragment to the end of the route.
			return String.Format( CultureInfo.InvariantCulture, "{0}#{1}", routeUrl, fragment );
		}
	}
}
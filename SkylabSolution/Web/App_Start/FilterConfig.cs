using System;
using System.Web.Mvc;

namespace Skylab.Web
{
	/// <summary>
	/// Helper class that sets up action filters.
	/// </summary>
	public static class FilterConfig
	{
		/// <summary>
		/// Registers the global filters for the application.
		/// </summary>
		/// <param name="filters">The collection of existing filters to extend.</param>
		/// <exception cref="System.ArgumentNullException">If <paramref name="filters"/> is <c>null</c>.</exception>
		public static void RegisterGlobalFilters( GlobalFilterCollection filters )
		{
			// Input validation.
			if( filters == null )
			{
				throw new ArgumentNullException( "filters" );
			}

			filters.Add( new HandleErrorAttribute() );
		}
	}
}

using System;
using System.Web.Mvc;

namespace Skylab.Web
{
	public static class FilterConfig
	{
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

using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace Skylab.Core.Security
{
	/// <summary>
	/// Helper class that encapsulates Shibboleth operations.
	/// </summary>
	public static class ShibbolethHelper
	{
		/// <summary>
		/// The URL of the HTTP endpoint that can be used to determine whether the Shibboleth service is available.
		/// </summary>
		private const string ServiceStatusUrl = @"https://login.bme.hu/idp/profile/Status";


		/// <summary>
		/// Determines whether the remote authentication service is available using the URL in the web.config file.
		/// </summary>
		/// <returns><c>True</c> if the remote authentication service is available; otherwise, <c>false</c>.</returns>
		[SuppressMessage( "Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Fool-proof code required." )]
		public static bool IsServiceAvailable()
		{
			try
			{
				using( WebClient wc = new WebClient() )
				{
					string result = wc.DownloadString( ShibbolethHelper.ServiceStatusUrl );
					return result.Equals( "ok", StringComparison.OrdinalIgnoreCase );
				}
			}
			catch
			{
				// The service is treated as unavailable in case of any error.
				return false;
			}
		}
	}
}
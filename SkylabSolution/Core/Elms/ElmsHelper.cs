using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Net;
using System.Web;
using Skylab.Core.Config;
using Skylab.Core.Security;

namespace Skylab.Core.Elms
{
	/// <summary>
	/// Helper class that encapsulates ELMS WebStore related operations.
	/// </summary>
	public static class ElmsHelper
	{
		/// <summary>
		/// The URL of the ELMS WebStore HTTP endpoint that must be called to register an authenticated user.
		/// </summary>
		private const string RegistrationUrl = @"https://e5.onthehub.com/WebStore/Security/AuthenticateUser.aspx";

		/// <summary>
		/// The name of the built-in "Students" role in the ELMS WebStore.
		/// </summary>
		private const string StudentStatus = "students";

		/// <summary>
		/// The name of the built-in "Faculty" role in the ELMS WebStore.
		/// </summary>
		private const string FacultyStatus = "faculty";

		/// <summary>
		/// The name of the built-in "Staff" role in the ELMS WebStore.
		/// </summary>
		private const string StaffStatus = "staff";


		/// <summary>
		/// Registers the previously logged in user for authentication in the ELMS WebStore.
		/// </summary>
		/// <param name="token">The Shibboleth token that describes the currently logged-in user.</param>
		/// <returns>An <see cref="ElmsRegistrationResult"/> instance with the details of the registration.</returns>
		[SuppressMessage( "Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "Skylab.Core.Log.WriteError(System.String)", Justification = "Localization is not supported yet on this site." )]
		[SuppressMessage( "Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "ElmsHelper", Justification = "False alarm." )]
		[SuppressMessage( "Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Fool-proof code required." )]
		public static ElmsRegistrationResult Register( ShibbolethToken token )
		{
			// Input validation.
			if( token == null )
			{
				Log.WriteError( "ElmsHelper.Register: token is null!" );
				throw new ArgumentNullException( "token" );
			}

			if( String.IsNullOrEmpty( token.Email ) )
			{
				Log.WriteError( "ElmsHelper.Register: token.Email is null!" );
				throw new ArgumentException( "The e-mail address is required for the registration!" );
			}

			// Prepare the constant parameters.
			string accountNumber = ConfigHelper.Elms.AccountNumber;
			string key = ConfigHelper.Elms.Key;

			// Prepare the user-specific parameters.
			string userName = HttpUtility.UrlEncode( token.Email );
			string email = HttpUtility.UrlEncode( token.Email );

			// Prepare the parameter that describe the user's permissions.
			List<string> statusList = new List<string>();
			if( token.IsStudent )
			{
				statusList.Add( ElmsHelper.StudentStatus );
			}
			if( token.IsSupervisor )
			{
				statusList.Add( ElmsHelper.StaffStatus );
				statusList.Add( ElmsHelper.FacultyStatus );
			}
			string statuses = String.Join( ",", statusList );

			// Build the request URL.
			string serviceUrl = String.Format( CultureInfo.InvariantCulture, "{0}?account={1}&key={2}&username={3}&academic_statuses={4}&email={5}", ElmsHelper.RegistrationUrl, accountNumber, key, userName, statuses, email );

			// Integrity check: the built URL must be a valid URI.
			Uri serviceUri;
			if( !Uri.TryCreate( serviceUrl, UriKind.Absolute, out serviceUri ) )
			{
				Log.WriteError( "ElmsHelper.Register: Invalid ServiceURL: {0}", serviceUrl );
				throw new InvalidOperationException( "The service URL is invalid!" );
			}

			// Send the HTTP GET request to the ELMS WebStore.
			ElmsRegistrationResult result = new ElmsRegistrationResult();
			try
			{
				// NOTE: This low-level class must be used, becuase the WebClient class does not provide access to the HTTP status code.
				HttpWebRequest request = (HttpWebRequest) WebRequest.Create( serviceUri );
				using( HttpWebResponse response = (HttpWebResponse) request.GetResponse() )
				{
					result.StatusCode = response.StatusCode;

					// Check the HTTP status code.
					if( response.StatusCode == HttpStatusCode.OK )
					{
						using( StreamReader reader = new StreamReader( response.GetResponseStream() ) )
						{
							// Read the raw content from the HTTP response.
							string responseText = reader.ReadToEnd();

							// Check that the raw content of the HTTP response is a valid absolute URL.
							Uri responseUri;
							if( Uri.TryCreate( responseText, UriKind.Absolute, out responseUri ) )
							{
								result.IsSuccess = true;
								result.RedirectUri = responseUri;
							}
						}
					}
				}
			}
			catch( WebException ex )
			{
				// Log the error.
				Log.WriteError( ex );
				Log.WriteError( "ElmsHelper.Register: WebException! ServiceURL: {0}", serviceUrl );

				HttpWebResponse response = ex.Response as HttpWebResponse;
				if( response != null )
				{
					Log.WriteError( "ElmsHelper.Register: WebException! StatusCode: {0}", response.StatusCode );
					Log.WriteError( "ElmsHelper.Register: WebException! StatusDescription: {0}", response.StatusDescription );
				}

				// Treat the registration unsuccessful in case of any error.
				result.IsSuccess = false;
			}
			catch( Exception ex )
			{
				// Log the error.
				Log.WriteException( ex );

				// Treat the registration unsuccessful in case of any error.
				result.IsSuccess = false;
			}

			return result;
		}
	}
}
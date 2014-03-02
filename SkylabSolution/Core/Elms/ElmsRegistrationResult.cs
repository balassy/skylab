using System;
using System.Net;

namespace Skylab.Core.Elms
{
	/// <summary>
	/// Encapsulates the details of the result of the ELMS WebStore registration call.
	/// </summary>
	public class ElmsRegistrationResult
	{
		/// <summary>
		/// Gets or sets a value indicating whether the user registration was successful.
		/// </summary>
		public bool IsSuccess { get; set; }

		/// <summary>
		/// Gets or sets the URL where the user should be redirected after successful registration.
		/// </summary>
		public Uri RedirectUri { get; set; }

		/// <summary>
		/// Gets or sets the low-level HTTP status code of the registration webservice call.
		/// </summary>
		public HttpStatusCode StatusCode { get; set; }
	}
}
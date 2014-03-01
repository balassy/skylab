using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Web.Mvc;
using Skylab.Core.Elms;
using Skylab.Core.Security;
using Skylab.Core.ViewModels.Secure;


namespace Skylab.Web.Controllers
{
	/// <summary>
	/// Provides the URL segment (~/secure) that is protected by the Shibboleth ISAPI filter.
	/// </summary>	
	public partial class SecureController : Controller
	{
		/// <summary>
		/// Represents the endpoint that is called where the Shibboleth identity provider redirects to after successfully authenticating the user.
		/// </summary>
		/// <returns>A Redirect to the ELMS WebStore page or an error page.</returns>
		[SuppressMessage( "Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login", Justification = "Our naming standard." )]
		[RequireHttps]
		public virtual ActionResult LoginRedirect()
		{
			// Get the details of the currently logged in user.
			ShibbolethToken token = ShibbolethToken.CreateCurrent();

			// Integrity check.
			if( token == null )
			{
				throw new InvalidOperationException( "The Shibboleth token is required!" );
			}

			LoginRedirectVM model = new LoginRedirectVM();

			// Validate that the current user has her e-mail address specified, because it is required for the ELMS registration.
			// If the e-mail address is missing, then display a specific error message.
			if( String.IsNullOrEmpty( token.Email ) )
			{
				model.FailureReason = ElmsRegistrationFailureReason.MissingEmail;
				return this.View( Views.LoginRedirect, model );
			}

			// Try to register the user in the ELMS WebStore.
			ElmsRegistrationResult result = ElmsHelper.Register( token );

			// If the registration failed, display a specific error message.
			if( !result.IsSuccess )
			{
				model.FailureReason = result.StatusCode == HttpStatusCode.BadRequest
					? ElmsRegistrationFailureReason.ClientError
					: ElmsRegistrationFailureReason.ServiceError;

				return this.View( Views.LoginRedirect, model );
			}

			// Redirect the user to the ELMS WebStore only if the registration was successful.
			// Integrity check: the redirect URL must be specified.
			if( result.RedirectUri == null )
			{
				throw new InvalidOperationException( "The redirect URL must be specified!" );
			}

			// If the redirect URL is specified, then redirect the registered user to the ELMS WebStore.
			return this.Redirect( result.RedirectUri.ToString() );
		}
	}
}
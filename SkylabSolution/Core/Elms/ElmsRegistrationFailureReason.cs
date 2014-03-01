namespace Skylab.Core.Elms
{
	/// <summary>
	/// The possible reasons why the ELMS WebStore registration is not succeeded.
	/// </summary>
	public enum ElmsRegistrationFailureReason
	{
		/// <summary>
		/// The user's e-mail address is missing from the Shibboleth token.
		/// </summary>
		MissingEmail,

		/// <summary>
		/// The ELMS WebService encountered an error.
		/// </summary>
		ServiceError,

		/// <summary>
		/// The ELMS WebService could not register the user because of an error in the HTTP request.
		/// </summary>
		ClientError
	}
}
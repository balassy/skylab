using System.Diagnostics.CodeAnalysis;
using Skylab.Core.Elms;

namespace Skylab.Core.ViewModels.Secure
{
	/// <summary>
	/// The view-model for the login redirect page.
	/// </summary>
	[SuppressMessage( "Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login", Justification = "Our naming standard." )]
	public class LoginRedirectVM
	{
		/// <summary>
		/// Gets or sets the detailed reason if the ELMS registration is failed.
		/// </summary>
		public ElmsRegistrationFailureReason FailureReason { get; set; }
	}
}
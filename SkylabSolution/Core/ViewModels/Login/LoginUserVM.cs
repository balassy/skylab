using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Skylab.Core.ViewModels.Login
{
	/// <summary>
	/// The view-model for the login page.
	/// </summary>
	[SuppressMessage( "Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login", Justification = "Our naming standard." )]
	public class LoginUserVM
	{
		/// <summary>
		/// Gets or sets a value indicating whether the Shibboleth service is available.
		/// </summary>
		[ReadOnly( true )]
		public bool IsServiceAvailable { get; set; }
	}
}
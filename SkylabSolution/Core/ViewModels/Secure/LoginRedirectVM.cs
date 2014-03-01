using System.Diagnostics.CodeAnalysis;
using Skylab.Core.Elms;

namespace Skylab.Core.ViewModels.Secure
{
	[SuppressMessage( "Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login", Justification = "Our naming standard." )]
	public class LoginRedirectVM
	{
		public ElmsRegistrationFailureReason FailureReason { get; set; }
	}
}
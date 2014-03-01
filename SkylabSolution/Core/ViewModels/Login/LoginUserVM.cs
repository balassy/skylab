using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Skylab.Core.ViewModels.Login
{
	[SuppressMessage( "Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login", Justification = "Our naming standard." )]
	public class LoginUserVM
	{
		[ReadOnly( true )]
		public bool IsServiceAvailable { get; set; }
	}
}
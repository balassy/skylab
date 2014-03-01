using System.Diagnostics.CodeAnalysis;
namespace Skylab.Web
{
	public static class RouteNames
	{
		public const string Index = "Index";

		[SuppressMessage( "Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Faq", Justification = "Our naming standard." )]
		public const string Faq = "Faq";

		public const string Contact = "Contact";

		public const string Download = "Download";

		public const string DownloadErrors = "DownloadErrors";

		[SuppressMessage( "Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Licence", Justification = "Our naming standard." )]
		public const string Licence = "Licence";

		[SuppressMessage( "Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login", Justification = "Our naming standard." )]
		public const string Login = "Login";

		[SuppressMessage( "Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login", Justification = "Our naming standard." )]
		public const string LoginRedirect = "LoginRedirect";

		[SuppressMessage( "Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Logout", Justification = "Our naming standard." )]
		public const string Logout = "Logout";

		public const string Program = "Program";

		public const string DownloadGuide = "DownloadGuide";

		public const string RegistrationGuide = "RegistrationGuide";

		public const string AdminGuide = "AdminGuide";
	}
}
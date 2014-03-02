using System.Diagnostics.CodeAnalysis;

namespace Skylab.Web
{
	/// <summary>
	/// Contains the constant names for all routes that are used in the application.
	/// </summary>
	public static class RouteNames
	{
		/// <summary>
		/// The route name for the Index (Kezdőlap) page.
		/// </summary>
		public const string Index = "Index";

		/// <summary>
		/// The route name for the Frequently Asked Questions (Gyakran Ismétlődő Kérdések) page.
		/// </summary>
		[SuppressMessage( "Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Faq", Justification = "Our naming standard." )]
		public const string Faq = "Faq";

		/// <summary>
		/// The route name for the Contact (Kapcsolatfelvétel) page.
		/// </summary>
		public const string Contact = "Contact";

		/// <summary>
		/// The route name for the Download (Letöltés) page.
		/// </summary>
		public const string Download = "Download";

		/// <summary>
		/// The route name for the Download Error Codes (Letöltési hibakódok) page.
		/// </summary>
		public const string DownloadErrors = "DownloadErrors";

		/// <summary>
		/// The route name for the DreamSpark Licence (Licenc feltételek) page.
		/// </summary>
		[SuppressMessage( "Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Licence", Justification = "Our naming standard." )]
		public const string Licence = "Licence";

		/// <summary>
		/// The route name for the Login (Bejelentkezés) page.
		/// </summary>
		[SuppressMessage( "Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login", Justification = "Our naming standard." )]
		public const string Login = "Login";

		/// <summary>
		/// The route name for the Login Failed (Sikertelen bejelentkezés) page.
		/// </summary>
		[SuppressMessage( "Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login", Justification = "Our naming standard." )]
		public const string LoginRedirect = "LoginRedirect";

		/// <summary>
		/// The route name for the Logout (Kijelentkezés) page.
		/// </summary>
		[SuppressMessage( "Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Logout", Justification = "Our naming standard." )]
		public const string Logout = "Logout";

		/// <summary>
		/// The route name for the About the DreamSpark Program (Bővebben a DreamSpark programról) page.
		/// </summary>
		public const string Program = "Program";

		/// <summary>
		/// The route name for the Guide for Download (Útmutató letöltéshez) page.
		/// </summary>
		public const string DownloadGuide = "DownloadGuide";

		/// <summary>
		/// The route name for the Guide for Registration (Útmutató regisztrációhoz) page.
		/// </summary>
		public const string RegistrationGuide = "RegistrationGuide";

		/// <summary>
		/// The route name for the Guide for SysAdmins (Útmutató rendszergazdáknak) page.
		/// </summary>
		public const string AdminGuide = "AdminGuide";
	}
}
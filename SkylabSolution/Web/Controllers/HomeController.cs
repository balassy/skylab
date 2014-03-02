using System.Diagnostics.CodeAnalysis;
using System.Web.Mvc;

namespace Skylab.Web.Controllers
{
	/// <summary>
	/// Handles the HTTP requests for the public static pages.
	/// </summary>
	[OutputCache( CacheProfile = "StaticPage" )]
	public partial class HomeController : Controller
	{
		/// <summary>
		/// Renders the Home (Kezdőlap) page.
		/// </summary>
		/// <returns>The HTML markup of the page.</returns>
		public virtual ActionResult Index()
		{
			return this.View();
		}


		/// <summary>
		/// Renders the Frequently Asked Questions (Gyakran Ismétlődő Kérdések) page.
		/// </summary>
		/// <returns>The HTML markup of the page.</returns>
		[SuppressMessage( "Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Faq", Justification = "Our naming standard." )]
		public virtual ActionResult Faq()
		{
			return this.View();
		}


		/// <summary>
		/// Renders the Contact (Kapcsolatfelvétel) page.
		/// </summary>
		/// <returns>The HTML markup of the page.</returns>
		public virtual ActionResult Contact()
		{
			return this.View();
		}


		/// <summary>
		/// Renders the Download (Letöltés) page.
		/// </summary>
		/// <returns>The HTML markup of the page.</returns>
		public virtual ActionResult Download()
		{
			return this.View();
		}


		/// <summary>
		/// Renders the Download Error Codes (Letöltési hibakódok magyarázata) page.
		/// </summary>
		/// <returns>The HTML markup of the page.</returns>
		public virtual ActionResult DownloadErrors()
		{
			return this.View();
		}


		/// <summary>
		/// Renders the DreamSpark Licence (Licenc feltételek) page.
		/// </summary>
		/// <returns>The HTML markup of the page.</returns>
		[SuppressMessage( "Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Licence", Justification = "Our naming standard." )]
		public virtual ActionResult Licence()
		{
			return this.View();
		}


		/// <summary>
		/// Renders the About the DreamSpark Program (Bővebben a DreamSpark programról) page.
		/// </summary>
		/// <returns>The HTML markup of the page.</returns>
		public virtual ActionResult Program()
		{
			return this.View();
		}


		/// <summary>
		/// Renders the Guide for Download (Útmutató letöltéshez) page.
		/// </summary>
		/// <returns>The HTML markup of the page.</returns>
		public virtual ActionResult DownloadGuide()
		{
			return this.View();
		}


		/// <summary>
		/// Renders the Guide for Registration (Útmutató regisztrációhoz) page.
		/// </summary>
		/// <returns>The HTML markup of the page.</returns>
		public virtual ActionResult RegistrationGuide()
		{
			return this.View();
		}


		/// <summary>
		/// Renders the Guide for SysAdmins (Útmutató rendszergazdáknak) page.
		/// </summary>
		/// <returns>The HTML markup of the page.</returns>
		public virtual ActionResult AdminGuide()
		{
			return this.View();
		}

	}
}
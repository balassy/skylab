using System.Diagnostics.CodeAnalysis;
using System.Web.Mvc;

namespace Skylab.Web.Controllers
{
	[OutputCache( CacheProfile = "StaticPage" )]
	public partial class HomeController : Controller
	{
		public virtual ActionResult Index()
		{
			return this.View();
		}


		[SuppressMessage( "Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Faq", Justification = "Our naming standard." )]
		public virtual ActionResult Faq()
		{
			return this.View();
		}


		public virtual ActionResult Contact()
		{
			return this.View();
		}


		public virtual ActionResult Download()
		{
			return this.View();
		}


		public virtual ActionResult DownloadErrors()
		{
			return this.View();
		}


		[SuppressMessage( "Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Licence", Justification = "Our naming standard." )]
		public virtual ActionResult Licence()
		{
			return this.View();
		}


		public virtual ActionResult Program()
		{
			return this.View();
		}


		public virtual ActionResult DownloadGuide()
		{
			return this.View();
		}


		public virtual ActionResult RegistrationGuide()
		{
			return this.View();
		}


		public virtual ActionResult AdminGuide()
		{
			return this.View();
		}

	}
}
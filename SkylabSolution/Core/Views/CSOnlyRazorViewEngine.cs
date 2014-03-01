namespace Skylab.Core.Views
{
	using System.Web.Mvc;

	/// <summary>
	/// Custom Razor view engine that searches only for .cshtml files and skips the .vbhtml paths.
	/// </summary>
	/// <remarks>
	/// Read more at http://stackoverflow.com/questions/6049445/make-asp-net-mvc-3-razor-view-engine-ignore-vbhtml-files.
	/// </remarks>
	public class CSOnlyRazorViewEngine : RazorViewEngine
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CSOnlyRazorViewEngine"/> class.
		/// </summary>
		public CSOnlyRazorViewEngine()
		{
			this.AreaViewLocationFormats = new[] 
			{ 
				"~/Areas/{2}/Views/{1}/{0}.cshtml",
				"~/Areas/{2}/Views/Shared/{0}.cshtml"
			};

			this.AreaMasterLocationFormats = new[] 
			{ 
				"~/Areas/{2}/Views/{1}/{0}.cshtml",
				"~/Areas/{2}/Views/Shared/{0}.cshtml"
			};

			this.AreaPartialViewLocationFormats = new[] 
			{ 
				"~/Areas/{2}/Views/{1}/{0}.cshtml",
				"~/Areas/{2}/Views/Shared/{0}.cshtml"
			};

			this.ViewLocationFormats = new[] 
			{
				"~/Views/{1}/{0}.cshtml",
				"~/Views/Shared/{0}.cshtml"
			};

			this.PartialViewLocationFormats = new[] 
			{
				"~/Views/{1}/{0}.cshtml",
				"~/Views/Shared/{0}.cshtml"
			};

			this.MasterLocationFormats = new[] 
			{
				"~/Views/{1}/{0}.cshtml",
				"~/Views/Shared/{0}.cshtml"
			};
		}
	}
}

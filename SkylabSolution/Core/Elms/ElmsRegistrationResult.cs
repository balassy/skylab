using System;
using System.Net;

namespace Skylab.Core.Elms
{
	public class ElmsRegistrationResult
	{
		public bool IsSuccess { get; set; }

		public Uri RedirectUri { get; set; }

		public HttpStatusCode StatusCode { get; set; }
	}
}
using System.Configuration;

namespace Skylab.Core.Config
{
	/// <summary>
	/// Helper class to retrieve configuration information.
	/// </summary>
	public static class ConfigHelper
	{
		/// <summary>
		/// Gets the settings from the <c>Elms</c> section of the config file.
		/// </summary>
		public static ElmsSection Elms
		{
			get
			{
				return ConfigurationManager.GetSection( @"Skylab/Elms" ) as ElmsSection;
			}
		}

	}

}
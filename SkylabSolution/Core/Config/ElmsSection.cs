using System.Configuration;

namespace Skylab.Core.Config
{
	/// <summary>
	/// Represents the <c>Skylab/Elms</c> section in the configuration file.
	/// </summary>
	public class ElmsSection : ConfigurationSection
	{
		/// <summary>
		/// Gets the Organizational Account Number of the ELMS subscription.
		/// </summary>
		[ConfigurationProperty( "accountNumber", IsRequired = true )]
		public string AccountNumber
		{
			get
			{
				return (string) this[ "accountNumber" ];
			}
		}


		/// <summary>
		/// Gets the shared secret used to verify the calling server.
		/// </summary>
		[ConfigurationProperty( "key", IsRequired = true )]
		public string Key
		{
			get
			{
				return (string) this[ "key" ];
			}
		}
	}
}
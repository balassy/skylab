namespace Skylab.Core.Security
{
	using System;
	using System.Collections.Specialized;
	using System.Diagnostics.CodeAnalysis;
	using System.Linq;
	using System.Reflection;
	using System.Web;

	/// <summary>
	/// Represents the useful values from a Shibboleth token.
	/// </summary>
	public class ShibbolethToken
	{
		/// <summary>
		/// Gets or sets the full display name of the user.
		/// </summary>
		[ServerVariable( "HTTP_DISPLAYNAME" )]
		public string DisplayName { get; set; }

		/// <summary>
		/// Gets or sets the Neptun code of the user.
		/// </summary>
		[SuppressMessage( "Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Neptun", Justification = "Proper name." )]
		[ServerVariable( "HTTP_NIIFPERSONORGID" )]
		public string NeptunCode { get; set; }

		/// <summary>
		/// Gets or sets the email address of the user.
		/// </summary>
		[ServerVariable( "HTTP_EMAIL" )]
		public string Email { get; set; }

		/// <summary>
		/// Gets or sets the persistent, unique, internal identifier of the user.
		/// </summary>
		[SuppressMessage( "Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "ID", Justification = "Our coding standard." )]
		[ServerVariable( "HTTP_EPPN" )]
		public string PersistentID { get; set; }

		/// <summary>
		/// Gets or sets the first name of the user.
		/// </summary>
		[ServerVariable( "HTTP_SURNAME" )]
		public string FirstName { get; set; }

		/// <summary>
		/// Gets or sets the last name of the user.
		/// </summary>
		[ServerVariable( "HTTP_GIVENNAME" )]
		public string LastName { get; set; }

		/// <summary>
		/// Gets or sets the login name of the user.
		/// </summary>
		[SuppressMessage( "Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login", Justification = "Our naming standard." )]
		[ServerVariable( "HTTP_REMOTEUSER" )]
		public string LoginName { get; set; }

		/// <summary>
		/// Gets or sets the affiliation, which determines the permissions (student, supervisor etc.) of the user.
		/// </summary>
		[ServerVariable( "HTTP_AFFILIATION" )]
		public string Affiliation { get; set; }

		/// <summary>
		/// Gets or sets the semicolon (;) separated list of course codes that were ever listened by the user.
		/// </summary>
		[ServerVariable( "HTTP_NIIFEDUPERSONARCHIVECOURSE" )]
		public string ArchiveCourse { get; set; }

		/// <summary>
		/// Gets or sets the semicolon (;) separated list of course codes that are taught by the user.
		/// </summary>
		[ServerVariable( "HTTP_NIIFEDUPERSONHELDCOURSE" )]
		public string HeldCourse { get; set; }

		/// <summary>
		/// Gets or sets the semicolon (;) separated list of course codes that are listened by the user in this semester.
		/// </summary>
		[ServerVariable( "HTTP_NIIFEDUPERSONATTENDEDCOURSE " )]
		public string AttendedCourse { get; set; }

		/// <summary>
		/// Gets or sets the name of the organization unit (department) the supervisor user belongs to.
		/// </summary>
		[ServerVariable( "HTTP_OU" )]
		public string DepartmentIdentifier { get; set; }


		/// <summary>
		/// Stores the parsed values of the <see cref="Affiliation"/> property.
		/// </summary>
		/// <remarks>
		/// Don't forget to call the <c>EnsureAffiliations</c> method to fill this field.
		/// </remarks>
		private string[] affiliations;


		/// <summary>
		/// Gets a value indicating whether the current user is a student.
		/// </summary>
		/// <value><c>True</c> if the user is a student; otherwise, <c>false</c>.</value>
		public bool IsStudent
		{
			get
			{
				this.EnsureAffiliations();
				return this.affiliations != null && this.affiliations.Contains( "student@bme.hu" );
			}
		}


		/// <summary>
		/// Gets a value indicating whether the current user is a supervisor staff member.
		/// </summary>
		/// <value><c>True</c> if the user is a supervisor staff member; otherwise, <c>false</c>.</value>
		public bool IsSupervisor
		{
			get
			{
				this.EnsureAffiliations();
				return this.affiliations != null && ( this.affiliations.Contains( "faculty@bme.hu" ) || this.affiliations.Contains( "staff@bme.hu" ) || this.affiliations.Contains( "employee@bme.hu" ) );
			}
		}


		/// <summary>
		/// Creates a new <see cref="ShibbolethToken"/> from the current values of the HTTP server variables.
		/// </summary>
		/// <returns></returns>
		public static ShibbolethToken CreateCurrent()
		{
			// Get all server variables.
			NameValueCollection vars = HttpContext.Current.Request.ServerVariables;

			// Create a new token and set its properties using the attached ServerVariable attributes.
			ShibbolethToken token = new ShibbolethToken();
			PropertyInfo[] properties = token.GetType().GetProperties();
			foreach( PropertyInfo property in properties )
			{
				ServerVariableAttribute attr = property.GetCustomAttribute<ServerVariableAttribute>();
				if( attr != null )
				{
					string value = vars[ attr.Name ];
					if( !String.IsNullOrEmpty( value ) )
					{
						property.SetValue( token, value );
					}
				}
			}

			return token;
		}


		/// <summary>
		/// Parses the value in the <see cref="Affiliation"/> property and fills the <see cref="affiliations"/> field if necessary.
		/// </summary>
		private void EnsureAffiliations()
		{
			if( this.affiliations == null && !String.IsNullOrEmpty( this.Affiliation ) )
			{
				this.affiliations = this.Affiliation.Split( ';' );
			}
		}

	}
}

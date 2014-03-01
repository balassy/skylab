namespace Skylab.Core.Security
{
	using System;

	/// <summary>
	/// Defines the name of the HTTP server variable that holds the value for the property.
	/// </summary>
	[AttributeUsage( AttributeTargets.Property, AllowMultiple = false, Inherited = false )]
	public sealed class ServerVariableAttribute : Attribute
	{
		/// <summary>
		/// Gets the name of the server variable that contains the value for the property this attribute is attached to.
		/// </summary>
		public string Name { get; private set; }


		/// <summary>
		/// Initializes a new instance of the <see cref="ServerVariableAttribute"/> class.
		/// </summary>
		/// <param name="name">The name of the server variable that contains the value for the property this attribute is attached to.</param>
		public ServerVariableAttribute( string name )
		{
			this.Name = name;
		}
	}
}

using System;
using System.Diagnostics;
using System.Globalization;
using System.Web;

namespace Skylab.Core
{
	public static class Log
	{
		/// <summary>
		/// Writes a new information level message into the event log.
		/// </summary>
		/// <param name="message">The message to write to the log.</param>
		public static void WriteInfo( string message )
		{
			Log.Write( TraceEventType.Information, message );
		}


		/// <summary>
		/// Writes a new information level message into the event log.
		/// </summary>
		/// <param name="format">A composite format string of the message.</param>
		/// <param name="args">An object array that contains zero or more objects to format into the message.</param>
		public static void WriteInfo( string format, params object[] args )
		{
			string message = String.Format( CultureInfo.InvariantCulture, format, args );
			Log.Write( TraceEventType.Information, message );
		}


		/// <summary>
		/// Writes a new warning level message into the event log.
		/// </summary>
		/// <param name="message">The message to write to the log.</param>
		public static void WriteWarning( string message )
		{
			Log.Write( TraceEventType.Warning, message );
		}


		/// <summary>
		/// Writes a new warning level message into the event log.
		/// </summary>
		/// <param name="format">A composite format string of the message.</param>
		/// <param name="args">An object array that contains zero or more objects to format into the message.</param>
		public static void WriteWarning( string format, params object[] args )
		{
			string message = String.Format( CultureInfo.InvariantCulture, format, args );
			Log.Write( TraceEventType.Warning, message );
		}


		/// <summary>
		/// Writes a new error level message into the event log.
		/// </summary>
		/// <param name="message">The message to write to the log.</param>
		public static void WriteError( string message )
		{
			Log.Write( TraceEventType.Error, message );
		}


		/// <summary>
		/// Writes a new error level message into the event log.
		/// </summary>
		/// <param name="format">A composite format string of the message.</param>
		/// <param name="args">An object array that contains zero or more objects to format into the message.</param>
		public static void WriteError( string format, params object[] args )
		{
			string message = String.Format( CultureInfo.InvariantCulture, format, args );
			Log.Write( TraceEventType.Error, message );
		}


		/// <summary>
		/// Writes the message of the specified <paramref name="exception"/> as an error event to the log.
		/// </summary>
		/// <param name="exception">The exception to write to the log.</param>
		public static void WriteError( Exception exception )
		{
			// Do nothing if there is no exception to log.
			if( exception == null )
			{
				return;
			}
			
			Log.Write( TraceEventType.Error, exception.Message );
		}


		/// <summary>
		/// Writes the full <paramref name="exception"/> as an error event to the log.
		/// </summary>
		/// <param name="exception">The exception to write to the log.</param>
		public static void WriteException( Exception exception )
		{
			// Do nothing if there is no exception to log.
			if( exception == null )
			{
				return;
			}

			Log.Write( TraceEventType.Error, exception.ToString() );
		}


		/// <summary>
		/// Writes the specified message to the event log.
		/// </summary>
		/// <param name="eventType">The severity level of the event.</param>
		/// <param name="message">The message of the event.</param>
		private static void Write( TraceEventType eventType, string message )
		{
			// Do nothing if there is no message to write into the log.
			if( String.IsNullOrEmpty( message ) )
			{
				return;
			}

			string timestamp = DateTime.Now.ToString( "yyyy.MM.dd. HH:mm:ss", CultureInfo.CurrentCulture );
			string client = HttpContext.Current.Request.UserHostAddress;
			string level = eventType.ToString();

			string line = String.Format( CultureInfo.InvariantCulture, "{0}\t{1,-17}\t{2,-12}\t{3}", timestamp, client, level, message );
			Trace.WriteLine( line );
		}
	}
}

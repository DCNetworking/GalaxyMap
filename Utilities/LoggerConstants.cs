using System;
using Serilog;

namespace GalaxyMap.Utilities
{
    /// <summary>
    /// Provides constants related to logging.
    /// </summary>
    public static class LoggerConstants
    {
        /// <summary>
        /// The template used for formatting log messages.
        /// </summary>
        public const string LoggerTemplate = "[{Timestamp:HH:mm:ss} {Level:u3}] IP: {IpAddress} | OS: {System} |[{Level:u3}] {Message:lj}{NewLine}{Exception}";

        /// <summary>
        /// The file name of the log file.
        /// </summary>
        public const string LoggerFileName = "log.txt";

        /// <summary>
        /// Handles the ProcessExit event of the CurrentDomain and logs a message when the application is about to end.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        public static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            // Log a message when the application is about to end
            Log.Information("Application is shutting down");
        }
    }
}
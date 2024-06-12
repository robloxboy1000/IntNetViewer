using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace IntNetViewer
{
    internal static class Program
    {
        

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Add the event handler for handling UI thread exceptions
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);

            // Add the event handler for handling non-UI thread exceptions
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
        // Event handler for UI thread exceptions
        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            HandleException(e.Exception);
        }

        // Event handler for non-UI thread exceptions
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            HandleException(e.ExceptionObject as Exception);
        }

        // Method to handle exceptions
        static void HandleException(Exception ex)
        {
            if (ex != null)
            {
                // Log the exception, show a message box, or perform other error handling
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (ex is InvalidOperationException)
                {
                    // Log the serious error if necessary

                    // Exit the application immediately
                    Environment.FailFast("Critical application error", ex);
                }
                // For serious errors, consider exiting the application
                // Application.Exit();
            }
        }
    }
}

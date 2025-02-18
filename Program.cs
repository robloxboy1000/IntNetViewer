using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace IntNetViewer
{
    internal static class Program
    {

        [DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        [DllImport("kernel32.dll")]
        private static extern bool AttachConsole(int dwProcessId);

        private const int ATTACH_PARENT_PROCESS = -1;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // bool isConsoleMode = false;

            // Attach to existing console if run from CMD, otherwise create a new one
            if (AttachConsole(ATTACH_PARENT_PROCESS))
            {
                //isConsoleMode = true;
            }
            else
            {
                AllocConsole();
                //isConsoleMode = true;
            }
            // Add the event handler for handling UI thread exceptions
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            // Add the event handler for handling non-UI thread exceptions
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            
            if (args.Length > 0)
            {
                if (args[0] == "--version" || args[0] == "-i")
                {
                    ShowVersion();
                    return;
                }
                else if (args[0] == "--help" || args[0] == "-h")
                {
                    ShowUsage();
                    return;
                }
                else if (args[0] == "--verbose" || args[0] == "-v")
                {
                    AllocConsole(); // Attach a new console window
                    Console.WriteLine("Verbose mode enabled.");
                }
                
            }
            if (args.Length == 0)
            {
                Console.WriteLine("No arguments were provided.");
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow(args));

            // Optional: Keep console open if running in console mode
            // if (isConsoleMode)
            // {
            //     Console.WriteLine("Press any key to exit...");
            //     Console.ReadKey();
            // }


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
                if (ex is NotImplementedException)
                {
                    MessageBox.Show("This feature is not implemented yet.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // Log the exception, show a message box, or perform other error handling
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (ex is InvalidOperationException)
                {
                    // Log the serious error if necessary

                    // Exit the application immediately
                    
                    Application.Exit();
                }
                // For serious errors, consider exiting the application
                // Application.Exit();
            }
            
        }

        static void ShowUsage()
        {
            Console.WriteLine($"IntNetViewer {Application.ProductVersion}");
            Console.WriteLine("Usage: int.exe [options]");
            Console.WriteLine("Options:");
            Console.WriteLine("  --version, -i       Show version information");
            Console.WriteLine("  --help, -h          Show this help message");
            Console.WriteLine("  --console, -v       use AllocConsole() to show Console.WriteLine()'s and CEF console in a command window");
        }

        static void ShowVersion()
        {
            Console.WriteLine($"IntNetViewer {Application.ProductVersion}");
        }
    }


    public static class WindowManager
    {
        public static int OpenWindows = 0;
    }
}

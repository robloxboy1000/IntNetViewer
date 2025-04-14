using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;
using System.Runtime.ExceptionServices;


namespace IntNetViewer
{
    internal static class Program
    {
        private static readonly string errorLinesFilePath = "errorlines.txt";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Assembly.LoadFrom(Application.StartupPath+"/CefSharp.Core.Runtime.dll");
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            AppDomain.CurrentDomain.FirstChanceException += FirstChanceException;

            // Add the event handler for handling UI thread exceptions
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            // Add the event handler for handling non-UI thread exceptions
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());


        }
        static string GetRandomErrorString()
        {
            string[] errorLines = File.ReadAllLines(errorLinesFilePath);
            Random rand = new Random();
            return errorLines[rand.Next(0, errorLines.Length)];
        }
        static void FirstChanceException(object sender, FirstChanceExceptionEventArgs e)
        {
            Console.WriteLine(e.Exception.Message);
            if (e.Exception is System.IO.FileNotFoundException fnfEx)
            {
                File.AppendAllText("AssemblyBindingLog.txt", fnfEx.ToString() + Environment.NewLine);
            }
        }
        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            
            try
            {
                string assemblyPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, new AssemblyName(args.Name).Name + ".dll");
#if DEBUG
                Console.WriteLine($"Attempting to load {args.Name}, {assemblyPath}");
#endif

                if (!File.Exists(assemblyPath))
                {
#if DEBUG
                    Console.WriteLine($"Assembly not found: {assemblyPath}");
#endif
                    return null;
                }
                return File.Exists(assemblyPath) ? Assembly.LoadFile(assemblyPath) : null;
                
            }
            catch (Exception
            #if DEBUG
            ex
            #endif
            )

            {
#if DEBUG
                Console.WriteLine($"Error loading assembly: {ex.Message}");
#endif
                return null;
            }

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
                    MessageBox.Show($"This feature is not implemented yet.\r\n{ex.Message}", GetRandomErrorString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // Log the exception, show a message box, or perform other error handling
                else if (ex is FileNotFoundException)
                {
                    MessageBox.Show($"An important file was not found.\r\n{ex.Message}", GetRandomErrorString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex is DllNotFoundException)
                {
                    MessageBox.Show($"A required library was not found.\r\n{ex.Message}", GetRandomErrorString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex is InvalidOperationException)
                {
                    // Log the serious error if necessary

                    // Exit the application immediately

                    Application.Exit();
                }
                else
                {
                    // Any other exception
                    // Log the exception, display it, etc
                    MessageBox.Show($"An unexpected error occurred: \r\n{ex.Message}", GetRandomErrorString(), MessageBoxButtons.OK, MessageBoxIcon.Error);

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
            Console.WriteLine("  --noconsole, -nc    Disable showing console at launch (broken)");
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

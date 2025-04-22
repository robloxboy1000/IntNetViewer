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
using System.Windows.Forms.Design;


namespace IntNetViewer
{
    internal static class Program
    {
        private static readonly string errorLinesFilePath = "errorlines.txt";
        public static bool noCef = false;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (Environment.OSVersion.Version.Major < 10)
            {
                MessageBox.Show("This application requires Windows 10 or higher.\r\nTo bypass this error, open with \"--nocef\" in CMD.", GetRandomErrorString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Check if the application is already running
            if (System.Diagnostics.Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                MessageBox.Show("The application is already running.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (args.Contains("--nocef"))
            {
                Console.WriteLine("CEFSharp will not be initialized. Use only for debugging.");
                MessageBox.Show("CEFSharp will not be initialized. Use only for debugging.", "Debug Mode", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                noCef = true;
            }
            else
            {
                Console.WriteLine("Debug mode disabled.");
            }
            string[] dlls = Directory.GetFiles(Application.StartupPath, "*.dll", SearchOption.TopDirectoryOnly);
            foreach (string dll in dlls)
            {
                
                if (noCef)
                {
                    if (dll.Contains("CefSharp.dll"))
                    {
                        // dont load
                    }
                    else if (dll.Contains("CefSharp.Core.dll"))
                    {
                        // dont load
                    }
                    else if (dll.Contains("CefSharp.WinForms.dll"))
                    {
                        // dont load
                    }
                    else if (dll.Contains("CefSharp.BrowserSubprocess.Core.dll"))
                    {
                        // dont load
                    }
                    else if (dll.Contains("CefSharp.Core.Runtime.dll"))
                    {
                        // dont load
                    }
                    // These are loaded by CEF, no need to preload
                    else if (dll.Contains("chrome_elf.dll"))
                    {
                        // dont load
                    }
                    else if (dll.Contains("d3dcompiler_47.dll"))
                    {
                        // dont load
                    }
                    else if (dll.Contains("dxcompiler.dll"))
                    {
                        // dont load
                    }
                    else if (dll.Contains("dxil.dll"))
                    {
                        // dont load
                    }
                    else if (dll.Contains("libcef.dll"))
                    {
                        // dont load
                    }
                    else if (dll.Contains("libEGL.dll"))
                    {
                        // dont load
                    }
                    else if (dll.Contains("libGLESv2.dll"))
                    {
                        // dont load
                    }
                    else if (dll.Contains("vk_swiftshader.dll"))
                    {
                        // dont load
                    }
                    else if (dll.Contains("vulkan-1.dll"))
                    {
                        // dont load
                    }
                    else
                    {
                        Console.WriteLine($"Loading " + dll);
                        try
                        {
                            Assembly.LoadFrom(dll);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error occurred while loading assembly.\r\n{ex.Message}", GetRandomErrorString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Console.WriteLine($"Error loading assembly: {ex.Message}");
                        }
                    }
                }
                // Load other required DLLs
                else
                {
                    // These are loaded by CEF, no need to preload
                    if (dll.Contains("chrome_elf.dll"))
                    {
                        // dont load
                    }
                    else if (dll.Contains("d3dcompiler_47.dll"))
                    {
                        // dont load
                    }
                    else if (dll.Contains("dxcompiler.dll"))
                    {
                        // dont load
                    }
                    else if (dll.Contains("dxil.dll"))
                    {
                        // dont load
                    }
                    else if (dll.Contains("libcef.dll"))
                    {
                        // dont load
                    }
                    else if (dll.Contains("libEGL.dll"))
                    {
                        // dont load
                    }
                    else if (dll.Contains("libGLESv2.dll"))
                    {
                        // dont load
                    }
                    else if (dll.Contains("vk_swiftshader.dll"))
                    {
                        // dont load
                    }
                    else if (dll.Contains("vulkan-1.dll"))
                    {
                        // dont load
                    }
                    else
                    {
                        Console.WriteLine($"Loading " + dll);
                        try
                        {
                            Assembly.LoadFrom(dll);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error occurred while loading assembly.\r\n{ex.Message}", GetRandomErrorString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Console.WriteLine($"Error loading assembly: {ex.Message}");
                        }
                    }
                        
                }
                
            }
            
            // AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
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
                    MessageBox.Show($"An invalid operation was attempted.\r\n{ex.Message}", GetRandomErrorString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    System.Environment.Exit(1);
                }
                else if (ex is System.IO.FileLoadException)
                {
                    MessageBox.Show($"An error occurred while loading a file.\r\n{ex.Message}", GetRandomErrorString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Any other exception
                    // Log the exception, display it, etc
                    MessageBox.Show($"An unexpected error occurred: \r\n{ex.Message}", GetRandomErrorString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            
        }

        


    }


    public static class WindowManager
    {
        public static int OpenWindows = 0;
    }
}

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Windows.Forms;


namespace IntNetViewer
{
    internal static class Program
    {
        private static readonly string errorLinesFilePath = "errorlines.txt";
        public static bool noCef = false;
        public static bool debug = false;
        public static string urlArg;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // Check if the application is already running
            if (System.Diagnostics.Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                MessageBox.Show("The application is already running.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                try
                {
                    Console.WriteLine($"Arguments: {args.Length}");
                    for (int i = 0; i < args.Length; i++)
                    {
                        Console.WriteLine($"Arg[{i}] = [{args[i]}]");
                    }
                    if (args.Length > 0)
                    {
                        
                        // http url
                        if (args[0].StartsWith("http"))
                        {
                            urlArg = args[0];
                        }

                        // noCef
                        
                        if (args[0].StartsWith("--nocef"))
                        {
                            Console.WriteLine("CEFSharp will not be initialized. Use only for debugging.");
                            MessageBox.Show("CEFSharp will not be initialized.", "No Cef Mode", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            noCef = true;
                        }
                        else
                        {

                        }

                        if (args.Length > 1)
                        {
                            if (args[1].StartsWith("--nocef"))
                            {
                                Console.WriteLine("CEFSharp will not be initialized. Use only for debugging.");
                                MessageBox.Show("CEFSharp will not be initialized.", "No Cef Mode", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                noCef = true;
                            }
                            else
                            {

                            }
                        }
                        if (args.Length > 2)
                        {
                            if (args[2].StartsWith("--nocef"))
                            {
                                Console.WriteLine("CEFSharp will not be initialized. Use only for debugging.");
                                MessageBox.Show("CEFSharp will not be initialized.", "No Cef Mode", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                noCef = true;
                            }
                            else
                            {

                            }
                        }
                        if (args.Length > 3)
                        {
                            if (args[3].StartsWith("--nocef"))
                            {
                                Console.WriteLine("CEFSharp will not be initialized. Use only for debugging.");
                                MessageBox.Show("CEFSharp will not be initialized.", "No Cef Mode", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                noCef = true;
                            }
                            else
                            {

                            }
                        }



                        // debug
                        if (args[0].StartsWith("--debug"))
                        {
                            Console.WriteLine("Debug mode enabled.");
                            MessageBox.Show("Debug mode enabled.", "Debug Mode", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            debug = true;
                        }
                        else
                        {

                        }

                        if (args.Length > 1)
                        {
                            if (args[1].StartsWith("--debug"))
                            {
                                Console.WriteLine("Debug mode enabled.");
                                MessageBox.Show("Debug mode enabled.", "Debug Mode", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                debug = true;
                            }
                            else
                            {

                            }
                        }
                        if (args.Length > 2)
                        {
                            if (args[2].StartsWith("--debug"))
                            {
                                Console.WriteLine("Debug mode enabled.");
                                MessageBox.Show("Debug mode enabled.", "Debug Mode", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                debug = true;
                            }
                            else
                            {

                            }
                        }
                        if (args.Length > 3)
                        {
                            if (args[3].StartsWith("--debug"))
                            {
                                Console.WriteLine("Debug mode enabled.");
                                MessageBox.Show("Debug mode enabled.", "Debug Mode", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                debug = true;
                            }
                            else
                            {

                            }
                        }




                        // usage
                        if (args[0].StartsWith("--usage"))
                        {
                            if (Process.GetCurrentProcess().ProcessName != "int-noconsole")
                            {
                                Console.Write("IntNetViewer is a simple web browser based on CEFSharp.\r\nUsage: int-noconsole.exe [--nocef|--debug|--usage|--help|/?]\r\n--nocef - Uses IE instead of CEFSharp.\r\n--debug - Enables debug mode.\r\n--usage/--help/\"/?\" - Shows this usage message.");
                                return;
                            }
                            else
                            {
                                MessageBox.Show("IntNetViewer is a simple web browser based on CEFSharp.\r\nUsage: int.exe [--nocef|--debug|--usage|--help|/?]\r\n--nocef - Uses IE instead of CEFSharp.\r\n--debug - Enables debug mode.\r\n--usage/--help/\"/?\" - Shows this usage message.", "Usage", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        else
                        {

                        }

                        if (args.Length > 1)
                        {
                            if (args[1].StartsWith("--usage"))
                            {
                                if (Process.GetCurrentProcess().ProcessName != "int-noconsole")
                                {
                                    Console.Write("IntNetViewer is a simple web browser based on CEFSharp.\r\nUsage: int-noconsole.exe [--nocef|--debug|--usage|--help|/?]\r\n--nocef - Uses IE instead of CEFSharp.\r\n--debug - Enables debug mode.\r\n--usage/--help/\"/?\" - Shows this usage message.");
                                    return;
                                }
                                else
                                {
                                    MessageBox.Show("IntNetViewer is a simple web browser based on CEFSharp.\r\nUsage: int.exe [--nocef|--debug|--usage|--help|/?]\r\n--nocef - Uses IE instead of CEFSharp.\r\n--debug - Enables debug mode.\r\n--usage/--help/\"/?\" - Shows this usage message.", "Usage", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                            else
                            {

                            }
                        }
                        if (args.Length > 2)
                        {
                            if (args[2].StartsWith("--usage"))
                            {
                                if (Process.GetCurrentProcess().ProcessName != "int-noconsole")
                                {
                                    Console.Write("IntNetViewer is a simple web browser based on CEFSharp.\r\nUsage: int-noconsole.exe [--nocef|--debug|--usage|--help|/?]\r\n--nocef - Uses IE instead of CEFSharp.\r\n--debug - Enables debug mode.\r\n--usage/--help/\"/?\" - Shows this usage message.");
                                    return;
                                }
                                else
                                {
                                    MessageBox.Show("IntNetViewer is a simple web browser based on CEFSharp.\r\nUsage: int.exe [--nocef|--debug|--usage|--help|/?]\r\n--nocef - Uses IE instead of CEFSharp.\r\n--debug - Enables debug mode.\r\n--usage/--help/\"/?\" - Shows this usage message.", "Usage", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                            else
                            {

                            }
                        }
                        if (args.Length > 3)
                        {
                            if (args[3].StartsWith("--usage"))
                            {
                                if (Process.GetCurrentProcess().ProcessName != "int-noconsole")
                                {
                                    Console.Write("IntNetViewer is a simple web browser based on CEFSharp.\r\nUsage: int-noconsole.exe [--nocef|--debug|--usage|--help|/?]\r\n--nocef - Uses IE instead of CEFSharp.\r\n--debug - Enables debug mode.\r\n--usage/--help/\"/?\" - Shows this usage message.");
                                    return;
                                }
                                else
                                {
                                    MessageBox.Show("IntNetViewer is a simple web browser based on CEFSharp.\r\nUsage: int.exe [--nocef|--debug|--usage|--help|/?]\r\n--nocef - Uses IE instead of CEFSharp.\r\n--debug - Enables debug mode.\r\n--usage/--help/\"/?\" - Shows this usage message.", "Usage", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                            else
                            {

                            }
                        }





                        // help
                        if (args[0].StartsWith("--help"))
                        {
                            if (Process.GetCurrentProcess().ProcessName != "int-noconsole")
                            {
                                Console.Write("IntNetViewer is a simple web browser based on CEFSharp.\r\nUsage: int-noconsole.exe [--nocef|--debug|--usage|--help|/?]\r\n--nocef - Uses IE instead of CEFSharp.\r\n--debug - Enables debug mode.\r\n--usage/--help/\"/?\" - Shows this usage message.");
                                return;
                            }
                            else
                            {
                                MessageBox.Show("IntNetViewer is a simple web browser based on CEFSharp.\r\nUsage: int.exe [--nocef|--debug|--usage|--help|/?]\r\n--nocef - Uses IE instead of CEFSharp.\r\n--debug - Enables debug mode.\r\n--usage/--help/\"/?\" - Shows this usage message.", "Usage", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        else
                        {

                        }

                        if (args.Length > 1)
                        {
                            if (args[1].StartsWith("--help"))
                            {
                                if (Process.GetCurrentProcess().ProcessName != "int-noconsole")
                                {
                                    Console.Write("IntNetViewer is a simple web browser based on CEFSharp.\r\nUsage: int-noconsole.exe [--nocef|--debug|--usage|--help|/?]\r\n--nocef - Uses IE instead of CEFSharp.\r\n--debug - Enables debug mode.\r\n--usage/--help/\"/?\" - Shows this usage message.");
                                    return;
                                }
                                else
                                {
                                    MessageBox.Show("IntNetViewer is a simple web browser based on CEFSharp.\r\nUsage: int.exe [--nocef|--debug|--usage|--help|/?]\r\n--nocef - Uses IE instead of CEFSharp.\r\n--debug - Enables debug mode.\r\n--usage/--help/\"/?\" - Shows this usage message.", "Usage", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                            else
                            {

                            }
                        }
                        if (args.Length > 2)
                        {
                            if (args[2].StartsWith("--help"))
                            {
                                if (Process.GetCurrentProcess().ProcessName != "int-noconsole")
                                {
                                    Console.Write("IntNetViewer is a simple web browser based on CEFSharp.\r\nUsage: int-noconsole.exe [--nocef|--debug|--usage|--help|/?]\r\n--nocef - Uses IE instead of CEFSharp.\r\n--debug - Enables debug mode.\r\n--usage/--help/\"/?\" - Shows this usage message.");
                                    return;
                                }
                                else
                                {
                                    MessageBox.Show("IntNetViewer is a simple web browser based on CEFSharp.\r\nUsage: int.exe [--nocef|--debug|--usage|--help|/?]\r\n--nocef - Uses IE instead of CEFSharp.\r\n--debug - Enables debug mode.\r\n--usage/--help/\"/?\" - Shows this usage message.", "Usage", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                            else
                            {

                            }
                        }
                        if (args.Length > 3)
                        {
                            if (args[3].StartsWith("--help"))
                            {
                                if (Process.GetCurrentProcess().ProcessName != "int-noconsole")
                                {
                                    Console.Write("IntNetViewer is a simple web browser based on CEFSharp.\r\nUsage: int-noconsole.exe [--nocef|--debug|--usage|--help|/?]\r\n--nocef - Uses IE instead of CEFSharp.\r\n--debug - Enables debug mode.\r\n--usage/--help/\"/?\" - Shows this usage message.");
                                    return;
                                }
                                else
                                {
                                    MessageBox.Show("IntNetViewer is a simple web browser based on CEFSharp.\r\nUsage: int.exe [--nocef|--debug|--usage|--help|/?]\r\n--nocef - Uses IE instead of CEFSharp.\r\n--debug - Enables debug mode.\r\n--usage/--help/\"/?\" - Shows this usage message.", "Usage", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                            else
                            {

                            }
                        }


                        // /?
                        if (args[0].StartsWith("/?"))
                        {
                            if (Process.GetCurrentProcess().ProcessName != "int-noconsole")
                            {
                                Console.Write("IntNetViewer is a simple web browser based on CEFSharp.\r\nUsage: int-noconsole.exe [--nocef|--debug|--usage|--help|/?]\r\n--nocef - Uses IE instead of CEFSharp.\r\n--debug - Enables debug mode.\r\n--usage/--help/\"/?\" - Shows this usage message.");
                                return;
                            }
                            else
                            {
                                MessageBox.Show("IntNetViewer is a simple web browser based on CEFSharp.\r\nUsage: int.exe [--nocef|--debug|--usage|--help|/?]\r\n--nocef - Uses IE instead of CEFSharp.\r\n--debug - Enables debug mode.\r\n--usage/--help/\"/?\" - Shows this usage message.", "Usage", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        else
                        {

                        }

                        if (args.Length > 1)
                        {
                            if (args[1].StartsWith("/?"))
                            {
                                if (Process.GetCurrentProcess().ProcessName != "int-noconsole")
                                {
                                    Console.Write("IntNetViewer is a simple web browser based on CEFSharp.\r\nUsage: int-noconsole.exe [--nocef|--debug|--usage|--help|/?]\r\n--nocef - Uses IE instead of CEFSharp.\r\n--debug - Enables debug mode.\r\n--usage/--help/\"/?\" - Shows this usage message.");
                                    return;
                                }
                                else
                                {
                                    MessageBox.Show("IntNetViewer is a simple web browser based on CEFSharp.\r\nUsage: int.exe [--nocef|--debug|--usage|--help|/?]\r\n--nocef - Uses IE instead of CEFSharp.\r\n--debug - Enables debug mode.\r\n--usage/--help/\"/?\" - Shows this usage message.", "Usage", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                            else
                            {

                            }
                        }
                        if (args.Length > 2)
                        {
                            if (args[2].StartsWith("/?"))
                            {
                                if (Process.GetCurrentProcess().ProcessName != "int-noconsole")
                                {
                                    Console.Write("IntNetViewer is a simple web browser based on CEFSharp.\r\nUsage: int-noconsole.exe [--nocef|--debug|--usage|--help|/?]\r\n--nocef - Uses IE instead of CEFSharp.\r\n--debug - Enables debug mode.\r\n--usage/--help/\"/?\" - Shows this usage message.");
                                    return;
                                }
                                else
                                {
                                    MessageBox.Show("IntNetViewer is a simple web browser based on CEFSharp.\r\nUsage: int.exe [--nocef|--debug|--usage|--help|/?]\r\n--nocef - Uses IE instead of CEFSharp.\r\n--debug - Enables debug mode.\r\n--usage/--help/\"/?\" - Shows this usage message.", "Usage", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                            else
                            {

                            }
                        }
                        if (args.Length > 3)
                        {
                            if (args[3].StartsWith("/?"))
                            {
                                if (Process.GetCurrentProcess().ProcessName != "int-noconsole")
                                {
                                    Console.Write("IntNetViewer is a simple web browser based on CEFSharp.\r\nUsage: int-noconsole.exe [--nocef|--debug|--usage|--help|/?]\r\n--nocef - Uses IE instead of CEFSharp.\r\n--debug - Enables debug mode.\r\n--usage/--help/\"/?\" - Shows this usage message.");
                                    return;
                                }
                                else
                                {
                                    MessageBox.Show("IntNetViewer is a simple web browser based on CEFSharp.\r\nUsage: int.exe [--nocef|--debug|--usage|--help|/?]\r\n--nocef - Uses IE instead of CEFSharp.\r\n--debug - Enables debug mode.\r\n--usage/--help/\"/?\" - Shows this usage message.", "Usage", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                            else
                            {

                            }
                        }
                        
                    }

                    else
                    {
                        if (Environment.OSVersion.Version.Major < 10)
                        {
                            MessageBox.Show("This application requires Windows 10 or higher.\r\nTo bypass this error, open with \"--nocef\" in CMD.", GetRandomErrorString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else if (Environment.OSVersion.Version.Major >= 10)
                        {
                            noCef = false;
                        }
                        urlArg = "";
                        Console.WriteLine("Debug mode disabled.");
                        
                    }
                    // Check for CefSharp libraries if not in noCef mode
                    if (!noCef)
                    {
                        if (!AreCefSharpLibrariesLoaded())
                        {
                            MessageBox.Show("CEFSharp libraries are missing or not loaded. Please ensure CefSharp is installed or run with --nocef.", GetRandomErrorString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    

                    AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
                    AppDomain.CurrentDomain.FirstChanceException += FirstChanceException;
                    // Add the event handler for handling UI thread exceptions
                    Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
                    // Add the event handler for handling non-UI thread exceptions
                    AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
                    Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainWindow(urlArg));
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }

            }

        }
        public static void WriteToLog(string message)
        {
            try
            {
                File.AppendAllText("log.txt", $"{DateTime.Now}: {message}{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to log: {ex.Message}");
            }
        }
        static string FindFile(string path)
        {
            string[] files = Directory.GetFiles("C:\\");
            foreach (string file in files)
            {
                if (File.Exists(path))
                {
                    if (VerifyFileIntegrity(file, GetFileHash(path)))
                    {
                        Console.WriteLine($"Found file: {file}");

                        return file;
                    }
                    else
                    {
                        Console.WriteLine($"File integrity check failed for: {file}");

                    }

                }

            }
            return null;
        }
        static bool VerifyFileIntegrity(string path, string origHash)
        {
            string fileHash = GetFileHash(path);
            if (fileHash == origHash)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static string GetFileHash(string path)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                try
                {
                    using (var stream = File.OpenRead(path))
                    {
                        var hash = sha256.ComputeHash(stream);
                        return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                    }
                }
                catch (Exception ex)
                {
                    if (ex is UnauthorizedAccessException || ex is FileNotFoundException)
                    {
                        Console.WriteLine($"File not found or access denied: {path}");

                        return null;
                    }
                    else
                    {
                        Console.WriteLine($"Error calculating hash for file {path}: {ex.Message}");

                        return null;
                    }

                }
            }
        }
        static string GetRandomErrorString()
        {
            string[] errorLines = File.ReadAllLines(errorLinesFilePath);
            Random rand = new Random();
            return errorLines[rand.Next(0, errorLines.Length)];
        }
        static void FirstChanceException(object sender, FirstChanceExceptionEventArgs e)
        {
            string exeptionType = e.Exception.ToString() + ": ";
            if (e.Exception == null || e.Exception.ToString() == "")
            {
                exeptionType = "Unknown Exception: ";
            }
            Console.WriteLine(e.Exception.Message);

            File.AppendAllText("ExecptionLog.txt", exeptionType + e.Exception.Message + Environment.NewLine);

        }

        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            //Console.WriteLine($"Resolving assembly: {args.Name}");
            string foundAssembly = null;
            // Search for the assembly in the current directory
            string assemblyPath = Path.Combine(Application.StartupPath, new AssemblyName(args.Name).Name + ".dll");
            if (File.Exists(assemblyPath))
            {
                foundAssembly = assemblyPath;
            }
            else
            {
                //Console.WriteLine($"Assembly not found in current directory: {assemblyPath}");
                // Search in the subdirectories
                string[] dlls = Directory.GetFiles(Application.StartupPath, "*.dll", SearchOption.AllDirectories);
                foreach (string dll in dlls)
                {
                    if (dll.EndsWith(new AssemblyName(args.Name).Name + ".dll"))
                    {
                        foundAssembly = dll;
                        break;
                    }
                    else
                    {

                        //Console.WriteLine($"Assembly not found in subdirectory: {dll}");
                        return null;
                    }
                }
            }
            if (foundAssembly != null)
            {
                try
                {
                    //Console.WriteLine($"Loading assembly from: {foundAssembly}");
                    return Assembly.LoadFrom(foundAssembly);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while loading assembly.\r\n{ex.Message}", GetRandomErrorString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Console.WriteLine($"Error loading assembly: {ex.Message}");
                    return null;
                }
            }
            else
            {
                //Console.WriteLine($"Assembly not found: {args.Name}");
                MessageBox.Show($"Assembly not found: {args.Name}", GetRandomErrorString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

        // Event handler for UI thread exceptions
        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            //HandleException(e.Exception);
        }

        // Event handler for non-UI thread exceptions
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            //HandleException(e.ExceptionObject as Exception);
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
                    MessageBox.Show($"An unexpected error occurred:\r\nType:{ex.GetType()}\r\n{ex.Message}", GetRandomErrorString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }
        public static bool AreCefSharpLibrariesLoaded()
        {
            try
            {
                // Try to load a core CefSharp type via reflection
                var cefSharpCore = AppDomain.CurrentDomain.GetAssemblies()
                    .Any(a => a.GetName().Name.StartsWith("CefSharp", StringComparison.OrdinalIgnoreCase));
                if (cefSharpCore)
                    return true;

                // Try to load by name if not already loaded
                Assembly.Load("CefSharp");
                Assembly.Load("CefSharp.WinForms");
                return true;
            }
            catch
            {
                return false;
            }
        }



    }


    public static class WindowManager
    {
        public static int OpenWindows = 0;
    }
}

using IntNetViewer.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntNetViewer
{
    class Notify
    {
        
        public static void NotifyIcon(string title, string text, Image image, bool isImportant)
        {
            // Convert the image to an Icon
            Icon icon = ConvertImageToIcon(image);
            // Initialize the NotifyIcon
            InitializeNotifyIcon(title, text, icon, isImportant);
        }
        public static Icon ConvertImageToIcon(Image image)
        {
            Bitmap bitmap = new Bitmap(image);
            IntPtr hIcon = bitmap.GetHicon();
            Icon icon = Icon.FromHandle(hIcon);
            return icon;
        }
        public static void InitializeNotifyIcon(string title, string text, Icon icon, bool isImportant)
        {
            var notifyIcon = new NotifyIcon
            {
                Icon = icon, // Set the icon to the application's icon
                Visible = true, // Make the icon visible in the system tray
                BalloonTipTitle = title,
                BalloonTipText = text,
                BalloonTipIcon = ToolTipIcon.None,
                Text = text,
            };
            if (isImportant)
            {
                Console.WriteLine($"notify time will be {int.MaxValue} ms.");
                notifyIcon.ShowBalloonTip(int.MaxValue); // show indefinitely
            }
            else
            {
                Console.WriteLine($"notify time will be 3000 ms.");
                // Show the notification
                notifyIcon.ShowBalloonTip(3000); // Display for 3 seconds
            }
                
        }
    }
}

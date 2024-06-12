using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntNetViewer
{
    public class CustomDownloadHandler : IDownloadHandler
    {
        private ToolStripMenuItem progressBar;
        private ToolStripMenuItem labelDLSpeed;
        private ToolStripMenuItem label2;
        private ToolStripMenuItem label3;
        private ToolStripMenuItem labelDLURL;
        private Form MainWindow;


        public CustomDownloadHandler(ToolStripMenuItem progressBar, ToolStripMenuItem labelDLSpeed, ToolStripMenuItem label2, ToolStripMenuItem label3, ToolStripMenuItem labelDLURL, MainWindow mainWindow)
        {
            this.progressBar = progressBar;
            this.labelDLSpeed = labelDLSpeed;
            this.label2 = label2;
            this.label3 = label3;
            this.labelDLURL = labelDLURL;
            this.MainWindow = mainWindow;
        }

        public bool CanDownload(IWebBrowser chromiumWebBrowser, IBrowser browser, string url, string requestMethod)
        {
            return true;
        }
        public bool OnBeforeDownload(IWebBrowser chromiumWebBrowser, IBrowser browser, DownloadItem downloadItem, IBeforeDownloadCallback callback)
        {
            
            MainWindow.Invoke(new Action(() => { labelDLURL.Text = downloadItem.Url; }));

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = downloadItem.SuggestedFileName;
            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                downloadItem.SuggestedFileName = saveFileDialog.FileName;
                callback.Continue(downloadItem.SuggestedFileName, showDialog: false);
            }
            else
            {
                callback.Dispose();
            }
            return true;
        }
        public void OnDownloadUpdated(IWebBrowser chromiumWebBrowser, IBrowser browser, DownloadItem downloadItem, IDownloadItemCallback callback)
        {

            if (downloadItem.IsComplete)
            {


            }
            else if (downloadItem.IsInProgress)
            {
                int progress = (int)(downloadItem.ReceivedBytes / (float)downloadItem.TotalBytes * 100);
                MainWindow.Invoke(new Action(() =>
                {
                    progressBar.Text = progress.ToString() + "%";
                }));
                if (downloadItem.ReceivedBytes >= 1000000000)
                {
                    MainWindow.Invoke(new Action(() =>
                    {
                        label2.Text = $"{downloadItem.ReceivedBytes / 1000000000.0:F1} GB";
                    }));
                }
                else if (downloadItem.ReceivedBytes >= 1000000)
                {
                    MainWindow.Invoke(new Action(() => { label2.Text = $"{downloadItem.ReceivedBytes / 1000000.0:F1} MB"; }));
                }
                else if (downloadItem.ReceivedBytes >= 1000)
                {
                    MainWindow.Invoke(new Action(() => { label2.Text = $"{downloadItem.ReceivedBytes / 1000.0:F1} KB"; }));
                }
                else
                {
                    MainWindow.Invoke(new Action(() => { label2.Text = $"{downloadItem.ReceivedBytes} B"; }));
                }


                if (downloadItem.TotalBytes >= 1000000000)
                {
                    MainWindow.Invoke(new Action(() => { label3.Text = $"{downloadItem.TotalBytes / 1000000000.0:F1} GB"; }));
                }
                else if (downloadItem.TotalBytes >= 1000000)
                {
                    MainWindow.Invoke(new Action(() => { label3.Text = $"{downloadItem.TotalBytes / 1000000.0:F1} MB"; }));
                }
                else if (downloadItem.TotalBytes >= 1000)
                {
                    MainWindow.Invoke(new Action(() => { label3.Text = $"{downloadItem.TotalBytes / 1000.0:F1} KB"; }));
                }
                else
                {
                    MainWindow.Invoke(new Action(() => { label3.Text = $"{downloadItem.TotalBytes} B"; }));
                }


                labelDLSpeed.Visible = true;
                if (downloadItem.CurrentSpeed >= 1000000000)
                {
                    MainWindow.Invoke(new Action(() => { labelDLSpeed.Text = $"{downloadItem.CurrentSpeed / 1000000000.0:F1} GB/s"; }));
                }
                else if (downloadItem.CurrentSpeed >= 1000000)
                {
                    MainWindow.Invoke(new Action(() => { labelDLSpeed.Text = $"{downloadItem.CurrentSpeed / 1000000.0:F1} MB/s"; }));
                }
                else if (downloadItem.CurrentSpeed >= 1000)
                {
                    MainWindow.Invoke(new Action(() => { labelDLSpeed.Text = $"{downloadItem.CurrentSpeed / 1000.0:F1} KB/s"; }));
                }
                else
                {
                    MainWindow.Invoke(new Action(() => { labelDLSpeed.Text = $"{downloadItem.CurrentSpeed} B/s"; }));
                }

            }
        }
    }
}

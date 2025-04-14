using CefSharp.DevTools.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntNetViewer
{
    public partial class StandaloneDLForm : Form
    {
        public StandaloneDLForm(string url, string destination)
        {
            InitializeComponent();
            StandaloneDownloader downloader = new StandaloneDownloader(lblProgress, progressBar1, this, label2);
            downloader.DownloadFile(url, destination);
        }

    }
    public class StandaloneDownloader
    {
        private ProgressBar progressBar;
        private Label lblProgress;
        private Form form;
        private Label lblFilename;

        public StandaloneDownloader(Label lblProgress, ProgressBar progressBar, Form form, Label lblFileName)
        {
            this.lblProgress = lblProgress;
            this.progressBar = progressBar;
            this.form = form;
            this.lblFilename = lblFileName;
        }
        public async void DownloadFile(string url, string destination)
        {
            
            if (string.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show("Please enter a valid URL!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string fileName = Path.GetFileName(new Uri(url).AbsolutePath); // Extract file name from URL
            destination = Path.Combine(destination, fileName);
            await DownloadFileWithProgressAsync(url, destination);
        }
        private async Task DownloadFileWithProgressAsync(string url, string destination)
        {
            
                try
                {
                using (HttpClient client = new HttpClient())
                {
                    // ✅ Add User-Agent (Pretend to be a browser)
                    client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36");

                    using (HttpResponseMessage response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
                    {
                        response.EnsureSuccessStatusCode(); // Throws exception if HTTP 403, 404, etc.

                        long? totalBytes = response.Content.Headers.ContentLength;
                        if (totalBytes == null)
                        {
                            MessageBox.Show("Unable to determine file size.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        lblFilename.Text = "";
                        progressBar.Value = 0;
                        lblProgress.Text = "0%";

                        using (Stream contentStream = await response.Content.ReadAsStreamAsync(),
                                      fileStream = new FileStream(destination, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
                        {
                            byte[] buffer = new byte[8192];
                            long totalRead = 0;
                            int bytesRead;
                            DateTime lastReportTime = DateTime.Now;

                            while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                            {
                                await fileStream.WriteAsync(buffer, 0, bytesRead);
                                totalRead += bytesRead;

                                int progress = (int)((double)totalRead / totalBytes.Value * 100);
                                string fileName = destination;

                                // ✅ Update UI on the main thread
                                form.Invoke((Action)(() =>
                                {
                                    lblFilename.Text = "File: " + fileName;
                                    progressBar.Value = progress;
                                    lblProgress.Text = $"{progress}%";
                                }));
                            }
                        }
                    }
                }
            }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            

            MessageBox.Show("Download Complete!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            form.Close(); // Close the form after download completion
        }


    }
}

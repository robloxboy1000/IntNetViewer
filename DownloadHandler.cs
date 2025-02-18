using CefSharp;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace IntNetViewer
{
	public class DownloadHandler : IDownloadHandler
	{
		private readonly MainWindow myForm;


		public DownloadHandler(MainWindow form)
		{
			myForm = form;
		}

		public bool CanDownload(IWebBrowser chromiumWebBrowser, IBrowser browser, string url, string requestMethod)
		{
			return true;
		}

		public bool OnBeforeDownload(IWebBrowser chromiumWebBrowser, IBrowser browser, DownloadItem item, IBeforeDownloadCallback callback)
		{
			if (!callback.IsDisposed)
			{
				

				using (callback)
				{

					myForm.UpdateDownloadItem(item);

					// ask browser what path it wants to save the file into
					string path = myForm.CalcDownloadPath(item);

					// if file should not be saved, path will be null, so skip file
					if (path == null)
					{

						// skip file
						callback.Continue(path, false);
						return false;

					}
					else
					{

						// open the downloads tab
						myForm.OpenDownloadsTab();
						callback.Continue(path, true);
						return true;
					}

				}

			}
			return false;
		}

		public void OnDownloadUpdated(IWebBrowser webBrowser, IBrowser browser, DownloadItem downloadItem, IDownloadItemCallback callback)
		{
			myForm.UpdateDownloadItem(downloadItem);
			if (downloadItem.IsInProgress && myForm.CancelRequests.Contains(downloadItem.Id)) {
				
				callback.Cancel();
			}
#if DEBUG
			Console.WriteLine(downloadItem.Url + " %" + downloadItem.PercentComplete + " complete");
#endif

		}


    }
}
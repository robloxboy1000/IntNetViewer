using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IntNetViewer {

    /// <summary>
    /// functions in this class are accessible by JS using the code `host.X()`
    /// </summary>
    public class HostHandler {
        MainWindow myForm;
        private string history;

        public HostHandler(MainWindow form) {
            myForm = form;
        }
        public void addNewBrowserTab(string url, bool focusNewTab = true) {
            myForm.AddNewTab(url);
        }
        public string getDownloads() {
            lock (myForm.downloads) {
                string x = JSON.Instance.ToJSON(myForm.downloads.ToArray());
                return x;
            }
        }

        public bool cancelDownload(int downloadId) {
            lock (myForm.downloadCancelRequests) {
                if (!myForm.downloadCancelRequests.Contains(downloadId)) {
                    myForm.downloadCancelRequests.Add(downloadId);
                }
            }
            return true;
        }

        public string getHistory()
        {
            lock (myForm.history)
            {
                string x = history;
                foreach (string item in myForm.history)
                {
                    x += item + "\r\n";
                }
                return x;
            }
        }

    }

}

using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntNetViewer
{
    public class CustomLifeSpanHandler : ILifeSpanHandler
    {
        private readonly Action<string> _openNewTab;

        public CustomLifeSpanHandler(Action<string> openNewTab)
        {
            _openNewTab = openNewTab;
        }

        public bool DoClose(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
            return false;
        }

        public void OnAfterCreated(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
            
        }

        public void OnBeforeClose(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
            
        }

        public bool OnBeforePopup(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName,
                                  WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures,
                                  IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {
            // This method is called before a new popup window is created.
            // Use the action to open a new tab or window in your application.
            _openNewTab(targetUrl);

            // Prevent the default popup behavior.
            newBrowser = null;
            return true;
        }

        // Implement other ILifeSpanHandler interface methods as needed
    }
}

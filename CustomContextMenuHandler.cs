using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntNetViewer
{
    public class CustomContextMenuHandler : IContextMenuHandler
    {
        public void OnBeforeContextMenu(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
        {
            model.Clear();
            model.AddItem(CefMenuCommand.Find, "Open selected URL");
            model.SetEnabledAt(0, !string.IsNullOrWhiteSpace(parameters.SelectionText));
            model.AddItem(CefMenuCommand.Back, "Back");
            model.AddItem(CefMenuCommand.Forward, "Forward");
            model.AddItem(CefMenuCommand.Reload, "Reload");
            model.AddItem(CefMenuCommand.ReloadNoCache, "Reload without cache");
            model.AddSeparator();
            model.AddItem(CefMenuCommand.ViewSource, "View page source");
        }

        public bool OnContextMenuCommand(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
        {
            if (commandId == CefMenuCommand.Find)
            {
                string url = parameters.SelectionText;
                frame.ExecuteJavaScriptAsync($"window.open('{url}', '_self')");
                return true;
            }
            return false;
        }

        public void OnContextMenuDismissed(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame)
        {
            
        }

        public bool RunContextMenu(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback)
        {
            return false;
        }
    }
}

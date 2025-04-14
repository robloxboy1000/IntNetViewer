using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CefSharp;

namespace IntNetViewer
{
    class JsDialogHandler : IJsDialogHandler
    {
        bool IJsDialogHandler.OnJSDialog(IWebBrowser chromiumWebBrowser, IBrowser browser, string originUrl, CefJsDialogType dialogType, string messageText, string defaultPromptText, IJsDialogCallback callback, ref bool suppressMessage)
        {

            suppressMessage = false;
            if (dialogType == CefJsDialogType.Alert)
            {
                MessageBox.Show(messageText, $"{originUrl} says:");
                callback.Continue(true, "OK");
                return true;
            }
            else if (dialogType == CefJsDialogType.Confirm)
            {
                MessageBoxResult result = MessageBox.Show(messageText, $"{originUrl} says:", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    callback.Continue(true, "OK");
                    return true;
                }
                else
                {
                    callback.Continue(false);
                    return true;
                }
            }
            else if (dialogType == CefJsDialogType.Prompt)
            {
                MessageBoxResult result = MessageBox.Show(messageText, $"{originUrl} says:", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    callback.Continue(true, "OK");
                    return true;
                }
                else
                {
                    callback.Continue(false);
                    return true;
                }
            }
            return true;
        }

        bool IJsDialogHandler.OnBeforeUnloadDialog(IWebBrowser chromiumWebBrowser, IBrowser browser, string messageText, bool isReload, IJsDialogCallback callback)
        {
            return false;
        }

        void IJsDialogHandler.OnResetDialogState(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
            
        }

        void IJsDialogHandler.OnDialogClosed(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
            
        }
    }
    
    
}

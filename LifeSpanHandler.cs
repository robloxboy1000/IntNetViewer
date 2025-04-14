using CefSharp;

namespace IntNetViewer
{
	internal class LifeSpanHandler : ILifeSpanHandler
	{
		MainWindow myForm;

		public LifeSpanHandler(MainWindow form)
		{
			myForm = form;
		}


		
		public bool DoClose(IWebBrowser browserControl, IBrowser browser)
		{
			return false;
		}
		
		public void OnAfterCreated(IWebBrowser browserControl, IBrowser browser)
		{
		}
		
		public void OnBeforeClose(IWebBrowser browserControl, IBrowser browser)
		{
		}
		
		public bool OnBeforePopup(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
		{

			// open popup in new tab!
			newBrowser = null;
			myForm.Invoke(new System.Action(() => myForm.AddNewTab(targetUrl)));

			return true;

		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.Structs;

namespace IntNetViewer
{
    public class CustomAudioHandler : IAudioHandler
    {
        private Label label2;

        public CustomAudioHandler(Label label2)
        {
            this.label2 = label2;
        }

        public void Dispose()
        {
            
        }

        public bool GetAudioParameters(IWebBrowser chromiumWebBrowser, IBrowser browser, ref AudioParameters parameters)
        {
            return true;
        }

        public void OnAudioStreamError(IWebBrowser chromiumWebBrowser, IBrowser browser, string errorMessage)
        {
            MessageBox.Show(errorMessage);
        }

        public void OnAudioStreamPacket(IWebBrowser chromiumWebBrowser, IBrowser browser, IntPtr data, int noOfFrames, long pts)
        {
            
        }

        public void OnAudioStreamStarted(IWebBrowser chromiumWebBrowser, IBrowser browser, AudioParameters parameters, int channels)
        {
            label2.Invoke(new Action(() => { label2.Visible = true; }));
        }

        public void OnAudioStreamStopped(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
            label2.Invoke(new Action(() => { label2.Visible = false; }));
        }
    }
}

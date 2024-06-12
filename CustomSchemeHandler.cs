using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using CefSharp;
using System.Windows.Forms;
using System.Drawing;
using CefSharp.Callback;

namespace IntNetViewer
{
    internal class CustomSchemeHandler : IResourceHandler, IDisposable
    {
        private static string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\";

        private string mimeType;
        private Stream stream;
        MainWindow myForm;
        private Uri uri;
        private string fileName;

        public CustomSchemeHandler(MainWindow form)
        {
            myForm = form;
        }

        public void Dispose()
        {

        }

        
        public bool Open(IRequest request, out bool handleRequest, ICallback callback)
        {
            uri = new Uri(request.Url);
            fileName = uri.AbsolutePath;

            // if url is blocked
            /*if (...request.Url....) {

				// cancel the request - set handleRequest to true and return false
				handleRequest = true;
				return false;
			}*/

            // if url is browser file
            if (uri.Host == "assets")
            {
                fileName = appPath + uri.Host + fileName;
                if (File.Exists(fileName))
                {
                    Task.Factory.StartNew(() => {
                        using (callback)
                        {
                            FileStream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                            mimeType = ResourceHandler.GetMimeType(Path.GetExtension(fileName));
                            stream = fStream;
                            callback.Continue();
                        }
                    });

                    // handle the request at a later time
                    handleRequest = false;
                    return true;
                }
            }

            


            // by default reject
            callback.Dispose();

            // cancel the request - set handleRequest to true and return false
            handleRequest = true;
            return false;
        }
        
        public void GetResponseHeaders(IResponse response, out long responseLength, out string redirectUrl)
        {

            responseLength = stream != null ? stream.Length : 0;
            redirectUrl = null;

            response.StatusCode = (int)HttpStatusCode.OK;
            response.StatusText = "OK";
            response.MimeType = mimeType;

            //return stream;
        }
        
        public bool ReadResponse(Stream dataOut, out int bytesRead, ICallback callback)
        {

            //Dispose the callback as it's an unmanaged resource, we don't need it in this case
            callback.Dispose();

            if (stream == null)
            {
                bytesRead = 0;
                return false;
            }

            //Data out represents an underlying buffer (typically 32kb in size).
            var buffer = new byte[dataOut.Length];
            bytesRead = stream.Read(buffer, 0, buffer.Length);

            dataOut.Write(buffer, 0, buffer.Length);

            return bytesRead > 0;

        }

        
        public bool Read(Stream dataOut, out int bytesRead, IResourceReadCallback callback)
        {

            // For backwards compatibility set bytesRead to
            //     -1 and return false and the ReadResponse method will be called.
            bytesRead = -1;
            return false;
        }

        
        public bool Skip(long bytesToSkip, out long bytesSkipped, IResourceSkipCallback callback)
        {
            // To indicate failure set bytesSkipped to < 0 (e.g. -2 for ERR_FAILED)
            //     and return false.
            bytesSkipped = -2;
            return false;
        }

        // Summary:
        //     Request processing has been canceled.
        public void Cancel()
        {
        }
        //
        // Summary:
        //     Return true if the specified cookie can be sent with the request or false
        //     otherwise. If false is returned for any cookie then no cookies will be sent
        //     with the request.
        public bool CanGetCookie(CefSharp.Cookie cookie)
        {
            return true;
        }
        //
        // Summary:
        //     Return true if the specified cookie returned with the response can be set
        //     or false otherwise.
        public bool CanSetCookie(CefSharp.Cookie cookie)
        {
            return true;
        }

        //
        // Summary:
        //     Begin processing the request.
        //
        // Parameters:
        //   request:
        //     The request object.
        //
        //   callback:
        //     The callback used to Continue or Cancel the request (async).
        //
        // Returns:
        //     To handle the request return true and call CefSharp.ICallback.Continue once the
        //     response header information is available CefSharp.ICallback.Continue can also
        //     be called from inside this method if header information is available immediately).
        //     To cancel the request return false.
        public bool ProcessRequest(IRequest request, ICallback callback)
        {
            return false;
        }
    }
}

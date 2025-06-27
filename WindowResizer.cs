using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntNetViewer
{
    public class WindowResizer
    {
        readonly Form form;
        public WindowResizer(Form form) 
        {
            this.form = form;
        }
        public void ResizeWindow(int width, int height)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentException("Width and height must be positive integers.");
            }
            // Assuming 'form' is a reference to the main application form
            // Get the main form
            form.Width = width;
            form.Height = height;
        }
    }
}

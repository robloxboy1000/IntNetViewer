using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace IntNetViewer
{
    public class ToolStripSpringTextBox : ToolStripTextBox
    {
        public override Size GetPreferredSize(Size constrainingSize)
        {
            // Use all available space
            if (IsOnOverflow || Owner.Orientation == Orientation.Vertical)
            {
                return DefaultSize;
            }

            // Calculate the space available for the text box
            int width = Owner.DisplayRectangle.Width;

            foreach (ToolStripItem item in Owner.Items)
            {
                if (item == this) continue;

                if (item.Visible)
                {
                    width -= item.Width;
                    width -= item.Margin.Left + item.Margin.Right;
                }
            }

            if (width < DefaultSize.Width)
            {
                width = DefaultSize.Width;
            }

            var size = base.GetPreferredSize(constrainingSize);
            size.Width = width;
            return size;
        }
    }
}

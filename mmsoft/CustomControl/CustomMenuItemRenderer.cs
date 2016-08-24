using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace MMSoft
{
   public class CustomMenuItemRenderer : ToolStripProfessionalRenderer
   {
      protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
      {
         Rectangle Rect_O = new Rectangle(new Point(1, 0), e.ToolStrip.Size);
         Color Color_O = e.Item.Selected ? Color.FromArgb(51, 153, 255) : Color.FromArgb(51, 102, 102);
         using (SolidBrush brush = new SolidBrush(Color_O))
            e.Graphics.FillRectangle(brush, Rect_O);
      }

      protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
      {
         // Do nothing
      }

      protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
      {
         e.TextColor = Color.White;
         base.OnRenderItemText(e);
      }
   }
}

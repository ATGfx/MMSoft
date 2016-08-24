using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace MMSoft
{
   class CustomListView : ListView
   {
      public CustomListView()
      {
         //Activate double buffering
        this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

        this.OwnerDraw = false;

        this.HideSelection = false;

        this.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(this.CustomDrawColumnHeader);
        this.DrawSubItem += new DrawListViewSubItemEventHandler(CustomDrawSubItem);
        this.DrawItem += new DrawListViewItemEventHandler(CustomDrawItem);
        this.MouseMove += new MouseEventHandler(CustomMouseMove);
        this.ColumnWidthChanged += new ColumnWidthChangedEventHandler(CustomColumnWidthChanged);
        //this.Invalidated += new InvalidateEventHandler(CustomInvalidated);
        this.MouseUp += new MouseEventHandler(CustomMouseUp);

      }

      protected void CustomDrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
      {
         SolidBrush Brush_O = new SolidBrush(Color.FromArgb(60, 60, 60));

         using (var StringFormat_O = new StringFormat())
         {
            StringFormat_O.Alignment = StringAlignment.Near;
            StringFormat_O.LineAlignment = StringAlignment.Center;
            StringFormat_O.FormatFlags = StringFormatFlags.LineLimit;

            using (var headerFont = new Font("Segoe UI Symbol", 10))
            {
               e.Graphics.FillRectangle(Brush_O, e.Bounds);
               e.Graphics.DrawString(e.Header.Text, headerFont, Brushes.White, e.Bounds, StringFormat_O);
            }
         }
      }

      void CustomDrawSubItem(object sender, DrawListViewSubItemEventArgs e)
      {
         TextFormatFlags flags = TextFormatFlags.Left;

         using (StringFormat sf = new StringFormat())
         {
            // Store the column text alignment, letting it default 
            // to Left if it has not been set to Center or Right. 
            sf.FormatFlags = System.Drawing.StringFormatFlags.LineLimit;
            switch (e.Header.TextAlign)
            {
               case HorizontalAlignment.Center:
                  sf.Alignment = StringAlignment.Center;
                  flags = TextFormatFlags.HorizontalCenter;
                  break;
               case HorizontalAlignment.Right:
                  sf.Alignment = StringAlignment.Far;
                  flags = TextFormatFlags.Right;
                  break;
            }

            // Draw the text and background for a subitem with a  
            // negative value.  
            double subItemValue;
            if (e.ColumnIndex > 0 /*&& Double.TryParse(
                e.SubItem.Text, NumberStyles.Currency,
                NumberFormatInfo.CurrentInfo, out subItemValue) &&
                subItemValue < 0*/)
            {
               // Unless the item is selected, draw the standard  
               // background to make it stand out from the gradient. 
               if ((e.ItemState & ListViewItemStates.Selected) == 0)
               {
                  e.DrawBackground();
               }

               // Draw the subitem text in red to highlight it. 
               e.Graphics.DrawString(e.SubItem.Text, this.Font, Brushes.White, e.Bounds, sf);

               return;
            }

            // Draw normal text for a subitem with a nonnegative  
            // or nonnumerical value.
            //e.DrawText(flags);
         }
      }

      void CustomDrawItem(object sender, DrawListViewItemEventArgs e)
      {
         using (StringFormat sf = new StringFormat())
         {

            if ((e.State & ListViewItemStates.Selected) != 0)
            {
               // Draw the background and focus rectangle for a selected item.
               e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(51, 153, 255)), e.Bounds);
               //e.DrawFocusRectangle();
               Rectangle rowBounds = e.Bounds;
               int leftMargin = e.Item.GetBounds(ItemBoundsPortion.Label).Left;
               Rectangle bounds = new Rectangle(leftMargin, rowBounds.Top, rowBounds.Width - leftMargin, rowBounds.Height);
               e.Graphics.FillRectangle(SystemBrushes.Highlight, bounds);
            }
            else
            {
               // Draw the background for an unselected item. 
               using (SolidBrush brush = new SolidBrush(Color.FromArgb(60, 60, 60)))
               {
                  e.Graphics.FillRectangle(brush, e.Bounds);
               }
            }


            //sf.LineAlignment = StringAlignment.Center;
            //e.Graphics.DrawString(e.Item.Text, this.Font, Brushes.Red, e.Bounds, sf);

            e.DrawText();

            // Draw the item text for views other than the Details view. 
            if (this.View != View.Details)
            {
               //e.DrawText();
            }
         }        
      }

      private void CustomMouseMove(object sender, MouseEventArgs e)
      {
         ListViewItem item = this.GetItemAt(e.X, e.Y);
         if (item != null)
         {
            this.Invalidate(item.Bounds);
         }
      }

      // Resets the item tags.  
      void CustomInvalidated(object sender, InvalidateEventArgs e)
      {
         foreach (ListViewItem item in this.Items)
         {
            if (item == null) return;
            item.Tag = null;
         }
      }

      // Forces the entire control to repaint if a column width is changed. 
      void CustomColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
      {
         this.Invalidate();
      }

      private void CustomMouseUp(object sender, MouseEventArgs e)
      {
         if (!this.IsDisposed)
         {
            ListViewItem clickedItem = this.GetItemAt(5, e.Y);
            if (clickedItem != null)
            {
               clickedItem.Selected = true;
               clickedItem.Focused = true;
            }
         }
      }
   }
}

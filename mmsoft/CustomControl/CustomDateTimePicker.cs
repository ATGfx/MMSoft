using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MMSoft
{
   /// <summary>
   ///     A derivation of DateTimePicker allowing to change background color
   /// </summary>
   class CustomDateTimePicker : System.Windows.Forms.DateTimePicker
   {
      public bool mDarkBackground_b = true;
      public bool mDisplayDay_b = true;

      public CustomDateTimePicker() : base()
      {
         this.SetStyle(ControlStyles.UserPaint, true);
      }

      /// <summary>
      ///     Gets or sets the background color of the control
      /// </summary>
      [Browsable(true)]
      public override Color BackColor
      {
         get { return base.BackColor; }
         set { base.BackColor = value; }
      }

      protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
      {
         Graphics g = this.CreateGraphics();
         //Graphics g = e.Graphics;

         //The dropDownRectangle defines position and size of dropdownbutton block, 
         //the width is fixed to 17 and height to 16. The dropdownbutton is aligned to right
         Rectangle dropDownRectangle = new Rectangle(ClientRectangle.Width - 17, 0, 17, ClientRectangle.Height);
         Brush bkgBrush;

         //When the control is enabled the brush is set to Backcolor, 
         //otherwise to color stored in _backDisabledColor
         bkgBrush = new SolidBrush(this.BackColor);

         // Painting...in action

         //Filling the background
         g.FillRectangle(bkgBrush, 0, 0, ClientRectangle.Width, ClientRectangle.Height);

         //Drawing the datetime text
         System.Globalization.CultureInfo CultureInfo_O = new System.Globalization.CultureInfo("fr-FR");
         String Day_ST = CultureInfo_O.DateTimeFormat.GetDayName(this.Value.DayOfWeek);
         String StringToDraw_st = (mDisplayDay_b ? Day_ST + " " : "") + this.Text;

         if (mDarkBackground_b)
         {
            g.DrawString(StringToDraw_st, this.Font, Brushes.White, 0, 2);
         }
         else
         {
            g.DrawString(StringToDraw_st, this.Font, Brushes.Black, 0, 2);
         }
         
         SizeF Size_O = g.MeasureString(Day_ST + " " + this.Text, this.Font);
         this.Width = (int)Size_O.Width;

         //Drawing the dropdownbutton using ComboBoxRenderer
         //ComboBoxRenderer.DrawDropDownButton(g, dropDownRectangle, System.Windows.Forms.VisualStyles.ComboBoxState.Normal);

         g.Dispose();
         bkgBrush.Dispose();
      }
   }
}

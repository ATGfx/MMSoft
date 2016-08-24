using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace MMSoft
{
   /// <summary>
   /// Class defining methods to set a dfined style to a control.
   /// </summary>
   class ControlStyle
   {
      public static Color DockableBorderColor_O = Color.FromArgb(51, 153, 255);

      public static void SetBackgroundStyle(Control Control_O)
      {
         Control_O.BackColor = Color.FromArgb(51, 102, 102);
         Control_O.ForeColor = Color.FromArgb(255, 255, 255);
      }

      public static void SetFrameStyle(Control Control_O)
      {
         Control_O.BackColor = Color.FromArgb(252, 252, 252);
         Control_O.ForeColor = Color.FromArgb(0, 0, 0);
      }

      public static void SetFrameHeaderStyle(Control Control_O)
      {
         Control_O.BackColor = Color.FromArgb(153, 0, 0);
         Control_O.ForeColor = Color.FromArgb(255, 255, 255);
      }

      public static void SetDateTimePickerStyle(CustomDateTimePicker DateTimePicker_O)
      {
         DateTimePicker_O.BackColor = Color.FromArgb(40, 40, 40);
      }

      public static void SetBackgroundColorFocusStyle(Control Control_O)
      {
         Control_O.BackColor = Color.FromArgb(51, 153, 255);
         Control_O.ForeColor = Color.White;
      }
   }
}

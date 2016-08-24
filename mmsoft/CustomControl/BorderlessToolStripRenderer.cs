using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MMSoft
{
   /// <summary>
   /// Class defining a custom renderer for the tool strip control.
   /// </summary>
   class BorderlessToolStripRenderer : ToolStripProfessionalRenderer 
   {
      /// <summary>
      /// Default contructor, call base class constructor.
      /// </summary>
      public BorderlessToolStripRenderer() : base()
      {
         RoundedEdges = false;
      } 

//       protected virtual void OnRenderSeparator(ToolStripSeparatorRenderEventArgs ^e) override
//       { 
//          if (e->Item == nullptr)
//          {
//             // Don't know if it is necessary but call base class anyway if null...
//             ToolStripProfessionalRenderer::OnRenderSeparator(e);
//          }
//          else
//          {
//             System::Drawing::RectangleF ^pBounds_O = gcnew System::Drawing::RectangleF(Point::Empty, e->Item->Size); 
//             Pen ^pPen_O = gcnew Pen(System::Drawing::Color::FromArgb(UI_MENU_SEPARATOR));                
//             SolidBrush ^pBrush_O = gcnew SolidBrush(System::Drawing::Color::FromArgb(UI_MENU_BACKCOLOR));
// 
//             if (!e->Vertical)
//             {                     
//                e->Graphics->FillRectangle(pBrush_O, pBounds_O->X, pBounds_O->Y, pBounds_O->Width, pBounds_O->Height);
// 
//                if (pBounds_O->Width > 10)
//                   e->Graphics->DrawLine(pPen_O, 5.0f, pBounds_O->Height/2, pBounds_O->Width - 5.0f, pBounds_O->Height/2);
//                else
//                   e->Graphics->DrawLine(pPen_O, 0.0f, pBounds_O->Height/2, pBounds_O->Width, pBounds_O->Height/2);
//             }
//             else 
//             {                      
//                e->Graphics->FillRectangle(pBrush_O, pBounds_O->X, pBounds_O->Y, pBounds_O->Width, pBounds_O->Height);
// 
//                if (pBounds_O->Height > 10)
//                   e->Graphics->DrawLine(pPen_O,pBounds_O->Width/2, 5.0f, pBounds_O->Width/2, pBounds_O->Height - 5.0f);                
//                else
//                   e->Graphics->DrawLine(pPen_O,pBounds_O->Width/2, 0.0f, pBounds_O->Width/2, pBounds_O->Height);                
//             } 
// 
//             //dispose and free up the resources
//             pPen_O->~Pen();//Dispose();
//             pBrush_O->~SolidBrush();//Dispose();
//          }
//       } 

//       protected void DrawItemBackground(RectangleF Bounds_O, bool IsSelected_b, Graphics Graphics_O)
//       {
//          SolidBrush Brush_O;
// 
//          if (IsSelected_b)
//          {
//             // Fill background
//             Brush_O = new SolidBrush(Color.FromArgb(0xFFFFFFFF));
//             Graphics_O.FillRectangle(Brush_O, Bounds_O.X+2, Bounds_O.Y, Bounds_O.Width-3, Bounds_O.Height);
//             //Brush_O.~SolidBrush();
// 
//             // Draw bevel...
// 
//             // Draw horizontal dark line (upper side)
//             Pen Pen_O = new Pen(Color.FromArgb(0xFF272727));
//             Graphics_O.DrawLine(Pen_O, Bounds_O.X+2, Bounds_O.Y, Bounds_O.Width-3, Bounds_O.Y);                  
//             //Pen_O.~Pen();                  
// 
//             // Draw horizontal light line (upper side)
//             Pen_O = new Pen(Color.FromArgb(0xFF939393));
//             Graphics_O.DrawLine(Pen_O, Bounds_O.X+2, Bounds_O.Y+1, Bounds_O.Width-3, Bounds_O.Y+1);    
//             //Pen_O.~Pen();
// 
//             // Draw horizontal dark line (lower side)
//             Pen_O = new Pen(Color.FromArgb(0xFF272727));
//             Graphics_O.DrawLine(Pen_O, Bounds_O.X+2, Bounds_O.Height-1, Bounds_O.Width-3, Bounds_O.Height-1);
// 
//             // Draw horizontal dark line (left side)
//             Graphics_O.DrawLine(Pen_O, Bounds_O.X+2, Bounds_O.Y, Bounds_O.X+2, Bounds_O.Height-2);
// 
//             // Draw horizontal dark line (right side)
//             Graphics_O.DrawLine(Pen_O, Bounds_O.Width-2, Bounds_O.Y, Bounds_O.Width-2, Bounds_O.Height-1);                                    
//             //Pen_O.~Pen();                  
//          }
//          else
//          {
//             Brush_O = new SolidBrush(Color.FromArgb(0xFFFFFFFF));
//             Graphics_O.FillRectangle(Brush_O, Bounds_O.X+2, Bounds_O.Y, Bounds_O.Width-3, Bounds_O.Height);
//             //Brush_O.~SolidBrush();
//          }            
// 
//          /*
//          if (e.Item.Pressed)
//          {
//             Pen ^pPen_O;
// 
//             // Draw horizontal dark line (lower side)
//             pPen_O = gcnew Pen(Color::Red);
//             e.Graphics.DrawLine(pPen_O, pBounds_O.X+2, pBounds_O.Height-2, pBounds_O.Width-3, pBounds_O.Height-2);
//          }
//          */
//       }
         
      /*
      protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e) 
      {
         if (e.Item == null)
         {
            // Don't know if it is necessary but call base class anyway if null...
            base.OnRenderMenuItemBackground(e);
         }
         else
         {
            RectangleF Bounds_O = new RectangleF(Point.Empty, e.Item.Size);
            //DrawItemBackground(Bounds_O, e.Item.Selected, e.Graphics);
            DrawItemBackground(e);   
         }            
     }  
       * */

      /// <summary>
      /// OnRenderToolStripBorder base class override. Do nothing to avoid rendering borders
      /// </summary>
      /// <param name="e"></param>
      protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
      {            
         // Do nothing                                
      }

//       protected virtual void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs ^e) override
//       {
//          if (e->Item == nullptr)
//          {
//             // Don't know if it is necessary but call base class anyway if null...
//             ToolStripProfessionalRenderer::OnRenderMenuItemBackground(e);
//          }
//          else
//          {
//             System::Drawing::RectangleF ^pBounds_O = gcnew System::Drawing::RectangleF(Point::Empty, e->Item->Size); 
//             DrawItemBackground(pBounds_O, e->Item->Selected, e->Graphics);               
//          }            
//       }     


      /*
      virtual void OnRenderSplitButtonBackground(ToolStripItemRenderEventArgs ^e) override
      {
         if (e->Item == nullptr)
         {
            // Don't know if it is necessary but call base class anyway if null...
            ToolStripProfessionalRenderer::OnRenderMenuItemBackground(e);
         }
         else
         {
            System::Drawing::RectangleF ^pBounds_O = gcnew System::Drawing::RectangleF(Point::Empty, e->Item->Size); 
            DrawItemBackground(pBounds_O, e->Item->Selected, e->Graphics);               
         }    
      }
      */

//       protected virtual void OnRenderArrow (ToolStripArrowRenderEventArgs ^e) override
//       { 
//          e->ArrowColor = Color::White;            
//          ToolStripProfessionalRenderer::OnRenderArrow(e);
//       }
   }
}
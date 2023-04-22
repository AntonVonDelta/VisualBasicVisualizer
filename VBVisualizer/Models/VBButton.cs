using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VBVisualizer.Models {
    public class VBButton : VBCaptionControl {
        public override Color BackgroundColor => SystemColors.ControlLight;

        public VBButton(string name) : base(name) {

        }

        public override void PaintBorder(Graphics graphics) {
            using (var pen = new Pen(Color.LightGray, 1)) {
                graphics.DrawRectangle(pen, AbsoluteLeft, AbsoluteTop, Width, Height);
            }

            using (var pen = new Pen(Color.Gray, 2)) {
                graphics.DrawLine(pen, AbsoluteLeft, AbsoluteTop + Height, AbsoluteLeft + Width, AbsoluteTop + Height);
                graphics.DrawLine(pen, AbsoluteLeft + Width, AbsoluteTop + Height, AbsoluteLeft + Width, AbsoluteTop);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VBVisualizer.Models {
    public class VBForm : VBControl {
        public override int AbsoluteLeft => 0;
        public override int AbsoluteTop => 0;

        public VBForm(string name) : base(name) {
        }

        public override void Paint(Graphics graphics) {
            using (var brush = new SolidBrush(Color.LightGray)) {
                graphics.FillRectangle(brush, 0, 0, Width, Height);
            }

            foreach (var child in _controls) {
                child.Paint(graphics);
            }
        }
    }
}

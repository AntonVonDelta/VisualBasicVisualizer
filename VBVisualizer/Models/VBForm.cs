using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VBVisualizer.Models {
    public class VBForm : VBCaptionControl {
        public override Color BackgroundColor => SystemColors.Control;
        public override int AbsoluteLeft => 0;
        public override int AbsoluteTop => 0;

        public VBForm(string name) : base(name) {
        }

        public override void PaintCaption(Graphics graphics) {
            return;
        }

        public override void PaintBorder(Graphics graphics) {
            return;
        }
    }
}

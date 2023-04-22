using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VBVisualizer.Models {
    public class VBLabel : VBCaptionControl {
        public override Color BackgroundColor => Color.Transparent;

        public VBLabel(string name) : base(name) {

        }

        public override void PaintBorder(Graphics graphics) {
            // No border for label
            return;
        }
    }
}

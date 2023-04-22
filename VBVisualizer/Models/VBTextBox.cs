using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VBVisualizer.Models {
    public class VBTextBox : VBCaptionControl {
        public override Color BackgroundColor => Color.White;

        public VBTextBox(string text) : base(text) { }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VBVisualizer.Models {
    public class VBListView : VBControl {
        public override Color BackgroundColor => Color.White;

        public VBListView(string name) : base(name) { }
    }
}

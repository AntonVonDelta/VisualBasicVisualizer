using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VBVisualizer.Models {
    public class VBControl {
        public string Name { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }
        public Color Forecolor { get; set; }

        protected List<VBControl> _controls = new List<VBControl>();

        public VBControl(string name) {
            Name = name;
        }

        public void AddControl(VBControl control) {
            _controls.Add(control);
        }
    }
}

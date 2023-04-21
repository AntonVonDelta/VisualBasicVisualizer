using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VBVisualizer.Models {
    public class VBControl {
        private string _name;
        private int _height;
        private int _width;
        private int _left;
        private int _top;
        private Color _forecolor;

        public string Name => _name; public int Height => _height;
        public int Width => _width;
        public int Left => _left;
        public int Top => _top;
        public Color Forecolor => _forecolor;

        public VBControl(string controlName) {
            _name = controlName;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VBVisualizer.Models {
    public class VBForm : VBControl {
        private List<VBLabel> _labels = new List<VBLabel>();
        private List<VBButton> _buttons = new List<VBButton>();

        public VBForm(string name):base(name) {
        }

        public void AddLabel(VBLabel control) {
            _labels.Add(control);
        }

        public void AddButton(VBButton control) {
            _buttons.Add(control);
        }
    }
}

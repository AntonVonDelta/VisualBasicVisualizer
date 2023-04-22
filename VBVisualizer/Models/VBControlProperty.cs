using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VBVisualizer.Models {
    public class VBControlProperty {
        public string Name { get; set; }
        public string Value { get; set; }

        public VBControlProperty(string name, string value) {
            Name = name;
            Value = value;
        }

        public VBControlProperty(string name, int value) {
            Name = name;
            Value = value.ToString();
        }
    }
}

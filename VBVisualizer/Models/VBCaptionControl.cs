using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VBVisualizer.Models {
    public class VBCaptionControl : VBControl {
        public string Caption { get; set; }

        public VBCaptionControl(string name) : base(name) {

        }

        public override void AddProperty(string name, string value) {
            base.AddProperty(name, value);

            if (name.ToLower() == "caption") {
                Caption = value;
            }
        }

        public override List<VBControlProperty> GetProperties() {
            var result = base.GetProperties();

            result.Insert(1, new VBControlProperty("Caption", Caption));

            return result;
        }
    }
}

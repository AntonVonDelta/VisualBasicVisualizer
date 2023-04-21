using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBVisualizer.Models;

namespace VBVisualizer.Parsers {
    public class PropertiesVisitor : VisualBasic6ParserBaseVisitor<object> {
        enum ControlType {
            Unknown,
            Form,
            Label,
            Button
        }

        private VBForm _form;
        private Stack<VBControl> _controls = new Stack<VBControl>();

        public VBForm Result => _form;

        private ControlType GetControlType(VisualBasic6Parser.Cp_ControlTypeContext context) {
            string firstIdentifier;
            string secondIdentifier;

            if (context.complexType().ambiguousIdentifier().Count() != 2) return ControlType.Unknown;
            firstIdentifier = context.complexType().ambiguousIdentifier()[0].GetText();
            secondIdentifier = context.complexType().ambiguousIdentifier()[1].GetText();

            if (firstIdentifier == "VB" && secondIdentifier == "Form") return ControlType.Form;
            if (firstIdentifier == "VB" && secondIdentifier == "Label") return ControlType.Label;
            if (firstIdentifier == "VB" && secondIdentifier == "CommandButton") return ControlType.Button;

            return ControlType.Unknown;
        }

        public IParseTree GetNextSibling(ParserRuleContext context) {
            var parent = (ParserRuleContext)context.parent;
            var indexOfCurrentContext = parent.children.IndexOf(context);

            return parent.GetChild(indexOfCurrentContext + 1);
        }

        public override object VisitCp_ControlType([NotNull] VisualBasic6Parser.Cp_ControlTypeContext context) {
            var controlType = GetControlType(context);

            _currentControlType = controlType;

            if (controlType == ControlType.Form) {
                if (_form != null) {
                    throw new Exception("Form control already defined");
                }
            }

            return null;
        }

        public override object VisitCp_ControlIdentifier([NotNull] VisualBasic6Parser.Cp_ControlIdentifierContext context) {
            _form = new VBForm(context.ambiguousIdentifier().GetText());
            return null;
        }
    }
}

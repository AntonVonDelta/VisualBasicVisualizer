using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VBVisualizer.Models;

namespace VBVisualizer.Parsers {
    public class PropertiesVisitor : VisualBasic6ParserBaseVisitor<object> {
        enum ControlProperty {
            Unknown,
            BorderStyle,
            Caption,
            ClientHeight,
            ClientWidth,
            ClientTop,
            ClientLeft,
            ForeColor,
            BackColor
        }

        private VBForm _form;
        private Stack<VBControl> _controls = new Stack<VBControl>();

        public VBForm Result => _form;

        private VBControl GetControl(VisualBasic6Parser.ControlPropertiesContext context) {
            string controlType;
            string controlName;

            controlType = context.cp_ControlType().GetText();
            controlName = context.cp_ControlIdentifier().GetText();

            if (controlType == "VB.Form") return new VBForm(controlName);
            if (controlType == "VB.Label") return new VBLabel(controlName);
            if (controlType == "VB.CommandButton") return new VBButton(controlName);

            return new VBUnknown(controlName);
        }

        private ControlProperty GetControlProperty(VisualBasic6Parser.Cp_SinglePropertyContext context) {
            ControlProperty result;
            var propertyName = context.implicitCallStmt_InStmt().iCS_S_VariableOrProcedureCall().ambiguousIdentifier().GetText();

            if (!Enum.TryParse(propertyName, true, out result)) {
                result = ControlProperty.Unknown;
            }

            return result;
        }

        public IParseTree GetNextSibling(ParserRuleContext context) {
            var parent = (ParserRuleContext)context.parent;
            var indexOfCurrentContext = parent.children.IndexOf(context);

            return parent.GetChild(indexOfCurrentContext + 1);
        }

        public override object VisitControlProperties([NotNull] VisualBasic6Parser.ControlPropertiesContext context) {
            var formControl = _form;
            var control = GetControl(context);

            if (!(control is VBForm) && formControl == null) throw new Exception("Form not defined");
            if (control is VBForm && formControl != null) throw new Exception("Form already defined");

            _controls.Push(control);

            if (control is VBForm) _form = (VBForm)control;
            else if (control is VBLabel) formControl.AddLabel(control as VBLabel);
            else if (control is VBButton) formControl.AddButton(control as VBButton);

            VisitChildren(context);

            _controls.Pop();

            return null;
        }

        public override object VisitCp_SingleProperty([NotNull] VisualBasic6Parser.Cp_SinglePropertyContext context) {
            var control = _controls.Peek();
            var propertyValue = context.cp_PropertyValue().literal().GetText();
            var controlPropertyType = GetControlProperty(context);

            switch (controlPropertyType) {
                case ControlProperty.ClientHeight:
                    control.Height = int.Parse(propertyValue);
                    break;

                case ControlProperty.ClientWidth:
                    control.Width = int.Parse(propertyValue);
                    break;

                case ControlProperty.ClientTop:
                    control.Top = int.Parse(propertyValue);
                    break;
                case ControlProperty.ClientLeft:
                    control.Left = int.Parse(propertyValue);
                    break;

                case ControlProperty.ForeColor:
                    var colorHexValue = Regex.Replace(propertyValue, @"[&H]", "");
                    var colorValue = int.Parse(colorHexValue, System.Globalization.NumberStyles.HexNumber);

                    control.Forecolor = Color.FromArgb(colorValue);
                    break;
            }

            return null;
        }
    }
}

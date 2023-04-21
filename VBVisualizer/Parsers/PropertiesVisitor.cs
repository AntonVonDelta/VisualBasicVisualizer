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

        private Stack<VBControl> _controls = new Stack<VBControl>();

        public VBForm Result => _controls.FirstOrDefault() as VBForm;

        private VBControl GetControl(VisualBasic6Parser.ControlPropertiesContext context) {
            string controlType;
            string controlName;

            controlType = context.cp_ControlType().GetText();
            controlName = context.cp_ControlIdentifier().GetText();

            if (controlType == "VB.Form") return new VBForm(controlName);
            if (controlType == "VB.Label") return new VBLabel(controlName);
            if (controlType == "VB.CommandButton") return new VBButton(controlName);

            return null;
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
            var controlType = GetControlType(context);

            return null;
        }

        public override object VisitCp_ControlType([NotNull] VisualBasic6Parser.Cp_ControlTypeContext context) {
            var controlType = GetControlType(context);
            var formControl = _controls.FirstOrDefault() as VBForm;

            if (controlType != ControlType.Form && formControl == null) throw new Exception("Form not defined");

            switch (controlType) {
                case ControlType.Form:
                    if (formControl != null) throw new Exception("Form control already defined");

                    _controls.Push(new VBForm());
                    break;

                case ControlType.Label:
                    var label = new VBLabel();

                    formControl.AddLabel(label);
                    _controls.Push(label);
                    break;

                case ControlType.Button:
                    var button = new VBButton();

                    formControl.AddButton(button);
                    _controls.Push(button);
                    break;

                default:
                    _controls.Push(new VBControl());
                    break;
            }

            return null;
        }

        public override object VisitCp_ControlIdentifier([NotNull] VisualBasic6Parser.Cp_ControlIdentifierContext context) {
            var control = _controls.Peek();

            control.Name = context.ambiguousIdentifier().GetText();
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

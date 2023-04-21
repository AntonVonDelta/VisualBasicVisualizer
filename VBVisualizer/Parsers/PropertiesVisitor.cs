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
        private VBControl _currentControl;

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
            var control = GetControl(context);
            var prevControl = _currentControl;

            if (control is VBForm) _form = control as VBForm;
            if (_currentControl != null) {
                _currentControl.AddControl(control);
            }

            _currentControl = control;
            base.VisitControlProperties(context);
            _currentControl = prevControl;

            return null;
        }

        public override object VisitCp_SingleProperty([NotNull] VisualBasic6Parser.Cp_SinglePropertyContext context) {
            var propertyValue = context.cp_PropertyValue().literal().GetText();
            var controlPropertyType = GetControlProperty(context);

            switch (controlPropertyType) {
                case ControlProperty.ClientHeight:
                    _currentControl.Height = int.Parse(propertyValue);
                    break;

                case ControlProperty.ClientWidth:
                    _currentControl.Width = int.Parse(propertyValue);
                    break;

                case ControlProperty.ClientTop:
                    _currentControl.Top = int.Parse(propertyValue);
                    break;
                case ControlProperty.ClientLeft:
                    _currentControl.Left = int.Parse(propertyValue);
                    break;

                case ControlProperty.ForeColor:
                    var colorHexValue = Regex.Replace(propertyValue, @"[&H]", "");
                    var colorValue = int.Parse(colorHexValue, System.Globalization.NumberStyles.HexNumber);

                    _currentControl.Forecolor = Color.FromArgb(colorValue);
                    break;
            }

            return null;
        }
    }
}

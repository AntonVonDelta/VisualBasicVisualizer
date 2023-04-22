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
        private VBForm _form;
        private VBControl _currentControl;
        private bool _insideNestedProperty;

        public VBForm Result => _form;

        private VBControl GetControl(VisualBasic6Parser.ControlPropertiesContext context) {
            string controlType;
            string controlName;

            controlType = context.cp_ControlType().GetText();
            controlName = context.cp_ControlIdentifier().GetText();

            if (controlType == "VB.Form") return new VBForm(controlName);
            if (controlType == "VB.Label") return new VBLabel(controlName);
            if (controlType == "VB.CommandButton") return new VBButton(controlName);
            if (controlType == "VB.Frame") return new VBFrame(controlName);
            if (controlType == "MSComctlLib.ListView") return new VBListView(controlName);

            return new VBUnknown(controlName);
        }

        public override object VisitControlProperties([NotNull] VisualBasic6Parser.ControlPropertiesContext context) {
            var control = GetControl(context);
            var prevControl = _currentControl;

            control.Parent = _currentControl;

            if (control is VBForm) _form = control as VBForm;
            if (_currentControl != null) {
                _currentControl.AddControl(control);
            }

            _currentControl = control;
            base.VisitControlProperties(context);
            _currentControl = prevControl;

            return null;
        }

        public override object VisitCp_NestedProperty([NotNull] VisualBasic6Parser.Cp_NestedPropertyContext context) {
            _insideNestedProperty = true;
            base.VisitCp_NestedProperty(context);
            _insideNestedProperty = false;

            return null;
        }

        public override object VisitCp_SingleProperty([NotNull] VisualBasic6Parser.Cp_SinglePropertyContext context) {
            string propertyName;
            string propertyValue;

            if (_insideNestedProperty) return null;
            if (context.implicitCallStmt_InStmt() == null || context.cp_PropertyValue() == null) return null;

            propertyName = context.implicitCallStmt_InStmt().iCS_S_VariableOrProcedureCall().ambiguousIdentifier().GetText();
            propertyValue = context.cp_PropertyValue().literal().GetText();

            _currentControl.AddProperty(propertyName, propertyValue);

            return null;
        }
    }
}

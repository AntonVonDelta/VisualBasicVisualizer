using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VBVisualizer.Models;
using VBVisualizer.Parsers;
using VBVisualizer.Utils;

namespace VBVisualizer {
    public partial class Form1 : Form {
        private VBForm _loadedForm;
        private VBControl _hoveringControl;
        private Point _originClickToolbar;

        public Form1() {
            InitializeComponent();
        }

        private VisualBasic6Parser.StartRuleContext GetTree(string input) {
            try {
                var charStream = new CaseInsensitiveStream(input);
                var lexer = new VisualBasic6Lexer(charStream);
                CommonTokenStream tokenStream;
                VisualBasic6Parser.StartRuleContext tree;
                VisualBasic6Parser parser;

                tokenStream = new CommonTokenStream(lexer);
                parser = new VisualBasic6Parser(tokenStream);

                tree = parser.startRule();

                return tree;
            } catch { }

            return null;
        }

        private void PaintForm(VBForm form, Control surface) {
            int formPadding = 1;

            surface.Width = form.Width + formPadding;
            surface.Height = form.Height + formPadding;

            _loadedForm = form;
            surface.Invalidate();
        }


        private void ProcessCode(string data) {
            var tree = GetTree(data);
            var propertiesVisitor = new PropertiesVisitor();
            VBForm form;

            propertiesVisitor.Visit(tree);
            form = propertiesVisitor.Result;

            PaintForm(form, formPanel);
        }

        private void btnOpen_Click(object sender, EventArgs e) {
            openFileDialog1.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            openFileDialog1.ShowDialog();

            try {
                using (var sr = new StreamReader(openFileDialog1.OpenFile())) {
                    ProcessCode(sr.ReadToEnd());
                }
            } catch (Exception ex) {

            }
        }

        private void formPanel_Paint(object sender, PaintEventArgs e) {
            if (_loadedForm == null) return;

            e.Graphics.Clear(SystemColors.Control);
            _loadedForm.Paint(e.Graphics);
        }

        private void toolbarPanel_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                _originClickToolbar = e.Location;
            }
        }

        private void toolbarPanel_MouseMove(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                formBorderPanel.Left += e.X - _originClickToolbar.X;
                formBorderPanel.Top += e.Y - _originClickToolbar.Y;
            }

        }

        private void formPanel_MouseMove(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.None) {
                List<VBControl> hitResult;
                VBControl deepestHitControl;

                if (_loadedForm == null) return;

                hitResult = _loadedForm.HitTest(e.Location);
                if (hitResult == null) {
                    if (_hoveringControl != null) {
                        _hoveringControl.Focused = false;
                        formPanel.Invalidate();
                    }
                    return;
                }

                deepestHitControl = hitResult.Last();

                if (deepestHitControl == _hoveringControl) return;
                if (_hoveringControl != null) _hoveringControl.Focused = false;

                deepestHitControl.Focused = true;
                _hoveringControl = deepestHitControl;

                formPanel.Invalidate();
            }
        }

        private void formPanel_MouseLeave(object sender, EventArgs e) {
            if (_loadedForm == null) return;
            if (_hoveringControl != null) _hoveringControl.Focused = false;
        }
    }
}

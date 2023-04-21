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

        private void ProcessCode(string data) {
            var tree = GetTree(data);
            var propertiesVisitor = new PropertiesVisitor();
            VBForm form;

            propertiesVisitor.Visit(tree);
            form = propertiesVisitor.Result;
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
    }
}

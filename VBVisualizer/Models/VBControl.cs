using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VBVisualizer.Models {
    public class VBControl {

        public string Name { get; set; }
        public VBControl Parent { get; set; }

        public bool Focused { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }
        public Color Forecolor { get; set; }
        public virtual Color BackgroundColor { get; set; } = Color.LightGray;
        public virtual int AbsoluteLeft => Parent.AbsoluteLeft + Left;
        public virtual int AbsoluteTop => Parent.AbsoluteTop + Top;

        protected List<VBControl> _controls = new List<VBControl>();

        public VBControl(string name) {
            Name = name;
        }

        protected int TwipsToPixels(int twips) {
            return (int)(twips * 0.0666666667);
        }

        public void AddControl(VBControl control) {
            _controls.Add(control);
        }

        public void AddProperty(string name, string value) {
            switch (name.ToLower()) {
                case "clientheight":
                    Height = TwipsToPixels(int.Parse(value)); break;
                case "height":
                    Height = TwipsToPixels(int.Parse(value)); break;

                case "clientwidth":
                    Width = TwipsToPixels(int.Parse(value)); break;
                case "width":
                    Width = TwipsToPixels(int.Parse(value)); break;

                case "left":
                    Left = TwipsToPixels(int.Parse(value)); break;

                case "top":
                    Top = TwipsToPixels(int.Parse(value)); break;

                case "forecolor":
                    var colorHexValue = Regex.Replace(value, @"[&H]", "");
                    var color = Color.FromArgb(int.Parse(colorHexValue, System.Globalization.NumberStyles.HexNumber));
                    Forecolor = color;
                    break;
            }
        }

        protected bool PointInside(Point location) {
            return location.X >= AbsoluteLeft && location.X <= AbsoluteLeft + Width &&
                   location.Y >= AbsoluteTop && location.Y <= AbsoluteTop + Height;
        }

        public virtual List<VBControl> HitTest(Point location) {
            var result = new List<VBControl>();

            if (!PointInside(location)) return null;
            result.Add(this);

            foreach (var child in _controls) {
                var childrenHitTestResult = child.HitTest(location);
                if (childrenHitTestResult == null) continue;

                result.AddRange(childrenHitTestResult);
            }

            return result;
        }

        public virtual void Paint(Graphics graphics) {
            using (var brush = new SolidBrush(BackgroundColor)) {
                graphics.FillRectangle(brush, AbsoluteLeft, AbsoluteTop, Width, Height);
            }

            if (!Focused) PaintBorder(graphics);
            else PaintHighlight(graphics);

            PaintCaption(graphics);

            foreach (var child in _controls) {
                child.Paint(graphics);
            }
        }

        public virtual void PaintBorder(Graphics graphics) {
            using (var pen = new Pen(Color.Black, 1)) {
                graphics.DrawRectangle(pen, AbsoluteLeft, AbsoluteTop, Width, Height);
            }
        }

        public virtual void PaintHighlight(Graphics graphics) {
            using (var pen = new Pen(Color.Black, 1)) {
                float[] dashValues = { 5, 2 };

                pen.DashPattern = dashValues;
                graphics.DrawRectangle(pen, AbsoluteLeft, AbsoluteTop, Width, Height);
            }
        }

        public virtual void PaintCaption(Graphics graphics) {
            using (var font = new Font(FontFamily.GenericMonospace, 8)) {
                using (var brush = new SolidBrush(Color.Black)) {
                    graphics.DrawString(Name, font, brush, AbsoluteLeft, AbsoluteTop);
                }
            }
        }
    }
}

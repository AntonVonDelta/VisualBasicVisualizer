namespace VBVisualizer {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.mainTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.btnOpen = new System.Windows.Forms.Button();
            this.viewPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.formBorderPanel = new System.Windows.Forms.Panel();
            this.formLayout = new System.Windows.Forms.TableLayoutPanel();
            this.toolbarPanel = new System.Windows.Forms.Panel();
            this.formPanel = new System.Windows.Forms.Panel();
            this.mainTableLayout.SuspendLayout();
            this.viewPanel.SuspendLayout();
            this.formBorderPanel.SuspendLayout();
            this.formLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // mainTableLayout
            // 
            this.mainTableLayout.ColumnCount = 2;
            this.mainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.07602F));
            this.mainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.92398F));
            this.mainTableLayout.Controls.Add(this.btnOpen, 0, 0);
            this.mainTableLayout.Controls.Add(this.viewPanel, 0, 1);
            this.mainTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayout.Location = new System.Drawing.Point(0, 0);
            this.mainTableLayout.Name = "mainTableLayout";
            this.mainTableLayout.RowCount = 2;
            this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.595409F));
            this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.40459F));
            this.mainTableLayout.Size = new System.Drawing.Size(1094, 697);
            this.mainTableLayout.TabIndex = 6;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(3, 3);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 6;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // viewPanel
            // 
            this.viewPanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.mainTableLayout.SetColumnSpan(this.viewPanel, 2);
            this.viewPanel.Controls.Add(this.button1);
            this.viewPanel.Controls.Add(this.formBorderPanel);
            this.viewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewPanel.Location = new System.Drawing.Point(0, 39);
            this.viewPanel.Margin = new System.Windows.Forms.Padding(0);
            this.viewPanel.Name = "viewPanel";
            this.viewPanel.Size = new System.Drawing.Size(1094, 658);
            this.viewPanel.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button1.Location = new System.Drawing.Point(387, 507);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // formBorderPanel
            // 
            this.formBorderPanel.AutoSize = true;
            this.formBorderPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.formBorderPanel.Controls.Add(this.formLayout);
            this.formBorderPanel.Location = new System.Drawing.Point(63, 47);
            this.formBorderPanel.Name = "formBorderPanel";
            this.formBorderPanel.Size = new System.Drawing.Size(770, 319);
            this.formBorderPanel.TabIndex = 9;
            // 
            // formLayout
            // 
            this.formLayout.AutoSize = true;
            this.formLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.formLayout.ColumnCount = 1;
            this.formLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.formLayout.Controls.Add(this.toolbarPanel, 0, 0);
            this.formLayout.Controls.Add(this.formPanel, 0, 1);
            this.formLayout.Location = new System.Drawing.Point(0, 0);
            this.formLayout.Margin = new System.Windows.Forms.Padding(0);
            this.formLayout.Name = "formLayout";
            this.formLayout.RowCount = 2;
            this.formLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.formLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.formLayout.Size = new System.Drawing.Size(770, 319);
            this.formLayout.TabIndex = 9;
            // 
            // toolbarPanel
            // 
            this.toolbarPanel.AutoSize = true;
            this.toolbarPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.toolbarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(222)))), ((int)(((byte)(250)))));
            this.toolbarPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolbarPanel.Location = new System.Drawing.Point(0, 0);
            this.toolbarPanel.Margin = new System.Windows.Forms.Padding(0);
            this.toolbarPanel.Name = "toolbarPanel";
            this.toolbarPanel.Size = new System.Drawing.Size(770, 20);
            this.toolbarPanel.TabIndex = 0;
            this.toolbarPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolbarPanel_MouseDown);
            this.toolbarPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.toolbarPanel_MouseMove);
            // 
            // formPanel
            // 
            this.formPanel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.formPanel.Location = new System.Drawing.Point(0, 20);
            this.formPanel.Margin = new System.Windows.Forms.Padding(0);
            this.formPanel.Name = "formPanel";
            this.formPanel.Size = new System.Drawing.Size(770, 299);
            this.formPanel.TabIndex = 2;
            this.formPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.formPanel_Paint);
            this.formPanel.MouseLeave += new System.EventHandler(this.formPanel_MouseLeave);
            this.formPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.formPanel_MouseMove);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 697);
            this.Controls.Add(this.mainTableLayout);
            this.Name = "Form1";
            this.Text = "Form1";
            this.mainTableLayout.ResumeLayout(false);
            this.viewPanel.ResumeLayout(false);
            this.viewPanel.PerformLayout();
            this.formBorderPanel.ResumeLayout(false);
            this.formBorderPanel.PerformLayout();
            this.formLayout.ResumeLayout(false);
            this.formLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TableLayoutPanel mainTableLayout;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Panel viewPanel;
        private System.Windows.Forms.Panel formBorderPanel;
        private System.Windows.Forms.TableLayoutPanel formLayout;
        private System.Windows.Forms.Panel toolbarPanel;
        private System.Windows.Forms.Panel formPanel;
        private System.Windows.Forms.Button button1;
    }
}


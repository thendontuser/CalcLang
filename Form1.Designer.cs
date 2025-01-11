namespace CalcLang
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            CodeSection = new RichTextBox();
            label1 = new Label();
            OutputBox = new ListBox();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            runToolStripMenuItem = new ToolStripMenuItem();
            themeToolStripMenuItem = new ToolStripMenuItem();
            lightToolStripMenuItem = new ToolStripMenuItem();
            darkToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1 = new ContextMenuStrip(components);
            LineCounter = new RichTextBox();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // CodeSection
            // 
            CodeSection.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            CodeSection.BackColor = Color.FromArgb(32, 32, 32);
            CodeSection.BorderStyle = BorderStyle.FixedSingle;
            CodeSection.Font = new Font("Microsoft YaHei", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            CodeSection.ForeColor = SystemColors.ControlLightLight;
            CodeSection.Location = new Point(111, 31);
            CodeSection.Margin = new Padding(4, 3, 4, 3);
            CodeSection.Name = "CodeSection";
            CodeSection.Size = new Size(1237, 555);
            CodeSection.TabIndex = 0;
            CodeSection.Text = "";
            CodeSection.TextChanged += CodeSection_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 589);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(65, 23);
            label1.TabIndex = 1;
            label1.Text = "Output";
            // 
            // OutputBox
            // 
            OutputBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            OutputBox.BackColor = Color.FromArgb(32, 32, 32);
            OutputBox.BorderStyle = BorderStyle.FixedSingle;
            OutputBox.Font = new Font("Microsoft YaHei", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            OutputBox.ForeColor = SystemColors.Window;
            OutputBox.FormattingEnabled = true;
            OutputBox.ItemHeight = 27;
            OutputBox.Location = new Point(0, 615);
            OutputBox.Margin = new Padding(4, 3, 4, 3);
            OutputBox.Name = "OutputBox";
            OutputBox.Size = new Size(1348, 110);
            OutputBox.TabIndex = 2;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(32, 32, 32);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, themeToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1348, 31);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, saveToolStripMenuItem, runToolStripMenuItem });
            fileToolStripMenuItem.Font = new Font("Microsoft YaHei", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            fileToolStripMenuItem.ForeColor = Color.White;
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(53, 27);
            fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(139, 28);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(139, 28);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // runToolStripMenuItem
            // 
            runToolStripMenuItem.Name = "runToolStripMenuItem";
            runToolStripMenuItem.Size = new Size(139, 28);
            runToolStripMenuItem.Text = "Run";
            runToolStripMenuItem.Click += runToolStripMenuItem_Click;
            // 
            // themeToolStripMenuItem
            // 
            themeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { lightToolStripMenuItem, darkToolStripMenuItem });
            themeToolStripMenuItem.Font = new Font("Microsoft YaHei", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            themeToolStripMenuItem.ForeColor = Color.White;
            themeToolStripMenuItem.Name = "themeToolStripMenuItem";
            themeToolStripMenuItem.Size = new Size(80, 27);
            themeToolStripMenuItem.Text = "Theme";
            // 
            // lightToolStripMenuItem
            // 
            lightToolStripMenuItem.Name = "lightToolStripMenuItem";
            lightToolStripMenuItem.Size = new Size(135, 28);
            lightToolStripMenuItem.Text = "Light";
            lightToolStripMenuItem.Click += lightToolStripMenuItem_Click;
            // 
            // darkToolStripMenuItem
            // 
            darkToolStripMenuItem.Name = "darkToolStripMenuItem";
            darkToolStripMenuItem.Size = new Size(135, 28);
            darkToolStripMenuItem.Text = "Dark";
            darkToolStripMenuItem.Click += darkToolStripMenuItem_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // LineCounter
            // 
            LineCounter.BackColor = Color.FromArgb(32, 32, 32);
            LineCounter.Font = new Font("Microsoft YaHei", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            LineCounter.ForeColor = SystemColors.ControlLightLight;
            LineCounter.Location = new Point(7, 34);
            LineCounter.Name = "LineCounter";
            LineCounter.ReadOnly = true;
            LineCounter.Size = new Size(97, 552);
            LineCounter.TabIndex = 8;
            LineCounter.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(32, 32, 32);
            ClientSize = new Size(1348, 731);
            Controls.Add(LineCounter);
            Controls.Add(OutputBox);
            Controls.Add(label1);
            Controls.Add(CodeSection);
            Controls.Add(menuStrip1);
            Font = new Font("Yu Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ForeColor = SystemColors.ButtonHighlight;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "CalcLang";
            FormClosing += Form1_FormClosing;
            KeyDown += Form1_KeyDown;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox CodeSection;
        private Label label1;
        private ListBox OutputBox;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem runToolStripMenuItem;
        private ToolStripMenuItem themeToolStripMenuItem;
        private ToolStripMenuItem lightToolStripMenuItem;
        private ToolStripMenuItem darkToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip1;
        private RichTextBox LineCounter;
    }
}
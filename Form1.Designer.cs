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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            CodeSection = new RichTextBox();
            label1 = new Label();
            OutputBox = new ListBox();
            RunBtn = new Button();
            OpenBtn = new Button();
            SaveBtn = new Button();
            SuspendLayout();
            // 
            // CodeSection
            // 
            CodeSection.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CodeSection.BackColor = Color.FromArgb(0, 0, 64);
            CodeSection.BorderStyle = BorderStyle.FixedSingle;
            CodeSection.ForeColor = SystemColors.ControlLightLight;
            CodeSection.Location = new Point(12, 47);
            CodeSection.Name = "CodeSection";
            CodeSection.Size = new Size(1156, 415);
            CodeSection.TabIndex = 0;
            CodeSection.Text = "";
            CodeSection.TextChanged += CodeSection_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 465);
            label1.Name = "label1";
            label1.Size = new Size(55, 20);
            label1.TabIndex = 1;
            label1.Text = "Output";
            // 
            // OutputBox
            // 
            OutputBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            OutputBox.BackColor = Color.FromArgb(0, 0, 64);
            OutputBox.ForeColor = SystemColors.Window;
            OutputBox.FormattingEnabled = true;
            OutputBox.Location = new Point(12, 488);
            OutputBox.Name = "OutputBox";
            OutputBox.Size = new Size(1156, 124);
            OutputBox.TabIndex = 2;
            // 
            // RunBtn
            // 
            RunBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            RunBtn.BackColor = SystemColors.ActiveBorder;
            RunBtn.ForeColor = SystemColors.ActiveCaptionText;
            RunBtn.Location = new Point(1074, 12);
            RunBtn.Name = "RunBtn";
            RunBtn.Size = new Size(94, 29);
            RunBtn.TabIndex = 3;
            RunBtn.Text = "Run";
            RunBtn.UseVisualStyleBackColor = false;
            RunBtn.Click += RunBtn_Click;
            // 
            // OpenBtn
            // 
            OpenBtn.BackColor = SystemColors.ActiveBorder;
            OpenBtn.ForeColor = SystemColors.ActiveCaptionText;
            OpenBtn.Location = new Point(12, 12);
            OpenBtn.Name = "OpenBtn";
            OpenBtn.Size = new Size(94, 29);
            OpenBtn.TabIndex = 4;
            OpenBtn.Text = "Open";
            OpenBtn.UseVisualStyleBackColor = false;
            OpenBtn.Click += OpenBtn_Click;
            // 
            // SaveBtn
            // 
            SaveBtn.BackColor = SystemColors.ActiveBorder;
            SaveBtn.ForeColor = SystemColors.ActiveCaptionText;
            SaveBtn.Location = new Point(112, 12);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(94, 29);
            SaveBtn.TabIndex = 5;
            SaveBtn.Text = "Save";
            SaveBtn.UseVisualStyleBackColor = false;
            SaveBtn.Click += SaveBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(0, 0, 64);
            ClientSize = new Size(1180, 637);
            Controls.Add(SaveBtn);
            Controls.Add(OpenBtn);
            Controls.Add(RunBtn);
            Controls.Add(OutputBox);
            Controls.Add(label1);
            Controls.Add(CodeSection);
            ForeColor = SystemColors.ButtonHighlight;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "CalcLang";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox CodeSection;
        private Label label1;
        private ListBox OutputBox;
        private Button RunBtn;
        private Button OpenBtn;
        private Button SaveBtn;
    }
}

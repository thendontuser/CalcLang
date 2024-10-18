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
            CodeSection.Font = new Font("Microsoft YaHei", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            CodeSection.ForeColor = SystemColors.ControlLightLight;
            CodeSection.Location = new Point(16, 54);
            CodeSection.Margin = new Padding(4, 3, 4, 3);
            CodeSection.Name = "CodeSection";
            CodeSection.Size = new Size(1317, 475);
            CodeSection.TabIndex = 0;
            CodeSection.Text = "";
            CodeSection.TextChanged += CodeSection_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 535);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(65, 23);
            label1.TabIndex = 1;
            label1.Text = "Output";
            // 
            // OutputBox
            // 
            OutputBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            OutputBox.BackColor = Color.FromArgb(0, 0, 64);
            OutputBox.Font = new Font("Microsoft YaHei", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            OutputBox.ForeColor = SystemColors.Window;
            OutputBox.FormattingEnabled = true;
            OutputBox.ItemHeight = 27;
            OutputBox.Location = new Point(16, 561);
            OutputBox.Margin = new Padding(4, 3, 4, 3);
            OutputBox.Name = "OutputBox";
            OutputBox.Size = new Size(1317, 112);
            OutputBox.TabIndex = 2;
            // 
            // RunBtn
            // 
            RunBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            RunBtn.BackColor = SystemColors.ActiveBorder;
            RunBtn.ForeColor = SystemColors.ActiveCaptionText;
            RunBtn.Location = new Point(1206, 14);
            RunBtn.Margin = new Padding(4, 3, 4, 3);
            RunBtn.Name = "RunBtn";
            RunBtn.Size = new Size(129, 33);
            RunBtn.TabIndex = 3;
            RunBtn.Text = "Run";
            RunBtn.UseVisualStyleBackColor = false;
            RunBtn.Click += RunBtn_Click;
            // 
            // OpenBtn
            // 
            OpenBtn.BackColor = SystemColors.ActiveBorder;
            OpenBtn.ForeColor = SystemColors.ActiveCaptionText;
            OpenBtn.Location = new Point(16, 14);
            OpenBtn.Margin = new Padding(4, 3, 4, 3);
            OpenBtn.Name = "OpenBtn";
            OpenBtn.Size = new Size(129, 33);
            OpenBtn.TabIndex = 4;
            OpenBtn.Text = "Open";
            OpenBtn.UseVisualStyleBackColor = false;
            OpenBtn.Click += OpenBtn_Click;
            // 
            // SaveBtn
            // 
            SaveBtn.BackColor = SystemColors.ActiveBorder;
            SaveBtn.ForeColor = SystemColors.ActiveCaptionText;
            SaveBtn.Location = new Point(154, 14);
            SaveBtn.Margin = new Padding(4, 3, 4, 3);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(129, 33);
            SaveBtn.TabIndex = 5;
            SaveBtn.Text = "Save";
            SaveBtn.UseVisualStyleBackColor = false;
            SaveBtn.Click += SaveBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(0, 0, 64);
            ClientSize = new Size(1351, 731);
            Controls.Add(SaveBtn);
            Controls.Add(OpenBtn);
            Controls.Add(RunBtn);
            Controls.Add(OutputBox);
            Controls.Add(label1);
            Controls.Add(CodeSection);
            Font = new Font("Yu Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ForeColor = SystemColors.ButtonHighlight;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
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

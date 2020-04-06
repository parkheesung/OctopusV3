namespace OctopusV3.Builder.EntityFrm
{
    partial class SPtoCodeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TB_Search = new System.Windows.Forms.TextBox();
            this.btn_load = new System.Windows.Forms.Button();
            this.LB_SP = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CK_Method = new System.Windows.Forms.CheckBox();
            this.btn_copy = new System.Windows.Forms.Button();
            this.btn_output = new System.Windows.Forms.Button();
            this.IsConnection = new System.Windows.Forms.CheckBox();
            this.CB_TYPE = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TB_OUTPUT = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.TB_Search);
            this.groupBox1.Controls.Add(this.btn_load);
            this.groupBox1.Controls.Add(this.LB_SP);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(303, 425);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stored Procedures";
            // 
            // TB_Search
            // 
            this.TB_Search.Location = new System.Drawing.Point(7, 61);
            this.TB_Search.Name = "TB_Search";
            this.TB_Search.Size = new System.Drawing.Size(290, 21);
            this.TB_Search.TabIndex = 2;
            this.TB_Search.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TB_Search_KeyUp);
            // 
            // btn_load
            // 
            this.btn_load.Location = new System.Drawing.Point(7, 23);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(290, 31);
            this.btn_load.TabIndex = 1;
            this.btn_load.Text = "LOAD";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // LB_SP
            // 
            this.LB_SP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LB_SP.FormattingEnabled = true;
            this.LB_SP.ItemHeight = 12;
            this.LB_SP.Location = new System.Drawing.Point(7, 93);
            this.LB_SP.Name = "LB_SP";
            this.LB_SP.ScrollAlwaysVisible = true;
            this.LB_SP.Size = new System.Drawing.Size(290, 328);
            this.LB_SP.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.CK_Method);
            this.groupBox2.Controls.Add(this.btn_copy);
            this.groupBox2.Controls.Add(this.btn_output);
            this.groupBox2.Controls.Add(this.IsConnection);
            this.groupBox2.Controls.Add(this.CB_TYPE);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(322, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(466, 140);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // CK_Method
            // 
            this.CK_Method.AutoSize = true;
            this.CK_Method.Location = new System.Drawing.Point(233, 50);
            this.CK_Method.Name = "CK_Method";
            this.CK_Method.Size = new System.Drawing.Size(140, 16);
            this.CK_Method.TabIndex = 5;
            this.CK_Method.Text = "메소드를 포함합니다.";
            this.CK_Method.UseVisualStyleBackColor = true;
            this.CK_Method.CheckedChanged += new System.EventHandler(this.CK_Method_CheckedChanged);
            // 
            // btn_copy
            // 
            this.btn_copy.Location = new System.Drawing.Point(103, 72);
            this.btn_copy.Name = "btn_copy";
            this.btn_copy.Size = new System.Drawing.Size(86, 58);
            this.btn_copy.TabIndex = 4;
            this.btn_copy.Text = "COPY";
            this.btn_copy.UseVisualStyleBackColor = true;
            this.btn_copy.Click += new System.EventHandler(this.btn_copy_Click);
            // 
            // btn_output
            // 
            this.btn_output.Location = new System.Drawing.Point(11, 72);
            this.btn_output.Name = "btn_output";
            this.btn_output.Size = new System.Drawing.Size(86, 58);
            this.btn_output.TabIndex = 3;
            this.btn_output.Text = "OUTPUT";
            this.btn_output.UseVisualStyleBackColor = true;
            this.btn_output.Click += new System.EventHandler(this.btn_output_Click);
            // 
            // IsConnection
            // 
            this.IsConnection.AutoSize = true;
            this.IsConnection.Location = new System.Drawing.Point(87, 50);
            this.IsConnection.Name = "IsConnection";
            this.IsConnection.Size = new System.Drawing.Size(140, 16);
            this.IsConnection.TabIndex = 2;
            this.IsConnection.Text = "커넥션을 포함합니다.";
            this.IsConnection.UseVisualStyleBackColor = true;
            this.IsConnection.CheckedChanged += new System.EventHandler(this.IsConnection_CheckedChanged);
            // 
            // CB_TYPE
            // 
            this.CB_TYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_TYPE.FormattingEnabled = true;
            this.CB_TYPE.Items.AddRange(new object[] {
            "Void",
            "ReturnValue",
            "List<T>"});
            this.CB_TYPE.Location = new System.Drawing.Point(87, 23);
            this.CB_TYPE.Name = "CB_TYPE";
            this.CB_TYPE.Size = new System.Drawing.Size(196, 20);
            this.CB_TYPE.TabIndex = 1;
            this.CB_TYPE.SelectedIndexChanged += new System.EventHandler(this.CB_TYPE_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "반환유형 :";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.TB_OUTPUT);
            this.groupBox3.Location = new System.Drawing.Point(322, 160);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(466, 278);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "OUTPUT";
            // 
            // TB_OUTPUT
            // 
            this.TB_OUTPUT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_OUTPUT.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TB_OUTPUT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_OUTPUT.ForeColor = System.Drawing.Color.Lime;
            this.TB_OUTPUT.Location = new System.Drawing.Point(6, 20);
            this.TB_OUTPUT.MaxLength = 99999999;
            this.TB_OUTPUT.Multiline = true;
            this.TB_OUTPUT.Name = "TB_OUTPUT";
            this.TB_OUTPUT.ReadOnly = true;
            this.TB_OUTPUT.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TB_OUTPUT.Size = new System.Drawing.Size(454, 252);
            this.TB_OUTPUT.TabIndex = 0;
            // 
            // SPtoCodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "SPtoCodeForm";
            this.Text = "SPtoCodeForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox LB_SP;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox CB_TYPE;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox IsConnection;
        private System.Windows.Forms.TextBox TB_Search;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.Button btn_copy;
        private System.Windows.Forms.Button btn_output;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox TB_OUTPUT;
        private System.Windows.Forms.CheckBox CK_Method;
    }
}
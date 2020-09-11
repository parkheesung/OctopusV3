namespace OctopusV3.Builder.EntityFrm
{
    partial class CreateControllerForm
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
            this.TB_OUTPUT = new System.Windows.Forms.TextBox();
            this.btn_output = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CK_Entity = new System.Windows.Forms.CheckBox();
            this.TB_Return = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_Prefix = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CK_ALL = new System.Windows.Forms.CheckBox();
            this.LB_SP = new System.Windows.Forms.CheckedListBox();
            this.TB_Search = new System.Windows.Forms.TextBox();
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_load = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.CK_Route = new System.Windows.Forms.CheckBox();
            this.btn_copy = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // TB_OUTPUT
            // 
            this.TB_OUTPUT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_OUTPUT.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TB_OUTPUT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_OUTPUT.Font = new System.Drawing.Font("돋움", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TB_OUTPUT.ForeColor = System.Drawing.Color.Lime;
            this.TB_OUTPUT.Location = new System.Drawing.Point(6, 20);
            this.TB_OUTPUT.MaxLength = 99999999;
            this.TB_OUTPUT.Multiline = true;
            this.TB_OUTPUT.Name = "TB_OUTPUT";
            this.TB_OUTPUT.ReadOnly = true;
            this.TB_OUTPUT.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TB_OUTPUT.Size = new System.Drawing.Size(665, 413);
            this.TB_OUTPUT.TabIndex = 0;
            // 
            // btn_output
            // 
            this.btn_output.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_output.Location = new System.Drawing.Point(437, 94);
            this.btn_output.Name = "btn_output";
            this.btn_output.Size = new System.Drawing.Size(109, 46);
            this.btn_output.TabIndex = 8;
            this.btn_output.Text = "OUTPUT";
            this.btn_output.UseVisualStyleBackColor = true;
            this.btn_output.Click += new System.EventHandler(this.btn_output_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btn_copy);
            this.groupBox2.Controls.Add(this.CK_Route);
            this.groupBox2.Controls.Add(this.CK_Entity);
            this.groupBox2.Controls.Add(this.TB_Return);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btn_output);
            this.groupBox2.Controls.Add(this.TB_Prefix);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(220, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(677, 162);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Require Input";
            // 
            // CK_Entity
            // 
            this.CK_Entity.AutoSize = true;
            this.CK_Entity.Location = new System.Drawing.Point(14, 104);
            this.CK_Entity.Name = "CK_Entity";
            this.CK_Entity.Size = new System.Drawing.Size(112, 16);
            this.CK_Entity.TabIndex = 13;
            this.CK_Entity.Text = "엔티티 사용여부";
            this.CK_Entity.UseVisualStyleBackColor = true;
            this.CK_Entity.CheckedChanged += new System.EventHandler(this.CK_Entity_CheckedChanged);
            // 
            // TB_Return
            // 
            this.TB_Return.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Return.Location = new System.Drawing.Point(121, 49);
            this.TB_Return.MaxLength = 100;
            this.TB_Return.Name = "TB_Return";
            this.TB_Return.Size = new System.Drawing.Size(535, 21);
            this.TB_Return.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "반환형 :";
            // 
            // TB_Prefix
            // 
            this.TB_Prefix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Prefix.Location = new System.Drawing.Point(121, 22);
            this.TB_Prefix.MaxLength = 100;
            this.TB_Prefix.Name = "TB_Prefix";
            this.TB_Prefix.Size = new System.Drawing.Size(535, 21);
            this.TB_Prefix.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Prefix :";
            // 
            // CK_ALL
            // 
            this.CK_ALL.AutoSize = true;
            this.CK_ALL.Location = new System.Drawing.Point(9, 94);
            this.CK_ALL.Name = "CK_ALL";
            this.CK_ALL.Size = new System.Drawing.Size(78, 16);
            this.CK_ALL.TabIndex = 3;
            this.CK_ALL.Text = "Check All";
            this.CK_ALL.UseVisualStyleBackColor = true;
            this.CK_ALL.CheckedChanged += new System.EventHandler(this.CK_ALL_CheckedChanged);
            // 
            // LB_SP
            // 
            this.LB_SP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LB_SP.FormattingEnabled = true;
            this.LB_SP.Location = new System.Drawing.Point(9, 126);
            this.LB_SP.Name = "LB_SP";
            this.LB_SP.Size = new System.Drawing.Size(183, 468);
            this.LB_SP.TabIndex = 2;
            this.LB_SP.SelectedIndexChanged += new System.EventHandler(this.LB_SP_SelectedIndexChanged);
            // 
            // TB_Search
            // 
            this.TB_Search.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Search.Font = new System.Drawing.Font("돋움", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TB_Search.Location = new System.Drawing.Point(9, 62);
            this.TB_Search.MaxLength = 100;
            this.TB_Search.Name = "TB_Search";
            this.TB_Search.Size = new System.Drawing.Size(183, 25);
            this.TB_Search.TabIndex = 1;
            this.TB_Search.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TB_Search_KeyUp);
            // 
            // pBar
            // 
            this.pBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pBar.Location = new System.Drawing.Point(13, 627);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(884, 23);
            this.pBar.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.CK_ALL);
            this.groupBox1.Controls.Add(this.LB_SP);
            this.groupBox1.Controls.Add(this.TB_Search);
            this.groupBox1.Controls.Add(this.btn_load);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 608);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SP List";
            // 
            // btn_load
            // 
            this.btn_load.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_load.Location = new System.Drawing.Point(9, 22);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(183, 33);
            this.btn_load.TabIndex = 0;
            this.btn_load.Text = "LOAD";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.TB_OUTPUT);
            this.groupBox4.Location = new System.Drawing.Point(220, 181);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(677, 440);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Message";
            // 
            // CK_Route
            // 
            this.CK_Route.AutoSize = true;
            this.CK_Route.Location = new System.Drawing.Point(14, 126);
            this.CK_Route.Name = "CK_Route";
            this.CK_Route.Size = new System.Drawing.Size(112, 16);
            this.CK_Route.TabIndex = 14;
            this.CK_Route.Text = "라우터 지정여부";
            this.CK_Route.UseVisualStyleBackColor = true;
            // 
            // btn_copy
            // 
            this.btn_copy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_copy.Location = new System.Drawing.Point(552, 94);
            this.btn_copy.Name = "btn_copy";
            this.btn_copy.Size = new System.Drawing.Size(104, 46);
            this.btn_copy.TabIndex = 15;
            this.btn_copy.Text = "COPY";
            this.btn_copy.UseVisualStyleBackColor = true;
            this.btn_copy.Click += new System.EventHandler(this.btn_copy_Click);
            // 
            // CreateControllerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 662);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pBar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Name = "CreateControllerForm";
            this.Text = "CreateControllerForm";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox TB_OUTPUT;
        private System.Windows.Forms.Button btn_output;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TB_Prefix;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CK_ALL;
        private System.Windows.Forms.CheckedListBox LB_SP;
        private System.Windows.Forms.TextBox TB_Search;
        private System.Windows.Forms.ProgressBar pBar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox TB_Return;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox CK_Entity;
        private System.Windows.Forms.CheckBox CK_Route;
        private System.Windows.Forms.Button btn_copy;
    }
}
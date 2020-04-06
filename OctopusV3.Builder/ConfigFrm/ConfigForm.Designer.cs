namespace OctopusV3.Builder.ConfigFrm
{
    partial class ConfigForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.TB_Address = new System.Windows.Forms.TextBox();
            this.TB_UserID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_Password = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Btn_Connect = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CB_Context = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Btn_Bind = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.TB_Msg = new System.Windows.Forms.TextBox();
            this.Btn_Load = new System.Windows.Forms.Button();
            this.Btn_Save = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Btn_Connect);
            this.groupBox1.Controls.Add(this.TB_Password);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TB_UserID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TB_Address);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 164);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection Database";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Address :";
            // 
            // TB_Address
            // 
            this.TB_Address.Location = new System.Drawing.Point(92, 25);
            this.TB_Address.MaxLength = 255;
            this.TB_Address.Name = "TB_Address";
            this.TB_Address.Size = new System.Drawing.Size(177, 21);
            this.TB_Address.TabIndex = 1;
            // 
            // TB_UserID
            // 
            this.TB_UserID.Location = new System.Drawing.Point(92, 52);
            this.TB_UserID.MaxLength = 50;
            this.TB_UserID.Name = "TB_UserID";
            this.TB_UserID.Size = new System.Drawing.Size(177, 21);
            this.TB_UserID.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "User ID :";
            // 
            // TB_Password
            // 
            this.TB_Password.Location = new System.Drawing.Point(92, 79);
            this.TB_Password.MaxLength = 100;
            this.TB_Password.Name = "TB_Password";
            this.TB_Password.Size = new System.Drawing.Size(177, 21);
            this.TB_Password.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password :";
            // 
            // Btn_Connect
            // 
            this.Btn_Connect.Location = new System.Drawing.Point(23, 111);
            this.Btn_Connect.Name = "Btn_Connect";
            this.Btn_Connect.Size = new System.Drawing.Size(246, 35);
            this.Btn_Connect.TabIndex = 6;
            this.Btn_Connect.Text = "Connect";
            this.Btn_Connect.UseVisualStyleBackColor = true;
            this.Btn_Connect.Click += new System.EventHandler(this.Btn_Connect_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.Btn_Bind);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.CB_Context);
            this.groupBox2.Location = new System.Drawing.Point(316, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(472, 164);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DB Context Select";
            // 
            // CB_Context
            // 
            this.CB_Context.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_Context.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Context.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_Context.FormattingEnabled = true;
            this.CB_Context.Location = new System.Drawing.Point(17, 45);
            this.CB_Context.Name = "CB_Context";
            this.CB_Context.Size = new System.Drawing.Size(432, 36);
            this.CB_Context.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "Database :";
            // 
            // Btn_Bind
            // 
            this.Btn_Bind.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Bind.Location = new System.Drawing.Point(17, 95);
            this.Btn_Bind.Name = "Btn_Bind";
            this.Btn_Bind.Size = new System.Drawing.Size(432, 51);
            this.Btn_Bind.TabIndex = 2;
            this.Btn_Bind.Text = "Binding";
            this.Btn_Bind.UseVisualStyleBackColor = true;
            this.Btn_Bind.Click += new System.EventHandler(this.Btn_Bind_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.Btn_Save);
            this.groupBox3.Controls.Add(this.Btn_Load);
            this.groupBox3.Location = new System.Drawing.Point(13, 184);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 254);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Buttons";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.TB_Msg);
            this.groupBox4.Location = new System.Drawing.Point(220, 184);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(568, 254);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Message";
            // 
            // TB_Msg
            // 
            this.TB_Msg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Msg.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TB_Msg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_Msg.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TB_Msg.ForeColor = System.Drawing.Color.Lime;
            this.TB_Msg.Location = new System.Drawing.Point(7, 21);
            this.TB_Msg.MaxLength = 99999999;
            this.TB_Msg.Multiline = true;
            this.TB_Msg.Name = "TB_Msg";
            this.TB_Msg.ReadOnly = true;
            this.TB_Msg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TB_Msg.Size = new System.Drawing.Size(555, 227);
            this.TB_Msg.TabIndex = 0;
            // 
            // Btn_Load
            // 
            this.Btn_Load.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Load.Location = new System.Drawing.Point(6, 21);
            this.Btn_Load.Name = "Btn_Load";
            this.Btn_Load.Size = new System.Drawing.Size(188, 38);
            this.Btn_Load.TabIndex = 0;
            this.Btn_Load.Text = "LOAD";
            this.Btn_Load.UseVisualStyleBackColor = true;
            this.Btn_Load.Click += new System.EventHandler(this.Btn_Load_Click);
            // 
            // Btn_Save
            // 
            this.Btn_Save.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Save.Location = new System.Drawing.Point(6, 65);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(188, 38);
            this.Btn_Save.TabIndex = 1;
            this.Btn_Save.Text = "SAVE";
            this.Btn_Save.UseVisualStyleBackColor = true;
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ConfigForm";
            this.Text = "ConfigForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Btn_Connect;
        private System.Windows.Forms.TextBox TB_Password;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_UserID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_Address;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Btn_Bind;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CB_Context;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox TB_Msg;
        private System.Windows.Forms.Button Btn_Load;
        private System.Windows.Forms.Button Btn_Save;
    }
}
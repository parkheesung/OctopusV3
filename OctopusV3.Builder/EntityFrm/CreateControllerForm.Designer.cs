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
            this.TB_Msg = new System.Windows.Forms.TextBox();
            this.TB_Prefix = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_output = new System.Windows.Forms.Button();
            this.Btn_Create = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CK_Overwrite = new System.Windows.Forms.CheckBox();
            this.CK_UseFramework = new System.Windows.Forms.CheckBox();
            this.Btn_Find = new System.Windows.Forms.Button();
            this.TB_Location = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_NameSpace = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CK_ALL = new System.Windows.Forms.CheckBox();
            this.CB_List = new System.Windows.Forms.CheckedListBox();
            this.TB_Search = new System.Windows.Forms.TextBox();
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_load = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // TB_Msg
            // 
            this.TB_Msg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Msg.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TB_Msg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_Msg.Font = new System.Drawing.Font("돋움", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TB_Msg.ForeColor = System.Drawing.Color.Lime;
            this.TB_Msg.Location = new System.Drawing.Point(6, 20);
            this.TB_Msg.MaxLength = 99999999;
            this.TB_Msg.Multiline = true;
            this.TB_Msg.Name = "TB_Msg";
            this.TB_Msg.ReadOnly = true;
            this.TB_Msg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TB_Msg.Size = new System.Drawing.Size(556, 112);
            this.TB_Msg.TabIndex = 0;
            // 
            // TB_Prefix
            // 
            this.TB_Prefix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Prefix.Location = new System.Drawing.Point(64, 20);
            this.TB_Prefix.MaxLength = 50;
            this.TB_Prefix.Name = "TB_Prefix";
            this.TB_Prefix.Size = new System.Drawing.Size(482, 21);
            this.TB_Prefix.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.TB_Prefix);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(219, 204);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(568, 60);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Option Input";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "Prefix :";
            // 
            // btn_output
            // 
            this.btn_output.Location = new System.Drawing.Point(438, 126);
            this.btn_output.Name = "btn_output";
            this.btn_output.Size = new System.Drawing.Size(109, 46);
            this.btn_output.TabIndex = 8;
            this.btn_output.Text = "OUTPUT";
            this.btn_output.UseVisualStyleBackColor = true;
            // 
            // Btn_Create
            // 
            this.Btn_Create.Location = new System.Drawing.Point(323, 126);
            this.Btn_Create.Name = "Btn_Create";
            this.Btn_Create.Size = new System.Drawing.Size(109, 46);
            this.Btn_Create.TabIndex = 7;
            this.Btn_Create.Text = "CREATE";
            this.Btn_Create.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btn_output);
            this.groupBox2.Controls.Add(this.Btn_Create);
            this.groupBox2.Controls.Add(this.CK_Overwrite);
            this.groupBox2.Controls.Add(this.CK_UseFramework);
            this.groupBox2.Controls.Add(this.Btn_Find);
            this.groupBox2.Controls.Add(this.TB_Location);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.TB_NameSpace);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(220, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(568, 185);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Require Input";
            // 
            // CK_Overwrite
            // 
            this.CK_Overwrite.AutoSize = true;
            this.CK_Overwrite.Location = new System.Drawing.Point(14, 156);
            this.CK_Overwrite.Name = "CK_Overwrite";
            this.CK_Overwrite.Size = new System.Drawing.Size(128, 16);
            this.CK_Overwrite.TabIndex = 6;
            this.CK_Overwrite.Text = "저장시 덮어씁니다.";
            this.CK_Overwrite.UseVisualStyleBackColor = true;
            // 
            // CK_UseFramework
            // 
            this.CK_UseFramework.AutoSize = true;
            this.CK_UseFramework.Checked = true;
            this.CK_UseFramework.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CK_UseFramework.Location = new System.Drawing.Point(14, 134);
            this.CK_UseFramework.Name = "CK_UseFramework";
            this.CK_UseFramework.Size = new System.Drawing.Size(214, 16);
            this.CK_UseFramework.TabIndex = 5;
            this.CK_UseFramework.Text = "OctopusFramework를 포함합니다.";
            this.CK_UseFramework.UseVisualStyleBackColor = true;
            // 
            // Btn_Find
            // 
            this.Btn_Find.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Find.Location = new System.Drawing.Point(422, 70);
            this.Btn_Find.Name = "Btn_Find";
            this.Btn_Find.Size = new System.Drawing.Size(124, 23);
            this.Btn_Find.TabIndex = 4;
            this.Btn_Find.Text = "Find";
            this.Btn_Find.UseVisualStyleBackColor = true;
            // 
            // TB_Location
            // 
            this.TB_Location.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Location.Location = new System.Drawing.Point(78, 71);
            this.TB_Location.MaxLength = 512;
            this.TB_Location.Name = "TB_Location";
            this.TB_Location.Size = new System.Drawing.Size(337, 21);
            this.TB_Location.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Location :";
            // 
            // TB_NameSpace
            // 
            this.TB_NameSpace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_NameSpace.Location = new System.Drawing.Point(101, 17);
            this.TB_NameSpace.MaxLength = 100;
            this.TB_NameSpace.Name = "TB_NameSpace";
            this.TB_NameSpace.Size = new System.Drawing.Size(445, 21);
            this.TB_NameSpace.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "NameSpace :";
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
            // 
            // CB_List
            // 
            this.CB_List.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_List.FormattingEnabled = true;
            this.CB_List.Location = new System.Drawing.Point(9, 126);
            this.CB_List.Name = "CB_List";
            this.CB_List.Size = new System.Drawing.Size(183, 260);
            this.CB_List.TabIndex = 2;
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
            // 
            // pBar
            // 
            this.pBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pBar.Location = new System.Drawing.Point(13, 415);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(775, 23);
            this.pBar.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.CK_ALL);
            this.groupBox1.Controls.Add(this.CB_List);
            this.groupBox1.Controls.Add(this.TB_Search);
            this.groupBox1.Controls.Add(this.btn_load);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 396);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Table&View";
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
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.TB_Msg);
            this.groupBox4.Location = new System.Drawing.Point(220, 270);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(568, 139);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Message";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(101, 44);
            this.textBox1.MaxLength = 100;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(445, 21);
            this.textBox1.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "NameSpace :";
            // 
            // CreateControllerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pBar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Name = "CreateControllerForm";
            this.Text = "CreateControllerForm";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox TB_Msg;
        private System.Windows.Forms.TextBox TB_Prefix;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_output;
        private System.Windows.Forms.Button Btn_Create;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox CK_Overwrite;
        private System.Windows.Forms.CheckBox CK_UseFramework;
        private System.Windows.Forms.Button Btn_Find;
        private System.Windows.Forms.TextBox TB_Location;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_NameSpace;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CK_ALL;
        private System.Windows.Forms.CheckedListBox CB_List;
        private System.Windows.Forms.TextBox TB_Search;
        private System.Windows.Forms.ProgressBar pBar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
    }
}
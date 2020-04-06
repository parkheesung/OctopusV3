namespace OctopusV3.Builder.EntityFrm
{
    partial class CreateRepositoryForm
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
            this.btn_file = new System.Windows.Forms.Button();
            this.btn_Find = new System.Windows.Forms.Button();
            this.TB_Position = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_NameSpace = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_Name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Chk_Table = new System.Windows.Forms.CheckBox();
            this.Chk_SP = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TB_Output = new System.Windows.Forms.TextBox();
            this.btn_output = new System.Windows.Forms.Button();
            this.btn_Table = new System.Windows.Forms.Button();
            this.btn_load = new System.Windows.Forms.Button();
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btn_load);
            this.groupBox1.Controls.Add(this.btn_Table);
            this.groupBox1.Controls.Add(this.btn_output);
            this.groupBox1.Controls.Add(this.btn_file);
            this.groupBox1.Controls.Add(this.btn_Find);
            this.groupBox1.Controls.Add(this.TB_Position);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TB_NameSpace);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TB_Name);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Chk_Table);
            this.groupBox1.Controls.Add(this.Chk_SP);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(775, 152);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // btn_file
            // 
            this.btn_file.Location = new System.Drawing.Point(414, 103);
            this.btn_file.Name = "btn_file";
            this.btn_file.Size = new System.Drawing.Size(96, 38);
            this.btn_file.TabIndex = 8;
            this.btn_file.Text = "File Write";
            this.btn_file.UseVisualStyleBackColor = true;
            this.btn_file.Click += new System.EventHandler(this.btn_file_Click);
            // 
            // btn_Find
            // 
            this.btn_Find.Location = new System.Drawing.Point(313, 75);
            this.btn_Find.Name = "btn_Find";
            this.btn_Find.Size = new System.Drawing.Size(75, 23);
            this.btn_Find.TabIndex = 4;
            this.btn_Find.Text = "FIND";
            this.btn_Find.UseVisualStyleBackColor = true;
            this.btn_Find.Click += new System.EventHandler(this.btn_Find_Click);
            // 
            // TB_Position
            // 
            this.TB_Position.Location = new System.Drawing.Point(108, 76);
            this.TB_Position.Name = "TB_Position";
            this.TB_Position.Size = new System.Drawing.Size(202, 21);
            this.TB_Position.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "File Position :";
            // 
            // TB_NameSpace
            // 
            this.TB_NameSpace.Location = new System.Drawing.Point(108, 22);
            this.TB_NameSpace.Name = "TB_NameSpace";
            this.TB_NameSpace.Size = new System.Drawing.Size(202, 21);
            this.TB_NameSpace.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "NameSpace :";
            // 
            // TB_Name
            // 
            this.TB_Name.Location = new System.Drawing.Point(108, 49);
            this.TB_Name.Name = "TB_Name";
            this.TB_Name.Size = new System.Drawing.Size(202, 21);
            this.TB_Name.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Prefix Name :";
            // 
            // Chk_Table
            // 
            this.Chk_Table.AutoSize = true;
            this.Chk_Table.Location = new System.Drawing.Point(414, 46);
            this.Chk_Table.Name = "Chk_Table";
            this.Chk_Table.Size = new System.Drawing.Size(180, 16);
            this.Chk_Table.TabIndex = 6;
            this.Chk_Table.Text = "Table과 View를 포함합니다.";
            this.Chk_Table.UseVisualStyleBackColor = true;
            // 
            // Chk_SP
            // 
            this.Chk_SP.AutoSize = true;
            this.Chk_SP.Checked = true;
            this.Chk_SP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Chk_SP.Location = new System.Drawing.Point(414, 24);
            this.Chk_SP.Name = "Chk_SP";
            this.Chk_SP.Size = new System.Drawing.Size(202, 16);
            this.Chk_SP.TabIndex = 5;
            this.Chk_SP.Text = "Stored Procedure를 포함합니다.";
            this.Chk_SP.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.TB_Output);
            this.groupBox2.Location = new System.Drawing.Point(13, 171);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(775, 225);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output";
            // 
            // TB_Output
            // 
            this.TB_Output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Output.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TB_Output.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_Output.Font = new System.Drawing.Font("돋움", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TB_Output.ForeColor = System.Drawing.Color.Lime;
            this.TB_Output.Location = new System.Drawing.Point(7, 21);
            this.TB_Output.MaxLength = 999999999;
            this.TB_Output.Multiline = true;
            this.TB_Output.Name = "TB_Output";
            this.TB_Output.ReadOnly = true;
            this.TB_Output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TB_Output.Size = new System.Drawing.Size(762, 198);
            this.TB_Output.TabIndex = 21;
            // 
            // btn_output
            // 
            this.btn_output.Location = new System.Drawing.Point(516, 103);
            this.btn_output.Name = "btn_output";
            this.btn_output.Size = new System.Drawing.Size(96, 38);
            this.btn_output.TabIndex = 9;
            this.btn_output.Text = "SP OUTPUT";
            this.btn_output.UseVisualStyleBackColor = true;
            this.btn_output.Click += new System.EventHandler(this.btn_output_Click);
            // 
            // btn_Table
            // 
            this.btn_Table.Location = new System.Drawing.Point(618, 103);
            this.btn_Table.Name = "btn_Table";
            this.btn_Table.Size = new System.Drawing.Size(112, 38);
            this.btn_Table.TabIndex = 10;
            this.btn_Table.Text = "TABLE OUTPUT";
            this.btn_Table.UseVisualStyleBackColor = true;
            this.btn_Table.Click += new System.EventHandler(this.btn_Table_Click);
            // 
            // btn_load
            // 
            this.btn_load.Location = new System.Drawing.Point(108, 103);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(202, 38);
            this.btn_load.TabIndex = 11;
            this.btn_load.Text = "Data Load";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // pBar
            // 
            this.pBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pBar.Location = new System.Drawing.Point(13, 415);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(775, 23);
            this.pBar.TabIndex = 21;
            // 
            // CreateRepositoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pBar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "CreateRepositoryForm";
            this.Text = "CreateRepositoryForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Find;
        private System.Windows.Forms.TextBox TB_Position;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_NameSpace;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox Chk_Table;
        private System.Windows.Forms.CheckBox Chk_SP;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TB_Output;
        private System.Windows.Forms.Button btn_file;
        private System.Windows.Forms.Button btn_output;
        private System.Windows.Forms.Button btn_Table;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.ProgressBar pBar;
    }
}
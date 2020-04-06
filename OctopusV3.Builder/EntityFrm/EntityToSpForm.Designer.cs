namespace OctopusV3.Builder.EntityFrm
{
    partial class EntityToSpForm
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
            this.LB_Table = new System.Windows.Forms.ListBox();
            this.TB_Search = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CB_TYPE = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CB_Role = new System.Windows.Forms.ComboBox();
            this.IsTransaction = new System.Windows.Forms.CheckBox();
            this.btn_load = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TB_Output = new System.Windows.Forms.TextBox();
            this.btn_output = new System.Windows.Forms.Button();
            this.btn_copy = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.btn_load);
            this.groupBox1.Controls.Add(this.TB_Search);
            this.groupBox1.Controls.Add(this.LB_Table);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 425);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tables&View";
            // 
            // LB_Table
            // 
            this.LB_Table.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LB_Table.FormattingEnabled = true;
            this.LB_Table.ItemHeight = 12;
            this.LB_Table.Location = new System.Drawing.Point(7, 81);
            this.LB_Table.Name = "LB_Table";
            this.LB_Table.Size = new System.Drawing.Size(203, 340);
            this.LB_Table.TabIndex = 0;
            // 
            // TB_Search
            // 
            this.TB_Search.Location = new System.Drawing.Point(6, 56);
            this.TB_Search.Name = "TB_Search";
            this.TB_Search.Size = new System.Drawing.Size(203, 21);
            this.TB_Search.TabIndex = 1;
            this.TB_Search.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TB_Search_KeyUp);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btn_copy);
            this.groupBox2.Controls.Add(this.btn_output);
            this.groupBox2.Controls.Add(this.IsTransaction);
            this.groupBox2.Controls.Add(this.CB_Role);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.CB_TYPE);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(235, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(553, 127);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "반환유형 :";
            // 
            // CB_TYPE
            // 
            this.CB_TYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_TYPE.FormattingEnabled = true;
            this.CB_TYPE.Items.AddRange(new object[] {
            "Void",
            "ReturnValue",
            "List<T>"});
            this.CB_TYPE.Location = new System.Drawing.Point(85, 18);
            this.CB_TYPE.Name = "CB_TYPE";
            this.CB_TYPE.Size = new System.Drawing.Size(189, 20);
            this.CB_TYPE.TabIndex = 1;
            this.CB_TYPE.SelectedIndexChanged += new System.EventHandler(this.CB_TYPE_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(280, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "구현유형 :";
            // 
            // CB_Role
            // 
            this.CB_Role.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Role.FormattingEnabled = true;
            this.CB_Role.Items.AddRange(new object[] {
            "Select",
            "Update",
            "Insert",
            "Delete",
            "Save"});
            this.CB_Role.Location = new System.Drawing.Point(346, 17);
            this.CB_Role.Name = "CB_Role";
            this.CB_Role.Size = new System.Drawing.Size(189, 20);
            this.CB_Role.TabIndex = 3;
            this.CB_Role.SelectedIndexChanged += new System.EventHandler(this.CB_Role_SelectedIndexChanged);
            // 
            // IsTransaction
            // 
            this.IsTransaction.AutoSize = true;
            this.IsTransaction.Location = new System.Drawing.Point(19, 48);
            this.IsTransaction.Name = "IsTransaction";
            this.IsTransaction.Size = new System.Drawing.Size(152, 16);
            this.IsTransaction.TabIndex = 4;
            this.IsTransaction.Text = "트랜잭션을 포함합니다.";
            this.IsTransaction.UseVisualStyleBackColor = true;
            // 
            // btn_load
            // 
            this.btn_load.Location = new System.Drawing.Point(7, 22);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(202, 30);
            this.btn_load.TabIndex = 2;
            this.btn_load.Text = "LOAD";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.TB_Output);
            this.groupBox3.Location = new System.Drawing.Point(235, 146);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(553, 292);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Output";
            // 
            // TB_Output
            // 
            this.TB_Output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Output.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TB_Output.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_Output.ForeColor = System.Drawing.Color.Lime;
            this.TB_Output.Location = new System.Drawing.Point(7, 21);
            this.TB_Output.MaxLength = 99999999;
            this.TB_Output.Multiline = true;
            this.TB_Output.Name = "TB_Output";
            this.TB_Output.ReadOnly = true;
            this.TB_Output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TB_Output.Size = new System.Drawing.Size(540, 265);
            this.TB_Output.TabIndex = 0;
            // 
            // btn_output
            // 
            this.btn_output.Location = new System.Drawing.Point(19, 70);
            this.btn_output.Name = "btn_output";
            this.btn_output.Size = new System.Drawing.Size(107, 44);
            this.btn_output.TabIndex = 5;
            this.btn_output.Text = "OUTPUT";
            this.btn_output.UseVisualStyleBackColor = true;
            this.btn_output.Click += new System.EventHandler(this.btn_output_Click);
            // 
            // btn_copy
            // 
            this.btn_copy.Location = new System.Drawing.Point(132, 70);
            this.btn_copy.Name = "btn_copy";
            this.btn_copy.Size = new System.Drawing.Size(107, 44);
            this.btn_copy.TabIndex = 6;
            this.btn_copy.Text = "COPY";
            this.btn_copy.UseVisualStyleBackColor = true;
            this.btn_copy.Click += new System.EventHandler(this.btn_copy_Click);
            // 
            // EntityToSpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "EntityToSpForm";
            this.Text = "EntityToSpForm";
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
        private System.Windows.Forms.ListBox LB_Table;
        private System.Windows.Forms.TextBox TB_Search;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox CB_Role;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CB_TYPE;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.CheckBox IsTransaction;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox TB_Output;
        private System.Windows.Forms.Button btn_copy;
        private System.Windows.Forms.Button btn_output;
    }
}
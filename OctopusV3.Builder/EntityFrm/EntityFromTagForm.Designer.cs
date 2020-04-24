namespace OctopusV3.Builder.EntityFrm
{
    partial class EntityFromTagForm
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
            this.TB_Location = new System.Windows.Forms.TextBox();
            this.btn_Find = new System.Windows.Forms.Button();
            this.btn_Read = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TB_Result = new System.Windows.Forms.TextBox();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_copy = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btn_Read);
            this.groupBox1.Controls.Add(this.btn_Find);
            this.groupBox1.Controls.Add(this.TB_Location);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(775, 56);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "대상";
            // 
            // TB_Location
            // 
            this.TB_Location.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Location.Location = new System.Drawing.Point(12, 21);
            this.TB_Location.Name = "TB_Location";
            this.TB_Location.Size = new System.Drawing.Size(538, 21);
            this.TB_Location.TabIndex = 0;
            // 
            // btn_Find
            // 
            this.btn_Find.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Find.Location = new System.Drawing.Point(556, 19);
            this.btn_Find.Name = "btn_Find";
            this.btn_Find.Size = new System.Drawing.Size(101, 23);
            this.btn_Find.TabIndex = 1;
            this.btn_Find.Text = "파일찾기";
            this.btn_Find.UseVisualStyleBackColor = true;
            this.btn_Find.Click += new System.EventHandler(this.btn_Find_Click);
            // 
            // btn_Read
            // 
            this.btn_Read.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Read.Location = new System.Drawing.Point(663, 19);
            this.btn_Read.Name = "btn_Read";
            this.btn_Read.Size = new System.Drawing.Size(101, 23);
            this.btn_Read.TabIndex = 2;
            this.btn_Read.Text = "태그읽기";
            this.btn_Read.UseVisualStyleBackColor = true;
            this.btn_Read.Click += new System.EventHandler(this.btn_Read_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.btn_copy);
            this.groupBox2.Controls.Add(this.btn_clear);
            this.groupBox2.Location = new System.Drawing.Point(13, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 363);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "기능";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.TB_Result);
            this.groupBox3.Location = new System.Drawing.Point(219, 75);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(569, 363);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Viewer";
            // 
            // TB_Result
            // 
            this.TB_Result.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Result.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TB_Result.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_Result.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TB_Result.ForeColor = System.Drawing.Color.Lime;
            this.TB_Result.Location = new System.Drawing.Point(6, 20);
            this.TB_Result.MaxLength = 999999999;
            this.TB_Result.Multiline = true;
            this.TB_Result.Name = "TB_Result";
            this.TB_Result.ReadOnly = true;
            this.TB_Result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TB_Result.Size = new System.Drawing.Size(557, 337);
            this.TB_Result.TabIndex = 0;
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(15, 22);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(173, 37);
            this.btn_clear.TabIndex = 0;
            this.btn_clear.Text = "CLEAR";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_copy
            // 
            this.btn_copy.Location = new System.Drawing.Point(15, 65);
            this.btn_copy.Name = "btn_copy";
            this.btn_copy.Size = new System.Drawing.Size(173, 37);
            this.btn_copy.TabIndex = 1;
            this.btn_copy.Text = "COPY";
            this.btn_copy.UseVisualStyleBackColor = true;
            this.btn_copy.Click += new System.EventHandler(this.btn_copy_Click);
            // 
            // EntityFromTagForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "EntityFromTagForm";
            this.Text = "EntityFromTagForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Find;
        private System.Windows.Forms.TextBox TB_Location;
        private System.Windows.Forms.Button btn_Read;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox TB_Result;
        private System.Windows.Forms.Button btn_copy;
        private System.Windows.Forms.Button btn_clear;
    }
}
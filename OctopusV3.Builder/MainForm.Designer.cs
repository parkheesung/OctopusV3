namespace OctopusV3.Builder
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helloWorldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entityCreateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entityToSPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createRepositoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sPtoCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contactUsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createControllerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.entitiesToolStripMenuItem,
            this.databaseToolStripMenuItem,
            this.editorToolStripMenuItem,
            this.setupToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helloWorldToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // helloWorldToolStripMenuItem
            // 
            this.helloWorldToolStripMenuItem.Name = "helloWorldToolStripMenuItem";
            this.helloWorldToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.helloWorldToolStripMenuItem.Text = "Hello, World";
            // 
            // entitiesToolStripMenuItem
            // 
            this.entitiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.entityCreateToolStripMenuItem,
            this.entityToSPToolStripMenuItem,
            this.createRepositoryToolStripMenuItem,
            this.createControllerToolStripMenuItem});
            this.entitiesToolStripMenuItem.Name = "entitiesToolStripMenuItem";
            this.entitiesToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.entitiesToolStripMenuItem.Text = "Entities";
            // 
            // entityCreateToolStripMenuItem
            // 
            this.entityCreateToolStripMenuItem.Name = "entityCreateToolStripMenuItem";
            this.entityCreateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.entityCreateToolStripMenuItem.Text = "EntityCreate";
            this.entityCreateToolStripMenuItem.Click += new System.EventHandler(this.entityCreateToolStripMenuItem_Click);
            // 
            // entityToSPToolStripMenuItem
            // 
            this.entityToSPToolStripMenuItem.Name = "entityToSPToolStripMenuItem";
            this.entityToSPToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.entityToSPToolStripMenuItem.Text = "EntityToSP";
            this.entityToSPToolStripMenuItem.Click += new System.EventHandler(this.entityToSPToolStripMenuItem_Click);
            // 
            // createRepositoryToolStripMenuItem
            // 
            this.createRepositoryToolStripMenuItem.Name = "createRepositoryToolStripMenuItem";
            this.createRepositoryToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.createRepositoryToolStripMenuItem.Text = "CreateRepository";
            this.createRepositoryToolStripMenuItem.Click += new System.EventHandler(this.createRepositoryToolStripMenuItem_Click);
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sPtoCodeToolStripMenuItem});
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.databaseToolStripMenuItem.Text = "Database";
            // 
            // sPtoCodeToolStripMenuItem
            // 
            this.sPtoCodeToolStripMenuItem.Name = "sPtoCodeToolStripMenuItem";
            this.sPtoCodeToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.sPtoCodeToolStripMenuItem.Text = "SPtoCode";
            this.sPtoCodeToolStripMenuItem.Click += new System.EventHandler(this.sPtoCodeToolStripMenuItem_Click);
            // 
            // editorToolStripMenuItem
            // 
            this.editorToolStripMenuItem.Name = "editorToolStripMenuItem";
            this.editorToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.editorToolStripMenuItem.Text = "Editor";
            // 
            // setupToolStripMenuItem
            // 
            this.setupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configurationToolStripMenuItem});
            this.setupToolStripMenuItem.Name = "setupToolStripMenuItem";
            this.setupToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.setupToolStripMenuItem.Text = "Setup";
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.configurationToolStripMenuItem.Text = "Configuration";
            this.configurationToolStripMenuItem.Click += new System.EventHandler(this.configurationToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contactUsToolStripMenuItem,
            this.closeAllToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // contactUsToolStripMenuItem
            // 
            this.contactUsToolStripMenuItem.Name = "contactUsToolStripMenuItem";
            this.contactUsToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.contactUsToolStripMenuItem.Text = "Contact Us";
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.closeAllToolStripMenuItem.Text = "Close All";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.closeAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(130, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // createControllerToolStripMenuItem
            // 
            this.createControllerToolStripMenuItem.Name = "createControllerToolStripMenuItem";
            this.createControllerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.createControllerToolStripMenuItem.Text = "CreateController";
            this.createControllerToolStripMenuItem.Click += new System.EventHandler(this.createControllerToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "OctopusV3.Builder";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helloWorldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contactUsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entityCreateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entityToSPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sPtoCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createRepositoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createControllerToolStripMenuItem;
    }
}


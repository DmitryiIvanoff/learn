namespace Kpo4162_Ivanov
{
    partial class FrmMain
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.MMenu = new System.Windows.Forms.MenuStrip();
            this.mmFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mmProjectsSETILooking = new System.Windows.Forms.ToolStripMenuItem();
            this.mmOpenProject = new System.Windows.Forms.ToolStripMenuItem();
            this.SStatus = new System.Windows.Forms.StatusStrip();
            this.dgvSETIes = new System.Windows.Forms.DataGridView();
            this.txtLogPath = new System.Windows.Forms.TextBox();
            this.txtDataFileName = new System.Windows.Forms.TextBox();
            this.MMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSETIes)).BeginInit();
            this.SuspendLayout();
            // 
            // MMenu
            // 
            this.MMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mmFile,
            this.mmProjectsSETILooking});
            this.MMenu.Location = new System.Drawing.Point(0, 0);
            this.MMenu.Name = "MMenu";
            this.MMenu.Size = new System.Drawing.Size(1039, 28);
            this.MMenu.TabIndex = 0;
            this.MMenu.Text = "menuStrip1";
            // 
            // mmFile
            // 
            this.mmFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnExit,
            this.mnOpen});
            this.mmFile.Name = "mmFile";
            this.mmFile.Size = new System.Drawing.Size(57, 24);
            this.mmFile.Text = "Файл";
            // 
            // mnExit
            // 
            this.mnExit.Name = "mnExit";
            this.mnExit.Size = new System.Drawing.Size(142, 26);
            this.mnExit.Text = "Выход";
            this.mnExit.Click += new System.EventHandler(this.mnExit_Click);
            // 
            // mnOpen
            // 
            this.mnOpen.Name = "mnOpen";
            this.mnOpen.Size = new System.Drawing.Size(142, 26);
            this.mnOpen.Text = "Открыть";
            this.mnOpen.Click += new System.EventHandler(this.mnOpen_Click);
            // 
            // mmProjectsSETILooking
            // 
            this.mmProjectsSETILooking.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mmOpenProject});
            this.mmProjectsSETILooking.Name = "mmProjectsSETILooking";
            this.mmProjectsSETILooking.Size = new System.Drawing.Size(285, 24);
            this.mmProjectsSETILooking.Text = "Проекты поиска внеземных сигналов";
            // 
            // mmOpenProject
            // 
            this.mmOpenProject.Name = "mmOpenProject";
            this.mmOpenProject.Size = new System.Drawing.Size(259, 26);
            this.mmOpenProject.Text = "Открыть данные проекта";
            this.mmOpenProject.Click += new System.EventHandler(this.mmOpenProject_Click);
            // 
            // SStatus
            // 
            this.SStatus.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.SStatus.Location = new System.Drawing.Point(0, 404);
            this.SStatus.Name = "SStatus";
            this.SStatus.Size = new System.Drawing.Size(1039, 22);
            this.SStatus.TabIndex = 1;
            this.SStatus.Text = "statusStrip1";
            // 
            // dgvSETIes
            // 
            this.dgvSETIes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSETIes.Location = new System.Drawing.Point(0, 163);
            this.dgvSETIes.Name = "dgvSETIes";
            this.dgvSETIes.RowTemplate.Height = 24;
            this.dgvSETIes.Size = new System.Drawing.Size(1039, 238);
            this.dgvSETIes.TabIndex = 2;
            // 
            // txtLogPath
            // 
            this.txtLogPath.Location = new System.Drawing.Point(677, 47);
            this.txtLogPath.Name = "txtLogPath";
            this.txtLogPath.ReadOnly = true;
            this.txtLogPath.Size = new System.Drawing.Size(339, 22);
            this.txtLogPath.TabIndex = 3;
            // 
            // txtDataFileName
            // 
            this.txtDataFileName.Location = new System.Drawing.Point(677, 98);
            this.txtDataFileName.Name = "txtDataFileName";
            this.txtDataFileName.ReadOnly = true;
            this.txtDataFileName.Size = new System.Drawing.Size(339, 22);
            this.txtDataFileName.TabIndex = 4;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 426);
            this.Controls.Add(this.txtDataFileName);
            this.Controls.Add(this.txtLogPath);
            this.Controls.Add(this.dgvSETIes);
            this.Controls.Add(this.SStatus);
            this.Controls.Add(this.MMenu);
            this.MainMenuStrip = this.MMenu;
            this.Name = "FrmMain";
            this.Text = "КПО:4162:Иванов";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.MMenu.ResumeLayout(false);
            this.MMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSETIes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MMenu;
        private System.Windows.Forms.ToolStripMenuItem mmFile;
        private System.Windows.Forms.ToolStripMenuItem mnExit;
        private System.Windows.Forms.ToolStripMenuItem mnOpen;
        private System.Windows.Forms.StatusStrip SStatus;
        private System.Windows.Forms.DataGridView dgvSETIes;
        private System.Windows.Forms.ToolStripMenuItem mmProjectsSETILooking;
        private System.Windows.Forms.ToolStripMenuItem mmOpenProject;
        private System.Windows.Forms.TextBox txtLogPath;
        private System.Windows.Forms.TextBox txtDataFileName;
    }
}


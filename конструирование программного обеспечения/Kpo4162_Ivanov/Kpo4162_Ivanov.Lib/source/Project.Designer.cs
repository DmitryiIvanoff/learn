namespace Kpo4162.Ivanov.Lib
{
    partial class FrmProject
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
            this.txtboxYear = new System.Windows.Forms.TextBox();
            this.txtboxName = new System.Windows.Forms.TextBox();
            this.txtboxDiametr = new System.Windows.Forms.TextBox();
            this.txtboxChastota = new System.Windows.Forms.TextBox();
            this.txtboxPrimechanie = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtboxYear
            // 
            this.txtboxYear.Location = new System.Drawing.Point(276, 12);
            this.txtboxYear.Name = "txtboxYear";
            this.txtboxYear.Size = new System.Drawing.Size(313, 22);
            this.txtboxYear.TabIndex = 0;
            // 
            // txtboxName
            // 
            this.txtboxName.Location = new System.Drawing.Point(276, 54);
            this.txtboxName.Name = "txtboxName";
            this.txtboxName.Size = new System.Drawing.Size(313, 22);
            this.txtboxName.TabIndex = 1;
            // 
            // txtboxDiametr
            // 
            this.txtboxDiametr.Location = new System.Drawing.Point(276, 95);
            this.txtboxDiametr.Name = "txtboxDiametr";
            this.txtboxDiametr.Size = new System.Drawing.Size(313, 22);
            this.txtboxDiametr.TabIndex = 2;
            // 
            // txtboxChastota
            // 
            this.txtboxChastota.Location = new System.Drawing.Point(276, 139);
            this.txtboxChastota.Name = "txtboxChastota";
            this.txtboxChastota.Size = new System.Drawing.Size(313, 22);
            this.txtboxChastota.TabIndex = 3;
            // 
            // txtboxPrimechanie
            // 
            this.txtboxPrimechanie.Location = new System.Drawing.Point(276, 197);
            this.txtboxPrimechanie.Name = "txtboxPrimechanie";
            this.txtboxPrimechanie.Size = new System.Drawing.Size(313, 22);
            this.txtboxPrimechanie.TabIndex = 4;
            // 
            // FrmProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 434);
            this.Controls.Add(this.txtboxPrimechanie);
            this.Controls.Add(this.txtboxChastota);
            this.Controls.Add(this.txtboxDiametr);
            this.Controls.Add(this.txtboxName);
            this.Controls.Add(this.txtboxYear);
            this.Name = "FrmProject";
            this.Text = "Проект";
            this.Load += new System.EventHandler(this.FrmProject_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtboxYear;
        private System.Windows.Forms.TextBox txtboxName;
        private System.Windows.Forms.TextBox txtboxDiametr;
        private System.Windows.Forms.TextBox txtboxChastota;
        private System.Windows.Forms.TextBox txtboxPrimechanie;
    }
}
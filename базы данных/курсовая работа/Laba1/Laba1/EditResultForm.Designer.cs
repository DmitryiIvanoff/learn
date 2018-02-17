namespace Laba1
{
    partial class EditResultForm
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
            this.button_result_edit_save = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.textBox_Edit_result_sname = new System.Windows.Forms.TextBox();
            this.textBox_Edit_result_result = new System.Windows.Forms.TextBox();
            this.textBox_Edit_result_athlete_ID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_result_edit_save
            // 
            this.button_result_edit_save.Location = new System.Drawing.Point(16, 157);
            this.button_result_edit_save.Name = "button_result_edit_save";
            this.button_result_edit_save.Size = new System.Drawing.Size(138, 45);
            this.button_result_edit_save.TabIndex = 32;
            this.button_result_edit_save.Text = "Сохранить";
            this.button_result_edit_save.UseVisualStyleBackColor = true;
            this.button_result_edit_save.Click += new System.EventHandler(this.button_result_edit_save_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(13, 106);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(169, 17);
            this.label18.TabIndex = 31;
            this.label18.Text = "Название соревнования";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(13, 63);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(76, 17);
            this.label19.TabIndex = 30;
            this.label19.Text = "Результат";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(13, 16);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(133, 17);
            this.label20.TabIndex = 29;
            this.label20.Text = "Номер спортсмена";
            // 
            // textBox_Edit_result_sname
            // 
            this.textBox_Edit_result_sname.Location = new System.Drawing.Point(222, 106);
            this.textBox_Edit_result_sname.Name = "textBox_Edit_result_sname";
            this.textBox_Edit_result_sname.Size = new System.Drawing.Size(381, 22);
            this.textBox_Edit_result_sname.TabIndex = 28;
            // 
            // textBox_Edit_result_result
            // 
            this.textBox_Edit_result_result.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBox_Edit_result_result.Location = new System.Drawing.Point(222, 63);
            this.textBox_Edit_result_result.Name = "textBox_Edit_result_result";
            this.textBox_Edit_result_result.Size = new System.Drawing.Size(381, 22);
            this.textBox_Edit_result_result.TabIndex = 27;
            // 
            // textBox_Edit_result_athlete_ID
            // 
            this.textBox_Edit_result_athlete_ID.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBox_Edit_result_athlete_ID.Enabled = false;
            this.textBox_Edit_result_athlete_ID.Location = new System.Drawing.Point(222, 16);
            this.textBox_Edit_result_athlete_ID.Name = "textBox_Edit_result_athlete_ID";
            this.textBox_Edit_result_athlete_ID.Size = new System.Drawing.Size(381, 22);
            this.textBox_Edit_result_athlete_ID.TabIndex = 26;
            // 
            // EditResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 233);
            this.Controls.Add(this.button_result_edit_save);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.textBox_Edit_result_sname);
            this.Controls.Add(this.textBox_Edit_result_result);
            this.Controls.Add(this.textBox_Edit_result_athlete_ID);
            this.Name = "EditResultForm";
            this.Text = "Форма редактирования таблицы result";
            this.Load += new System.EventHandler(this.EditResultForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_result_edit_save;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textBox_Edit_result_sname;
        private System.Windows.Forms.TextBox textBox_Edit_result_result;
        private System.Windows.Forms.TextBox textBox_Edit_result_athlete_ID;
    }
}
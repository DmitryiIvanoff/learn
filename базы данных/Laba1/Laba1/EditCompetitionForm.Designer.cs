namespace Laba1
{
    partial class EditCompetitionForm
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
            this.dateTimePicker_Edit_competition_dend = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_Edit_competition_dbegin = new System.Windows.Forms.DateTimePicker();
            this.button_competition_Edit_Save = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox_Edit_competition_place = new System.Windows.Forms.TextBox();
            this.textBox_Edit_competition_sname = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // dateTimePicker_Edit_competition_dend
            // 
            this.dateTimePicker_Edit_competition_dend.Location = new System.Drawing.Point(226, 163);
            this.dateTimePicker_Edit_competition_dend.Name = "dateTimePicker_Edit_competition_dend";
            this.dateTimePicker_Edit_competition_dend.Size = new System.Drawing.Size(192, 22);
            this.dateTimePicker_Edit_competition_dend.TabIndex = 39;
            // 
            // dateTimePicker_Edit_competition_dbegin
            // 
            this.dateTimePicker_Edit_competition_dbegin.Location = new System.Drawing.Point(226, 108);
            this.dateTimePicker_Edit_competition_dbegin.Name = "dateTimePicker_Edit_competition_dbegin";
            this.dateTimePicker_Edit_competition_dbegin.Size = new System.Drawing.Size(192, 22);
            this.dateTimePicker_Edit_competition_dbegin.TabIndex = 38;
            // 
            // button_competition_Edit_Save
            // 
            this.button_competition_Edit_Save.Location = new System.Drawing.Point(20, 222);
            this.button_competition_Edit_Save.Name = "button_competition_Edit_Save";
            this.button_competition_Edit_Save.Size = new System.Drawing.Size(138, 45);
            this.button_competition_Edit_Save.TabIndex = 37;
            this.button_competition_Edit_Save.Text = "Сохранить";
            this.button_competition_Edit_Save.UseVisualStyleBackColor = true;
            this.button_competition_Edit_Save.Click += new System.EventHandler(this.button_competition_Edit_Save_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 163);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(117, 17);
            this.label13.TabIndex = 36;
            this.label13.Text = "Дата окончания";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(17, 108);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 17);
            this.label14.TabIndex = 35;
            this.label14.Text = "Дата начала";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(17, 65);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(132, 17);
            this.label15.TabIndex = 34;
            this.label15.Text = "Место проведения";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(17, 18);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(169, 17);
            this.label16.TabIndex = 33;
            this.label16.Text = "Название соревнования";
            // 
            // textBox_Edit_competition_place
            // 
            this.textBox_Edit_competition_place.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBox_Edit_competition_place.Location = new System.Drawing.Point(226, 65);
            this.textBox_Edit_competition_place.Name = "textBox_Edit_competition_place";
            this.textBox_Edit_competition_place.Size = new System.Drawing.Size(381, 22);
            this.textBox_Edit_competition_place.TabIndex = 32;
            // 
            // textBox_Edit_competition_sname
            // 
            this.textBox_Edit_competition_sname.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBox_Edit_competition_sname.Enabled = false;
            this.textBox_Edit_competition_sname.Location = new System.Drawing.Point(226, 18);
            this.textBox_Edit_competition_sname.Name = "textBox_Edit_competition_sname";
            this.textBox_Edit_competition_sname.Size = new System.Drawing.Size(381, 22);
            this.textBox_Edit_competition_sname.TabIndex = 31;
            // 
            // EditCompetitionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 292);
            this.Controls.Add(this.dateTimePicker_Edit_competition_dend);
            this.Controls.Add(this.dateTimePicker_Edit_competition_dbegin);
            this.Controls.Add(this.button_competition_Edit_Save);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.textBox_Edit_competition_place);
            this.Controls.Add(this.textBox_Edit_competition_sname);
            this.Name = "EditCompetitionForm";
            this.Text = "Форма редактирования таблицы competition";
            this.Load += new System.EventHandler(this.EditCompetitionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker_Edit_competition_dend;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Edit_competition_dbegin;
        private System.Windows.Forms.Button button_competition_Edit_Save;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBox_Edit_competition_place;
        private System.Windows.Forms.TextBox textBox_Edit_competition_sname;
    }
}
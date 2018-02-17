namespace Laba1
{
    partial class EditAthleteForm
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
            this.dateTimePicker_Edit_athlete_DOB = new System.Windows.Forms.DateTimePicker();
            this.button_athlete_Save_Edit = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox_Edit_athlete_cname = new System.Windows.Forms.TextBox();
            this.textBox_Edit_athlete_rang = new System.Windows.Forms.TextBox();
            this.textBox_Edit_athlete_FIO = new System.Windows.Forms.TextBox();
            this.textBox_Edit_athlete_athlete_ID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dateTimePicker_Edit_athlete_DOB
            // 
            this.dateTimePicker_Edit_athlete_DOB.Location = new System.Drawing.Point(221, 111);
            this.dateTimePicker_Edit_athlete_DOB.Name = "dateTimePicker_Edit_athlete_DOB";
            this.dateTimePicker_Edit_athlete_DOB.Size = new System.Drawing.Size(192, 22);
            this.dateTimePicker_Edit_athlete_DOB.TabIndex = 37;
            // 
            // button_athlete_Save_Edit
            // 
            this.button_athlete_Save_Edit.Location = new System.Drawing.Point(15, 268);
            this.button_athlete_Save_Edit.Name = "button_athlete_Save_Edit";
            this.button_athlete_Save_Edit.Size = new System.Drawing.Size(138, 45);
            this.button_athlete_Save_Edit.TabIndex = 36;
            this.button_athlete_Save_Edit.Text = "Сохранить";
            this.button_athlete_Save_Edit.UseVisualStyleBackColor = true;
            this.button_athlete_Save_Edit.Click += new System.EventHandler(this.button_athlete_Edit_Save_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 209);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 17);
            this.label9.TabIndex = 35;
            this.label9.Text = "Название команды";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 154);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 17);
            this.label10.TabIndex = 34;
            this.label10.Text = "Разряд";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 111);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(111, 17);
            this.label11.TabIndex = 33;
            this.label11.Text = "Дата рождения";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 64);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(168, 17);
            this.label12.TabIndex = 32;
            this.label12.Text = "Фамилия Имя Отчество";
            // 
            // textBox_Edit_athlete_cname
            // 
            this.textBox_Edit_athlete_cname.Location = new System.Drawing.Point(221, 209);
            this.textBox_Edit_athlete_cname.Name = "textBox_Edit_athlete_cname";
            this.textBox_Edit_athlete_cname.Size = new System.Drawing.Size(381, 22);
            this.textBox_Edit_athlete_cname.TabIndex = 31;
            // 
            // textBox_Edit_athlete_rang
            // 
            this.textBox_Edit_athlete_rang.Location = new System.Drawing.Point(221, 154);
            this.textBox_Edit_athlete_rang.Name = "textBox_Edit_athlete_rang";
            this.textBox_Edit_athlete_rang.Size = new System.Drawing.Size(381, 22);
            this.textBox_Edit_athlete_rang.TabIndex = 30;
            // 
            // textBox_Edit_athlete_FIO
            // 
            this.textBox_Edit_athlete_FIO.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBox_Edit_athlete_FIO.Location = new System.Drawing.Point(221, 64);
            this.textBox_Edit_athlete_FIO.Name = "textBox_Edit_athlete_FIO";
            this.textBox_Edit_athlete_FIO.Size = new System.Drawing.Size(381, 22);
            this.textBox_Edit_athlete_FIO.TabIndex = 29;
            // 
            // textBox_Edit_athlete_athlete_ID
            // 
            this.textBox_Edit_athlete_athlete_ID.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBox_Edit_athlete_athlete_ID.Enabled = false;
            this.textBox_Edit_athlete_athlete_ID.Location = new System.Drawing.Point(221, 12);
            this.textBox_Edit_athlete_athlete_ID.Name = "textBox_Edit_athlete_athlete_ID";
            this.textBox_Edit_athlete_athlete_ID.Size = new System.Drawing.Size(381, 22);
            this.textBox_Edit_athlete_athlete_ID.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 39;
            this.label1.Text = "ID спортсмена";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // EditAthleteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 401);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Edit_athlete_athlete_ID);
            this.Controls.Add(this.dateTimePicker_Edit_athlete_DOB);
            this.Controls.Add(this.button_athlete_Save_Edit);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBox_Edit_athlete_cname);
            this.Controls.Add(this.textBox_Edit_athlete_rang);
            this.Controls.Add(this.textBox_Edit_athlete_FIO);
            this.Name = "EditAthleteForm";
            this.Text = "Форма редактирования таблицы athlete";
            this.Load += new System.EventHandler(this.EditAthleteForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker_Edit_athlete_DOB;
        private System.Windows.Forms.Button button_athlete_Save_Edit;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox_Edit_athlete_cname;
        private System.Windows.Forms.TextBox textBox_Edit_athlete_rang;
        private System.Windows.Forms.TextBox textBox_Edit_athlete_FIO;
        private System.Windows.Forms.TextBox textBox_Edit_athlete_athlete_ID;
        private System.Windows.Forms.Label label1;
    }
}
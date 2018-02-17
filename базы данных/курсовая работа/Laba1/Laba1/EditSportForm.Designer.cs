namespace Laba1
{
    partial class EditSportForm
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
            this.button_Save_sport = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Edit_wrdata = new System.Windows.Forms.TextBox();
            this.textBox_Edit_wrecord = new System.Windows.Forms.TextBox();
            this.textBox_Edit_edizm = new System.Windows.Forms.TextBox();
            this.textBox_Edit_stype = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_Save_sport
            // 
            this.button_Save_sport.Location = new System.Drawing.Point(87, 211);
            this.button_Save_sport.Name = "button_Save_sport";
            this.button_Save_sport.Size = new System.Drawing.Size(138, 45);
            this.button_Save_sport.TabIndex = 21;
            this.button_Save_sport.Text = "Сохранить";
            this.button_Save_sport.UseVisualStyleBackColor = true;
            this.button_Save_sport.Click += new System.EventHandler(this.button_Save_sport_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(84, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 17);
            this.label4.TabIndex = 20;
            this.label4.Text = "Год установления рекорда";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "Мировой рекорд";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "Единица измерения";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "Вид спорта";
            // 
            // textBox_Edit_wrdata
            // 
            this.textBox_Edit_wrdata.Location = new System.Drawing.Point(293, 152);
            this.textBox_Edit_wrdata.Name = "textBox_Edit_wrdata";
            this.textBox_Edit_wrdata.Size = new System.Drawing.Size(381, 22);
            this.textBox_Edit_wrdata.TabIndex = 16;
            // 
            // textBox_Edit_wrecord
            // 
            this.textBox_Edit_wrecord.Location = new System.Drawing.Point(293, 97);
            this.textBox_Edit_wrecord.Name = "textBox_Edit_wrecord";
            this.textBox_Edit_wrecord.Size = new System.Drawing.Size(381, 22);
            this.textBox_Edit_wrecord.TabIndex = 15;
            // 
            // textBox_Edit_edizm
            // 
            this.textBox_Edit_edizm.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBox_Edit_edizm.Location = new System.Drawing.Point(293, 54);
            this.textBox_Edit_edizm.Name = "textBox_Edit_edizm";
            this.textBox_Edit_edizm.Size = new System.Drawing.Size(381, 22);
            this.textBox_Edit_edizm.TabIndex = 14;
            // 
            // textBox_Edit_stype
            // 
            this.textBox_Edit_stype.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBox_Edit_stype.Enabled = false;
            this.textBox_Edit_stype.Location = new System.Drawing.Point(293, 7);
            this.textBox_Edit_stype.Name = "textBox_Edit_stype";
            this.textBox_Edit_stype.Size = new System.Drawing.Size(381, 22);
            this.textBox_Edit_stype.TabIndex = 13;
            this.textBox_Edit_stype.TextChanged += new System.EventHandler(this.textBox_Edit_stype_TextChanged);
            // 
            // EditSportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 263);
            this.Controls.Add(this.button_Save_sport);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Edit_wrdata);
            this.Controls.Add(this.textBox_Edit_wrecord);
            this.Controls.Add(this.textBox_Edit_edizm);
            this.Controls.Add(this.textBox_Edit_stype);
            this.Name = "EditSportForm";
            this.Text = "Форма редактирования таблицы sport";
            this.Load += new System.EventHandler(this.EditSportForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Save_sport;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Edit_wrdata;
        private System.Windows.Forms.TextBox textBox_Edit_wrecord;
        private System.Windows.Forms.TextBox textBox_Edit_edizm;
        private System.Windows.Forms.TextBox textBox_Edit_stype;

    }
}
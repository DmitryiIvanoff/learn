namespace Laba1
{
    partial class Form_command_Edit
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
            this.button_Save_command = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_Edit_Command_stype = new System.Windows.Forms.TextBox();
            this.textBox_Edit_Command_cname = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_Save_command
            // 
            this.button_Save_command.Location = new System.Drawing.Point(38, 136);
            this.button_Save_command.Name = "button_Save_command";
            this.button_Save_command.Size = new System.Drawing.Size(138, 45);
            this.button_Save_command.TabIndex = 30;
            this.button_Save_command.Text = "Сохранить";
            this.button_Save_command.UseVisualStyleBackColor = true;
            this.button_Save_command.Click += new System.EventHandler(this.button_Save_command_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 17);
            this.label7.TabIndex = 29;
            this.label7.Text = "Вид спорта";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(35, 41);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(134, 17);
            this.label8.TabIndex = 28;
            this.label8.Text = "Название команды";
            // 
            // textBox_Edit_Command_stype
            // 
            this.textBox_Edit_Command_stype.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBox_Edit_Command_stype.Location = new System.Drawing.Point(244, 88);
            this.textBox_Edit_Command_stype.Name = "textBox_Edit_Command_stype";
            this.textBox_Edit_Command_stype.Size = new System.Drawing.Size(381, 22);
            this.textBox_Edit_Command_stype.TabIndex = 27;
            // 
            // textBox_Edit_Command_cname
            // 
            this.textBox_Edit_Command_cname.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBox_Edit_Command_cname.Enabled = false;
            this.textBox_Edit_Command_cname.Location = new System.Drawing.Point(244, 41);
            this.textBox_Edit_Command_cname.Name = "textBox_Edit_Command_cname";
            this.textBox_Edit_Command_cname.Size = new System.Drawing.Size(381, 22);
            this.textBox_Edit_Command_cname.TabIndex = 26;
            // 
            // Form_command_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 231);
            this.Controls.Add(this.button_Save_command);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_Edit_Command_stype);
            this.Controls.Add(this.textBox_Edit_Command_cname);
            this.Name = "Form_command_Edit";
            this.Text = "Форма редактирования таблицы command";
            this.Load += new System.EventHandler(this.Form_command_Edit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Save_command;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_Edit_Command_stype;
        private System.Windows.Forms.TextBox textBox_Edit_Command_cname;
    }
}
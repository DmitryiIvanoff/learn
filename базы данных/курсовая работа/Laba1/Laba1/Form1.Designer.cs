namespace Laba1
{
    partial class Form1
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
            this.button_Create = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox_edizm = new System.Windows.Forms.TextBox();
            this.button_GO = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Create
            // 
            this.button_Create.Location = new System.Drawing.Point(1138, 13);
            this.button_Create.Margin = new System.Windows.Forms.Padding(4);
            this.button_Create.Name = "button_Create";
            this.button_Create.Size = new System.Drawing.Size(201, 55);
            this.button_Create.TabIndex = 1;
            this.button_Create.Text = "Создать/Редактировать таблицы";
            this.button_Create.UseVisualStyleBackColor = true;
            this.button_Create.Click += new System.EventHandler(this.button_Create_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(1097, 24);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox_edizm
            // 
            this.textBox_edizm.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBox_edizm.Location = new System.Drawing.Point(12, 421);
            this.textBox_edizm.Name = "textBox_edizm";
            this.textBox_edizm.Size = new System.Drawing.Size(1153, 22);
            this.textBox_edizm.TabIndex = 6;
            // 
            // button_GO
            // 
            this.button_GO.Location = new System.Drawing.Point(1182, 421);
            this.button_GO.Name = "button_GO";
            this.button_GO.Size = new System.Drawing.Size(158, 23);
            this.button_GO.TabIndex = 15;
            this.button_GO.Text = "Выполнить";
            this.button_GO.UseVisualStyleBackColor = true;
            this.button_GO.Click += new System.EventHandler(this.button_GO_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 75);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1327, 340);
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1352, 472);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button_GO);
            this.Controls.Add(this.textBox_edizm);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button_Create);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Спорт";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Create;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox_edizm;
        private System.Windows.Forms.Button button_GO;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}


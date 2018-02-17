namespace Laba1
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            this.ListBoxSport = new System.Windows.Forms.ListBox();
            this.sportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sportDataSet = new Laba1.SportDataSet();
            this.sportTableAdapter = new Laba1.SportDataSetTableAdapters.sportTableAdapter();
            this.Обновить_Btn = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage_sport = new System.Windows.Forms.TabPage();
            this.button_sport_delete = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button_Add_sport = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_wrdata = new System.Windows.Forms.TextBox();
            this.textBox_wrecord = new System.Windows.Forms.TextBox();
            this.textBox_edizm = new System.Windows.Forms.TextBox();
            this.textBox_stype = new System.Windows.Forms.TextBox();
            this.tabPage_command = new System.Windows.Forms.TabPage();
            this.button_Delete_command = new System.Windows.Forms.Button();
            this.button_Edit_command = new System.Windows.Forms.Button();
            this.button_Add_command = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_Command_stype = new System.Windows.Forms.TextBox();
            this.textBox_Command_cname = new System.Windows.Forms.TextBox();
            this.button_Refresh_command = new System.Windows.Forms.Button();
            this.listBox_command = new System.Windows.Forms.ListBox();
            this.tabPage_athlete = new System.Windows.Forms.TabPage();
            this.dateTimePicker_athlete_DOB = new System.Windows.Forms.DateTimePicker();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button_athlete_Add = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox_athlete_cname = new System.Windows.Forms.TextBox();
            this.textBox_athlete_rang = new System.Windows.Forms.TextBox();
            this.textBox_athlete_FIO = new System.Windows.Forms.TextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.listBox_athlete = new System.Windows.Forms.ListBox();
            this.tabPage_competition = new System.Windows.Forms.TabPage();
            this.dateTimePicker_competition_dend = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_competition_dbegin = new System.Windows.Forms.DateTimePicker();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button_competition_Add = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox_competition_place = new System.Windows.Forms.TextBox();
            this.textBox_competition_sname = new System.Windows.Forms.TextBox();
            this.button13 = new System.Windows.Forms.Button();
            this.listBox_competition = new System.Windows.Forms.ListBox();
            this.tabPage_result = new System.Windows.Forms.TabPage();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.textBox_result_sname = new System.Windows.Forms.TextBox();
            this.textBox_result_result = new System.Windows.Forms.TextBox();
            this.textBox_result_athlete_ID = new System.Windows.Forms.TextBox();
            this.button17 = new System.Windows.Forms.Button();
            this.listBox_result = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.sportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sportDataSet)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabPage_sport.SuspendLayout();
            this.tabPage_command.SuspendLayout();
            this.tabPage_athlete.SuspendLayout();
            this.tabPage_competition.SuspendLayout();
            this.tabPage_result.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListBoxSport
            // 
            this.ListBoxSport.FormattingEnabled = true;
            this.ListBoxSport.ItemHeight = 16;
            this.ListBoxSport.Location = new System.Drawing.Point(677, 15);
            this.ListBoxSport.Name = "ListBoxSport";
            this.ListBoxSport.Size = new System.Drawing.Size(479, 276);
            this.ListBoxSport.TabIndex = 0;
            this.ListBoxSport.SelectedIndexChanged += new System.EventHandler(this.ListBoxSport_SelectedIndexChanged);
            // 
            // sportBindingSource
            // 
            this.sportBindingSource.DataMember = "sport";
            this.sportBindingSource.DataSource = this.sportDataSet;
            this.sportBindingSource.CurrentChanged += new System.EventHandler(this.sportBindingSource_CurrentChanged);
            // 
            // sportDataSet
            // 
            this.sportDataSet.DataSetName = "SportDataSet";
            this.sportDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sportTableAdapter
            // 
            this.sportTableAdapter.ClearBeforeFill = true;
            // 
            // Обновить_Btn
            // 
            this.Обновить_Btn.Location = new System.Drawing.Point(1162, 15);
            this.Обновить_Btn.Name = "Обновить_Btn";
            this.Обновить_Btn.Size = new System.Drawing.Size(87, 23);
            this.Обновить_Btn.TabIndex = 2;
            this.Обновить_Btn.Text = "Обновить";
            this.Обновить_Btn.UseVisualStyleBackColor = true;
            this.Обновить_Btn.Click += new System.EventHandler(this.Обновить_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage_sport);
            this.tabControl2.Controls.Add(this.tabPage_command);
            this.tabControl2.Controls.Add(this.tabPage_athlete);
            this.tabControl2.Controls.Add(this.tabPage_competition);
            this.tabControl2.Controls.Add(this.tabPage_result);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1380, 572);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage_sport
            // 
            this.tabPage_sport.Controls.Add(this.button_sport_delete);
            this.tabPage_sport.Controls.Add(this.button1);
            this.tabPage_sport.Controls.Add(this.button_Add_sport);
            this.tabPage_sport.Controls.Add(this.label4);
            this.tabPage_sport.Controls.Add(this.label3);
            this.tabPage_sport.Controls.Add(this.label2);
            this.tabPage_sport.Controls.Add(this.label1);
            this.tabPage_sport.Controls.Add(this.textBox_wrdata);
            this.tabPage_sport.Controls.Add(this.textBox_wrecord);
            this.tabPage_sport.Controls.Add(this.textBox_edizm);
            this.tabPage_sport.Controls.Add(this.textBox_stype);
            this.tabPage_sport.Controls.Add(this.Обновить_Btn);
            this.tabPage_sport.Controls.Add(this.ListBoxSport);
            this.tabPage_sport.Location = new System.Drawing.Point(4, 25);
            this.tabPage_sport.Name = "tabPage_sport";
            this.tabPage_sport.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_sport.Size = new System.Drawing.Size(1372, 543);
            this.tabPage_sport.TabIndex = 0;
            this.tabPage_sport.Text = "Вид спорта";
            this.tabPage_sport.UseVisualStyleBackColor = true;
            this.tabPage_sport.Click += new System.EventHandler(this.tabPage_sport_Click);
            // 
            // button_sport_delete
            // 
            this.button_sport_delete.Location = new System.Drawing.Point(1163, 74);
            this.button_sport_delete.Name = "button_sport_delete";
            this.button_sport_delete.Size = new System.Drawing.Size(75, 23);
            this.button_sport_delete.TabIndex = 14;
            this.button_sport_delete.Text = "Удалить";
            this.button_sport_delete.UseVisualStyleBackColor = true;
            this.button_sport_delete.Click += new System.EventHandler(this.button_sport_delete_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1162, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Редактировать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonEdit_sport_Click);
            // 
            // button_Add_sport
            // 
            this.button_Add_sport.Location = new System.Drawing.Point(37, 276);
            this.button_Add_sport.Name = "button_Add_sport";
            this.button_Add_sport.Size = new System.Drawing.Size(138, 45);
            this.button_Add_sport.TabIndex = 12;
            this.button_Add_sport.Text = "Добавить";
            this.button_Add_sport.UseVisualStyleBackColor = true;
            this.button_Add_sport.Click += new System.EventHandler(this.button_Add_sport_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Год установления рекорда";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Мировой рекорд";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Единица измерения";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Вид спорта";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox_wrdata
            // 
            this.textBox_wrdata.Location = new System.Drawing.Point(243, 217);
            this.textBox_wrdata.Name = "textBox_wrdata";
            this.textBox_wrdata.Size = new System.Drawing.Size(381, 22);
            this.textBox_wrdata.TabIndex = 7;
            // 
            // textBox_wrecord
            // 
            this.textBox_wrecord.Location = new System.Drawing.Point(243, 162);
            this.textBox_wrecord.Name = "textBox_wrecord";
            this.textBox_wrecord.Size = new System.Drawing.Size(381, 22);
            this.textBox_wrecord.TabIndex = 6;
            // 
            // textBox_edizm
            // 
            this.textBox_edizm.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBox_edizm.Location = new System.Drawing.Point(243, 119);
            this.textBox_edizm.Name = "textBox_edizm";
            this.textBox_edizm.Size = new System.Drawing.Size(381, 22);
            this.textBox_edizm.TabIndex = 5;
            // 
            // textBox_stype
            // 
            this.textBox_stype.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBox_stype.Location = new System.Drawing.Point(243, 72);
            this.textBox_stype.Name = "textBox_stype";
            this.textBox_stype.Size = new System.Drawing.Size(381, 22);
            this.textBox_stype.TabIndex = 4;
            this.textBox_stype.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tabPage_command
            // 
            this.tabPage_command.Controls.Add(this.button_Delete_command);
            this.tabPage_command.Controls.Add(this.button_Edit_command);
            this.tabPage_command.Controls.Add(this.button_Add_command);
            this.tabPage_command.Controls.Add(this.label7);
            this.tabPage_command.Controls.Add(this.label8);
            this.tabPage_command.Controls.Add(this.textBox_Command_stype);
            this.tabPage_command.Controls.Add(this.textBox_Command_cname);
            this.tabPage_command.Controls.Add(this.button_Refresh_command);
            this.tabPage_command.Controls.Add(this.listBox_command);
            this.tabPage_command.Location = new System.Drawing.Point(4, 25);
            this.tabPage_command.Name = "tabPage_command";
            this.tabPage_command.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_command.Size = new System.Drawing.Size(1372, 543);
            this.tabPage_command.TabIndex = 1;
            this.tabPage_command.Text = "Комманда";
            this.tabPage_command.UseVisualStyleBackColor = true;
            // 
            // button_Delete_command
            // 
            this.button_Delete_command.Location = new System.Drawing.Point(1189, 112);
            this.button_Delete_command.Name = "button_Delete_command";
            this.button_Delete_command.Size = new System.Drawing.Size(75, 23);
            this.button_Delete_command.TabIndex = 27;
            this.button_Delete_command.Text = "Удалить";
            this.button_Delete_command.UseVisualStyleBackColor = true;
            this.button_Delete_command.Click += new System.EventHandler(this.button_Delete_command_Click);
            // 
            // button_Edit_command
            // 
            this.button_Edit_command.Location = new System.Drawing.Point(1188, 82);
            this.button_Edit_command.Name = "button_Edit_command";
            this.button_Edit_command.Size = new System.Drawing.Size(124, 23);
            this.button_Edit_command.TabIndex = 26;
            this.button_Edit_command.Text = "Редактировать";
            this.button_Edit_command.UseVisualStyleBackColor = true;
            this.button_Edit_command.Click += new System.EventHandler(this.button_Edit_command_Click);
            // 
            // button_Add_command
            // 
            this.button_Add_command.Location = new System.Drawing.Point(63, 205);
            this.button_Add_command.Name = "button_Add_command";
            this.button_Add_command.Size = new System.Drawing.Size(138, 45);
            this.button_Add_command.TabIndex = 25;
            this.button_Add_command.Text = "Добавить";
            this.button_Add_command.UseVisualStyleBackColor = true;
            this.button_Add_command.Click += new System.EventHandler(this.button_Add_command_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(60, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 17);
            this.label7.TabIndex = 22;
            this.label7.Text = "Вид спорта";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(60, 110);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(134, 17);
            this.label8.TabIndex = 21;
            this.label8.Text = "Название команды";
            // 
            // textBox_Command_stype
            // 
            this.textBox_Command_stype.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBox_Command_stype.Location = new System.Drawing.Point(269, 157);
            this.textBox_Command_stype.Name = "textBox_Command_stype";
            this.textBox_Command_stype.Size = new System.Drawing.Size(381, 22);
            this.textBox_Command_stype.TabIndex = 18;
            // 
            // textBox_Command_cname
            // 
            this.textBox_Command_cname.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBox_Command_cname.Location = new System.Drawing.Point(269, 110);
            this.textBox_Command_cname.Name = "textBox_Command_cname";
            this.textBox_Command_cname.Size = new System.Drawing.Size(381, 22);
            this.textBox_Command_cname.TabIndex = 17;
            // 
            // button_Refresh_command
            // 
            this.button_Refresh_command.Location = new System.Drawing.Point(1188, 53);
            this.button_Refresh_command.Name = "button_Refresh_command";
            this.button_Refresh_command.Size = new System.Drawing.Size(87, 23);
            this.button_Refresh_command.TabIndex = 16;
            this.button_Refresh_command.Text = "Обновить";
            this.button_Refresh_command.UseVisualStyleBackColor = true;
            this.button_Refresh_command.Click += new System.EventHandler(this.button_Refresh_command_Click);
            // 
            // listBox_command
            // 
            this.listBox_command.FormattingEnabled = true;
            this.listBox_command.ItemHeight = 16;
            this.listBox_command.Location = new System.Drawing.Point(703, 53);
            this.listBox_command.Name = "listBox_command";
            this.listBox_command.Size = new System.Drawing.Size(479, 436);
            this.listBox_command.TabIndex = 15;
            // 
            // tabPage_athlete
            // 
            this.tabPage_athlete.Controls.Add(this.dateTimePicker_athlete_DOB);
            this.tabPage_athlete.Controls.Add(this.button6);
            this.tabPage_athlete.Controls.Add(this.button7);
            this.tabPage_athlete.Controls.Add(this.button_athlete_Add);
            this.tabPage_athlete.Controls.Add(this.label9);
            this.tabPage_athlete.Controls.Add(this.label10);
            this.tabPage_athlete.Controls.Add(this.label11);
            this.tabPage_athlete.Controls.Add(this.label12);
            this.tabPage_athlete.Controls.Add(this.textBox_athlete_cname);
            this.tabPage_athlete.Controls.Add(this.textBox_athlete_rang);
            this.tabPage_athlete.Controls.Add(this.textBox_athlete_FIO);
            this.tabPage_athlete.Controls.Add(this.button9);
            this.tabPage_athlete.Controls.Add(this.listBox_athlete);
            this.tabPage_athlete.Location = new System.Drawing.Point(4, 25);
            this.tabPage_athlete.Name = "tabPage_athlete";
            this.tabPage_athlete.Size = new System.Drawing.Size(1372, 543);
            this.tabPage_athlete.TabIndex = 2;
            this.tabPage_athlete.Text = "Спортсмен";
            this.tabPage_athlete.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker_athlete_DOB
            // 
            this.dateTimePicker_athlete_DOB.Location = new System.Drawing.Point(269, 157);
            this.dateTimePicker_athlete_DOB.Name = "dateTimePicker_athlete_DOB";
            this.dateTimePicker_athlete_DOB.Size = new System.Drawing.Size(192, 22);
            this.dateTimePicker_athlete_DOB.TabIndex = 28;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(970, 447);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 27;
            this.button6.Text = "Удалить";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(817, 447);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(124, 23);
            this.button7.TabIndex = 26;
            this.button7.Text = "Редактировать";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button_athlete_Add
            // 
            this.button_athlete_Add.Location = new System.Drawing.Point(63, 314);
            this.button_athlete_Add.Name = "button_athlete_Add";
            this.button_athlete_Add.Size = new System.Drawing.Size(138, 45);
            this.button_athlete_Add.TabIndex = 25;
            this.button_athlete_Add.Text = "Добавить";
            this.button_athlete_Add.UseVisualStyleBackColor = true;
            this.button_athlete_Add.Click += new System.EventHandler(this.button8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(60, 255);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 17);
            this.label9.TabIndex = 24;
            this.label9.Text = "Название команды";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(60, 200);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 17);
            this.label10.TabIndex = 23;
            this.label10.Text = "Разряд";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(60, 157);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(111, 17);
            this.label11.TabIndex = 22;
            this.label11.Text = "Дата рождения";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(60, 110);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(168, 17);
            this.label12.TabIndex = 21;
            this.label12.Text = "Фамилия Имя Отчество";
            // 
            // textBox_athlete_cname
            // 
            this.textBox_athlete_cname.Location = new System.Drawing.Point(269, 255);
            this.textBox_athlete_cname.Name = "textBox_athlete_cname";
            this.textBox_athlete_cname.Size = new System.Drawing.Size(381, 22);
            this.textBox_athlete_cname.TabIndex = 20;
            // 
            // textBox_athlete_rang
            // 
            this.textBox_athlete_rang.Location = new System.Drawing.Point(269, 200);
            this.textBox_athlete_rang.Name = "textBox_athlete_rang";
            this.textBox_athlete_rang.Size = new System.Drawing.Size(381, 22);
            this.textBox_athlete_rang.TabIndex = 19;
            // 
            // textBox_athlete_FIO
            // 
            this.textBox_athlete_FIO.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBox_athlete_FIO.Location = new System.Drawing.Point(269, 110);
            this.textBox_athlete_FIO.Name = "textBox_athlete_FIO";
            this.textBox_athlete_FIO.Size = new System.Drawing.Size(381, 22);
            this.textBox_athlete_FIO.TabIndex = 17;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(703, 447);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(87, 23);
            this.button9.TabIndex = 16;
            this.button9.Text = "Обновить";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // listBox_athlete
            // 
            this.listBox_athlete.FormattingEnabled = true;
            this.listBox_athlete.ItemHeight = 16;
            this.listBox_athlete.Location = new System.Drawing.Point(703, 53);
            this.listBox_athlete.Name = "listBox_athlete";
            this.listBox_athlete.Size = new System.Drawing.Size(661, 372);
            this.listBox_athlete.TabIndex = 15;
            // 
            // tabPage_competition
            // 
            this.tabPage_competition.Controls.Add(this.dateTimePicker_competition_dend);
            this.tabPage_competition.Controls.Add(this.dateTimePicker_competition_dbegin);
            this.tabPage_competition.Controls.Add(this.button10);
            this.tabPage_competition.Controls.Add(this.button11);
            this.tabPage_competition.Controls.Add(this.button_competition_Add);
            this.tabPage_competition.Controls.Add(this.label13);
            this.tabPage_competition.Controls.Add(this.label14);
            this.tabPage_competition.Controls.Add(this.label15);
            this.tabPage_competition.Controls.Add(this.label16);
            this.tabPage_competition.Controls.Add(this.textBox_competition_place);
            this.tabPage_competition.Controls.Add(this.textBox_competition_sname);
            this.tabPage_competition.Controls.Add(this.button13);
            this.tabPage_competition.Controls.Add(this.listBox_competition);
            this.tabPage_competition.Location = new System.Drawing.Point(4, 25);
            this.tabPage_competition.Name = "tabPage_competition";
            this.tabPage_competition.Size = new System.Drawing.Size(1372, 543);
            this.tabPage_competition.TabIndex = 3;
            this.tabPage_competition.Text = "Соревнование";
            this.tabPage_competition.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker_competition_dend
            // 
            this.dateTimePicker_competition_dend.Location = new System.Drawing.Point(269, 255);
            this.dateTimePicker_competition_dend.Name = "dateTimePicker_competition_dend";
            this.dateTimePicker_competition_dend.Size = new System.Drawing.Size(192, 22);
            this.dateTimePicker_competition_dend.TabIndex = 30;
            // 
            // dateTimePicker_competition_dbegin
            // 
            this.dateTimePicker_competition_dbegin.Location = new System.Drawing.Point(269, 200);
            this.dateTimePicker_competition_dbegin.Name = "dateTimePicker_competition_dbegin";
            this.dateTimePicker_competition_dbegin.Size = new System.Drawing.Size(192, 22);
            this.dateTimePicker_competition_dbegin.TabIndex = 29;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(1189, 112);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 27;
            this.button10.Text = "Удалить";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(1188, 82);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(124, 23);
            this.button11.TabIndex = 26;
            this.button11.Text = "Редактировать";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button_competition_Add
            // 
            this.button_competition_Add.Location = new System.Drawing.Point(63, 314);
            this.button_competition_Add.Name = "button_competition_Add";
            this.button_competition_Add.Size = new System.Drawing.Size(138, 45);
            this.button_competition_Add.TabIndex = 25;
            this.button_competition_Add.Text = "Добавить";
            this.button_competition_Add.UseVisualStyleBackColor = true;
            this.button_competition_Add.Click += new System.EventHandler(this.button12_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(60, 255);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(117, 17);
            this.label13.TabIndex = 24;
            this.label13.Text = "Дата окончания";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(60, 200);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 17);
            this.label14.TabIndex = 23;
            this.label14.Text = "Дата начала";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(60, 157);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(132, 17);
            this.label15.TabIndex = 22;
            this.label15.Text = "Место проведения";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(60, 110);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(169, 17);
            this.label16.TabIndex = 21;
            this.label16.Text = "Название соревнования";
            // 
            // textBox_competition_place
            // 
            this.textBox_competition_place.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBox_competition_place.Location = new System.Drawing.Point(269, 157);
            this.textBox_competition_place.Name = "textBox_competition_place";
            this.textBox_competition_place.Size = new System.Drawing.Size(381, 22);
            this.textBox_competition_place.TabIndex = 18;
            // 
            // textBox_competition_sname
            // 
            this.textBox_competition_sname.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBox_competition_sname.Location = new System.Drawing.Point(269, 110);
            this.textBox_competition_sname.Name = "textBox_competition_sname";
            this.textBox_competition_sname.Size = new System.Drawing.Size(381, 22);
            this.textBox_competition_sname.TabIndex = 17;
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(1188, 53);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(87, 23);
            this.button13.TabIndex = 16;
            this.button13.Text = "Обновить";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // listBox_competition
            // 
            this.listBox_competition.FormattingEnabled = true;
            this.listBox_competition.ItemHeight = 16;
            this.listBox_competition.Location = new System.Drawing.Point(703, 53);
            this.listBox_competition.Name = "listBox_competition";
            this.listBox_competition.Size = new System.Drawing.Size(479, 436);
            this.listBox_competition.TabIndex = 15;
            // 
            // tabPage_result
            // 
            this.tabPage_result.Controls.Add(this.button14);
            this.tabPage_result.Controls.Add(this.button15);
            this.tabPage_result.Controls.Add(this.button16);
            this.tabPage_result.Controls.Add(this.label18);
            this.tabPage_result.Controls.Add(this.label19);
            this.tabPage_result.Controls.Add(this.label20);
            this.tabPage_result.Controls.Add(this.textBox_result_sname);
            this.tabPage_result.Controls.Add(this.textBox_result_result);
            this.tabPage_result.Controls.Add(this.textBox_result_athlete_ID);
            this.tabPage_result.Controls.Add(this.button17);
            this.tabPage_result.Controls.Add(this.listBox_result);
            this.tabPage_result.Location = new System.Drawing.Point(4, 25);
            this.tabPage_result.Name = "tabPage_result";
            this.tabPage_result.Size = new System.Drawing.Size(1372, 543);
            this.tabPage_result.TabIndex = 4;
            this.tabPage_result.Text = "Результат";
            this.tabPage_result.UseVisualStyleBackColor = true;
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(1189, 112);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(75, 23);
            this.button14.TabIndex = 27;
            this.button14.Text = "Удалить";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(1188, 82);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(124, 23);
            this.button15.TabIndex = 26;
            this.button15.Text = "Редактировать";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(63, 251);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(138, 45);
            this.button16.TabIndex = 25;
            this.button16.Text = "Добавить";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(60, 200);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(169, 17);
            this.label18.TabIndex = 23;
            this.label18.Text = "Название соревнования";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(60, 157);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(76, 17);
            this.label19.TabIndex = 22;
            this.label19.Text = "Результат";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(60, 110);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(133, 17);
            this.label20.TabIndex = 21;
            this.label20.Text = "Номер спортсмена";
            // 
            // textBox_result_sname
            // 
            this.textBox_result_sname.Location = new System.Drawing.Point(269, 200);
            this.textBox_result_sname.Name = "textBox_result_sname";
            this.textBox_result_sname.Size = new System.Drawing.Size(381, 22);
            this.textBox_result_sname.TabIndex = 19;
            // 
            // textBox_result_result
            // 
            this.textBox_result_result.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBox_result_result.Location = new System.Drawing.Point(269, 157);
            this.textBox_result_result.Name = "textBox_result_result";
            this.textBox_result_result.Size = new System.Drawing.Size(381, 22);
            this.textBox_result_result.TabIndex = 18;
            // 
            // textBox_result_athlete_ID
            // 
            this.textBox_result_athlete_ID.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBox_result_athlete_ID.Location = new System.Drawing.Point(269, 110);
            this.textBox_result_athlete_ID.Name = "textBox_result_athlete_ID";
            this.textBox_result_athlete_ID.Size = new System.Drawing.Size(381, 22);
            this.textBox_result_athlete_ID.TabIndex = 17;
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(1188, 53);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(87, 23);
            this.button17.TabIndex = 16;
            this.button17.Text = "Обновить";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // listBox_result
            // 
            this.listBox_result.FormattingEnabled = true;
            this.listBox_result.ItemHeight = 16;
            this.listBox_result.Location = new System.Drawing.Point(703, 53);
            this.listBox_result.Name = "listBox_result";
            this.listBox_result.Size = new System.Drawing.Size(479, 436);
            this.listBox_result.TabIndex = 15;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1380, 572);
            this.Controls.Add(this.tabControl2);
            this.Name = "Form2";
            this.Text = "Редактирование БД";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sportDataSet)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabPage_sport.ResumeLayout(false);
            this.tabPage_sport.PerformLayout();
            this.tabPage_command.ResumeLayout(false);
            this.tabPage_command.PerformLayout();
            this.tabPage_athlete.ResumeLayout(false);
            this.tabPage_athlete.PerformLayout();
            this.tabPage_competition.ResumeLayout(false);
            this.tabPage_competition.PerformLayout();
            this.tabPage_result.ResumeLayout(false);
            this.tabPage_result.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ListBoxSport;
        private SportDataSet sportDataSet;
        private System.Windows.Forms.BindingSource sportBindingSource;
        private SportDataSetTableAdapters.sportTableAdapter sportTableAdapter;
        private System.Windows.Forms.Button Обновить_Btn;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage_sport;
        private System.Windows.Forms.TabPage tabPage_command;
        private System.Windows.Forms.TabPage tabPage_athlete;
        private System.Windows.Forms.TabPage tabPage_competition;
        private System.Windows.Forms.TabPage tabPage_result;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_wrdata;
        private System.Windows.Forms.TextBox textBox_wrecord;
        private System.Windows.Forms.TextBox textBox_edizm;
        private System.Windows.Forms.TextBox textBox_stype;
        private System.Windows.Forms.Button button_Add_sport;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_sport_delete;
        private System.Windows.Forms.Button button_Delete_command;
        private System.Windows.Forms.Button button_Edit_command;
        private System.Windows.Forms.Button button_Add_command;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_Command_stype;
        private System.Windows.Forms.TextBox textBox_Command_cname;
        private System.Windows.Forms.Button button_Refresh_command;
        private System.Windows.Forms.ListBox listBox_command;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button_athlete_Add;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox_athlete_cname;
        private System.Windows.Forms.TextBox textBox_athlete_rang;
        private System.Windows.Forms.TextBox textBox_athlete_FIO;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.ListBox listBox_athlete;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button_competition_Add;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBox_competition_place;
        private System.Windows.Forms.TextBox textBox_competition_sname;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.ListBox listBox_competition;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textBox_result_sname;
        private System.Windows.Forms.TextBox textBox_result_result;
        private System.Windows.Forms.TextBox textBox_result_athlete_ID;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.ListBox listBox_result;
        private System.Windows.Forms.DateTimePicker dateTimePicker_athlete_DOB;
        private System.Windows.Forms.DateTimePicker dateTimePicker_competition_dend;
        private System.Windows.Forms.DateTimePicker dateTimePicker_competition_dbegin;
    }
}
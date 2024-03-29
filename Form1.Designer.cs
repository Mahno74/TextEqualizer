﻿namespace TextEqualizer
{
    partial class Form1
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
            ChangeClipboardChain(this.Handle, nextClipboardViewer);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox_Header = new System.Windows.Forms.TextBox();
            this.label_CharCounter = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_Manual = new System.Windows.Forms.RadioButton();
            this.label_FontSize = new System.Windows.Forms.Label();
            this.radioButton_Fio_observer = new System.Windows.Forms.RadioButton();
            this.checkBox_TopMostWindows = new System.Windows.Forms.CheckBox();
            this.checkBox_SurnameBold = new System.Windows.Forms.CheckBox();
            this.radioButton_text_observer = new System.Windows.Forms.RadioButton();
            this.numericUpDown_Font_Size = new System.Windows.Forms.NumericUpDown();
            this.richTextBox_Fio = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox_Case_Format = new System.Windows.Forms.ComboBox();
            this.comboBox_FIO_Format = new System.Windows.Forms.ComboBox();
            this.button_Fio = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_Header = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Font_Size)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_Header
            // 
            this.textBox_Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_Header.Location = new System.Drawing.Point(6, 21);
            this.textBox_Header.Multiline = true;
            this.textBox_Header.Name = "textBox_Header";
            this.textBox_Header.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Header.Size = new System.Drawing.Size(674, 162);
            this.textBox_Header.TabIndex = 0;
            // 
            // label_CharCounter
            // 
            this.label_CharCounter.AutoSize = true;
            this.label_CharCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_CharCounter.Location = new System.Drawing.Point(15, 185);
            this.label_CharCounter.Name = "label_CharCounter";
            this.label_CharCounter.Size = new System.Drawing.Size(178, 20);
            this.label_CharCounter.TabIndex = 1;
            this.label_CharCounter.Text = "Количество символов";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_Manual);
            this.groupBox1.Controls.Add(this.label_FontSize);
            this.groupBox1.Controls.Add(this.radioButton_Fio_observer);
            this.groupBox1.Controls.Add(this.checkBox_TopMostWindows);
            this.groupBox1.Controls.Add(this.checkBox_SurnameBold);
            this.groupBox1.Controls.Add(this.radioButton_text_observer);
            this.groupBox1.Controls.Add(this.numericUpDown_Font_Size);
            this.groupBox1.Location = new System.Drawing.Point(523, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(157, 161);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки";
            // 
            // radioButton_Manual
            // 
            this.radioButton_Manual.AutoSize = true;
            this.radioButton_Manual.Checked = true;
            this.radioButton_Manual.Location = new System.Drawing.Point(11, 22);
            this.radioButton_Manual.Name = "radioButton_Manual";
            this.radioButton_Manual.Size = new System.Drawing.Size(97, 17);
            this.radioButton_Manual.TabIndex = 18;
            this.radioButton_Manual.TabStop = true;
            this.radioButton_Manual.Text = "Ручной режим";
            this.radioButton_Manual.UseVisualStyleBackColor = true;
            // 
            // label_FontSize
            // 
            this.label_FontSize.AutoSize = true;
            this.label_FontSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_FontSize.Location = new System.Drawing.Point(55, 116);
            this.label_FontSize.Name = "label_FontSize";
            this.label_FontSize.Size = new System.Drawing.Size(73, 12);
            this.label_FontSize.TabIndex = 5;
            this.label_FontSize.Text = "размер шрифта";
            // 
            // radioButton_Fio_observer
            // 
            this.radioButton_Fio_observer.AutoSize = true;
            this.radioButton_Fio_observer.Location = new System.Drawing.Point(11, 68);
            this.radioButton_Fio_observer.Name = "radioButton_Fio_observer";
            this.radioButton_Fio_observer.Size = new System.Drawing.Size(76, 17);
            this.radioButton_Fio_observer.TabIndex = 17;
            this.radioButton_Fio_observer.Text = "АвтоФИО";
            this.radioButton_Fio_observer.UseVisualStyleBackColor = true;
            // 
            // checkBox_TopMostWindows
            // 
            this.checkBox_TopMostWindows.AutoSize = true;
            this.checkBox_TopMostWindows.Checked = true;
            this.checkBox_TopMostWindows.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_TopMostWindows.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox_TopMostWindows.Location = new System.Drawing.Point(11, 139);
            this.checkBox_TopMostWindows.Name = "checkBox_TopMostWindows";
            this.checkBox_TopMostWindows.Size = new System.Drawing.Size(116, 16);
            this.checkBox_TopMostWindows.TabIndex = 3;
            this.checkBox_TopMostWindows.Text = "Поверх всех окон";
            this.checkBox_TopMostWindows.UseVisualStyleBackColor = true;
            this.checkBox_TopMostWindows.CheckedChanged += new System.EventHandler(this.CheckBox_TopMostWindows_CheckedChanged);
            // 
            // checkBox_SurnameBold
            // 
            this.checkBox_SurnameBold.AutoSize = true;
            this.checkBox_SurnameBold.Checked = true;
            this.checkBox_SurnameBold.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_SurnameBold.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox_SurnameBold.Location = new System.Drawing.Point(11, 93);
            this.checkBox_SurnameBold.Name = "checkBox_SurnameBold";
            this.checkBox_SurnameBold.Size = new System.Drawing.Size(127, 16);
            this.checkBox_SurnameBold.TabIndex = 3;
            this.checkBox_SurnameBold.Text = "Выделить фамилию";
            this.checkBox_SurnameBold.UseVisualStyleBackColor = true;
            // 
            // radioButton_text_observer
            // 
            this.radioButton_text_observer.AutoSize = true;
            this.radioButton_text_observer.Location = new System.Drawing.Point(11, 45);
            this.radioButton_text_observer.Name = "radioButton_text_observer";
            this.radioButton_text_observer.Size = new System.Drawing.Size(79, 17);
            this.radioButton_text_observer.TabIndex = 16;
            this.radioButton_text_observer.Text = "АвтоТекст";
            this.radioButton_text_observer.UseVisualStyleBackColor = true;
            // 
            // numericUpDown_Font_Size
            // 
            this.numericUpDown_Font_Size.Location = new System.Drawing.Point(11, 113);
            this.numericUpDown_Font_Size.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown_Font_Size.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDown_Font_Size.Name = "numericUpDown_Font_Size";
            this.numericUpDown_Font_Size.Size = new System.Drawing.Size(38, 20);
            this.numericUpDown_Font_Size.TabIndex = 4;
            this.numericUpDown_Font_Size.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // richTextBox_Fio
            // 
            this.richTextBox_Fio.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox_Fio.Location = new System.Drawing.Point(14, 60);
            this.richTextBox_Fio.Name = "richTextBox_Fio";
            this.richTextBox_Fio.Size = new System.Drawing.Size(489, 64);
            this.richTextBox_Fio.TabIndex = 11;
            this.richTextBox_Fio.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox_Case_Format);
            this.groupBox2.Controls.Add(this.comboBox_FIO_Format);
            this.groupBox2.Controls.Add(this.richTextBox_Fio);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.button_Fio);
            this.groupBox2.Location = new System.Drawing.Point(12, 313);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(691, 195);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Фамилия Имя Отчество (выберите формат)";
            // 
            // comboBox_Case_Format
            // 
            this.comboBox_Case_Format.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Case_Format.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_Case_Format.FormattingEnabled = true;
            this.comboBox_Case_Format.Location = new System.Drawing.Point(262, 22);
            this.comboBox_Case_Format.Name = "comboBox_Case_Format";
            this.comboBox_Case_Format.Size = new System.Drawing.Size(218, 22);
            this.comboBox_Case_Format.TabIndex = 12;
            // 
            // comboBox_FIO_Format
            // 
            this.comboBox_FIO_Format.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_FIO_Format.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_FIO_Format.FormattingEnabled = true;
            this.comboBox_FIO_Format.Location = new System.Drawing.Point(14, 19);
            this.comboBox_FIO_Format.Name = "comboBox_FIO_Format";
            this.comboBox_FIO_Format.Size = new System.Drawing.Size(223, 26);
            this.comboBox_FIO_Format.TabIndex = 8;
            // 
            // button_Fio
            // 
            this.button_Fio.BackgroundImage = global::TextEqualizer.Properties.Resources.man_2_icon_icons1;
            this.button_Fio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_Fio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Fio.Location = new System.Drawing.Point(14, 133);
            this.button_Fio.Name = "button_Fio";
            this.button_Fio.Size = new System.Drawing.Size(489, 43);
            this.button_Fio.TabIndex = 9;
            this.button_Fio.Text = "Вставить ФИО из буфера обмена";
            this.button_Fio.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button_Header);
            this.groupBox3.Controls.Add(this.label_CharCounter);
            this.groupBox3.Controls.Add(this.textBox_Header);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(691, 295);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Блок отчистки текста от \"мусора\"";
            // 
            // button_Header
            // 
            this.button_Header.BackgroundImage = global::TextEqualizer.Properties.Resources._27_Edit_Text_256x256_35395;
            this.button_Header.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Header.Location = new System.Drawing.Point(6, 208);
            this.button_Header.Name = "button_Header";
            this.button_Header.Size = new System.Drawing.Size(674, 66);
            this.button_Header.TabIndex = 2;
            this.button_Header.Text = "Вставить текст из буфера обмена";
            this.button_Header.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Header.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 532);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Font_Size)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Header;
        private System.Windows.Forms.Label label_CharCounter;
        private System.Windows.Forms.Button button_Header;
        private System.Windows.Forms.Button button_Fio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox richTextBox_Fio;
        private System.Windows.Forms.CheckBox checkBox_SurnameBold;
        private System.Windows.Forms.Label label_FontSize;
        private System.Windows.Forms.NumericUpDown numericUpDown_Font_Size;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButton_text_observer;
        private System.Windows.Forms.RadioButton radioButton_Fio_observer;
        private System.Windows.Forms.RadioButton radioButton_Manual;
        private System.Windows.Forms.ComboBox comboBox_FIO_Format;
        private System.Windows.Forms.ComboBox comboBox_Case_Format;
        private System.Windows.Forms.CheckBox checkBox_TopMostWindows;
    }
}


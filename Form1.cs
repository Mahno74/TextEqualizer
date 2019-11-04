﻿using LingvoNET;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TextEqualizer
{
    public partial class Form1 : Form
    {
        public bool io = false;
        [DllImport("User32.dll")]
        protected static extern int SetClipboardViewer(int hWndNewViewer);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);
        IntPtr nextClipboardViewer;

        public Form1()
        {
            InitializeComponent();
            button_Fio.Click += new EventHandler(Fio_Formatting); //нажатие на кнопку ФИО
            button_Header.Click += new EventHandler(Text_Formatting); //нажатие на кнопку вставить текст
            nextClipboardViewer = (IntPtr)SetClipboardViewer((int)Handle);

        }
        protected override void WndProc(ref Message m)
        {
            const int WM_DRAWCLIPBOARD = 0x308;
            const int WM_CHANGECBCHAIN = 0x030D;
            switch (m.Msg)
            {
                case WM_DRAWCLIPBOARD:
                    DisplayClipboardData();
                    SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam);
                    break;
                case WM_CHANGECBCHAIN:
                    if (m.WParam == nextClipboardViewer) nextClipboardViewer = m.LParam;
                    else
                        SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "Форматирование текстов и ФИО по шаблону  Юрасов В.В. (с) 2019";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "d M  yyyy";
            comboBox_FIO_Format.Items.Add("Фамилия Имя Отчество");
            comboBox_FIO_Format.Items.Add("Фамилия/Имя Отчество");
            comboBox_FIO_Format.Items.Add("ФАМИЛИЯ Имя Отчество");
            comboBox_FIO_Format.Items.Add("ФАМИЛИЯ/Имя Отчество");
            comboBox_FIO_Format.Items.Add("        Имя Отчество");
            comboBox_FIO_Format.Items.Add("        И.О.");
            comboBox_FIO_Format.SelectedIndex = 0;
            comboBox_Case_Format.Items.Add("Именительный->(Кто? Что?)");
            comboBox_Case_Format.Items.Add("Родительный ->(Кого? Чего?)");
            comboBox_Case_Format.Items.Add("Дательный   ->(Кому? Чему?)");
            comboBox_Case_Format.Items.Add("Винительный ->(Кого? Что?)");
            comboBox_Case_Format.Items.Add("Творительный->(Кем? Чем ?)");
            comboBox_Case_Format.Items.Add("Передложный ->(О ком? О чём?)");
            comboBox_Case_Format.SelectedIndex = 0;

        }
        private void DisplayClipboardData() //вызывается автоматически про попадании текса в буфер обмена
        {
            if (io) return; //если в буфер попало только  ИО или И.О. то ничего не делаем
            if (radioButton_Fio_observer.Checked) //Автоматическая работа с ФИО
            {
                Fio_Formatting(null, null);
            }
            if (radioButton_text_observer.Checked) //Автоматическа работа с текстом
            {
                Text_Formatting(null, null);
            }

        }
        private void Text_Formatting(object sender, EventArgs e) //нажатие на кнопку Текст или дабл клик в поле
        {
            if (Clipboard.GetText() == null) return;
            textBox_Header.Text = Clipboard.GetText(); //вставляем текст из буфера обмена
            label_CharCounter.ForeColor = Color.Green;
            textBox_Header.Text = Extractor.TextHandler(textBox_Header.Text); //выносим мусор из строки
            if (textBox_Header.Text.Length > 255) label_CharCounter.ForeColor = Color.Red; //проверяем влезет ли тескт в заголовок
            label_CharCounter.Text = "Количество символов: " + textBox_Header.Text.Length.ToString();
            //помещаем отформатированный текс в буфер обмена
            textBox_Header.SelectAll();
            textBox_Header.Copy();
        }


        private void Fio_Formatting(object sender, EventArgs e) //нажатие на кнопку ФИО заголовков или дабл клик в поле
        {
            richTextBox_Fio.Text = Clipboard.GetText();
            richTextBox_Fio.Font = new Font(richTextBox_Fio.Font.FontFamily, (int)numericUpDown_Font_Size.Value, FontStyle.Regular); //Ставим дефолтный шрифт
            string lastName = Extractor.TextHandler(richTextBox_Fio.Text, 1, true);
            string firstName = Extractor.TextHandler(richTextBox_Fio.Text, 2, true);
            string middleName = Extractor.TextHandler(richTextBox_Fio.Text, 3, true);
            //Склоняем
            lastName = Extractor.Declensions(lastName, comboBox_Case_Format.SelectedIndex);
            firstName = Extractor.Declensions(firstName, comboBox_Case_Format.SelectedIndex);
            middleName = Extractor.Declensions(middleName, comboBox_Case_Format.SelectedIndex);


            switch (comboBox_FIO_Format.SelectedIndex)
            {
                case 0: //Фамилия Имя Отчество
                    richTextBox_Fio.Text = lastName + " " + firstName + " " + middleName;
                    break;
                case 1: //Фамилия/Имя Отчество
                    richTextBox_Fio.Text = lastName + Environment.NewLine + firstName + " " + middleName;
                    break;
                case 2: //ФАМИЛИЯ Имя Отчество
                    richTextBox_Fio.Text = lastName.ToUpper() + " " + firstName + " " + middleName;
                    break;
                case 3: //ФАМИЛИЯ/Имя Отчество
                    richTextBox_Fio.Text = lastName.ToUpper() + Environment.NewLine + firstName + " " + middleName;
                    break;
                case 4: //Имя Отчество
                    io = true;
                    richTextBox_Fio.Text = firstName + " " + middleName;
                    break;
                case 5: //И.О.
                    io = true;
                    try { richTextBox_Fio.Text = firstName.Substring(0, 1) + "." + middleName.Substring(0, 1) + "."; }
                    catch (System.ArgumentOutOfRangeException) { richTextBox_Fio.Text = ""; }
                    break;
                default:
                    break;
            }


            if (checkBox_SurnameBold.Checked) //выделяем фамилияю капсом
            {
                if ((comboBox_FIO_Format.SelectedIndex == 4) || (comboBox_FIO_Format.SelectedIndex == 5))  //выделяем всю строку жирным
                    richTextBox_Fio.Select(0, richTextBox_Fio.Text.Length);
                else
                    richTextBox_Fio.Select(0, lastName.Length); //выделяем только первое слово (фамилию)

                richTextBox_Fio.SelectionFont = new Font(richTextBox_Fio.Font.FontFamily, richTextBox_Fio.Font.Size, FontStyle.Bold);
            }

            richTextBox_Fio.SelectAll();
            richTextBox_Fio.Copy();
            io = false;
        }


    }
}

﻿using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
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
            nextClipboardViewer = (IntPtr)SetClipboardViewer((int)Handle); //для автомитического слежения за буфером
        }
        protected override void WndProc(ref Message m)//для автомитического слежения за буфером 
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
            dateTimePicker1.CustomFormat = "dd M yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd.MM.yyyy";
            comboBox_FIO_Format.Items.Add("Фамилия Имя Отчество"); //0
            comboBox_FIO_Format.Items.Add("Фамилия/Имя Отчество");//1
            comboBox_FIO_Format.Items.Add("ФАМИЛИЯ Имя Отчество");//2
            comboBox_FIO_Format.Items.Add("ФАМИЛИЯ/Имя Отчество");//3
            comboBox_FIO_Format.Items.Add("Имя Отчество");//4
            comboBox_FIO_Format.Items.Add("Фамилия И.О.");//5
            comboBox_FIO_Format.Items.Add("И.О. Фамилия");//6
            comboBox_FIO_Format.Items.Add("И.О.");//7

            comboBox_Case_Format.Items.Add("Именительный->(Кто? Что?)");
            comboBox_Case_Format.Items.Add("Родительный ->(Кого? Чего?)");
            comboBox_Case_Format.Items.Add("Дательный   ->(Кому? Чему?)");
            comboBox_Case_Format.Items.Add("Винительный ->(Кого? Что?)");
            comboBox_Case_Format.Items.Add("Творительный->(Кем? Чем ?)");
            comboBox_Case_Format.Items.Add("Передложный ->(О ком? О чём?)");
            ReadSettings();
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

            var fio = Extractor.FIO(richTextBox_Fio.Text);
            string lastName = fio[0];
            string firstName = fio[1];
            string middleName = fio[2];
            //Склоняем
            if(lastName!="") lastName = Extractor.Declensions(lastName, comboBox_Case_Format.SelectedIndex);
            if (firstName != "") firstName = Extractor.Declensions(firstName, comboBox_Case_Format.SelectedIndex);
            if (middleName != "") middleName = Extractor.Declensions(middleName, comboBox_Case_Format.SelectedIndex);


            switch (comboBox_FIO_Format.SelectedIndex)
            {
                case 0: //Фамилия Имя Отчество
                    richTextBox_Fio.Text = (lastName + " " + firstName + " " + middleName).Trim();
                    break;
                case 1: //Фамилия/Имя Отчество
                    richTextBox_Fio.Text = (lastName + Environment.NewLine + firstName + " " + middleName).Trim();
                    break;
                case 2: //ФАМИЛИЯ Имя Отчество
                    richTextBox_Fio.Text = (lastName.ToUpper() + " " + firstName + " " + middleName).Trim();
                    break;
                case 3: //ФАМИЛИЯ/Имя Отчество
                    richTextBox_Fio.Text = (lastName.ToUpper() + Environment.NewLine + firstName + " " + middleName).Trim();
                    break;
                case 4: //Имя Отчество
                    io = true;
                    richTextBox_Fio.Text = (firstName + " " + middleName).Trim();
                    break;
                case 5: //Фамилия И.О.
                    io = true;
                    try { (richTextBox_Fio.Text = lastName + " " + firstName.Substring(0, 1) + "." + middleName.Substring(0, 1) + ".").Trim(); }
                    catch (System.ArgumentOutOfRangeException) { richTextBox_Fio.Text = ""; }
                    break;
                case 6: //И.О. Фамилия 
                    io = true;
                    try { (richTextBox_Fio.Text = firstName.Substring(0, 1) + "." + middleName.Substring(0, 1) + ". " + lastName).Trim(); }
                    catch (System.ArgumentOutOfRangeException) { richTextBox_Fio.Text = ""; }
                    break;
                case 7: //И.О.
                    io = true;
                    try { (richTextBox_Fio.Text = firstName.Substring(0, 1) + "." + middleName.Substring(0, 1) + ".").Trim(); }
                    catch (System.ArgumentOutOfRangeException) { richTextBox_Fio.Text = ""; }
                    break;
                default:
                    break;
            }
            if (checkBox_SurnameBold.Checked) //выделяем фамилияю капсом
            {
                if ((comboBox_FIO_Format.SelectedIndex == 4) || (comboBox_FIO_Format.SelectedIndex == 6) || (comboBox_FIO_Format.SelectedIndex == 7))  //выделяем всю строку жирным
                    richTextBox_Fio.Select(0, richTextBox_Fio.Text.Length);
                else
                    richTextBox_Fio.Select(0, lastName.Length); //выделяем только первое слово (фамилию)
                richTextBox_Fio.SelectionFont = new Font(richTextBox_Fio.Font.FontFamily, richTextBox_Fio.Font.Size, FontStyle.Bold);
            }
            //Clipboard.Clear();
            richTextBox_Fio.SelectAll();
            richTextBox_Fio.Copy();
            io = false;
        }
        private void ReadSettings() //чтение настроек
        {
            try
            {
                using (BinaryReader readerData = new BinaryReader(File.OpenRead("settings.bin")))
                {
                    checkBox_SurnameBold.Checked = readerData.ReadBoolean(); //жирная фамилия
                    numericUpDown_Font_Size.Value = readerData.ReadDecimal(); //размер шрифта
                    comboBox_FIO_Format.SelectedIndex = readerData.ReadInt32(); //вид ФИО
                }
            }
            catch (Exception) //если файла с настройками нет, создаем
            {
                SaveSettings();
            }
        }
        private void SaveSettings() //сохрание настроек
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.OpenWrite("settings.bin")))
                {
                    writer.Write(checkBox_SurnameBold.Checked); //жирная фамилия
                    writer.Write(numericUpDown_Font_Size.Value); //размер шрифта
                    writer.Write(comboBox_FIO_Format.SelectedIndex); //вид ФИО
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message);
            }
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e) => SaveSettings(); //Сохранение настроек при выходе

        //Дату принятия в буфер обмена
        private void label_SessionDate_Click(object sender, EventArgs e) => Clipboard.SetText(dateTimePicker1.Text);
        //Дату публикации в буфер обмена
        private void label_PubDate_Click(object sender, EventArgs e) => Clipboard.SetText(dateTimePicker2.Text);
    }
}

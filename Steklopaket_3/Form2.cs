using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Steklopaket_3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        // загрузка формы
        private void Form2_Load(object sender, EventArgs e)
        {
            // делаем недоступной кнопку Ok
            button1.Enabled = false;

            // по умолчанию выбранный
            // тип стеклопакета - однокамерный
            radioButton1.Checked = true;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form О_программе = new Form3();
            О_программе.Show();
        }

        // изменение содержимого полей Ширина и Высота
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // исходные данные изменились, очистим компонент
            // вывода результатирующих данных label3 от данных
            // предыдущего расчета, если он произвлдился
            if (label3.Text != string.Empty)
                label3.Text = string.Empty;

            // проверка, нужно ли блокировать кнопку Ok
            if ((textBox1.TextLength == 0) ||
                (textBox2.TextLength == 0) ||
                (textBox1.Text == ",") ||
                (textBox2.Text == ","))
                button1.Enabled = false;
            else button1.Enabled = true; 
        }

        // нажатие клавиши в поле Ширина
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // контроль правильности вводимых данных
            if (!Char.IsDigit(e.KeyChar) && !(Char.IsControl(e.KeyChar)))
                if (!((e.KeyChar.ToString() == ",") && (textBox1.Text.IndexOf(",") == -1)))
                    e.Handled = true;
        }

        // нажатие клавиши в поле Высота
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // контроль правильности вводимых данных
            if (!Char.IsDigit(e.KeyChar) && !(Char.IsControl(e.KeyChar)))
                if (!((e.KeyChar.ToString() == ",") && (textBox1.Text.IndexOf(",") == -1)))
                    e.Handled = true;
        }

        // изменения типа стеклопакета, Однокамерный/Двухкамерный,
        // установка/сброс флажка Подоконник;
        // процедура обработки события CheckedChanged создается
        // для компонента radiobutton1, после чего назначается
        // как процедура обработки этого же события
        // и для компонентов radioButton2 и checkBox2
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (label3.Text != string.Empty)
                label3.Text = string.Empty;
        }

        // щелчок на кнопке Ok
        private void button1_Click(object sender, EventArgs e)
        {
            Single w, h, s, // ширина, высота и площадь
                   c,       // цена за 1 кв.м.
                   cst;     // стоимость

            w = Convert.ToSingle(textBox1.Text);
            h = Convert.ToSingle(textBox2.Text);
            s = w * h / 10000;

            if (radioButton1.Checked)
                c = 5000;  // однокамерный стеклопакет
            else
                c = 6000;  // двухкамерный стеклопакет

            cst = s * c;

            // если установлен флажок Подоконник
            if (checkBox2.Checked) cst += 20 * w;

            if (radioButton1.Checked)
                label3.Text = "Размер окна: " + w.ToString("N") + " x " + h.ToString("N") + " см\n" + "Стеклопакет: " + radioButton1.Text + "\nСтоимость: " + cst.ToString("C");
            else
                label3.Text = "Размер окна: " + w.ToString("N") + " x " + h.ToString("N") + "см\n" + "Стеклопакет: " + radioButton2.Text + "\nСтоимость: " + cst.ToString("C");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (label3.Text != string.Empty)
                label3.Text = string.Empty;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (label3.Text != string.Empty)
                label3.Text = string.Empty;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // исходные данные изменились, очистим компонент
            // вывода результатирующих данных label3 от данных
            // предыдущего расчета, если он произвлдился
            if (label3.Text != string.Empty)
                label3.Text = string.Empty;

            // проверка, нужно ли блокировать кнопку Ok
            if ((textBox1.TextLength == 0) ||
                (textBox2.TextLength == 0) ||
                (textBox1.Text == ",") ||
                (textBox2.Text == ","))
                button1.Enabled = false;
            else button1.Enabled = true;
        }
    }
}

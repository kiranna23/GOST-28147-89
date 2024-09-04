using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Crypto
{
    public partial class BaseForm : Form
    {
        byte[] key = new byte[32];
        byte[,] table = new byte[8, 16];
        byte[] TextBin = new byte[1];
        string text = "", buffer = "", result = "";
        public BaseForm()
        {
            InitializeComponent();
        }

        private void fileEncryptButton_Click(object sender, EventArgs e)
        {
           
        }

        private void fileDecryptButton_Click(object sender, EventArgs e)
        {

        }

        private void encrTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void keyTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void decrTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string path = openFileDialog1.FileName;
            table = File1.ReadTableBin(path);
            if (table == null)
            {
                MessageBox.Show("Размер таблицы не равен 64 байтам");
            }
            else
            {
                textBox1.Text = path;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void loadKeyButton_Click(object sender, EventArgs e)
        {

            openFileDialog1.ShowDialog();
            string path = openFileDialog1.FileName;
            key = File1.ReadKey(path);
            if (key == null)
            {
                MessageBox.Show("Размер ключа не равен 32 байтам");
            }
            else
            {
                keyTextBox.Text = path;
            }
        }

        private void fileLoadButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string file = openFileDialog1.FileName;
            keyTextBox.Text = file;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string path = openFileDialog1.FileName;
            char a1 = path[path.Length - 3], a2 = path[path.Length - 2], a3 = path[path.Length - 1];
            string res = Char.ToString(a1) + Char.ToString(a2) + Char.ToString(a3);
            textBox2.Text = path;
            if (res == "txt")
            {
                text = File1.ReadText(path);
                if (text == null)
                    MessageBox.Show("Размер данных не кратен 8 байтам");
                else
                    textBox3.Text = text;
            }
            else
            {
                TextBin = File1.ReadTextBin(path);
                if (TextBin == null)
                    MessageBox.Show("Размер данных не кратен 8 байтам");
                else
                    textBox3.Text = Encoding.UTF8.GetString(TextBin);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            buffer = Encrypt.MainProgramm(key, table, text);
            byte[] DecText = Converter.DataToByte(buffer);
            result = Encoding.UTF8.GetString(DecText);
            textBox4.Text = result; 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            buffer = Decrypt.MainProgramm(key, table, TextBin);
            byte[] DecText = Converter.DataToByte(buffer);
            result = Encoding.UTF8.GetString(DecText);
            textBox4.Text = result;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            File1.WriteDataToBinaryFile(buffer);
            MessageBox.Show("Результат сохранен!");
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

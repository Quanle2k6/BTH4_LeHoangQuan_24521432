using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai05
{
    public partial class Form2 : Form
    {
        private Form1 mainForm;
        public Form2(Form1 form1)
        {
            InitializeComponent();
            this.mainForm = form1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBox1.Text) || string.IsNullOrEmpty(this.textBox2.Text) || string.IsNullOrEmpty(this.textBox3.Text) || string.IsNullOrEmpty(this.comboBox1.Text) || (float.Parse(textBox3.Text) < 0 || float.Parse(textBox3.Text) > 10))
            {
                MessageBox.Show("Bạn cần nhập đầy đủ và đúng thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (string.IsNullOrEmpty(this.textBox1.Text))
                {
                    errorProvider1.SetError(textBox1, "MSSV cần nhập đầy đủ!");
                }
                else
                {
                    errorProvider1.SetError(textBox1, "");
                }

                if (string.IsNullOrEmpty(this.textBox2.Text))
                {
                    errorProvider2.SetError(textBox2, "Họ tên cần nhập đầy đủ!");

                }
                else
                {
                    errorProvider2.SetError(textBox2, "");
                }

               

                if (string.IsNullOrEmpty(this.comboBox1.Text))
                {
                    errorProvider4.SetError(comboBox1, "Cần lựa chọn khoa sinh viên đang theo học!");

                }
                else
                {
                    errorProvider4.SetError(comboBox1, "");
                }
                if (string.IsNullOrEmpty(this.textBox3.Text))
                {
                    errorProvider3.SetError(textBox3, "Điểm số cần nhập đầy đủ!");

                }
                else
                {
                    if (float.Parse(textBox3.Text) < 0 || float.Parse(textBox3.Text) > 10)
                    {
                        errorProvider3.SetError(textBox3, "Điểm số cần nằm trong khoảng từ 0 đến 10");

                    }
                    else
                    {
                        errorProvider3.SetError(textBox3, "");

                    }
                }
               
                return;
            }
            else
            {
                mainForm.ThemDuLieu(textBox1.Text, textBox2.Text, comboBox1.Text, float.Parse(textBox3.Text));
                this.Close();
            }    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsDigit(e.KeyChar))
            {
                return;
            }
            if (char.IsControl(e.KeyChar))
            {
                return;
            }
            e.Handled = true;
            return;

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

           
            if (char.IsLetter(e.KeyChar))
            {
                return;
            }
            if (char.IsControl(e.KeyChar))
            {
                return;
            }
            if (e.KeyChar == ' ')
            {
                return;
            }
            e.Handled = true;
            return;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (char.IsNumber(e.KeyChar))
                return;
            if (char.IsControl(e.KeyChar))
                return;
            if (e.KeyChar == '.')
            {
                if (!tb.Text.Contains("."))
                {
                    return;
                }
                e.Handled = true;
                return;
            }
            e.Handled = true;
            return;
                   
        }

        
            
    }
}

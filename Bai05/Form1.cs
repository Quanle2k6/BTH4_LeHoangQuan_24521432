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
    public partial class Form1 : Form
    {
        public class SinhVien
        {
            internal string MSSV;
            internal string HoTen;
            internal string Khoa;
            internal float DiemTB;
            public SinhVien(string mssv = "", string hoTen = "", string khoa = "", float diemTB = 0)
            {
                MSSV = mssv;
                HoTen = hoTen;
                Khoa = khoa; 
                DiemTB = diemTB;
            }
            public bool Find(string Search)
            {
                Search = Search.ToLower();
                string hoten = HoTen.ToLower();
                if (hoten.Contains(Search))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public List<SinhVien> dsSinhVien = new List<SinhVien>();
        public Form1()
        {
            InitializeComponent();
        }

        private void themToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.ShowDialog();
            toolStripTextBox1.Text = string.Empty;
            HienThi(dsSinhVien);
        }

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void HienThi(List<SinhVien> listsinhvien)
        {
            dataGridView1.Rows.Clear();
            int num = 1;
            foreach (var s in listsinhvien)
            {
                dataGridView1.Rows.Add(num, s.MSSV, s.HoTen, s.Khoa, s.DiemTB);
                num++;
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.ShowDialog();
            toolStripTextBox1.Text = string.Empty;
            HienThi(dsSinhVien);
        }

        public void ThemDuLieu(string mssv, string hoten, string khoa, float diem)
        {
            SinhVien ttSV = new SinhVien(mssv, hoten, khoa, diem);
            dsSinhVien.Add(ttSV);
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (dsSinhVien.Count == 0)
                return;
            if (string.IsNullOrEmpty(toolStripTextBox1.Text))
            {
                HienThi(dsSinhVien);
                return;
            }
            else
            {
                List<SinhVien> search = new List<SinhVien>();
                foreach (var s in dsSinhVien)
                {
                    if (s.Find(toolStripTextBox1.Text))
                        search.Add(s);
                }
                search.Sort((s1, s2) => s1.HoTen.CompareTo(s2.HoTen));
                HienThi(search);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 

namespace Bai04
{
    public partial class Form1 : Form
    {
        private InstalledFontCollection installFonts;
        public Font CustomFont;
        private bool isBold = false;
        private bool isItalic = false;
        private bool isUnderlined = false;
        private float[] SelectedSize = {8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72};
        private float fSize = 14;
        private string FilePath = string.Empty;
        private string FamilyFont = "Tahoma";
        public Form1()
        {
            InitializeComponent();
            installFonts = new InstalledFontCollection();
        }

        private void dinhDangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                CustomFont = fontDialog1.Font;
                toolStripComboBox1.Text = FamilyFont = CustomFont.Name;
                toolStripComboBox2.Text = CustomFont.SizeInPoints.ToString();
                fSize = CustomFont.SizeInPoints;
                if (CustomFont.Style.HasFlag(FontStyle.Bold))
                    isBold = true;
                else
                    isBold = false;
                toolStripButton3.BackColor = (isBold) ? Color.Transparent : Color.Gray;

                if (CustomFont.Style.HasFlag(FontStyle.Italic))
                    isItalic = true;
                else
                    isItalic = false;
                toolStripButton4.BackColor = (isItalic) ? Color.Transparent : Color.Gray;

                if (CustomFont.Style.HasFlag(FontStyle.Underline))
                    isUnderlined = true;
                else
                    isUnderlined = false;
                toolStripButton5.BackColor = (isUnderlined) ? Color.Transparent : Color.Gray;
                ApplyNewFontStyle();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FilePath))
            {
                DialogResult isSave = MessageBox.Show("Bạn có muốn lưu lại file này hay không?", "Xác nhận lưu", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (isSave == DialogResult.Yes)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "Rich Text Format File|*.rtf";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        string savePath = sfd.FileName;
                        System.IO.File.WriteAllText(savePath, richTextBox1.Text);
                        ResetSetting();
                        FilePath = null;
                    }
                }
                else if (isSave == DialogResult.No)
                {
                    FilePath = null;
                    ResetSetting();
                }
            }
            else
            {
                DialogResult isSave = MessageBox.Show("Bạn có muốn lưu lại file này hay không?", "Xác nhận lưu", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (isSave == DialogResult.Yes)
                {
                    string savePath = FilePath;
                    System.IO.File.WriteAllText(savePath, richTextBox1.Text);
                    FilePath = null;
                    ResetSetting();
                }
                else if (isSave == DialogResult.No)
                {
                    FilePath = null;
                    ResetSetting();
                }
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text File|*.txt|Rich Text Format File|*.rtf";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (Stream stream = ofd.OpenFile())
                {
                    // Khởi tạo StreamReader để đọc văn bản từ Stream
                    // `true` ở đây để đảm bảo StreamReader đóng Stream gốc khi nó tự đóng
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        // Đọc toàn bộ nội dung file và gán vào RichTextBox
                        richTextBox1.Text = reader.ReadToEnd();
                    }
                }
                Font currentFont = richTextBox1.SelectionFont;
                toolStripComboBox1.Text = currentFont.Name;
                fSize = currentFont.SizeInPoints;
                toolStripComboBox2.Text = fSize.ToString();
                FilePath = ofd.FileName;
            }    
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FilePath))
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Rich Text Format File|*.rtf";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string savePath = sfd.FileName;
                    System.IO.File.WriteAllText(savePath, richTextBox1.Text);
                    FilePath = savePath;
                }

            }
            else
            {
                string savePath = FilePath;
                System.IO.File.WriteAllText(savePath, richTextBox1.Text);
                MessageBox.Show("Văn bản đã được lưu thành công!");
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FilePath))
            {
                DialogResult isSave = MessageBox.Show("Bạn có muốn lưu lại file này hay không?", "Xác nhận lưu", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (isSave == DialogResult.Yes)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "Rich Text Format File|*.rtf";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        string savePath = sfd.FileName;
                        System.IO.File.WriteAllText(savePath, richTextBox1.Text);
                        ResetSetting();
                        FilePath = null;
                    }
                }
                else if (isSave == DialogResult.No)
                {
                    FilePath = null;
                    ResetSetting();
                }
            }
            else
            {
                DialogResult isSave = MessageBox.Show("Bạn có muốn lưu lại file này hay không?", "Xác nhận lưu", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (isSave == DialogResult.Yes)
                {
                    string savePath = FilePath;
                    System.IO.File.WriteAllText(savePath, richTextBox1.Text);
                    FilePath = null;
                    ResetSetting();
                }
                else if (isSave == DialogResult.No)
                {
                    FilePath = null;
                    ResetSetting();
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FilePath))
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Rich Text Format File|*.rtf";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string savePath = sfd.FileName;
                    System.IO.File.WriteAllText(savePath, richTextBox1.Text);
                    FilePath = savePath;
                }

            }
            else
            {
                string savePath = FilePath;
                System.IO.File.WriteAllText(savePath, richTextBox1.Text);
                MessageBox.Show("Văn bản đã được lưu thành công!");
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            // Đảo ngược trạng thái
            isBold = !isBold;

            // Cập nhật màu nền nút bấm
            toolStripButton3.BackColor = isBold ? Color.Gray : Color.Transparent;

            ApplyNewFontStyle();
           
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            // Đảo ngược trạng thái
            isItalic = !isItalic;

            // Cập nhật màu nền nút bấm
            toolStripButton4.BackColor = isItalic ? Color.Gray : Color.Transparent;

            ApplyNewFontStyle();

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            // Đảo ngược trạng thái
            isUnderlined = !isUnderlined;

            // Cập nhật màu nền nút bấm
            toolStripButton5.BackColor = isUnderlined ? Color.Gray : Color.Transparent;

            ApplyNewFontStyle();

        }

        

        private void toolStripComboBox2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(toolStripComboBox2.Text)) return;
            else if (toolStripComboBox2.Text[toolStripComboBox2.Text.Length - 1] == '.')
            {
                string sSize = toolStripComboBox2.Text.Substring(0, toolStripComboBox2.Text.Length - 1);
                fSize = float.Parse(sSize);
                ApplyNewFontStyle();
            }
            else if (toolStripComboBox2.Text[toolStripComboBox2.Text.Length - 1] != '.' && !string.IsNullOrEmpty(toolStripComboBox2.Text))
            {
                fSize = float.Parse(toolStripComboBox2.Text);
                ApplyNewFontStyle();
            }
            else
            {
                toolStripComboBox2.Text = fSize.ToString();
            }    

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CustomFont = new Font("Tahoma", 14, FontStyle.Regular);
            FontFamily[] FontFamilies = installFonts.Families;
            foreach (FontFamily family in FontFamilies)
            {
                toolStripComboBox1.Items.Add(family.Name);
            }
            toolStripComboBox1.Text = "Tahoma";
            foreach (var Size in SelectedSize)
            {
                toolStripComboBox2.Items.Add(Size.ToString());
            }
            toolStripComboBox2.Text = "14";
            richTextBox1.SelectionFont = CustomFont;

        }

        private void toolStripComboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            ToolStripComboBox toolStripComboBox = sender as ToolStripComboBox;
            if (toolStripComboBox == null) return;

            ComboBox comboBox = toolStripComboBox.ComboBox;

            if (char.IsControl(e.KeyChar))
                return;

            if (char.IsDigit(e.KeyChar))
                return;

            if (e.KeyChar == '.')
            {
                if (!toolStripComboBox.Text.Contains("."))
                    return;

                e.Handled = true;
                return;
            }

            e.Handled = true;
        }
        private void ApplyNewFontStyle()
        {
            FontStyle style = FontStyle.Regular;

            if (isBold)
                style |= FontStyle.Bold;

            if (isItalic) 
                style |= FontStyle.Italic;

            if (isUnderlined)
                style |= FontStyle.Underline;

            Font currentFont = new Font(FamilyFont, fSize);

            CustomFont = new Font(currentFont.FontFamily, currentFont.Size, style);

            richTextBox1.SelectionFont = CustomFont;
        }
        private void ResetSetting()
        {
            isBold = false;
            toolStripButton3.BackColor = Color.Transparent;
            isItalic = false;
            toolStripButton4.BackColor = Color.Transparent;
            isUnderlined = false;
            toolStripButton5.BackColor = Color.Transparent;

            // Áp dụng font mặc định
            richTextBox1.Clear();
            richTextBox1.SelectionFont = new Font("Tahoma", 14, FontStyle.Regular);
            FamilyFont = "Tahoma";
            fSize = 14;
            toolStripComboBox1.Text = FamilyFont;
            toolStripComboBox2.Text = fSize.ToString();

            FilePath = string.Empty;
        }
        private void toolStripButton1_MouseDown(object sender, MouseEventArgs e)
        {
            BackColor = Color.Gray;
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            Font selFont = richTextBox1.SelectionFont;

            if (selFont == null)
            {
                toolStripComboBox1.Text = "";
                toolStripComboBox2.Text = "";

                isBold = false;
                isItalic = false;
                isUnderlined = false;

                toolStripButton3.BackColor = Color.Transparent;
                toolStripButton4.BackColor = Color.Transparent;
                toolStripButton5.BackColor = Color.Transparent;
            }
            else
            {
                // Một định dạng duy nhất
                toolStripComboBox1.Text =  FamilyFont = selFont.FontFamily.Name;
                toolStripComboBox2.Text = selFont.SizeInPoints.ToString();
                fSize = selFont.SizeInPoints;

                isBold = selFont.Bold;
                isItalic = selFont.Italic;
                isUnderlined = selFont.Underline;

                toolStripButton3.BackColor = isBold ? Color.Gray : Color.Transparent;
                toolStripButton4.BackColor = isItalic ? Color.Gray : Color.Transparent;
                toolStripButton5.BackColor = isUnderlined ? Color.Gray : Color.Transparent;
            }
        }

        private void toolStripComboBox1_Leave(object sender, EventArgs e)
        {
            if (toolStripComboBox1.Items.Contains(toolStripComboBox1.Text))
            {
                FamilyFont = toolStripComboBox1.Text;
                ApplyNewFontStyle();
            }
            else
            {
                MessageBox.Show("Font bạn chọn không tồn tại nên sẽ chuyển về font mặc định");
                FamilyFont = "Tahoma";
                ApplyNewFontStyle();
            }
        }
    }
}

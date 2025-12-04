using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai06
{
    public partial class Form1 : Form
    {
        public string Src_Folder = string.Empty;
        public string Dest_Folder = string.Empty;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                Src_Folder = fbd.SelectedPath;
                textBox1.Text = Src_Folder;
                errorProvider1.SetError(textBox1, ""); // Xóa lỗi nếu chọn thành công
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                Dest_Folder = fbd.SelectedPath;
                textBox2.Text = Dest_Folder;
                errorProvider2.SetError(textBox2, ""); // Xóa lỗi nếu chọn thành công
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Src_Folder) || string.IsNullOrEmpty(Dest_Folder))
            {
                MessageBox.Show("Vui lòng chọn đầy đủ đường dẫn thư mục nguồn và đích!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Directory.Exists(Src_Folder))
            {
                errorProvider1.SetError(textBox1, "Đường dẫn nguồn không tồn tại");
                return;
            }

            errorProvider1.SetError(textBox1, "");
            errorProvider2.SetError(textBox2, "");

            button3.Enabled = false; 
            toolStripStatusLabel1.Text = "Đang bắt đầu sao chép...";

            string[] filesToCopy = Directory.GetFiles(Src_Folder);

            if (filesToCopy.Length == 0)
            {
                MessageBox.Show("Thư mục nguồn không có tập tin nào để sao chép.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button3.Enabled = true;
                toolStripStatusLabel1.Text = "Đã hoàn thành.";
                return;
            }

            progressBar1.Maximum = filesToCopy.Length;
            progressBar1.Value = 0;
            progressBar1.Step = 1;

            try
            {
                Directory.CreateDirectory(Dest_Folder);

                await Task.Run(() =>
                {
                    foreach (string sourceFile in filesToCopy)
                    {
                        string fileName = Path.GetFileName(sourceFile);
                        string destFile = Path.Combine(Dest_Folder, fileName);

                        this.Invoke((MethodInvoker)delegate
                        {
                            toolStripStatusLabel1.Text = $"Đang sao chép: {fileName}";
                            toolTip1.SetToolTip(progressBar1, $"Đang sao chép: {fileName}");
                            progressBar1.PerformStep();
                        });

                        File.Copy(sourceFile, destFile, true);
                    }
                });

                // 5. Hoàn thành
                toolStripStatusLabel1.Text = $"Hoàn thành sao chép {filesToCopy.Length} tập tin!";
                toolTip1.SetToolTip(progressBar1, "Đã hoàn thành sao chép");
                MessageBox.Show("Sao chép tất cả tập tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "LỖI: Sao chép thất bại!";
                MessageBox.Show($"Lỗi trong quá trình sao chép: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                button3.Enabled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Src_Folder = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Dest_Folder = textBox2.Text;
        }
    }
}
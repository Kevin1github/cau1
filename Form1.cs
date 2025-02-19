using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ett1_win
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrWhiteSpace(textName.Text) || string.IsNullOrWhiteSpace(textClass.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(textAge.Text, out int age) || age <= 0)
                {
                    MessageBox.Show("Tuổi phải là số nguyên dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var context = new StudentContext())
                {
                    var student = new Student
                    {
                        Name = textName.Text.Trim(),
                        Age = age,
                        Class = textClass.Text.Trim()
                    };

                    context.Students.Add(student);
                    context.SaveChanges();
                }

                MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Xóa dữ liệu sau khi thêm
                textName.Clear();
                textAge.Clear();
                textClass.Clear();

                // Cập nhật lại DataGridView
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (var context = new StudentContext())
                {
                    dataGridView1.DataSource = context.Students.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

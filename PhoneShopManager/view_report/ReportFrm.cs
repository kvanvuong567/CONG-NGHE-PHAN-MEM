using PhoneShopManager.dao;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PhoneShopManager.view_report
{
    public partial class ReportFrm : Form
    {
        private DAO dao;

        public ReportFrm()
        {
            InitializeComponent();
            dao = new DAO();
            dgvReport.AutoGenerateColumns = true;
            dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Tự động điều chỉnh kích thước cột

            // Thêm các mục vào ComboBox
            InitializeTimeFrameComboBox();
        }

        private void InitializeTimeFrameComboBox()
        {
            comboBoxTimeFrame.Items.Add("Theo Ngày");
            comboBoxTimeFrame.Items.Add("Theo Tháng");
            comboBoxTimeFrame.Items.Add("Theo Năm");

            // Chọn mặc định là "Theo Ngày"
            if (comboBoxTimeFrame.Items.Count > 0)
            {
                comboBoxTimeFrame.SelectedIndex = 0; // Chọn mặc định là "Theo Ngày"
            }
            else
            {
                MessageBox.Show("Không có mục nào để chọn trong khoảng thời gian."); // Thông báo nếu không có mục
            }
        }

        private void GenerateReport()
        {
            string selectedTimeFrame = comboBoxTimeFrame.SelectedItem.ToString();
            string query = GetQuery(selectedTimeFrame);

            if (query == null)
            {
                MessageBox.Show("Vui lòng chọn một khoảng thời gian hợp lệ.");
                return;
            }

            DataTable reportData = GetReportData(query);

            // Kiểm tra xem DataTable có dữ liệu hay không
            if (reportData.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để hiển thị."); // Thông báo nếu không có dữ liệu
            }
            else
            {
                dgvReport.DataSource = reportData; // Gán dữ liệu cho DataGridView
            }
        }

        private string GetQuery(string timeFrame)
        {
            switch (timeFrame)
            {
                case "Theo Ngày":
                    return "SELECT o.ProductID, p.ProductName, SUM(o.Quantity) AS QuantitySold, SUM(o.TotalPrice) AS TotalRevenue " +
                           "FROM [Order] o INNER JOIN Product p ON o.ProductID = p.ProductID " +
                           "WHERE CAST(o.OrderDate AS DATE) = CAST(GETDATE() AS DATE) " +
                           "GROUP BY o.ProductID, p.ProductName";

                case "Theo Tháng":
                    return "SELECT o.ProductID, p.ProductName, SUM(o.Quantity) AS QuantitySold, SUM(o.TotalPrice) AS TotalRevenue " +
                           "FROM [Order] o INNER JOIN Product p ON o.ProductID = p.ProductID " +
                           "WHERE MONTH(o.OrderDate) = MONTH(GETDATE()) AND YEAR(o.OrderDate) = YEAR(GETDATE()) " +
                           "GROUP BY o.ProductID, p.ProductName";

                case "Theo Năm":
                    return "SELECT o.ProductID, p.ProductName, SUM(o.Quantity) AS QuantitySold, SUM(o.TotalPrice) AS TotalRevenue " +
                           "FROM [Order] o INNER JOIN Product p ON o.ProductID = p.ProductID " +
                           "WHERE YEAR(o.OrderDate) = YEAR(GETDATE()) " +
                           "GROUP BY o.ProductID, p.ProductName";

                default:
                    return null; // Trả về null nếu không có lựa chọn hợp lệ
            }
        }

        private DataTable GetReportData(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(dao.GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                MessageBox.Show($"Số hàng nhận được: {dt.Rows.Count}"); // Kiểm tra số hàng
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy dữ liệu: {ex.Message}"); // Hiển thị thông báo lỗi
            }
            return dt; // Trả về DataTable chứa kết quả truy vấn
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGenerateReport_Click_1(object sender, EventArgs e)
        {
            GenerateReport();
        }
    }
}

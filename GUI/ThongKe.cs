using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using NguyenThanhNhan_2121110075.BAL;
namespace NguyenThanhNhan_2121110075.GUI
{
    public partial class ThongKe : Form
    {
        public ThongKe()
        {
            InitializeComponent();
        }

        QLMuonBAL qlmbal = new QLMuonBAL();

        private void ThongKe_Load(object sender, EventArgs e)
        {
           
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            try
            {
                reportViewer1.LocalReport.ReportEmbeddedResource = "NguyenThanhNhan_2121110075.GUI.Report1.rdlc";

                // Tạo nguồn dữ liệu cho báo cáo
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "DataSet1";  // Tên DataSet trong tệp rdlc
                reportDataSource.Value = qlmbal.ReadQuanLyMuon();

                // Gán nguồn dữ liệu cho báo cáo
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                // Refresh và hiển thị báo cáo trên ReportViewer
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                // Xử lý nếu có lỗi xảy ra
                MessageBox.Show("Đã xảy ra lỗi trong quá trình tạo báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

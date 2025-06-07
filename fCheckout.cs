using QuanLyTiemTapHoa.DAO;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Windows.Forms;
using System.IO;
namespace QuanLyTiemTapHoa
{
    public partial class fCheckout : Form
    {
        private string currentOrderID;


        public fCheckout(string orderID)
        {
            InitializeComponent();

            this.currentOrderID = orderID;

        }

        private void fCheckout_Load(object sender, EventArgs e)
        {
            LoadBillData();
        }

        void LoadBillData()
        {
            //if (this.currentOrderID[currentOrderID[currentOrderID.Length - 1]] <= 0)
            //{
            //    MessageBox.Show("Mã hóa đơn không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.Close();
            //    return;
            //}

            lblOrderID.Text = "Mã hóa đơn: " + this.currentOrderID.ToString();


            lblOrderDate.Text = "Ngày tạo: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");


            flpBillItems.Controls.Clear();

            DataTable billData = OrderDAO.Instance.GetOrderDetailsForBill(this.currentOrderID);
            MessageBox.Show("Rows count: " + (billData?.Rows.Count.ToString() ?? "NULL"));
            if (billData == null)
            {
                MessageBox.Show("Không thể tải chi tiết hóa đơn. Dữ liệu trả về null.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal grandTotal = 0;
            int stt = 1;

            CultureInfo culture = new CultureInfo("vi-VN"); // For VNĐ formatting

            foreach (DataRow itemRow in billData.Rows)
            {
                string productName = itemRow["ProductName"].ToString();
                int quantity = Convert.ToInt32(itemRow["Quantity"]);
                decimal unitPrice = Convert.ToDecimal(itemRow["UnitPrice"]);
                decimal totalPrice = Convert.ToDecimal(itemRow["ThanhTien"]); // Or calculate: quantity * unitPrice;

                grandTotal += totalPrice;

                // Create a panel for each item row
                Panel itemPanel = new Panel();
                itemPanel.Width = flpBillItems.ClientSize.Width - 5; // Adjust for scrollbar if visible
                itemPanel.Height = 30; // Or adjust based on font
                itemPanel.Margin = new Padding(0, 0, 0, 3); // Spacing between items

                Label lblSTT = new Label() { Text = stt.ToString(), Location = new Point(12, 5), AutoSize = true };
                Label lblName = new Label() { Text = productName, Location = new Point(50, 5), Size = new Size(125, 20) }; // Give more width
                Label lblSL = new Label() { Text = quantity.ToString(), Location = new Point(180, 5), AutoSize = true };
                Label lblDonGia = new Label() { Text = unitPrice.ToString("c0", culture), Location = new Point(220, 5), Size = new Size(55, 20), TextAlign = ContentAlignment.MiddleRight };
                Label lblThanhTien = new Label() { Text = totalPrice.ToString("c0", culture), Location = new Point(280, 5), Size = new Size(70, 20), TextAlign = ContentAlignment.MiddleRight };

                itemPanel.Controls.Add(lblSTT);
                itemPanel.Controls.Add(lblName);
                itemPanel.Controls.Add(lblSL);
                itemPanel.Controls.Add(lblDonGia);
                itemPanel.Controls.Add(lblThanhTien);

                flpBillItems.Controls.Add(itemPanel);
                stt++;
            }

            lblGrandTotal.Text = grandTotal.ToString("c0", culture);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FlowLayoutPanel targetControl = this.flpBillItems;

            if (targetControl == null || targetControl.Controls.Count == 0)
            {
                MessageBox.Show("Không có mục nào để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            Size originalSize = targetControl.Size;
            bool originalAutoScroll = targetControl.AutoScroll;
            Point originalScrollPosition = targetControl.AutoScrollPosition;
            Size originalFormSize = this.Size;
            FormWindowState originalWindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Minimized) this.WindowState = FormWindowState.Normal;


            try
            {

                targetControl.AutoScroll = false;


                int requiredHeight = 0;
                foreach (Control item in targetControl.Controls)
                {
                    // Giả sử FlowDirection là TopDownrequiredHeight += item.Height + item.Margin.Vertical;
                }
                requiredHeight += targetControl.Padding.Vertical; // Thêm padding của FlowLayoutPanel

                // Nếu chiều cao yêu cầu lớn hơn chiều cao hiện tại, thay đổi kích thước
                if (requiredHeight > targetControl.Height)
                {

                    int screenHeight = Screen.FromControl(this).WorkingArea.Height;
                    int newHeight = Math.Min(requiredHeight + 20, screenHeight - this.Top - 50); // +20 cho thoải mái, trừ vị trí form và thanh taskbar

                    targetControl.Height = newHeight;


                    if (targetControl.Bottom > this.ClientSize.Height - 50) // 50 là khoảng cho nút và total
                    {
                        this.Height = Math.Min(originalFormSize.Height + (targetControl.Bottom - (this.ClientSize.Height - 50)) + 20, screenHeight);
                    }
                    Application.DoEvents();
                }



                Bitmap bmp = new Bitmap(targetControl.Width, requiredHeight > 0 ? requiredHeight : targetControl.Height);


                targetControl.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));


                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg";
                saveDialog.Title = "Lưu biên lai (Toàn bộ)";
                saveDialog.FileName = $"HoaDon_{this.currentOrderID}_Full_{DateTime.Now:yyyyMMddHHmmss}.png";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(saveDialog.FileName))
                    {
                        ImageFormat format = Path.GetExtension(saveDialog.FileName).ToLower() == ".jpg" ? ImageFormat.Jpeg : ImageFormat.Png;
                        bmp.Save(saveDialog.FileName, format);
                        MessageBox.Show("Đã lưu biên lai thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất biên lai: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Khôi phục lại kích thước và trạng thái AutoScroll ban đầu
                targetControl.AutoScroll = originalAutoScroll;
                targetControl.Size = originalSize;
                targetControl.AutoScrollPosition = originalScrollPosition; // Khôi phục vị trí cuộn

                // Khôi phục kích thước form
                this.Size = originalFormSize;
                this.WindowState = originalWindowState;
                Application.DoEvents(); // Cho phép UI cập nhật lại
            }
        }
    }
}
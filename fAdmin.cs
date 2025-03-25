using ClosedXML.Excel;
using QuanLyTiemTapHoa.DAO;
using QuanLyTiemTapHoa.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace QuanLyTiemTapHoa
{
    public partial class fAdmin : Form
    {
        private DataTable statisticsData;

        public DataTable StatisticsData { get => statisticsData; set => statisticsData = value; }

        public fAdmin()
        {
            InitializeComponent();

            LoadAllData();
            BindingData();
        }

        private void LoadDataAccounts()
        {
            dgvAccounts.DataSource = AccountDAO.Instance.GetDataAllAccounts();

            if (dgvAccounts.Rows.Count > 0)
            {
                foreach (DataGridViewColumn col in dgvAccounts.Columns)
                {
                    col.Visible = col.Name == "FullName" || col.Name == "Role";
                }
                dgvAccounts.Columns["FullName"].HeaderText = "Họ và tên";
                dgvAccounts.Columns["Role"].HeaderText = "Vị trí";
            }
        }

        private void LoadDataCustomers()
        {
            dgvCustomers.DataSource = CustomerDAO.Instance.GetDataAllCustomers();

            if (dgvCustomers.Rows.Count > 0)
            {
                foreach (DataGridViewColumn col in dgvCustomers.Columns)
                {
                    col.Visible = col.Name == "FullName" || col.Name == "CreatedAt";
                }
                dgvCustomers.Columns["FullName"].HeaderText = "Họ và tên";
                dgvCustomers.Columns["CreatedAt"].HeaderText = "Ngày đăng ký";
            }
        }

        private void LoadDataCategories()
        {
            dgvCategories.DataSource = CategoryDAO.Instance.GetDataAllCategories();

            if (dgvCategories.Rows.Count > 0)
            {
                foreach (DataGridViewColumn col in dgvCategories.Columns)
                {
                    col.Visible = col.Name == "CategoryName";
                }
                dgvCategories.Columns["CategoryName"].HeaderText = "Tên mục";
            }
        }

        private void LoadDataProducts()
        {
            dgvProducts.DataSource = ProductDAO.Instance.GetDataAllProducts();

            if (dgvProducts.Rows.Count > 0)
            {
                foreach (DataGridViewColumn col in dgvProducts.Columns)
                {
                    col.Visible = col.Name == "ProductName" || col.Name == "StockQuantity";
                }
                dgvProducts.Columns["ProductName"].HeaderText = "Tên sản phẩm";
                dgvProducts.Columns["StockQuantity"].HeaderText = "Tồn kho";
            }
        }

        private void LoadDataOrders()
        {
            dgvOrders.DataSource = OrderDAO.Instance.GetDataAllOrders();

            if (dgvOrders.Rows.Count > 0)
            {
                foreach (DataGridViewColumn col in dgvOrders.Columns)
                {
                    col.Visible = col.Name == "StaffName" || col.Name == "OrderDate" || col.Name == "Status";
                }
                dgvOrders.Columns["StaffName"].HeaderText = "Người tạo đơn";
                dgvOrders.Columns["OrderDate"].HeaderText = "Ngày tạo";
                dgvOrders.Columns["Status"].HeaderText = "Trạng thái";
            }
        }

        private void LoadDataOrderDetails()
        {
            lvOderDetail.Items.Clear();

            List<MenuRow> listRow = MenuRowDAO.Instance.GetListMenuRow(int.Parse(tbOrderID.Text));

            foreach (MenuRow row in listRow)
            {
                ListViewItem lvItem = new ListViewItem(row.ProductName.ToString());
                lvItem.SubItems.Add(row.Quantity.ToString());
                lvItem.SubItems.Add(row.Price.ToString());
                lvItem.SubItems.Add(row.TotalPrice.ToString());

                lvOderDetail.Items.Add(lvItem);
            }
        }

        private void LoadDateTimePickerOrder()
        {
            DateTime today = DateTime.Today;
            dtpStart.Value = new DateTime(today.Year, today.Month, 1);
            dtpEnd.Value = dtpStart.Value.AddMonths(1).AddDays(-1);
        }

        private void LoadDataCompletedOrderByDates()
        {
            statisticsData = OrderDAO.Instance.GetCompletedOrderByDates(dtpStart.Value.ToString("yyyy-MM-dd"), dtpEnd.Value.AddDays(1).ToString("yyyy-MM-dd"));
            dgvCompletedOrders.DataSource = statisticsData;

            if (dgvCompletedOrders.Rows.Count > 0)
            {
                dgvCompletedOrders.Columns["CustomerName"].HeaderText = "Tên khách hàng";
                dgvCompletedOrders.Columns["StaffName"].HeaderText = "Người tạo đơn";
                dgvCompletedOrders.Columns["OrderDate"].HeaderText = "Ngày tạo";
                dgvCompletedOrders.Columns["Status"].HeaderText = "Trạng thái";
            }
        }

        private void LoadAllData()
        {
            LoadDataAccounts();
            LoadDataCustomers();
            LoadDataCategories();
            LoadDataProducts();
            LoadDataOrders();
            LoadDateTimePickerOrder();
            LoadDataCompletedOrderByDates();
        }

        private void BindingDataUser()
        {
            tbUserID.DataBindings.Add(new Binding("Text", dgvAccounts.DataSource, "UserID"));
            tbUserFullName.DataBindings.Add(new Binding("Text", dgvAccounts.DataSource, "FullName"));
            tbUserRole.DataBindings.Add(new Binding("Text", dgvAccounts.DataSource, "Role"));
            tbUserPhone.DataBindings.Add(new Binding("Text", dgvAccounts.DataSource, "Phone"));
            tbUserEmail.DataBindings.Add(new Binding("Text", dgvAccounts.DataSource, "Email"));
        }

        private void BindingDataCustomer()
        {
            tbCustomerID.DataBindings.Add(new Binding("Text", dgvCustomers.DataSource, "CustomerID"));
            tbCusFullName.DataBindings.Add(new Binding("Text", dgvCustomers.DataSource, "FullName"));
            tbCusPhone.DataBindings.Add(new Binding("Text", dgvCustomers.DataSource, "Phone"));
            tbCusEmail.DataBindings.Add(new Binding("Text", dgvCustomers.DataSource, "Email"));
            tbCusCreatedAt.DataBindings.Add(new Binding("Text", dgvCustomers.DataSource, "CreatedAt"));
        }

        private void BindingDataCategory()
        {
            tbCategoryID.DataBindings.Add(new Binding("Text", dgvCategories.DataSource, "CategoryID"));
            tbCategoryName.DataBindings.Add(new Binding("Text", dgvCategories.DataSource, "CategoryName"));
        }

        private void BindingDataProduct()
        {
            tbProductID.DataBindings.Add(new Binding("Text", dgvProducts.DataSource, "ProductID"));
            tbProductName.DataBindings.Add(new Binding("Text", dgvProducts.DataSource, "ProductName"));
            tbProductCateID.DataBindings.Add(new Binding("Text", dgvProducts.DataSource, "CategoryID"));
            tbProductPrice.DataBindings.Add(new Binding("Text", dgvProducts.DataSource, "Price"));
            tbProductStockQuantity.DataBindings.Add(new Binding("Text", dgvProducts.DataSource, "StockQuantity"));
        }

        private void BindingDataOrder()
        {
            tbOrderID.DataBindings.Add(new Binding("Text", dgvOrders.DataSource, "OrderID"));
            tbCustomerName.DataBindings.Add(new Binding("Text", dgvOrders.DataSource, "CustomerName"));
            tbStaffName.DataBindings.Add(new Binding("Text", dgvOrders.DataSource, "StaffName"));
            tbOrderDate.DataBindings.Add(new Binding("Text", dgvOrders.DataSource, "OrderDate"));
            tbStatus.DataBindings.Add(new Binding("Text", dgvOrders.DataSource, "Status"));
        }

        private void BindingData()
        {
            BindingDataUser();
            BindingDataCustomer();
            BindingDataCategory();
            BindingDataProduct();
            BindingDataOrder();
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            LoadDataCompletedOrderByDates();
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            LoadDataCompletedOrderByDates();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel files|*.xlsx", FileName = "data.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        wb.Worksheets.Add(statisticsData, "Sheet1");
                        wb.SaveAs(sfd.FileName);
                    }
                    MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void tbOrderID_TextChanged(object sender, EventArgs e)
        {
            LoadDataOrderDetails();
        }
    }
}

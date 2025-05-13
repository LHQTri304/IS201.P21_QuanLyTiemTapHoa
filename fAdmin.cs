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
        }

        #region Load data
        private void LoadDataAccounts(string keyword = "")
        {
            dgvAccounts.DataSource = keyword == "" ? AccountDAO.Instance.GetDataAllAccounts() : AccountDAO.Instance.GetDataFindAccounts(keyword);

            if (dgvAccounts.Rows.Count > 0)
            {
                foreach (DataGridViewColumn col in dgvAccounts.Columns)
                {
                    col.Visible = col.Name == "FullName" || col.Name == "Role";
                }
                dgvAccounts.Columns["FullName"].HeaderText = "Họ và tên";
                dgvAccounts.Columns["Role"].HeaderText = "Vị trí";
            }

            // Clear all old bindings
            tbUserID.DataBindings.Clear();
            tbUserFullName.DataBindings.Clear();
            cbbUserRole.DataBindings.Clear();
            tbUserPhone.DataBindings.Clear();
            tbUserEmail.DataBindings.Clear();

            // Rebind
            BindingDataUser();
        }

        private void LoadDataCustomers(string keyword = "")
        {
            dgvCustomers.DataSource = keyword == "" ? CustomerDAO.Instance.GetDataAllCustomers() : CustomerDAO.Instance.GetDataFindCustomers(keyword);

            if (dgvCustomers.Rows.Count > 0)
            {
                foreach (DataGridViewColumn col in dgvCustomers.Columns)
                {
                    col.Visible = col.Name == "FullName" || col.Name == "CreatedAt";
                }
                dgvCustomers.Columns["FullName"].HeaderText = "Họ và tên";
                dgvCustomers.Columns["CreatedAt"].HeaderText = "Ngày đăng ký";
            }

            // Clear old bindings
            tbCustomerID.DataBindings.Clear();
            tbCusFullName.DataBindings.Clear();
            tbCusPhone.DataBindings.Clear();
            tbCusEmail.DataBindings.Clear();
            tbCusCreatedAt.DataBindings.Clear();

            // Rebind
            BindingDataCustomer();
        }

        private void LoadDataCategories(string keyword = "")
        {
            dgvCategories.DataSource = keyword == "" ? CategoryDAO.Instance.GetDataAllCategories() : CategoryDAO.Instance.GetDataFindCategories(keyword);

            if (dgvCategories.Rows.Count > 0)
            {
                foreach (DataGridViewColumn col in dgvCategories.Columns)
                {
                    col.Visible = col.Name == "CategoryName";
                }
                dgvCategories.Columns["CategoryName"].HeaderText = "Tên mục";
            }

            // Clear old bindings
            tbCategoryID.DataBindings.Clear();
            tbCategoryName.DataBindings.Clear();

            // Rebind
            BindingDataCategory();
        }

        private void LoadDataProducts(string keyword = "")
        {
            dgvProducts.DataSource = keyword == "" ? ProductDAO.Instance.GetDataAllProducts() : ProductDAO.Instance.GetDataFindProducts(keyword);

            if (dgvProducts.Rows.Count > 0)
            {
                foreach (DataGridViewColumn col in dgvProducts.Columns)
                {
                    col.Visible = col.Name == "ProductName" || col.Name == "StockQuantity";
                }
                dgvProducts.Columns["ProductName"].HeaderText = "Tên sản phẩm";
                dgvProducts.Columns["StockQuantity"].HeaderText = "Tồn kho";
            }

            // Clear old bindings
            tbProductID.DataBindings.Clear();
            tbProductName.DataBindings.Clear();
            tbProductCateID.DataBindings.Clear();
            tbProductPrice.DataBindings.Clear();
            tbProductStockQuantity.DataBindings.Clear();

            // Rebind
            BindingDataProduct();
        }

        private void LoadDataOrders(string keyword = "")
        {
            dgvOrders.DataSource = keyword == "" ? OrderDAO.Instance.GetDataAllOrders() : OrderDAO.Instance.GetDataFindOrders(keyword);

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

            // Clear old bindings
            tbOrderID.DataBindings.Clear();
            tbCustomerName.DataBindings.Clear();
            tbStaffName.DataBindings.Clear();
            tbOrderDate.DataBindings.Clear();
            tbStatus.DataBindings.Clear();

            // Rebind
            BindingDataOrder();
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
        #endregion


        #region Binding data
        private void BindingDataUser()
        {
            tbUserID.DataBindings.Add(new Binding("Text", dgvAccounts.DataSource, "UserID"));
            tbUserFullName.DataBindings.Add(new Binding("Text", dgvAccounts.DataSource, "FullName"));
            cbbUserRole.DataBindings.Add(new Binding("Text", dgvAccounts.DataSource, "Role"));
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
        #endregion


        #region Logic components
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
        #endregion


        #region Logic CRUD
        private void btnRemoveUser_Click(object sender, EventArgs e)
        {
            int result = AccountDAO.Instance.RemoveAccount(Convert.ToInt32(tbUserID.Text));

            if (result != 0)
                MessageBox.Show("Xóa thành công");
            else
                MessageBox.Show("Xóa thất bại");

            LoadDataAccounts();
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            int result = AccountDAO.Instance.UpdateAccount(Convert.ToInt32(tbUserID.Text), tbUserFullName.Text, cbbUserRole.Text, tbUserPhone.Text, tbUserEmail.Text);

            if (result != 0)
                MessageBox.Show("Cập nhật thành công");
            else
                MessageBox.Show("Cập nhật thất bại"); ;

            LoadDataAccounts();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            int result = CustomerDAO.Instance.AddCustomer(tbCusFullName.Text, tbCusPhone.Text, tbCusEmail.Text);

            if (result != 0)
                MessageBox.Show("Thêm khách hàng thành công");
            else
                MessageBox.Show("Thêm thất bại"); ;

            LoadDataCustomers();
        }

        private void btnRemoveCustomer_Click(object sender, EventArgs e)
        {
            int result = CustomerDAO.Instance.RemoveCustomer(Convert.ToInt32(tbCustomerID.Text));

            if (result != 0)
                MessageBox.Show("Xóa khách hàng thành công");
            else
                MessageBox.Show("Xóa thất bại");

            LoadDataCustomers();
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            int result = CustomerDAO.Instance.UpdateCustomer(Convert.ToInt32(tbCustomerID.Text), tbCusFullName.Text, tbCusPhone.Text, tbCusEmail.Text);

            if (result != 0)
                MessageBox.Show("Cập nhật thành công");
            else
                MessageBox.Show("Cập nhật thất bại");

            LoadDataCustomers();
        }
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            int result = CategoryDAO.Instance.AddCategory(tbCategoryName.Text);

            if (result != 0)
                MessageBox.Show("Thêm danh mục thành công");
            else
                MessageBox.Show("Thêm thất bại");

            LoadDataCategories();
        }

        private void btnRemoveCategory_Click(object sender, EventArgs e)
        {
            int result = CategoryDAO.Instance.RemoveCategory(Convert.ToInt32(tbCategoryID.Text));

            if (result != 0)
                MessageBox.Show("Xóa danh mục thành công");
            else
                MessageBox.Show("Xóa thất bại");

            LoadDataCategories();
        }

        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            int result = CategoryDAO.Instance.UpdateCategory(Convert.ToInt32(tbCategoryID.Text), tbCategoryName.Text);

            if (result != 0)
                MessageBox.Show("Cập nhật thành công");
            else
                MessageBox.Show("Cập nhật thất bại");

            LoadDataCategories();
        }
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            int result = ProductDAO.Instance.AddProduct(
                tbProductName.Text,
                Convert.ToInt32(tbCategoryID.Text),
                Convert.ToDecimal(tbProductPrice.Text),
                Convert.ToInt32(tbProductStockQuantity.Text)
            );

            if (result != 0)
                MessageBox.Show("Thêm sản phẩm thành công");
            else
                MessageBox.Show("Thêm thất bại");

            LoadDataProducts();
        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            int result = ProductDAO.Instance.RemoveProduct(Convert.ToInt32(tbProductID.Text));

            if (result != 0)
                MessageBox.Show("Xóa sản phẩm thành công");
            else
                MessageBox.Show("Xóa thất bại");

            LoadDataProducts();
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            int result = ProductDAO.Instance.UpdateProduct(
                Convert.ToInt32(tbProductID.Text),
                tbProductName.Text,
                Convert.ToInt32(tbCategoryID.Text),
                Convert.ToDecimal(tbProductPrice.Text),
                Convert.ToInt32(tbProductStockQuantity.Text)
            );

            if (result != 0)
                MessageBox.Show("Cập nhật thành công");
            else
                MessageBox.Show("Cập nhật thất bại");

            LoadDataProducts();
        }
        #endregion


        #region Find bar & Reload dataGridView
        private void tbFindUsers_TextChanged(object sender, EventArgs e)
        {
            LoadDataAccounts(tbFindUsers.Text);
        }

        private void tbFindCustomers_TextChanged(object sender, EventArgs e)
        {
            LoadDataCustomers(tbFindCustomers.Text);
        }

        private void tbFindCategories_TextChanged(object sender, EventArgs e)
        {
            LoadDataCategories(tbFindCategories.Text);
        }

        private void tbFindProducts_TextChanged(object sender, EventArgs e)
        {
            LoadDataProducts(tbFindProducts.Text);
        }

        private void tbFindOrders_TextChanged(object sender, EventArgs e)
        {
            LoadDataOrders(tbFindOrders.Text);
        }
        #endregion

        private void btnReloadUsers_Click(object sender, EventArgs e)
        {
            LoadDataAccounts();
        }

        private void btnReloadCustomers_Click(object sender, EventArgs e)
        {
            LoadDataCustomers();
        }

        private void btnReloadCategories_Click(object sender, EventArgs e)
        {
            LoadDataCategories();
        }

        private void btnReloadProducts_Click(object sender, EventArgs e)
        {
            LoadDataProducts();
        }

        private void btnReloadOrders_Click(object sender, EventArgs e)
        {
            LoadDataOrders();
        }
    }
}

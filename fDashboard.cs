using QuanLyTiemTapHoa.DAO;
using QuanLyTiemTapHoa.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace QuanLyTiemTapHoa
{
    public partial class fDashboard : Form
    {
        private int currentOrderID = 0;
        private int currentCategoryID = 0;
        private int currentProductID = 0;

        public int CurrentOrderID { get => currentOrderID; private set => currentOrderID = value; }
        public int CurrentCategoryID { get => currentCategoryID; private set => currentCategoryID = value; }
        public int CurrentProductID { get => currentProductID; private set => currentProductID = value; }

        public fDashboard()
        {
            InitializeComponent();

            currentOrderID = OrderDAO.Instance.GetIdNewestOrder();
            LoadOrder();
            LoadCategories();
            LoadProducts();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void tsmLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadOrder()
        {
            lvNewOder.Items.Clear();

            List<MenuRow> listRow = MenuRowDAO.Instance.GetListMenuRow(currentOrderID);

            foreach (MenuRow row in listRow)
            {
                ListViewItem lvItem = new ListViewItem(row.ProductName.ToString());
                lvItem.SubItems.Add(row.Quantity.ToString());
                lvItem.SubItems.Add(row.Price.ToString());
                lvItem.SubItems.Add(row.TotalPrice.ToString());

                lvNewOder.Items.Add(lvItem);
            }

            LoadTotalBillCost();
        }

        private void LoadTotalBillCost()
        {
            float total = 0;

            List<MenuRow> listRow = MenuRowDAO.Instance.GetListMenuRow(CurrentOrderID);

            foreach (MenuRow row in listRow)
                total += row.TotalPrice;

            CultureInfo culture = new CultureInfo("vi-VN");
            tbTotalBillCost.Text = total.ToString("c", culture);
        }

        private void LoadCategories()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetListCategories();

            cbbCategories.DataSource = listCategory;
            cbbCategories.DisplayMember = "CategoryName";
        }

        private void LoadProducts(int CategoryID = -1)
        {
            List<Product> listProduct = ProductDAO.Instance.GetListProducts(CategoryID);

            cbbProducts.DataSource = listProduct;
            cbbProducts.DisplayMember = "ProductName";
        }

        private void cbbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;

            Category selected = cb.SelectedItem as Category;
            currentCategoryID = selected.CategoryID;

            LoadProducts(currentCategoryID);
        }

        private void cbbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;

            Product selected = cb.SelectedItem as Product;
            currentProductID = selected.ProductID;
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            if (OrderDAO.Instance.InitNewOrder() != 1)
            {
                MessageBox.Show("Lỗi tạo đơn hàng mới");
                return;
            }
            if (OrderDAO.Instance.RemoveOrder(currentOrderID) != 1)
            {
                MessageBox.Show("Lỗi xóa đơn hàng hiện tại");
                return;
            }

            currentOrderID = OrderDAO.Instance.GetIdNewestOrder();
            LoadOrder();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (nudQuantity.Value > 0)
            {
                if (OrderDAO.Instance.InsertProductToOrder(currentOrderID, currentProductID, (int)nudQuantity.Value) != 1)
                {
                    MessageBox.Show("Lỗi thêm sản phẩm vào đơn hàng");
                    return;
                }
            }
            else
            {
                if (OrderDAO.Instance.RemoveProductFromOrder(currentOrderID, currentProductID, -(int)nudQuantity.Value) != 1)
                {
                    MessageBox.Show("Lỗi xóa sản phẩm khỏi đơn hàng");
                    return;
                }
            }

            LoadOrder();
        }
    }
}

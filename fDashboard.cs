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
        private CultureInfo culture = new CultureInfo("vi-VN") { NumberFormat = { CurrencyDecimalDigits = 0 } };
        private string currentOrderID = "";
        private string currentCategoryID = "";
        private string currentProductID = "";

        public string CurrentOrderID { get => currentOrderID; private set => currentOrderID = value; }
        public string CurrentCategoryID { get => currentCategoryID; private set => currentCategoryID = value; }
        public string CurrentProductID { get => currentProductID; private set => currentProductID = value; }

        public fDashboard(string username)
        {
            InitializeComponent();

            currentOrderID = OrderDAO.Instance.GetIdNewestOrder();
            LoadOrder();
            //LoadCategories();
            LoadProductList();

            if (username.ToLower() == "admin")
            {
                tsmAdmin.Visible = true;
            }
            else
            {
                tsmAdmin.Visible = false;
            }
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
            flpOrderDetails.Controls.Clear();

            List<MenuRow> listRow = MenuRowDAO.Instance.GetListMenuRow(currentOrderID);

            foreach (MenuRow item in listRow)
            {
                var panel = new ShowingOrderDetailPanel()
                {
                    ProductName = item.ProductName,
                    ProductCount = item.Quantity.ToString(),
                    ProductPrice = item.Price.ToString("c", culture),
                    ProductTotalPrice = item.TotalPrice.ToString("c", culture),
                    OnPanelClick = () =>
                    {
                        RemoveOrderDetail(item);
                    }
                };

                flpOrderDetails.Controls.Add(panel);
            }

            LoadTotalBillCost();
        }

        private void LoadTotalBillCost()
        {
            float total = 0;

            List<MenuRow> listRow = MenuRowDAO.Instance.GetListMenuRow(CurrentOrderID);

            foreach (MenuRow row in listRow)
                total += row.TotalPrice;

            tbTotalBillCost.Text = total.ToString("c", culture);
        }

        private void LoadCategories()
        {
            //List<Category> listCategory = CategoryDAO.Instance.GetListCategories();

            //cbbCategories.DataSource = listCategory;
            //cbbCategories.DisplayMember = "CategoryName";
        }

        private void LoadProductList(string keyword = "")
        {
            flpListProducts.Controls.Clear();
            List<Product> listProduct = ProductDAO.Instance.GetListProducts(keyword);

            foreach (Product item in listProduct)
            {
                var panel = new FindingProductPanel()
                {
                    ProductName = item.ProductName,
                    ProductPrice = item.Price.ToString("c", culture),
                    OnPanelClick = () =>
                    {
                        AddOrRemoveProduct(item);
                    }
                };

                flpListProducts.Controls.Add(panel);
            }
        }

        private void AddOrRemoveProduct(Product item)
        {
            if (nudQuantity.Value > 0)
            {
                if (OrderDAO.Instance.InsertProductToOrder(currentOrderID, item.ProductID, (int)nudQuantity.Value) != 1)
                {
                    MessageBox.Show("Lỗi thêm sản phẩm vào đơn hàng");
                    return;
                }
            }
            else
            {
                if (OrderDAO.Instance.RemoveProductFromOrder(currentOrderID, item.ProductID, (int)nudQuantity.Value) != 1)
                {
                    MessageBox.Show("Lỗi xóa sản phẩm khỏi đơn hàng");
                    return;
                }
            }

            LoadOrder();
        }

        private void RemoveOrderDetail(MenuRow item)
        {
            flpOrderDetails.Controls.Clear();
            if (OrderDAO.Instance.RemoveProductFromOrder(currentOrderID, item.ProductID, -999999) != 1)
            {
                MessageBox.Show("Lỗi xóa sản phẩm khỏi đơn hàng");
                return;
            }

            LoadOrder();
        }

        private void cbbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ComboBox cb = sender as ComboBox;

            //if (cb.SelectedItem == null)
            //    return;

            //Category selected = cb.SelectedItem as Category;
            //currentCategoryID = selected.CategoryID;

            //LoadProductList(currentCategoryID, tbProducts.Text);
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            if (OrderDAO.Instance.InitNewOrder() != 1)
            {
                MessageBox.Show("Lỗi tạo đơn hàng mới");
                return;
            }

            currentOrderID = OrderDAO.Instance.GetIdNewestOrder();
            LoadOrder();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            //if (nudQuantity.Value > 0)
            //{
            //    if (OrderDAO.Instance.InsertProductToOrder(currentOrderID, currentProductID, (int)nudQuantity.Value) != 1)
            //    {
            //        MessageBox.Show("Lỗi thêm sản phẩm vào đơn hàng");
            //        return;
            //    }
            //}
            //else
            //{
            //    if (OrderDAO.Instance.RemoveProductFromOrder(currentOrderID, currentProductID, -(int)nudQuantity.Value) != 1)
            //    {
            //        MessageBox.Show("Lỗi xóa sản phẩm khỏi đơn hàng");
            //        return;
            //    }
            //}

            //LoadOrder();
        }

        private void tbProducts_TextChanged(object sender, EventArgs e)
        {
            LoadProductList(tbProducts.Text);
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            currentOrderID = OrderDAO.Instance.GetIdNewestOrder();
            if (MessageBox.Show("Bạn có chắc chắn thanh toán đơn hàng này không?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (OrderDAO.Instance.CheckOut(currentOrderID) != 1)
                {
                    MessageBox.Show("Lỗi thanh toán đơn hàng");
                    return;
                }
                else
                {
                    MessageBox.Show("Thanh toán thành công");
                    //OrderDAO.Instance.InitNewOrder();

                    fCheckout billForm = new fCheckout(currentOrderID);
                    billForm.ShowDialog();
                    currentOrderID = OrderDAO.Instance.GetIdNewestOrder();
                    LoadOrder();
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            //
        }
    }
}

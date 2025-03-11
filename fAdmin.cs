using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using QuanLyTiemTapHoa.DAO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyTiemTapHoa
{
    public partial class fAdmin : Form
    {
        public fAdmin()
        {
            InitializeComponent();

            LoadDataAccounts();
            LoadDataCustomers();
            LoadDataCategories();
            LoadDataProducts();
            LoadDataOrders();
        }

        private void LoadDataAccounts()
        {
            dgvAccounts.DataSource = AccountDAO.Instance.GetDataAllAccounts();
        }

        private void LoadDataCustomers()
        {
            dgvCustomers.DataSource = CustomerDAO.Instance.GetDataAllCustomers();
        }

        private void LoadDataCategories()
        {
            dgvCategories.DataSource = CategorieDAO.Instance.GetDataAllCategories();
        }

        private void LoadDataProducts()
        {
            dgvProducts.DataSource = ProductDAO.Instance.GetDataAllProducts();
        }

        private void LoadDataOrders()
        {
            dgvOrders.DataSource = OrderDAO.Instance.GetDataAllOrders();
        }
    }
}

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

namespace QuanLyTiemTapHoa
{
    public partial class fDashboard : Form
    {
        public fDashboard()
        {
            InitializeComponent();
            LoadUserList();
        }

        void LoadUserList()
        {
            string query = "CALL USP_GetUsersByUsernames(\"'admin', 'johndoe'\")";

            DataProvider provider = new DataProvider();

            dtgvUser.DataSource = provider.ExecuteQuery(query);
        }
    }
}

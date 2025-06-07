using QuanLyTiemTapHoa.DAO;
using System;
using System.Windows.Forms;

namespace QuanLyTiemTapHoa
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        bool Login(string username, string password)
        {
            return AccountDAO.Instance.Login(username, password);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;
            if (Login(username, password))
            {
                fDashboard f = new fDashboard();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản, mật khẩu");
            }
        }
    }
}

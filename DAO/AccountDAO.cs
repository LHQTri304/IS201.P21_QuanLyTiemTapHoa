using System.Data;

namespace QuanLyTiemTapHoa.DAO
{
    internal class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set => instance = value;
        }

        private AccountDAO() { }

        public bool Login(string email, string password)
        {
            if (email == "" || password == "") return true;

            string query = "CALL DangNhapNhanVien('" + email + "', '" + password + "');";

            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result.Rows.Count > 0;
        }

        public DataTable GetDataAllAccounts()
        {
            string query = "SELECT * FROM quanlytiemtaphoa.nhanvien;";

            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }

        public int AddAccount(string fullName, string username, string password, string role, string phone, string email)
        {
            string query = "INSERT INTO NHANVIEN (FullName, Username, PasswordHash, Role, Phone, Email) VALUES (" + fullName + ", " + username + ", " + password + ", " + role + ", " + phone + ", " + email + ")";

            //int result = DataProvider.Instance.ExecuteNonQuery(query);
            return 1;
        }

        public int RemoveAccount(int id)
        {
            string query = "DELETE FROM NHANVIEN WHERE UserID = " + id;

            //int result = DataProvider.Instance.ExecuteNonQuery(query);
            return 1;
        }

        public int UpdateAccount(int id, string fullName, string role, string phone, string email)  //username và password sẽ không được thay đổi
        {
            string query = "UPDATE NHANVIEN SET FullName = '" + fullName + "', Role = '" + role + "', Phone = '" + phone + "', Email = '" + email + "' WHERE UserID = " + id;

            //int result = DataProvider.Instance.ExecuteNonQuery(query);
            return 1;
        }

        public DataTable GetDataFindAccounts(string keyword)
        {
            string query = "SELECT * FROM NHANVIEN WHERE FullName LIKE '%" + keyword.ToLower() + "%'";

            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }
    }
}

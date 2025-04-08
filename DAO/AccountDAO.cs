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

        public bool Login(string username, string password)
        {
            if (username == "" || password == "") return true;

            string query = "CALL GetUserLogin_ByUsernameAndPassword('" + username + "', '" + password + "');";

            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result.Rows.Count > 0;
        }

        public DataTable GetDataAllAccounts()
        {
            string query = "SELECT * FROM quanlytiemtaphoa.users;";

            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }

        public int AddAccount(string fullName, string username, string password, string role, string phone, string email)
        {
            string query = "INSERT INTO Users (FullName, Username, PasswordHash, Role, Phone, Email) VALUES (" + fullName + ", " + username + ", " + password + ", " + role + ", " + phone + ", " + email + ")";

            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result;
        }

        public int RemoveAccount(int id)
        {
            string query = "DELETE FROM Users WHERE UserID = " + id;

            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result;
        }

        public int UpdateAccount(int id, string fullName, string role, string phone, string email)  //username và password sẽ không được thay đổi
        {
            string query = "UPDATE Users SET FullName = '" + fullName + "', Role = '" + role + "', Phone = '" + phone + "', Email = '" + email + "' WHERE UserID = " + id;

            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result;
        }

        public DataTable GetDataFindAccounts(string keyword)
        {
            string query = "SELECT * FROM Users WHERE FullName LIKE '%" + keyword.ToLower() + "%'";

            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }
    }
}

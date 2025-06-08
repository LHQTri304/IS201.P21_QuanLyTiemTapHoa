using Mysqlx.Session;
using MySqlX.XDevAPI.Common;
using System.Data;
using System.Windows.Forms;

namespace QuanLyTiemTapHoa.DAO
{
    internal class CustomerDAO
    {
        private static CustomerDAO instance;

        public static CustomerDAO Instance
        {
            get { if (instance == null) instance = new CustomerDAO(); return instance; }
            private set => instance = value;
        }

        private CustomerDAO() { }


        public DataTable GetDataAllCustomer()
        {
            string query = "SELECT * FROM Customers";

            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }
        public DataTable GetDataAllCustomerOld()
        {
            string query = "SELECT * FROM Customers;";

            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }

        public int AddCustomer(string fullName, string phone, string email)
        {
            string query = "INSERT INTO Customer (FullName, Phone) VALUES ('" + fullName + "', '" + phone + "')";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result;
        }

        public int RemoveCustomer(int id)
        {
            string query = "DELETE FROM Customer WHERE CustomerID = " + id;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result;
        }

        public int UpdateCustomer(int id, string fullName, string phone, string email)
        {
            string query = "UPDATE Customer SET FullName = '" + fullName + "', Phone = '" + phone + "', Email = '" + email + "' WHERE CustomerID = " + id;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result;
        }

        public DataTable GetDataFindCustomer(string keyword)
        {
            string query = "SELECT * FROM Customer WHERE TenKH LIKE '%" + keyword.ToLower() + "%'";

            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }
    }
}

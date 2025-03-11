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


        public DataTable GetDataAllCustomers()
        {
            string query = "SELECT * FROM quanlytiemtaphoa.customers;";

            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }
    }
}

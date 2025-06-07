//using System.Data;
//using System.Windows.Forms;

//namespace QuanLyTiemTapHoa.DAO
//{
//    internal class CustomerDAO
//    {
//        private static CustomerDAO instance;

//        public static CustomerDAO Instance
//        {
//            get { if (instance == null) instance = new CustomerDAO(); return instance; }
//            private set => instance = value;
//        }

//        private CustomerDAO() { }


//        public DataTable GetDataAllKHACHHANG()
//        {
//            string query = "SELECT * FROM quanlytiemtaphoa.khachhang;";

//            DataTable result = DataProvider.Instance.ExecuteQuery(query);
//            return result;
//        }

//        public int AddCustomer(string fullName, string phone, string email)
//        {
//            string query = "INSERT INTO KHACHHANG (FullName, Phone) VALUES ('" + fullName + "', '" + phone + "')";
//            //int result = DataProvider.Instance.ExecuteNonQuery(query);
//            return 1;
//        }

//        public int RemoveCustomer(int id)
//        {
//            string query = "DELETE FROM KHACHHANG WHERE CustomerID = " + id;
//            //int result = DataProvider.Instance.ExecuteNonQuery(query);
//            return 1;
//        }

//        public int UpdateCustomer(int id, string fullName, string phone, string email)
//        {
//            string query = "UPDATE KHACHHANG SET FullName = '" + fullName + "', Phone = '" + phone + "', Email = '" + email + "' WHERE CustomerID = " + id;
//            //int result = DataProvider.Instance.ExecuteNonQuery(query);
//            return 1;
//        }

//        public DataTable GetDataFindKHACHHANG(string keyword)
//        {
//            string query = "SELECT * FROM KHACHHANG WHERE TenKH LIKE '%" + keyword.ToLower() + "%'";

//            DataTable result = DataProvider.Instance.ExecuteQuery(query);
//            return result;
//        }
//    }
//}

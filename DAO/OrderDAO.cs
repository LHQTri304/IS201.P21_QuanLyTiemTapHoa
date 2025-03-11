using System.Data;
using System.Windows.Forms;

namespace QuanLyTiemTapHoa.DAO
{
    internal class OrderDAO
    {
        private static OrderDAO instance;

        public static OrderDAO Instance
        {
            get { if (instance == null) instance = new OrderDAO(); return instance; }
            private set => instance = value;
        }

        private OrderDAO() { }

        public DataTable GetDataAllOrders()
        {
            string query = "SELECT * FROM quanlytiemtaphoa.orders;";

            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }
    }
}

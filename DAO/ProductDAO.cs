using System.Data;
using System.Windows.Forms;

namespace QuanLyTiemTapHoa.DAO
{
    internal class ProductDAO
    {
        private static ProductDAO instance;

        public static ProductDAO Instance
        {
            get { if (instance == null) instance = new ProductDAO(); return instance; }
            private set => instance = value;
        }

        private ProductDAO() { }

        public DataTable GetDataAllProducts()
        {
            string query = "SELECT * FROM quanlytiemtaphoa.products;";

            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }
    }
}

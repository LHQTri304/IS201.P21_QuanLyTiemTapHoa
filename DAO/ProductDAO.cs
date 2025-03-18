using QuanLyTiemTapHoa.DTO;
using System.Collections.Generic;
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

        public List<Product> GetListProducts(int categoryID = -1)
        {
            List<Product> list = new List<Product>();

            string query = "SELECT * FROM quanlytiemtaphoa.products";

            if (categoryID > -1)
            {
                query += " where CategoryID = " + categoryID;
            }

            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in result.Rows)
            {
                Product product = new Product(row);
                list.Add(product);
            }

            return list;
        }
    }
}

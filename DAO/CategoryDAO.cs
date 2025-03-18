using QuanLyTiemTapHoa.DTO;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace QuanLyTiemTapHoa.DAO
{
    internal class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance
        {
            get { if (instance == null) instance = new CategoryDAO(); return instance; }
            private set => instance = value;
        }

        private CategoryDAO() { }


        public DataTable GetDataAllCategories()
        {
            string query = "SELECT * FROM quanlytiemtaphoa.categories;";

            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }

        public List<Category> GetListCategories()
        {
            List <Category> list = new List<Category>();

            string query = "SELECT * FROM quanlytiemtaphoa.categories;";

            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in result.Rows)
            {
                Category category = new Category(row);
                list.Add(category);
            }

            return list;
        }
    }
}

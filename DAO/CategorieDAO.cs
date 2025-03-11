using System.Data;
using System.Windows.Forms;

namespace QuanLyTiemTapHoa.DAO
{
    internal class CategorieDAO
    {
        private static CategorieDAO instance;

        public static CategorieDAO Instance
        {
            get { if (instance == null) instance = new CategorieDAO(); return instance; }
            private set => instance = value;
        }

        private CategorieDAO() { }


        public DataTable GetDataAllCategories()
        {
            string query = "SELECT * FROM quanlytiemtaphoa.categories;";

            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }
    }
}

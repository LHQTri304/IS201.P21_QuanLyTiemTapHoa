using QuanLyTiemTapHoa.DTO;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace QuanLyTiemTapHoa.DAO
{
    internal class KhuyenMaiDAO
    {
        private static KhuyenMaiDAO instance;

        public static KhuyenMaiDAO Instance
        {
            get { if (instance == null) instance = new KhuyenMaiDAO(); return instance; }
            private set => instance = value;
        }

        private KhuyenMaiDAO() { }

        public DataTable GetDataAllKhuyenMais()
        {
            string query = "SELECT * FROM quanlytiemtaphoa.khuyenmai;";

            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }

        public DataTable GetDataFindKhuyenMais(string keyword)
        {
            string query = "SELECT * FROM khuyenmai WHERE MaKM LIKE '%" + keyword.ToLower() + "%'";

            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }
    }
}

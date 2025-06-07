using System.Data;
using System.Text;
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
            string query = "SELECT * FROM quanlytiemtaphoa.hoadon as hd, quanlytiemtaphoa.nhanvien as nv where hd.MaNV = nv.MaNV";

            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }

        public DataTable GetCompletedOrderByDates(string dateStart, string dateEnd)
        {
            string query = "SELECT * FROM quanlytiemtaphoa.hoadon as hd, quanlytiemtaphoa.nhanvien as nv"
                + " where hd.MaNV = nv.MaNV and hd.NgayLap >= '" + dateStart + "' and hd.NgayLap <= '" + dateEnd + "'";

            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }

        public string GetIdNewestOrder()
        {
            string query = "SELECT * FROM quanlytiemtaphoa.hoadon ORDER BY SoHD DESC LIMIT 1;";

            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            return result.Rows.Count > 0 ? result.Rows[0]["SoHD"].ToString() : string.Empty;
        }

        public int InitNewOrder()
        {
            string query = "CALL ThemHoaDonMoi()";

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result;
        }

        public int InsertProductToOrder(string SoHD, string MaSP, int SoLuong)
        {
            if (SoLuong <= 0)
                return -1; // Return -1 if quantity is invalid (less than or equal to zero)

            string query = "CALL ThemSanPhamVaoCTHD('" + SoHD + "', '" + MaSP + "', " + SoLuong + ");";

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result;
        }

        public int RemoveProductFromOrder(string SoHD, string MaSP, int SoLuong)
        {
            if (SoLuong >= 0)
                return -1; // Return -1 if quantity is invalid (more than or equal to zero)

            string query = "CALL ThemSanPhamVaoCTHD('" + SoHD + "', '" + MaSP + "', " + SoLuong + ");";

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result;
        }

        public DataTable GetDataFindOrders(string keyword)
        {
            string query = "SELECT o.OrderID, c.FullName as CustomerName, u.FullName as StaffName, o.OrderDate, o.Status"
                + " FROM quanlytiemtaphoa.hoadon as o, quanlytiemtaphoa.nhanvien as u, quanlytiemtaphoa.khachhang as c"
                + " WHERE o.CustomerID = c.CustomerID and o.UserID = u.UserID AND u.FullName LIKE '%" + keyword.ToLower() + "%'";

            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }

        public int CheckOut(string OrderID)
        {
            //string query = "UPDATE quanlytiemtaphoa.hoadon SET Status = 'completed' WHERE OrderID = '" + OrderID + "';";

            //int result = DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }


        public DataTable GetOrderDetailsForBill(string orderID)
        {
            string query = "SELECT TenSP as ProductName, SoLuong as Quantity, GiaSP as UnitPrice, TongGia as ThanhTien FROM CTHD WHERE SoHD = '" + orderID + "';";

            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            return result;
        }
    }
}

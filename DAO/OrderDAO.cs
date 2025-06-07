using System;
using System.Data;

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
            string query = "SELECT o.OrderID, c.FullName as CustomerName, u.FullName as StaffName, o.OrderDate, o.Status FROM quanlytiemtaphoa.orders as o, quanlytiemtaphoa.users as u, quanlytiemtaphoa.khachhang as c where o.CustomerID = c.CustomerID and o.UserID = u.UserID";

            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }

        public DataTable GetCompletedOrderByDates(string dateStart, string dateEnd)
        {
            string query = "SELECT c.FullName as CustomerName, u.FullName as StaffName, o.OrderDate, o.Status FROM quanlytiemtaphoa.orders as o, quanlytiemtaphoa.users as u, quanlytiemtaphoa.khachhang as c where o.CustomerID = c.CustomerID and o.UserID = u.UserID and o.Status = 'completed' and o.OrderDate >= '" + dateStart + "' and o.OrderDate <= '" + dateEnd + "'";

            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }

        public int GetIdNewestOrder()
        {
            string query = "SELECT * FROM Orders ORDER BY OrderID DESC LIMIT 1;";

            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return Convert.ToInt32(result.Rows[0]["OrderID"]);
        }

        public int InitNewOrder()
        {
            string query = "INSERT INTO Orders (CustomerID, UserID, Status) VALUES (1, NULL, 'pending');";

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result;
        }

        public int RemoveOrder(int id)
        {
            string query = "CALL DeleteOrder(" + id + ")";

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result;
        }

        public int InsertProductToOrder(int OrderID, int ProductID, int Quantity)
        {
            string query = "CALL AddProductInOrder(" + OrderID + ", " + ProductID + ", " + Quantity + ");";

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result;
        }

        public int RemoveProductFromOrder(int OrderID, int ProductID, int Quantity)
        {
            string query = "CALL RemoveProductFromOrder(" + OrderID + ", " + ProductID + ", " + Quantity + ");";

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result;
        }

        public DataTable GetDataFindOrders(string keyword)
        {
            string query = "SELECT o.OrderID, c.FullName as CustomerName, u.FullName as StaffName, o.OrderDate, o.Status FROM quanlytiemtaphoa.orders as o, quanlytiemtaphoa.users as u, quanlytiemtaphoa.khachhang as c where o.CustomerID = c.CustomerID and o.UserID = u.UserID AND u.FullName LIKE '%" + keyword.ToLower() + "%'";

            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }

        public int CheckOut(int OrderID)
        {
            string query = "UPDATE quanlytiemtaphoa.orders SET Status = 'completed' WHERE OrderID = " + OrderID;

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result;
        }


        public DataTable GetOrderDetailsForBill(int orderID)
        {
            // Lấy giá từ bảng Products (p.Price) vì OrderDetails không lưu UnitPrice
            string query = string.Format(
                "SELECT p.ProductName, od.Quantity, p.Price AS UnitPrice, (od.Quantity * p.Price) AS ThanhTien " +
                "FROM OrderDetails od " +
                "JOIN Products p ON od.ProductID = p.ProductID " +
                "WHERE od.OrderID = {0}", orderID);

            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }

    }
}

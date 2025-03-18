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
            string query = "SELECT * FROM quanlytiemtaphoa.orders;";

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
    }
}

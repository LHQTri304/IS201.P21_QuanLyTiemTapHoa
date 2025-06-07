//using QuanLyTiemTapHoa.DTO;
//using System.Collections.Generic;
//using System.Data;

//namespace QuanLyTiemTapHoa.DAO
//{
//    internal class MenuRowDAO
//    {
//        private static MenuRowDAO instance;

//        public static MenuRowDAO Instance
//        {
//            get { if (instance == null) instance = new MenuRowDAO(); return instance; }
//            private set => instance = value;
//        }

//        private MenuRowDAO() { }


//        public List<MenuRow> GetListMenuRow(int orderID)
//        {
//            List<MenuRow> listMenuRow = new List<MenuRow>();

//            string query = "SELECT p.ProductID, p.ProductName, od.Quantity, p.Price, p.Price*od.Quantity as TotalPrice FROM quanlytiemtaphoa.orderdetails as od, quanlytiemtaphoa.orders as o, quanlytiemtaphoa.products as p where od.OrderID = o.OrderID and od.ProductID = p.ProductID and od.OrderID = " + orderID;

//            DataTable result = DataProvider.Instance.ExecuteQuery(query);
//            foreach (DataRow row in result.Rows)
//            {
//                MenuRow menuRow = new MenuRow(row);
//                listMenuRow.Add(menuRow);
//            }

//            return listMenuRow;
//        }
//    }
//}

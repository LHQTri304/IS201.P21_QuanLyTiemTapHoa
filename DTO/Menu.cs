//using System;
//using System.Data;

//namespace QuanLyTiemTapHoa.DTO
//{
//    public class MenuRow
//    {
//        public MenuRow(string productName, int quantity, float price, float totalPrice)
//        {
//            ProductName = productName;
//            Quantity = quantity;
//            Price = price;
//            TotalPrice = totalPrice;
//        }
//        public MenuRow(DataRow row)
//        {
//            ProductID = Convert.ToInt32(row["ProductID"].ToString());
//            ProductName = row["ProductName"].ToString();
//            Quantity = Convert.ToInt32(row["Quantity"].ToString());
//            Price = (float)Convert.ToDouble(row["Price"]);
//            TotalPrice = (float)Convert.ToDouble(row["TotalPrice"]);
//        }

//        private int productID;
//        private string productName;
//        private int quantity;
//        private float price;
//        private float totalPrice;

//        public int ProductID { get => productID; set => productID = value; }
//        public string ProductName { get => productName; set => productName = value; }
//        public int Quantity { get => quantity; set => quantity = value; }
//        public float Price { get => price; set => price = value; }
//        public float TotalPrice { get => totalPrice; set => totalPrice = value; }
//    }
//}

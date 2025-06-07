using System;
using System.Data;

namespace QuanLyTiemTapHoa.DTO
{
    public class MenuRow
    {
        public MenuRow(string productName, int quantity, float price, float totalPrice)
        {
            ProductName = productName;
            Quantity = quantity;
            Price = price;
            TotalPrice = totalPrice;
        }
        public MenuRow(DataRow row)
        {
            ProductID = row["MaSP"].ToString();
            ProductName = row["TenSP"].ToString();
            Quantity = Convert.ToInt32(row["SoLuong"].ToString());
            Price = (float)Convert.ToDouble(row["GiaSP"]);
            TotalPrice = (float)Convert.ToDouble(row["TongGia"]);
        }

        private string productID;
        private string productName;
        private int quantity;
        private float price;
        private float totalPrice;

        public string ProductID { get => productID; set => productID = value; }
        public string ProductName { get => productName; set => productName = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public float Price { get => price; set => price = value; }
        public float TotalPrice { get => totalPrice; set => totalPrice = value; }
    }
}

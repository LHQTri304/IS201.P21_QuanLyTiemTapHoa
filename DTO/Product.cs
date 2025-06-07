using System;
using System.Data;

namespace QuanLyTiemTapHoa.DTO
{
    public class Product
    {
        public Product(string id, string name, float price)
        {
            ProductID = id;
            ProductName = name;
            Price = price;
        }
        public Product(DataRow row)
        {
            ProductID = row["MaSP"].ToString();
            ProductName = row["TenSP"].ToString();
            Price = (float)Convert.ToDouble(row["GiaSP"].ToString());
        }

        private string productID;
        private string productName;
        private float price;

        public string ProductID { get => productID; set => productID = value; }
        public string ProductName { get => productName; set => productName = value; }
        public float Price { get => price; set => price = value; }
    }
}

using System;
using System.Data;

namespace QuanLyTiemTapHoa.DTO
{
    public class Product
    {
        public Product(int id, string name, int categoryID, float price, int stockQuantity)
        {
            ProductID = id;
            ProductName = name;
            CategoryID = categoryID;
            Price = price;
            StockQuantity = stockQuantity;
        }
        public Product(DataRow row)
        {
            ProductID = Convert.ToInt32(row["ProductID"].ToString());
            ProductName = row["ProductName"].ToString();
            CategoryID = Convert.ToInt32(row["CategoryID"].ToString());
            Price = (float)Convert.ToDouble(row["Price"].ToString());
            StockQuantity = Convert.ToInt32(row["StockQuantity"].ToString());
        }

        private int productID;
        private string productName;
        private int categoryID;
        private float price;
        private int stockQuantity;

        public int ProductID { get => productID; set => productID = value; }
        public string ProductName { get => productName; set => productName = value; }
        public int CategoryID { get => categoryID; set => categoryID = value; }
        public float Price { get => price; set => price = value; }
        public int StockQuantity { get => stockQuantity; set => stockQuantity = value; }
    }
}

//using System;
//using System.Data;

//namespace QuanLyTiemTapHoa.DTO
//{
//    public class Category
//    {
//        public Category(int id, string name)
//        {
//            CategoryID = id;
//            CategoryName = name;
//        }
//        public Category(DataRow row)
//        {
//            CategoryID = Convert.ToInt32(row["CategoryID"].ToString());
//            CategoryName = row["CategoryName"].ToString();
//        }
//        private int categoryID;
//        private string categoryName;

//        public int CategoryID { get => categoryID; set => categoryID = value; }
//        public string CategoryName { get => categoryName; set => categoryName = value; }
//    }
//}

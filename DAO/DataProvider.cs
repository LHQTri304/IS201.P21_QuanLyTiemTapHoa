//using MySql.Data.MySqlClient;
//using System;
//using System.Data;

//namespace QuanLyTiemTapHoa.DAO
//{
//    internal class DataProvider
//    {
//        private static DataProvider instance;
//        private string connetionString = "server=localhost;database=quanlytiemtaphoa;uid=root;pwd=Qtmysql3045!;";

//        public static DataProvider Instance
//        {
//            get
//            {
//                if (instance == null)
//                {
//                    instance = new DataProvider();
//                }
//                return instance;
//            }
//            private set => instance = value;
//        }

//        private DataProvider() { }

//        public DataTable ExecuteQuery(string query)
//        {
//            DataTable data = new DataTable();
//            using (MySqlConnection cnn = new MySqlConnection())
//            {
//                cnn.ConnectionString = connetionString;
//                try
//                {
//                    cnn.Open();
//                    Console.WriteLine("Connection Open ! ");

//                    MySqlCommand cmd = new MySqlCommand(query, cnn);

//                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

//                    adapter.Fill(data);

//                    cnn.Close();

//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine("Can not open connection ! ");
//                }
//            }
//            return data;
//        }

//        public int ExecuteNonQuery(string query)
//        {
//            int data = 0;
//            using (MySqlConnection cnn = new MySqlConnection())
//            {
//                cnn.ConnectionString = connetionString;
//                try
//                {
//                    cnn.Open();
//                    Console.WriteLine("Connection Open ! ");

//                    MySqlCommand cmd = new MySqlCommand(query, cnn);

//                    data = cmd.ExecuteNonQuery();

//                    cnn.Close();

//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine("Can not open connection ! ");
//                }
//            }
//            return data;
//        }

//        public object ExecuteScalar(string query)
//        {
//            object data = 0;
//            using (MySqlConnection cnn = new MySqlConnection())
//            {
//                cnn.ConnectionString = connetionString;
//                try
//                {
//                    cnn.Open();
//                    Console.WriteLine("Connection Open ! ");

//                    MySqlCommand cmd = new MySqlCommand(query, cnn);

//                    data = cmd.ExecuteScalar();

//                    cnn.Close();

//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine("Can not open connection ! ");
//                }
//            }
//            return data;
//        }
//    }
//}

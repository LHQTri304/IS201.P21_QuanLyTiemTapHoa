using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTiemTapHoa.DAO
{
    internal class DataProvider
    {
        string connetionString = "server=localhost;database=quanlytiemtaphoa;uid=root;pwd=Qtmysql3045!;";

        public DataTable ExecuteQuery(string query)
        {
            DataTable data = new DataTable();
            using (MySqlConnection cnn = new MySqlConnection())
            {
                cnn.ConnectionString = connetionString;
                try
                {
                    cnn.Open();
                    Console.WriteLine("Connection Open ! ");

                    MySqlCommand cmd = new MySqlCommand(query, cnn);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                    adapter.Fill(data);

                    cnn.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Can not open connection ! ");
                }
            }
            return data;
        }

        public int ExecuteNonQuery(string query)
        {
            int data = 0;
            using (MySqlConnection cnn = new MySqlConnection())
            {
                cnn.ConnectionString = connetionString;
                try
                {
                    cnn.Open();
                    Console.WriteLine("Connection Open ! ");

                    MySqlCommand cmd = new MySqlCommand(query, cnn);

                    data = cmd.ExecuteNonQuery();                    

                    cnn.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Can not open connection ! ");
                }
            }
            return data;
        }

        public object ExecuteScalar(string query)
        {
            object data = 0;
            using (MySqlConnection cnn = new MySqlConnection())
            {
                cnn.ConnectionString = connetionString;
                try
                {
                    cnn.Open();
                    Console.WriteLine("Connection Open ! ");

                    MySqlCommand cmd = new MySqlCommand(query, cnn);

                    data = cmd.ExecuteScalar();

                    cnn.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Can not open connection ! ");
                }
            }
            return data;
        }
    }
}

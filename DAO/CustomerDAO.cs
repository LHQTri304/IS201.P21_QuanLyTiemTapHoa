﻿using System.Data;
using System.Windows.Forms;

namespace QuanLyTiemTapHoa.DAO
{
    internal class CustomerDAO
    {
        private static CustomerDAO instance;

        public static CustomerDAO Instance
        {
            get { if (instance == null) instance = new CustomerDAO(); return instance; }
            private set => instance = value;
        }

        private CustomerDAO() { }


        public DataTable GetDataAllCustomers()
        {
            string query = "SELECT * FROM quanlytiemtaphoa.customers;";

            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }

        public int AddCustomer(string fullName, string phone, string email)
        {
            string query = "INSERT INTO Customers (FullName, Phone, Email) VALUES ('" + fullName + "', '" + phone + "', '" + email + "')";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result;
        }

        public int RemoveCustomer(int id)
        {
            string query = "DELETE FROM Customers WHERE CustomerID = " + id;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result;
        }

        public int UpdateCustomer(int id, string fullName, string phone, string email)
        {
            string query = "UPDATE Customers SET FullName = '" + fullName + "', Phone = '" + phone + "', Email = '" + email + "' WHERE CustomerID = " + id;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result;
        }

        public DataTable GetDataFindCustomers(string keyword)
        {
            string query = "SELECT * FROM Customers WHERE FullName LIKE '%" + keyword.ToLower() + "%'";

            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }
    }
}

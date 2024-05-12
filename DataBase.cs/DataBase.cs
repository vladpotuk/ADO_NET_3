using System;
using System.Data;
using System.Data.SqlClient;

namespace ADO_NET_3
{
    public static class DataBase
    {
        private static string connectionString = "Data Source=\"10.0.0.40,1604\";Initial Catalog=warehouse;User ID=slimt;Password=1604;Encrypt=True;TrustServerCertificate=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public static bool TestConnection()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static DataTable GetAllProducts()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT * FROM Products";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dt);
            }
            return dt;
        }

        public static DataTable GetAllProductsInfo()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT * FROM Products";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dt);
            }
            return dt;
        }

        public static DataTable GetAllProductTypes()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT DISTINCT ProductType FROM Products";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dt);
            }
            return dt;
        }

        public static DataTable GetAllSalesManagers()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT DISTINCT SalesManager FROM Sales";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dt);
            }
            return dt;
        }

        public static DataTable GetProductsMaxQuantity()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT TOP 1 * FROM Products ORDER BY Quantity DESC";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dt);
            }
            return dt;
        }

        public static DataTable GetProductsMinQuantity()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT TOP 1 * FROM Products ORDER BY Quantity";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dt);
            }
            return dt;
        }

        public static DataTable GetProductsMinCost()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT TOP 1 * FROM Products ORDER BY CostPrice";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dt);
            }
            return dt;
        }

        public static DataTable GetProductsMaxCost()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT TOP 1 * FROM Products ORDER BY CostPrice DESC";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dt);
            }
            return dt;
        }

        public static DataTable GetProductsByType(string productType)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string query = $"SELECT * FROM Products WHERE ProductType = '{productType}'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dt);
            }
            return dt;
        }

        public static DataTable GetProductsBySalesManager(string managerName)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string query = $"SELECT * FROM Sales WHERE SalesManager = '{managerName}'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dt);
            }
            return dt;
        }

        public static DataTable GetProductsByCustomerCompany(string companyName)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string query = $"SELECT * FROM Sales WHERE CustomerCompany = '{companyName}'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dt);
            }
            return dt;
        }

        public static DataTable GetRecentSalesInfo()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT TOP 1 * FROM Sales ORDER BY SaleDate DESC";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dt);
            }
            return dt;
        }

        public static DataTable GetAverageQuantityByProductType()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT ProductType, AVG(Quantity) AS AverageQuantity FROM Products GROUP BY ProductType";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dt);
            }
            return dt;
        }
    }
}

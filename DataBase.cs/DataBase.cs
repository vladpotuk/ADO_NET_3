using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DBManager
    {
        public string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public DBManager() { }

        public void InsertStationery(string name, string type, int quantity, decimal costPerUnit)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Stationery (Name, Type, Quantity, Cost_per_Unit) VALUES (@name, @type, @quantity, @costPerUnit)", connection);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@costPerUnit", costPerUnit);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertStationeryType(string type)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Stationery (Type) VALUES (@type)", connection);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertSalesManager(string manager)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Sales (Sales_Manager) VALUES (@manager)", connection);
                    cmd.Parameters.AddWithValue("@manager", manager);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertBuyerCompany(string company)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Sales (Buyer_Company) VALUES (@company)", connection);
                    cmd.Parameters.AddWithValue("@company", company);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateStationery(int id, string name, string type, int quantity, decimal costPerUnit)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Stationery SET Name = @name, Type = @type, Quantity = @quantity, Cost_per_Unit = @costPerUnit WHERE Stationery_ID = @id", connection);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@costPerUnit", costPerUnit);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateBuyerCompany(string oldCompany, string newCompany)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Sales SET Buyer_Company = @newCompany WHERE Buyer_Company = @oldCompany", connection);
                    cmd.Parameters.AddWithValue("@oldCompany", oldCompany);
                    cmd.Parameters.AddWithValue("@newCompany", newCompany);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateSalesManager(string oldManager, string newManager)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Sales SET Sales_Manager = @newManager WHERE Sales_Manager = @oldManager", connection);
                    cmd.Parameters.AddWithValue("@oldManager", oldManager);
                    cmd.Parameters.AddWithValue("@newManager", newManager);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateStationeryType(string oldType, string newType)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Stationery SET Type = @newType WHERE Type = @oldType", connection);
                    cmd.Parameters.AddWithValue("@oldType", oldType);
                    cmd.Parameters.AddWithValue("@newType", newType);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteStationery(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Stationery WHERE Stationery_ID = @id", connection);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteSalesManager(string manager)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Sales WHERE Sales_Manager = @manager", connection);
                    cmd.Parameters.AddWithValue("@manager", manager);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteStationeryType(string type)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Stationery WHERE Type = @type", connection);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteBuyerCompany(string company)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Sales WHERE Buyer_Company = @company", connection);
                    cmd.Parameters.AddWithValue("@company", company);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GetManagerWithMostSales()
        {
            string? manager = "";
            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT TOP 1 Sales_Manager FROM Sales GROUP BY Sales_Manager ORDER BY SUM(Quantity_Sold) DESC", connection);
                    manager = cmd.ExecuteScalar()?.ToString();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return manager;
        }

        public string GetMostProfitableSalesManager()
        {
            string? manager = "";
            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT TOP 1 Sales_Manager FROM Sales GROUP BY Sales_Manager ORDER BY SUM(Quantity_Sold * Price_Per_Unit) DESC", connection);
                    manager = cmd.ExecuteScalar()?.ToString();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return manager;
        }

        public string GetMostProfitableSalesManagerForPeriod(DateTime startDate, DateTime endDate)
        {
            string? manager = "";
            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT TOP 1 Sales_Manager FROM Sales WHERE Sale_Date BETWEEN @startDate AND @endDate GROUP BY Sales_Manager ORDER BY SUM(Quantity_Sold * Price_Per_Unit) DESC", connection);
                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", endDate);
                    manager = cmd.ExecuteScalar()?.ToString();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return manager;
        }

        public string GetFirmWithLargestPurchase()
        {
            string? firm = "";
            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT TOP 1 Buyer_Company FROM Sales GROUP BY Buyer_Company ORDER BY SUM(Quantity_Sold * Price_Per_Unit) DESC", connection);
                    firm = cmd.ExecuteScalar()?.ToString();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return firm;
        }

        public string GetTypeWithMostSales()
        {
            string? type = "";
            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT TOP 1 Type FROM Stationery s JOIN Sales sa ON s.Stationery_ID = sa.Stationery_ID GROUP BY Type ORDER BY SUM(sa.Quantity_Sold) DESC", connection);
                    type = cmd.ExecuteScalar()?.ToString();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return type;
        }

        public string GetMostProfitableType()
        {
            string? type = "";
            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT TOP 1 Type FROM Stationery s JOIN Sales sa ON s.Stationery_ID = sa.Stationery_ID GROUP BY Type ORDER BY SUM(sa.Quantity_Sold * sa.Price_Per_Unit) DESC", connection);
                    type = cmd.ExecuteScalar()?.ToString();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return type;
        }

        public string GetMostPopularStationery()
        {
            string? stationery = "";
            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT TOP 1 Name FROM Stationery s JOIN Sales sa ON s.Stationery_ID = sa.Stationery_ID GROUP BY Name ORDER BY SUM(sa.Quantity_Sold) DESC", connection);
                    stationery = cmd.ExecuteScalar()?.ToString();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return stationery;
        }

        public List<string> GetUnsoldStationery(int days)
        {
            List<string> unsoldStationery = new List<string>();
            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT Name FROM Stationery WHERE Stationery_ID NOT IN (SELECT DISTINCT Stationery_ID FROM Sales WHERE DATEDIFF(day, Sale_Date, GETDATE()) <= @days)", connection);
                    cmd.Parameters.AddWithValue("@days", days);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        unsoldStationery.Add(reader["Name"].ToString());
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return unsoldStationery;
        }
    }
}

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

            public static void InsertProduct(string productName, string productType, int quantity, decimal costPrice)
            {
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO Products (ProductName, ProductType, Quantity, CostPrice) VALUES (@ProductName, @ProductType, @Quantity, @CostPrice)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ProductName", productName);
                    command.Parameters.AddWithValue("@ProductType", productType);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@CostPrice", costPrice);
                    command.ExecuteNonQuery();
                }
            }

            public static void InsertProductType(string productType)
            {
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO ProductTypes (ProductType) VALUES (@ProductType)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ProductType", productType);
                    command.ExecuteNonQuery();
                }
            }

            public static void InsertSalesManager(string managerName)
            {
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO SalesManagers (ManagerName) VALUES (@ManagerName)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ManagerName", managerName);
                    command.ExecuteNonQuery();
                }
            }

            public static void InsertCustomerCompany(string companyName)
            {
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO CustomerCompanies (CompanyName) VALUES (@CompanyName)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CompanyName", companyName);
                    command.ExecuteNonQuery();
                }
            }
            public static void UpdateProduct(int productId, string productName, string productType, int quantity, decimal costPrice)
            {
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE Products SET ProductName = @ProductName, ProductType = @ProductType, Quantity = @Quantity, CostPrice = @CostPrice WHERE ProductId = @ProductId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ProductId", productId);
                    command.Parameters.AddWithValue("@ProductName", productName);
                    command.Parameters.AddWithValue("@ProductType", productType);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@CostPrice", costPrice);
                    command.ExecuteNonQuery();
                }
            }

            public static void UpdateCustomerCompany(int companyId, string companyName)
            {
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE CustomerCompanies SET CompanyName = @CompanyName WHERE CompanyId = @CompanyId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CompanyId", companyId);
                    command.Parameters.AddWithValue("@CompanyName", companyName);
                    command.ExecuteNonQuery();
                }
            }

            public static void UpdateSalesManager(int managerId, string managerName)
            {
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE SalesManagers SET ManagerName = @ManagerName WHERE ManagerId = @ManagerId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ManagerId", managerId);
                    command.Parameters.AddWithValue("@ManagerName", managerName);
                    command.ExecuteNonQuery();
                }
            }

            public static void UpdateProductType(int typeId, string productType)
            {
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE ProductTypes SET ProductType = @ProductType WHERE TypeId = @TypeId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TypeId", typeId);
                    command.Parameters.AddWithValue("@ProductType", productType);
                    command.ExecuteNonQuery();
                }
            }
            public static void DeleteProduct(int productId)
            {
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO ArchivedProducts SELECT * FROM Products WHERE ProductId = @ProductId; DELETE FROM Products WHERE ProductId = @ProductId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ProductId", productId);
                    command.ExecuteNonQuery();
                }
            }

            public static void DeleteSalesManager(int managerId)
            {
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO ArchivedSalesManagers SELECT * FROM SalesManagers WHERE ManagerId = @ManagerId; DELETE FROM SalesManagers WHERE ManagerId = @ManagerId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ManagerId", managerId);
                    command.ExecuteNonQuery();
                }
            }

            public static void DeleteProductType(int typeId)
            {
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO ArchivedProductTypes SELECT * FROM ProductTypes WHERE TypeId = @TypeId; DELETE FROM ProductTypes WHERE TypeId = @TypeId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TypeId", typeId);
                    command.ExecuteNonQuery();
                }
        }

            public static void DeleteCustomerCompany(int companyId)
            {
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO ArchivedCustomerCompanies SELECT * FROM CustomerCompanies WHERE CompanyId = @CompanyId; DELETE FROM CustomerCompanies WHERE CompanyId = @CompanyId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CompanyId", companyId);
                    command.ExecuteNonQuery();
                }
            }
            public static DataTable GetManagerWithMostSalesByQuantity()
            {
                DataTable dt = new DataTable();
                using (SqlConnection connection = GetConnection())
                {
                    string query = "SELECT TOP 1 SalesManager, SUM(Quantity) AS TotalSales FROM Sales GROUP BY SalesManager ORDER BY TotalSales DESC";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(dt);
                }
                return dt;
            }

            public static DataTable GetManagerWithHighestProfit()
            {
                DataTable dt = new DataTable();
                using (SqlConnection connection = GetConnection())
                {
                    string query = "SELECT TOP 1 SalesManager, SUM(Quantity * PricePerUnit) AS TotalProfit FROM Sales GROUP BY SalesManager ORDER BY TotalProfit DESC";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(dt);
                }
                return dt;
            }

            public static DataTable GetManagerWithHighestProfitInTimePeriod(DateTime startDate, DateTime endDate)
            {
                DataTable dt = new DataTable();
                using (SqlConnection connection = GetConnection())
                {
                    string query = $"SELECT TOP 1 SalesManager, SUM(Quantity * PricePerUnit) AS TotalProfit FROM Sales WHERE SaleDate >= '{startDate.ToString("yyyy-MM-dd")}' AND SaleDate <= '{endDate.ToString("yyyy-MM-dd")}' GROUP BY SalesManager ORDER BY TotalProfit DESC";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(dt);
                }
                return dt;
            }

            public static DataTable GetTopPurchasingCustomerCompany()
            {
                DataTable dt = new DataTable();
                using (SqlConnection connection = GetConnection())
                {
                    string query = "SELECT TOP 1 CustomerCompany, SUM(TotalPrice) AS TotalPurchaseAmount FROM Sales GROUP BY CustomerCompany ORDER BY TotalPurchaseAmount DESC";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(dt);
                }
                return dt;
            }

            public static DataTable GetBestSellingProductType()
            {
                DataTable dt = new DataTable();
                using (SqlConnection connection = GetConnection())
                {
                    string query = "SELECT TOP 1 ProductType, SUM(Quantity) AS TotalSales FROM Sales GROUP BY ProductType ORDER BY TotalSales DESC";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(dt);
                }
                return dt;
            }

            public static DataTable GetMostProfitableProductType()
            {
                DataTable dt = new DataTable();
                using (SqlConnection connection = GetConnection())
                {
                    string query = "SELECT TOP 1 Products.ProductType, SUM(Sales.Quantity * Sales.PricePerUnit) AS TotalProfit FROM Sales INNER JOIN Products ON Sales.ProductId = Products.ProductId GROUP BY Products.ProductType ORDER BY TotalProfit DESC";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(dt);
                }
                return dt;
            }

            public static DataTable GetMostPopularProducts()
            {
                DataTable dt = new DataTable();
                using (SqlConnection connection = GetConnection())
                {
                    string query = "SELECT TOP 1 ProductName, SUM(Quantity) AS TotalSales FROM Sales INNER JOIN Products ON Sales.ProductId = Products.ProductId GROUP BY ProductName ORDER BY TotalSales DESC";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(dt);
                }
                return dt;
            }

            public static DataTable GetUnsoldProductsForDays(int numberOfDays)
            {
                DataTable dt = new DataTable();
                using (SqlConnection connection = GetConnection())
                {
                    string query = $"SELECT ProductName FROM Products WHERE NOT EXISTS (SELECT * FROM Sales WHERE Products.ProductId = Sales.ProductId AND SaleDate >= DATEADD(day, -{numberOfDays}, GETDATE()))";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(dt);
                }
                return dt;
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
                    string query = "SELECT DISTINCT ManagerName FROM SalesManagers";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(dt);
                }
                return dt;
            }

            public static DataTable GetAllCustomerCompanies()
            {
                DataTable dt = new DataTable();
                using (SqlConnection connection = GetConnection())
                {
                    string query = "SELECT DISTINCT CompanyName FROM CustomerCompanies";
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

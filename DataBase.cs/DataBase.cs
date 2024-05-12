using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Test
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public Test(int id, string text)
        {
            Id = id;
            Text = text;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Text: {Text}";
        }
    }

    public class DBManager
    {
        public string ConnectionString = "Data Source=10.0.0.50,1413;Initial Catalog=ado_test;User ID=strof;Password=1604;Encrypt=True;Trust Server Certificate=True";

        public DBManager()
        {

        }

        public List<Test> SelectFromDb()
        {
            try
            {
                List<Test> result = new List<Test>();
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM test", connection);
                    var sqlReader = cmd.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        result.Add(new Test(sqlReader.GetInt32(0), sqlReader.GetString(1)));
                    }
                }
                return result;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertToDb(Test test)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO test (text) VALUES (@text)", connection);
                    cmd.Parameters.AddWithValue("@text", test.Text);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateToDb(Test test)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE test SET text = @text WHERE id = @id", connection);
                    cmd.Parameters.AddWithValue("@text", test.Text);
                    cmd.Parameters.AddWithValue("@id", test.Id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void OpenConnection()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();
                   
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CloseConnection()
        {
            try
            {
 
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable GetAllStationery()
        {
            try
            {
                DataTable result = new DataTable();
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Stationery", connection);
                    adapter.Fill(result);
                }
                return result;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<string> GetAllStationeryTypes()
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllSalesManagers()
        {
            throw new NotImplementedException();
        }

        public DataTable GetStationeryWithMaxUnits()
        {
            throw new NotImplementedException();
        }

        public DataTable GetStationeryWithMinUnits()
        {
            throw new NotImplementedException();
        }

        public DataTable GetStationeryWithMinCost()
        {
            throw new NotImplementedException();
        }

        public DataTable GetStationeryWithMaxCost()
        {
            throw new NotImplementedException();
        }

        public DataTable GetStationeryByType(string selectedType)
        {
            throw new NotImplementedException();
        }

        public DataTable GetStationeryByManager(string selectedManager)
        {
            throw new NotImplementedException();
        }

        public DataTable GetStationeryByBuyer(string selectedBuyer)
        {
            throw new NotImplementedException();
        }

        public DataRow GetRecentSale()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, double> GetAverageItemsPerType()
        {
            throw new NotImplementedException();
        }
    }
}
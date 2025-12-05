using System;
using System.Data;
using Microsoft.Data.SqlClient;
using UsuariosEXMN.Models;
using ApplicationLogic;


namespace UsuariosEXMN.DataAccess
{
    public class EmployeesRepository
    {
        private readonly string _connectionString;

        public EmployeesRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // INSERT
        public void Insert(Employee emp)
        {
            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            string sql = @"
                INSERT INTO Employees (LastName, FirstName, Title, Address, City, Region, 
                                       PostalCode, Country, HomePhone, Extension)
                VALUES (@LastName, @FirstName, @Title, @Address, @City, @Region, 
                        @PostalCode, @Country, @HomePhone, @Extension)";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@LastName", emp.LastName);
            cmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
            cmd.Parameters.AddWithValue("@Title", emp.Title ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Address", emp.Address ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@City", emp.City ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Region", emp.Region ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@PostalCode", emp.PostalCode ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Country", emp.Country ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@HomePhone", emp.HomePhone ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Extension", emp.Extension ?? (object)DBNull.Value);

            cmd.ExecuteNonQuery();
        }

        // FIND
        public Employee? Find(int id)
        {
            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            string sql = "SELECT * FROM Employees WHERE EmployeeID = @EmployeeID";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@EmployeeID", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Employee
                {
                    EmployeeID = (int)reader["EmployeeID"],
                    LastName = reader["LastName"].ToString(),
                    FirstName = reader["FirstName"].ToString(),
                    Title = reader["Title"].ToString(),
                    Address = reader["Address"].ToString(),
                    City = reader["City"].ToString(),
                    Region = reader["Region"].ToString(),
                    PostalCode = reader["PostalCode"].ToString(),
                    Country = reader["Country"].ToString(),
                    HomePhone = reader["HomePhone"].ToString(),
                    Extension = reader["Extension"].ToString()
                };
            }

            return null;
        }

        // UPDATE
        public void Update(Employee emp)
        {
            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            string sql = @"
                UPDATE Employees SET
                    LastName=@LastName,
                    FirstName=@FirstName,
                    Title=@Title,
                    Address=@Address,
                    City=@City,
                    Region=@Region,
                    PostalCode=@PostalCode,
                    Country=@Country,
                    HomePhone=@HomePhone,
                    Extension=@Extension
                WHERE EmployeeID=@EmployeeID";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@LastName", emp.LastName);
            cmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
            cmd.Parameters.AddWithValue("@Title", emp.Title ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Address", emp.Address ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@City", emp.City ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Region", emp.Region ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@PostalCode", emp.PostalCode ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Country", emp.Country ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@HomePhone", emp.HomePhone ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Extension", emp.Extension ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@EmployeeID", emp.EmployeeID);

            cmd.ExecuteNonQuery();
        }

        // DELETE
        public void Delete(int id)
        {
            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            string sql = "DELETE FROM Employees WHERE EmployeeID=@EmployeeID";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@EmployeeID", id);

            cmd.ExecuteNonQuery();
        }
    }
}

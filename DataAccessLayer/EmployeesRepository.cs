using Shared;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    class EmployeesRepository
    {
        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM EMPLOYEES";
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    Employee employee = new Employee
                    {
                        Id = sqlDataReader.GetInt32(0),
                        FirstName = sqlDataReader.GetString(1),
                        LastName = sqlDataReader.GetString(2),
                        Password = sqlDataReader.GetString(3),
                        
                    };
                    employees.Add(employee);
                }
                return employees;
            }

        }
        public int DeleteEmplyee(int emplyeeid)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = "DELETE FROM Employees WHERE EmployeeID = @EmployeeID";
                    sqlCommand.Parameters.AddWithValue("@EmployeeID", emplyeeid);

                    return sqlCommand.ExecuteNonQuery();
                }
            }
        }
        public int InsertEmployee(Employee employee)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = "INSERT INTO Employees VALUES (@FirstName,@LastName,@Password)";
                    sqlCommand.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    sqlCommand.Parameters.AddWithValue("@LastName", employee.LastName);
                    sqlCommand.Parameters.AddWithValue("@Password", employee.Password);        
                    return sqlCommand.ExecuteNonQuery();
                }
            }
        }
        public int UpdateEmployee(Employee employee)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                string command = "UPDATE Employees SET FirstName=@FirstName, LastName =@LastName, username=@Username, Password=@Password WHERE Id=@Id";

                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@FirstName", employee.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", employee.LastName);             
                sqlCommand.Parameters.AddWithValue("@Username", employee.UserName);
                sqlCommand.Parameters.AddWithValue("@Password", employee.Password);
                sqlConnection.Open();

                return sqlCommand.ExecuteNonQuery();

            }
        }
    }
}

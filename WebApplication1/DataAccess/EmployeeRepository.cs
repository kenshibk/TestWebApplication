using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient; // ADO.NETのための名前空間
using WebApplication1.Models; // モデルクラスのために必要

namespace WebApplication1.DataAccess // プロジェクト名やフォルダ構成に合わせて変更してください
{
    public class EmployeeRepository
    {
        private readonly string _connectionString;

        // コンストラクタで接続文字列を受け取る
        public EmployeeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Departments テーブルのデータを全て取得するメソッド
        public List<Department> GetAllDepartments()
        {
            List<Department> departments = new List<Department>();
            string sql = "SELECT DepartmentID, DepartmentName FROM Departments ORDER BY DepartmentID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            departments.Add(new Department
                            {
                                DepartmentID = reader.GetInt32(reader.GetOrdinal("DepartmentID")), // int型で取得
                                DepartmentName = reader["DepartmentName"].ToString()
                            });
                        }
                    }
                }
            }
            return departments;
        }

        // Employees テーブルのデータを全て取得するメソッド
        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            string sql = "SELECT EmployeeID, DepartmentID, EmployeeName, HireDate FROM Employees ORDER BY EmployeeID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employees.Add(new Employee
                            {
                                EmployeeID = reader.GetInt32(reader.GetOrdinal("EmployeeID")), // int型で取得
                                // DepartmentIDはNullの可能性を考慮 (実際はFKなのでNullにはならないがNullable型で定義したため)
                                DepartmentID = reader.IsDBNull(reader.GetOrdinal("DepartmentID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("DepartmentID")),
                                EmployeeName = reader["EmployeeName"].ToString(),
                                // HireDateもNullの可能性を考慮
                                HireDate = reader.IsDBNull(reader.GetOrdinal("HireDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("HireDate"))
                            });
                        }
                    }
                }
            }
            return employees;
        }

        // Salaries テーブルのデータを全て取得するメソッド
        public List<Salary> GetAllSalaries()
        {
            List<Salary> salaries = new List<Salary>();
            string sql = "SELECT SalaryID, EmployeeID, Amount, EffectiveDate FROM Salaries ORDER BY SalaryID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            salaries.Add(new Salary
                            {
                                SalaryID = reader.GetInt32(reader.GetOrdinal("SalaryID")), // int型で取得
                                // EmployeeIDはNullの可能性を考慮
                                EmployeeID = reader.IsDBNull(reader.GetOrdinal("EmployeeID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("EmployeeID")),
                                Amount = reader.GetDecimal(reader.GetOrdinal("Amount")), // decimal型で取得
                                EffectiveDate = reader.GetDateTime(reader.GetOrdinal("EffectiveDate")) // DateTime型で取得
                            });
                        }
                    }
                }
            }
            return salaries;
        }
    }
}
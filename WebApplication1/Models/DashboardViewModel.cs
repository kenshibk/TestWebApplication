using System.Collections.Generic;

namespace WebApplication1.Models
{
    // 複数のテーブルのデータを一つの画面に表示するためのViewModel
    public class DashboardViewModel
    {
        // 各テーブルのデータを格納するリスト
        public List<Department> Departments { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Salary> Salaries { get; set; }


    }
}

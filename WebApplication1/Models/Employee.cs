namespace WebApplication1.Models
{
    // Employees テーブルに対応するモデル
    public class Employee
    {
        public int EmployeeID { get; set; }
        public int? DepartmentID { get; set; } // 外部キーなのでNull許容にする場合が多い
        public string EmployeeName { get; set; }
        public DateTime? HireDate { get; set; } // Null許容にする場合が多い
    }
}

namespace WebApplication1.Models
{
    // Salaries テーブルに対応するモデル
    public class Salary
    {
        public int SalaryID { get; set; }
        public int? EmployeeID { get; set; } // 外部キーなのでNull許容にする場合が多い
        public decimal Amount { get; set; }
        public DateTime EffectiveDate { get; set; }
    }
}

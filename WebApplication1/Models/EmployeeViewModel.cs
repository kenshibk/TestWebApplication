namespace WebApplication1.Models
{
    public class EmployeeViewModel
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public DateOnly? HireDate { get; set; }
        public decimal Salary { get; set; }
        public DateOnly? EffectiveDate { get; set; }
    }
}
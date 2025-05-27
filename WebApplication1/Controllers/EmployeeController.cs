using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DBModels.CO;
using WebApplication1.Models;
using System.Linq;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly COContext _context;

        public EmployeeController(COContext context)
        {
            _context = context;
        }

        // 一覧表示
        public IActionResult Index()
        {
            var list = _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Salaries)
                .Select(e => new EmployeeViewModel
                {
                    DepartmentID = e.DepartmentID ?? 0,
                    DepartmentName = e.Department.DepartmentName,
                    EmployeeID = e.EmployeeID,
                    EmployeeName = e.EmployeeName,
                    HireDate = e.HireDate,
                    Salary = e.Salaries != null ? e.Salaries.Amount : 0, 
                    EffectiveDate = e.Salaries != null ? e.Salaries.EffectiveDate : null
                }).ToList();

            return View(list);
        }

        // 編集画面表示
        public IActionResult Edit(int id)
        {
            var e = _context.Employees
                .Include(x => x.Department)
                .Include(x => x.Salaries)
                .FirstOrDefault(x => x.EmployeeID == id);

            if (e == null) return NotFound();

            var vm = new EmployeeViewModel
            {
                DepartmentID = e.DepartmentID ?? 0,
                DepartmentName = e.Department.DepartmentName,
                EmployeeID = e.EmployeeID,
                EmployeeName = e.EmployeeName,
                HireDate = e.HireDate,
                Salary = e.Salaries.Amount,
                EffectiveDate = e.Salaries.EffectiveDate
            };

            return View(vm);
        }

        // 編集内容保存
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmployeeViewModel vm)
        {
            // ローマ字（英字）が含まれているかチェック
            if (!string.IsNullOrEmpty(vm.EmployeeName) && System.Text.RegularExpressions.Regex.IsMatch(vm.EmployeeName, "[A-Za-z]"))
            {
                return BadRequest(new { message = "社員名にローマ字（英字）は使用できません。" });
            }

            var e = _context.Employees
                .Include(x => x.Department)
                .Include(x => x.Salaries)
                .FirstOrDefault(x => x.EmployeeID == vm.EmployeeID);

            if (e == null)
                return NotFound();

            // 部門更新
            e.DepartmentID = vm.DepartmentID;
            // 社員情報更新
            e.EmployeeName = vm.EmployeeName;
            e.HireDate = vm.HireDate;
            // 給与情報更新
            e.Salaries.Amount = vm.Salary;
            e.Salaries.EffectiveDate = (DateOnly)vm.EffectiveDate;

            _context.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public IActionResult GetEmployee(int id)
        {
            var e = _context.Employees
                .Include(x => x.Department)
                .Include(x => x.Salaries)
                .FirstOrDefault(x => x.EmployeeID == id);

            if (e == null) return NotFound();

            return Json(new
            {
                EmployeeID = e.EmployeeID,
                DepartmentID = e.DepartmentID ?? 0, // 追加
                DepartmentName = e.Department?.DepartmentName,
                EmployeeName = e.EmployeeName,
                HireDate = e.HireDate?.ToString("yyyy-MM-dd"),
                Salary = e.Salaries?.Amount ?? 0,
                EffectiveDate = e.Salaries?.EffectiveDate.ToString("yyyy-MM-dd")
            });
        }

        [HttpGet]
        public IActionResult GetDepartments()
        {
            var list = _context.Departments
                .Select(d => new { departmentID = d.DepartmentID, departmentName = d.DepartmentName })
                .ToList();
            return Json(list);
        }
    }
}
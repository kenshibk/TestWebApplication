#region
//using System.Diagnostics;
//using Microsoft.AspNetCore.Mvc;
//using WebApplication1.Models;

//namespace WebApplication1.Controllers;

//public class HomeController : Controller
//{
//    private readonly ILogger<HomeController> _logger;

//    public HomeController(ILogger<HomeController> logger)
//    {
//        _logger = logger;
//    }

//    public IActionResult Index()
//    {
//        return View();
//    }

//    public IActionResult Privacy()
//    {
//        return View();
//    }

//    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//    public IActionResult Error()
//    {
//        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//    }
//}
#endregion


using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApplication1.DataAccess; // DataAccessクラスのために必要
using WebApplication1.Models; // モデルクラスのために必要
using System.Collections.Generic;
using System.Diagnostics;


namespace WebApplication1.Controllers // プロジェクト名に合わせて変更してください
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration; // 接続文字列取得のために必要

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // デフォルトのアクションメソッド
        public IActionResult Index()
        {
            // appsettings.json から接続文字列を取得
            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            // EmployeeRepository のインスタンスを作成
            EmployeeRepository repository = new EmployeeRepository(connectionString);

            // 各テーブルからデータを取得
            List<Department> departments = repository.GetAllDepartments();
            List<Employee> employees = repository.GetAllEmployees();
            List<Salary> salaries = repository.GetAllSalaries();

            // 取得したデータをDashboardViewModelにまとめる
            var viewModel = new DashboardViewModel
            {
                Departments = departments,
                Employees = employees,
                Salaries = salaries
            };

            // ViewModelをビューに渡す
            return View(viewModel);
        }

        // Privacy などの他のアクションメソッドは必要に応じて残すか削除
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
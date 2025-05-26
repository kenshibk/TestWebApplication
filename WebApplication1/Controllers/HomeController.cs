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
using WebApplication1.DataAccess; // DataAccess�N���X�̂��߂ɕK�v
using WebApplication1.Models; // ���f���N���X�̂��߂ɕK�v
using System.Collections.Generic;
using System.Diagnostics;


namespace WebApplication1.Controllers // �v���W�F�N�g���ɍ��킹�ĕύX���Ă�������
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration; // �ڑ�������擾�̂��߂ɕK�v

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // �f�t�H���g�̃A�N�V�������\�b�h
        public IActionResult Index()
        {
            // appsettings.json ����ڑ���������擾
            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            // EmployeeRepository �̃C���X�^���X���쐬
            EmployeeRepository repository = new EmployeeRepository(connectionString);

            // �e�e�[�u������f�[�^���擾
            List<Department> departments = repository.GetAllDepartments();
            List<Employee> employees = repository.GetAllEmployees();
            List<Salary> salaries = repository.GetAllSalaries();

            // �擾�����f�[�^��DashboardViewModel�ɂ܂Ƃ߂�
            var viewModel = new DashboardViewModel
            {
                Departments = departments,
                Employees = employees,
                Salaries = salaries
            };

            // ViewModel���r���[�ɓn��
            return View(viewModel);
        }

        // Privacy �Ȃǂ̑��̃A�N�V�������\�b�h�͕K�v�ɉ����Ďc�����폜
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
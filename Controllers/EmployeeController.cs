using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using EmployeeFirst.Database.Repositories;
using EmployeeFirst.Models;

namespace EmployeeFirst.Controllers
{
    public class EmployeeController : Controller
	{
		private readonly ILogger<EmployeeController> _logger;


        private List<EmployeeModel> employeesList = new List<EmployeeModel>();


        public EmployeeController(ILogger<EmployeeController> logger)
		{
			_logger = logger;


        }


        public async Task<IActionResult> Index()
        {
            var employees = await DBEmployeeRepository.GetAllEmployeesAsync();
            employeesList.AddRange(employees);

            return View("Employees", employeesList);
		}


		[HttpPost]
        public async Task<IActionResult> New(EmployeeModel newEmployee)
		{

			await DBEmployeeRepository.AddEmployeeAsync(newEmployee);

            return RedirectToAction("Index", "Employee");
		}

		[HttpPost]
        public async Task<IActionResult> Update(EmployeeModel newEmployee)
		{

			await DBEmployeeRepository.UpdateEmployeeAsync(newEmployee);

            return RedirectToAction("Index", "Employee");
		}

		
        public IActionResult NewEmployee()
		{

			EmployeeModel employee = new EmployeeModel();

			return View("NewEmployee", employee);
		}

        public async Task<IActionResult> UpdateEmployee(int id)
		{

			try
			{
                var employee = await DBEmployeeRepository.GetByIdAsync(id);
                return View("UpdateEmployee", employee);

            }
            catch(Exception ex)
			{

                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            }

		}

		public async Task<IActionResult> Delete(int id)
		{
			await DBEmployeeRepository.DeleteAsync(id);

            return RedirectToAction("Index", "Employee");
        }

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
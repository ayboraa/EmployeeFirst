using Microsoft.EntityFrameworkCore;
using EmployeeFirst.Database.DBContexts;
using EmployeeFirst.Models;

namespace EmployeeFirst.Database.Repositories
{


    public class DBEmployeeRepository
    {


        public static void Initialize() { }

        public static async Task<EmployeeModel> GetByIdAsync(int id)
        {
            using (var db = new EmployeeContext())
            {
                var employee = await db.Employees.FindAsync(id);


                if (employee != null)
                    return employee;
                else
                    throw new Exception("Employee cannot be found.");

            }
        }

        public static async Task<IEnumerable<EmployeeModel>> GetAllEmployeesAsync()
        {
            using (var db = new EmployeeContext())
            {
                var employees = await db.Employees.ToListAsync();

                if (employees != null)
                    return employees;
                else
                    throw new Exception("Employee cannot be found.");

            }
        }

        public static async Task AddEmployeeAsync(EmployeeModel newEmployee)
        {
            using (var db = new EmployeeContext())
            {
                await db.Employees.AddAsync(newEmployee);
                await db.SaveChangesAsync();
            }
        }
        
        public static async Task UpdateEmployeeAsync(EmployeeModel newEmployee)
        {
            using (var db = new EmployeeContext())
            {
                Console.WriteLine(newEmployee.Id);
                var oldEmployee = await GetByIdAsync(newEmployee.Id);
                oldEmployee = newEmployee;
                db.Employees.Update(oldEmployee);
                await db.SaveChangesAsync();
            }
        }

        public static async Task DeleteAsync(int id)
        {
            using (var db = new EmployeeContext())
            {
                try
                {

                    var employee = await GetByIdAsync(id);

                    db.Employees.Remove(employee);

                    await db.SaveChangesAsync();

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.ToString());

                }

            }
        }


    }
}

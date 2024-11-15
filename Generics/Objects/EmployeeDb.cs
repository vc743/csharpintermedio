using Generics.Models;
using Generics.Classes;
using Generics.Interfaces;

namespace Generics.Objects
{
    public class EmployeeDb : IBaseRepository<Employee, EmployeeResult, List<EmployeeResult>>
    {
        private readonly List<Employee> employees;

        public EmployeeDb(List<Employee> employees)
        {
            this.employees = employees;
        }

        public Employee GetEmployeeById(int Id)
        {
            return this.employees.FirstOrDefault(e => e.EmployeeId == Id);
        }

        public async Task<bool> Exists(Func<Employee, bool> filter)
        {
            var result = this.employees.Any(filter);

            return await Task.FromResult(result);
        }

        public async Task<List<EmployeeResult>> GetAll()
        {
            List<EmployeeResult> employeeResults = new List<EmployeeResult>();

            employeeResults = this.employees.Select(p => new EmployeeResult()
            {
                EmployeeId = p.EmployeeId,
                Name = $"{p.FirstName} {p.LastName}",
                Title = p.Title,
                Address = p.Address,
                Phone = p.Phone
            }).ToList();

            return await Task.FromResult<List<EmployeeResult>>(employeeResults);
        }

        public async Task<List<EmployeeResult>> GetAll(Func<Employee, bool> filter)
        {
            List<EmployeeResult> employeeResults = new List<EmployeeResult>();

            employeeResults = this.employees.Where(filter).Select(p => new EmployeeResult()
            {
                EmployeeId = p.EmployeeId,
                Name = $"{p.FirstName} {p.LastName}",
                Title = p.Title,
                Address = p.Address,
                Phone = p.Phone
            }).ToList();

            return await Task.FromResult<List<EmployeeResult>>(employeeResults);
        }

        public async Task<EmployeeResult> GetEntityBy(int Id)
        {
            EmployeeResult employeeResult = new EmployeeResult();

            var employee = GetEmployeeById(Id);

            employeeResult.EmployeeId = employee.EmployeeId;
            employeeResult.Name = $"{employee.FirstName} {employee.LastName}";
            employeeResult.Title = employee.Title;
            employeeResult.Address = employee.Address;
            employeeResult.Phone = employee.Phone;

            return await Task.FromResult<EmployeeResult>(employeeResult);
        }

        public async Task<EmployeeResult> Remove(Employee entity)
        {
            EmployeeResult employeeResult = new EmployeeResult();

            var employee = GetEmployeeById(entity.EmployeeId);

            this.employees.Remove(employee);

            return await Task.FromResult(employeeResult);
        }

        public async Task<EmployeeResult> Save(Employee entity)
        {
            EmployeeResult employeeResult = new EmployeeResult();

            this.employees.Add(entity);

            return await Task.FromResult(employeeResult);
        }

        public async Task<EmployeeResult> Update(Employee entity)
        {
            EmployeeResult employeeResult = new EmployeeResult();

            await this.Remove(entity);

            await this.Save(entity);

            return await Task.FromResult(employeeResult);
        }
    }
}

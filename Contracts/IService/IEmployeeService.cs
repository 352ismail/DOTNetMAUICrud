using EmployeeManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Contracts.IService
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployeeList();
        Task<int> Create(Employee employee);
        Task<int> Update(Employee employee);
        Task<int> Delete(Employee employee);
    }
}

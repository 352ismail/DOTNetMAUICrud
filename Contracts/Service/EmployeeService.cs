using EmployeeManager.Contracts.IService;
using EmployeeManager.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Contracts.Service
{
    public class EmployeeService : IEmployeeService
    {
        private SQLiteAsyncConnection _context;
        public EmployeeService()
        {
            SetUpDB();
        }
        public async void SetUpDB()
        {
            if (_context is null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "employee.db3");
                _context = new SQLiteAsyncConnection(dbPath);
                await _context.CreateTableAsync<Employee>();

            }
        }

        public async Task<int> Create(Employee employee)
        {
            return await _context.InsertAsync(employee);
        }

        public async Task<int> Delete(Employee employee)
        {
            return await _context.DeleteAsync(employee);
        }

        public async Task<List<Employee>> GetEmployeeList()
        {
            var employees = await _context.Table<Employee>().ToListAsync();
            return employees;
        }

        public async Task<int> Update(Employee employee)
        {
            return await _context.UpdateAsync(employee);
        }
    }
}

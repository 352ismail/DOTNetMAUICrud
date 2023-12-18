using EmployeeManager.Contracts.IService;
using EmployeeManager.Models;
using EmployeeManager.Views;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.ViewModels
{
    public partial class EmployeeListViewModel : ObservableObject
    {
        public ObservableCollection<Employee> Employees { get; set; } =
            new ObservableCollection<Employee>();

        private readonly IEmployeeService _employeeService;

        public EmployeeListViewModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [ICommand]
        public async void GetEmployeesList()
        {
            var employees = await _employeeService.GetEmployeeList();
            if (employees.Any())
            {
                Employees.Clear();
                foreach (var employee in employees)
                {
                    Employees.Add(employee);
                }
            }
        }

        [ICommand]
        public async void AddUpdateEmployees()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateEmployee));
        }

        [ICommand]
        public async void DisplayActions(Employee model)
        {
            var response = await AppShell.Current.DisplayActionSheet("Select Option","Ok",null,"Edit","Delete");
            if(response == "Edit")
            {
                var navParameter = new Dictionary<string, object>();
                navParameter.Add("EmployeeDetails", model);
                await AppShell.Current.GoToAsync(nameof(AddUpdateEmployee), navParameter);
                //await _employeeService.Update(model);
            }
            else if (response == "Delete")
            {
                var deleteResponse  = await _employeeService.Delete(model);
                if(deleteResponse > 0)
                {
                    GetEmployeesList();
                }
            }
        }
    }
}

using EmployeeManager.Contracts.IService;
using EmployeeManager.Models;
using EmployeeManager.Views;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.ViewModels
{
    [QueryProperty(nameof(EmployeeDetail), "EmployeeDetails")]
    public partial class AddUpdateEmployeeViewModel: ObservableObject
    {
        [ObservableProperty]
        private Employee _employeeDetail =  new Employee();

        private readonly IEmployeeService _employeeService;
        public AddUpdateEmployeeViewModel(IEmployeeService employeeService)
        {
                _employeeService = employeeService;
        }

        [ICommand]
        public async void AddUpdateEmployees()
        {
            int response = -1;
            if(EmployeeDetail.Id > 0)
            {
                response = await _employeeService.Update(EmployeeDetail);
            }
            else
            {
                 response = await _employeeService.Create(new Models.Employee
                {
                    Email = EmployeeDetail.Email,
                    FirstName = EmployeeDetail.FirstName,
                    LastName = EmployeeDetail.LastName,
                });
            }
            if(response > 0)
            {
                await Shell.Current.DisplayAlert("Success", "Record Added Successfully","Ok");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "An Error Occurred", "Ok");
            }
        }
    }
}

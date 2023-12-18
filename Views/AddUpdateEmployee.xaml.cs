using EmployeeManager.ViewModels;

namespace EmployeeManager.Views;

public partial class AddUpdateEmployee : ContentPage
{
	public AddUpdateEmployee(AddUpdateEmployeeViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}
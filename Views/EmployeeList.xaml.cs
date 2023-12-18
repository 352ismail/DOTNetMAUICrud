using EmployeeManager.ViewModels;

namespace EmployeeManager.Views;

public partial class EmployeeList : ContentPage
{
	private EmployeeListViewModel _viewModel;
	public EmployeeList(EmployeeListViewModel viewmodel)
	{

		InitializeComponent();
		_viewModel = viewmodel;
		this.BindingContext = viewmodel;
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
		_viewModel.GetEmployeesListCommand.Execute(null);
    }
}
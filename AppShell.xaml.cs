using EmployeeManager.Views;

namespace EmployeeManager
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AddUpdateEmployee), typeof(AddUpdateEmployee));
        }
    }
}

using Microsoft.Maui.Controls;
using PersonalExpenseTracker.ViewModels;

namespace PersonalExpenseTracker.Views
{
    public partial class ExpensesPage : ContentPage
    {
        public ExpensesPage(ExpensesViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext is ExpensesViewModel vm)
            {
                vm.LoadExpensesCommand.Execute(null);
            }
        }
    }
}

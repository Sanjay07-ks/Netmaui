using Microsoft.Maui.Controls;
using PersonalExpenseTracker.ViewModels;

namespace PersonalExpenseTracker.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage(HomeViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext is HomeViewModel vm)
            {
                vm.LoadStatsCommand.Execute(null);
            }
        }

        private async void OnManageCategoriesClicked(object? sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("CategoriesPage");
        }

        private async void OnViewExpensesClicked(object? sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("ExpensesPage");
        }

        private async void OnAddExpenseClicked(object? sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("AddEditExpensePage");
        }
    }
}

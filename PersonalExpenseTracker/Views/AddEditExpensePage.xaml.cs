using Microsoft.Maui.Controls;
using PersonalExpenseTracker.ViewModels;

namespace PersonalExpenseTracker.Views
{
    public partial class AddEditExpensePage : ContentPage
    {
        public AddEditExpensePage(AddEditExpenseViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}

using Microsoft.Maui.Controls;
using PersonalExpenseTracker.ViewModels;

namespace PersonalExpenseTracker.Views
{
    public partial class CategoryDetailPage : ContentPage
    {
        public CategoryDetailPage(CategoryDetailViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}

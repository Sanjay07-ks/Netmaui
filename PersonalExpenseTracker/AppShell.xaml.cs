using Microsoft.Maui.Controls;
using PersonalExpenseTracker.Views;

namespace PersonalExpenseTracker;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(CategoriesPage), typeof(CategoriesPage));
		Routing.RegisterRoute(nameof(CategoryDetailPage), typeof(CategoryDetailPage));
		Routing.RegisterRoute(nameof(ExpensesPage), typeof(ExpensesPage));
		Routing.RegisterRoute(nameof(AddEditExpensePage), typeof(AddEditExpensePage));
	}
}

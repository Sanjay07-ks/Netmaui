using Microsoft.Extensions.Logging;
using PersonalExpenseTracker.Models;
using PersonalExpenseTracker.Services;
using PersonalExpenseTracker.ViewModels;
using PersonalExpenseTracker.Views;

namespace PersonalExpenseTracker;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		// Database
		builder.Services.AddSingleton<LocalDatabase>();

		// Services
		builder.Services.AddSingleton<IDataStore<Category>, SQLiteCategoryDataStore>();
		builder.Services.AddSingleton<IDataStore<Expense>, SQLiteExpenseDataStore>();

		// ViewModels
		builder.Services.AddSingleton<HomeViewModel>();
		builder.Services.AddTransient<CategoriesViewModel>();
		builder.Services.AddTransient<CategoryDetailViewModel>();
		builder.Services.AddTransient<ExpensesViewModel>();
		builder.Services.AddTransient<AddEditExpenseViewModel>();

		// Views
		builder.Services.AddSingleton<HomePage>();
		builder.Services.AddTransient<CategoriesPage>();
		builder.Services.AddTransient<CategoryDetailPage>();
		builder.Services.AddTransient<ExpensesPage>();
		builder.Services.AddTransient<AddEditExpensePage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

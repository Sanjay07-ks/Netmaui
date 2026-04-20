using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using PersonalExpenseTracker.Models;
using PersonalExpenseTracker.Services;

namespace PersonalExpenseTracker.ViewModels
{
    public class ExpensesViewModel : BaseViewModel
    {
        private readonly IDataStore<Expense> _expenseDataStore;
        private readonly IDataStore<Category> _categoryDataStore;

        public ObservableCollection<Expense> Expenses { get; }
        public ICommand LoadExpensesCommand { get; }
        public ICommand AddExpenseCommand { get; }
        public ICommand DeleteExpenseCommand { get; }
        public ICommand EditExpenseCommand { get; }

        public ExpensesViewModel(IDataStore<Expense> expenseDataStore, IDataStore<Category> categoryDataStore)
        {
            Title = "Expenses";
            _expenseDataStore = expenseDataStore;
            _categoryDataStore = categoryDataStore;
            Expenses = new ObservableCollection<Expense>();

            LoadExpensesCommand = new Command(async () => await ExecuteLoadExpensesCommand());
            AddExpenseCommand = new Command(async () => await Shell.Current.GoToAsync("AddEditExpensePage"));
            
            DeleteExpenseCommand = new Command<Expense>(async (expense) => {
                if (expense == null) return;
                await _expenseDataStore.DeleteItemAsync(expense.Id);
                Expenses.Remove(expense);
            });

            EditExpenseCommand = new Command<Expense>(async (expense) => {
                if (expense == null) return;
                await Shell.Current.GoToAsync($"AddEditExpensePage?ExpenseId={expense.Id}");
            });
        }

        public async Task ExecuteLoadExpensesCommand()
        {
            IsBusy = true;
            try
            {
                Expenses.Clear();
                var items = await _expenseDataStore.GetItemsAsync(true);
                
                // For UI mapping
                var cats = await _categoryDataStore.GetItemsAsync();
                
                foreach (var item in items)
                {
                    item.Category = cats.FirstOrDefault(c => c.Id == item.CategoryId);
                    Expenses.Add(item);
                }
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}

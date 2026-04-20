using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using PersonalExpenseTracker.Models;
using PersonalExpenseTracker.Services;

namespace PersonalExpenseTracker.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly IDataStore<Expense> _expenseDataStore;
        
        private int totalExpenses;
        public int TotalExpenses 
        {
            get => totalExpenses;
            set => SetProperty(ref totalExpenses, value);
        }

        private decimal totalAmount;
        public decimal TotalAmount
        {
            get => totalAmount;
            set => SetProperty(ref totalAmount, value);
        }

        public ICommand LoadStatsCommand { get; }

        public HomeViewModel(IDataStore<Expense> expenseDataStore)
        {
            Title = "Home";
            _expenseDataStore = expenseDataStore;
            LoadStatsCommand = new Command(async () => await LoadStats());
        }

        public async Task LoadStats()
        {
            IsBusy = true;
            try
            {
                var expenses = await _expenseDataStore.GetItemsAsync(true);
                var expenseList = expenses.ToList();
                TotalExpenses = expenseList.Count;
                TotalAmount = expenseList.Sum(e => e.Amount);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}

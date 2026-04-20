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
    [QueryProperty(nameof(ExpenseId), nameof(ExpenseId))]
    public class AddEditExpenseViewModel : BaseViewModel
    {
        private string expenseId;
        private string titleStr;
        private decimal amount;
        private DateTime date = DateTime.Today;
        private string note;
        private Category selectedCategory;

        private readonly IDataStore<Expense> _expenseDataStore;
        private readonly IDataStore<Category> _categoryDataStore;

        public ObservableCollection<Category> Categories { get; }

        public string ExpenseId
        {
            get => expenseId;
            set
            {
                expenseId = value;
                LoadExpenseAsync(value);
            }
        }

        public string TitleStr
        {
            get => titleStr;
            set => SetProperty(ref titleStr, value);
        }

        public decimal Amount
        {
            get => amount;
            set => SetProperty(ref amount, value);
        }

        public DateTime Date
        {
            get => date;
            set => SetProperty(ref date, value);
        }

        public string Note
        {
            get => note;
            set => SetProperty(ref note, value);
        }

        public Category SelectedCategory
        {
            get => selectedCategory;
            set => SetProperty(ref selectedCategory, value);
        }

        public ICommand SaveCommand { get; }
        public ICommand LoadCategoriesCommand { get; }

        public AddEditExpenseViewModel(IDataStore<Expense> expenseDataStore, IDataStore<Category> categoryDataStore)
        {
            _expenseDataStore = expenseDataStore;
            _categoryDataStore = categoryDataStore;
            Categories = new ObservableCollection<Category>();

            SaveCommand = new Command(async () => await SaveExpenseAsync());
            LoadCategoriesCommand = new Command(async () => await LoadCategoriesAsync());
            Task.Run(async () => await LoadCategoriesAsync());
        }

        private async Task LoadCategoriesAsync()
        {
            var cats = await _categoryDataStore.GetItemsAsync();
            Categories.Clear();
            foreach (var cat in cats)
            {
                Categories.Add(cat);
            }
            if(!string.IsNullOrEmpty(ExpenseId)) 
            {
                LoadExpenseAsync(ExpenseId); // reload to bind category properly
            }
        }

        private async void LoadExpenseAsync(string id)
        {
            try
            {
                var expense = await _expenseDataStore.GetItemAsync(id);
                if (expense != null)
                {
                    TitleStr = expense.Title;
                    Amount = expense.Amount;
                    Date = expense.Date;
                    Note = expense.Note;
                    
                    if (Categories.Any()) 
                    {
                        SelectedCategory = Categories.FirstOrDefault(c => c.Id == expense.CategoryId);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private async Task SaveExpenseAsync()
        {
            if (string.IsNullOrWhiteSpace(TitleStr) || SelectedCategory == null)
                return;

            if (string.IsNullOrEmpty(ExpenseId))
            {
                var expense = new Expense 
                { 
                    Title = TitleStr, 
                    Amount = Amount, 
                    Date = Date, 
                    Note = Note, 
                    CategoryId = SelectedCategory.Id 
                };
                await _expenseDataStore.AddItemAsync(expense);
            }
            else
            {
                var expense = new Expense 
                { 
                    Id = ExpenseId, 
                    Title = TitleStr, 
                    Amount = Amount, 
                    Date = Date, 
                    Note = Note, 
                    CategoryId = SelectedCategory.Id 
                };
                await _expenseDataStore.UpdateItemAsync(expense);
            }

            await Shell.Current.GoToAsync("..");
        }
    }
}

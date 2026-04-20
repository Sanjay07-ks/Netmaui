using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using PersonalExpenseTracker.Models;
using PersonalExpenseTracker.Services;

namespace PersonalExpenseTracker.ViewModels
{
    public class CategoriesViewModel : BaseViewModel
    {
        private readonly IDataStore<Category> _categoryDataStore;

        public ObservableCollection<Category> Categories { get; }
        public ICommand LoadCategoriesCommand { get; }
        public ICommand AddCategoryCommand { get; }
        public ICommand DeleteCategoryCommand { get; }
        public ICommand EditCategoryCommand { get; }

        public CategoriesViewModel(IDataStore<Category> categoryDataStore)
        {
            Title = "Categories";
            _categoryDataStore = categoryDataStore;
            Categories = new ObservableCollection<Category>();

            LoadCategoriesCommand = new Command(async () => await ExecuteLoadCategoriesCommand());
            AddCategoryCommand = new Command(async () => await Shell.Current.GoToAsync("CategoryDetailPage"));
            
            DeleteCategoryCommand = new Command<Category>(async (category) => {
                if (category == null) return;
                await _categoryDataStore.DeleteItemAsync(category.Id);
                Categories.Remove(category);
            });

            EditCategoryCommand = new Command<Category>(async (category) => {
                if (category == null) return;
                await Shell.Current.GoToAsync($"CategoryDetailPage?CategoryId={category.Id}");
            });
        }

        public async Task ExecuteLoadCategoriesCommand()
        {
            IsBusy = true;
            try
            {
                Categories.Clear();
                var items = await _categoryDataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Categories.Add(item);
                }
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}

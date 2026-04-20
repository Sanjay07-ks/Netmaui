using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using PersonalExpenseTracker.Models;
using PersonalExpenseTracker.Services;

namespace PersonalExpenseTracker.ViewModels
{
    [QueryProperty(nameof(CategoryId), nameof(CategoryId))]
    public class CategoryDetailViewModel : BaseViewModel
    {
        private string categoryId;
        private string name;
        private string icon;

        private readonly IDataStore<Category> _categoryDataStore;

        public string CategoryId
        {
            get => categoryId;
            set
            {
                categoryId = value;
                LoadCategoryAsync(value);
            }
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Icon
        {
            get => icon;
            set => SetProperty(ref icon, value);
        }

        public ICommand SaveCommand { get; }

        public CategoryDetailViewModel(IDataStore<Category> categoryDataStore)
        {
            _categoryDataStore = categoryDataStore;
            SaveCommand = new Command(async () => await SaveCategoryAsync());
        }

        private async void LoadCategoryAsync(string id)
        {
            try
            {
                var category = await _categoryDataStore.GetItemAsync(id);
                if (category != null)
                {
                    Name = category.Name;
                    Icon = category.Icon;
                }
            }
            catch (Exception)
            {
            }
        }

        private async Task SaveCategoryAsync()
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Icon))
            {
                return; 
            }

            if (string.IsNullOrEmpty(CategoryId))
            {
                var category = new Category { Name = Name, Icon = Icon };
                await _categoryDataStore.AddItemAsync(category);
            }
            else
            {
                var category = new Category { Id = CategoryId, Name = Name, Icon = Icon };
                await _categoryDataStore.UpdateItemAsync(category);
            }

            await Shell.Current.GoToAsync("..");
        }
    }
}

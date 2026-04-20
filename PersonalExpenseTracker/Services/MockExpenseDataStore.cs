using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalExpenseTracker.Models;

namespace PersonalExpenseTracker.Services
{
    public class MockExpenseDataStore : IDataStore<Expense>
    {
        readonly List<Expense> expenses;

        public MockExpenseDataStore()
        {
            expenses = new List<Expense>();
        }

        public async Task<bool> AddItemAsync(Expense item)
        {
            expenses.Add(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Expense item)
        {
            var oldItem = expenses.Where((Expense arg) => arg.Id == item.Id).FirstOrDefault();
            expenses.Remove(oldItem);
            expenses.Add(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = expenses.Where((Expense arg) => arg.Id == id).FirstOrDefault();
            expenses.Remove(oldItem);
            return await Task.FromResult(true);
        }

        public async Task<Expense> GetItemAsync(string id)
        {
            return await Task.FromResult(expenses.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Expense>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(expenses);
        }
    }
}

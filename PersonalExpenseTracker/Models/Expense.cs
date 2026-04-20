using System;
using SQLite;

namespace PersonalExpenseTracker.Models
{
    public class Expense
    {
        [PrimaryKey]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CategoryId { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }

        // Navigation property for UI binding – not stored in DB
        [Ignore]
        public Category Category { get; set; }
    }
}

using System;
using SQLite;

namespace PersonalExpenseTracker.Models
{
    public class Category
    {
        [PrimaryKey]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Icon { get; set; }
    }
}

using student__management_login.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace student__management_login.viewmodel
{
    public class studentmarkviewmodel
    {
        public ObservableCollection<studentmark> StudentDetail { get; set; }

        public studentmarkviewmodel()
        {
            StudentDetail = new ObservableCollection<studentmark>
        {
            new studentmark { studentName = "sanjay", department = "IT", tamilmark = 65, englishmark = 85, mathmark = 46, sciencemark = 87, socialmark = 35 },
            new studentmark { studentName = "boopathi", department = "AI&DS", tamilmark = 65, englishmark = 85, mathmark = 46, sciencemark = 87, socialmark = 35 }
        };
        }
    }
}
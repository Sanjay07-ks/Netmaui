
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using student__management_login.model;
using student__management_login.view;
using System;
using System.Collections.Generic;
using System.Text;

namespace student__management_login.viewmodel
{
    public partial class studentviewmodel : ObservableObject
    {
        
        private student _student;
        [ObservableProperty]
        private int _userId;
       
        [ObservableProperty]
        private string _password;
        
        public studentviewmodel()
        {
            _student = new student();
        }

        private student Get_student1()
        {
            return _student;
        }
        [RelayCommand]
        private async Task Login()
        {
            // basic validation
            if (UserId <= 0 || string.IsNullOrWhiteSpace(Password))
            {
                await Application.Current.MainPage.DisplayAlert("validation error", "Provided UserId or Password is Empty", "Okay");
                    return;
            }
            else if (UserId ==8 && Password=="admin")
            {
               await Shell.Current.GoToAsync(nameof(studentmarkview));
                
               // Navigation
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("validation error", "Provided UserId or Password is Wrong", "Okay");
                return;
            }

            
            // update model
            //if (Userid, out var id)
                _student.userId = UserId;

            _student.password = Password;

            // perform authentication / navigation here (await async service call if needed)
            await Task.CompletedTask;
        }


    }


}

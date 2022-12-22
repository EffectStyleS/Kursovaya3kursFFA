using Kursovaya_KPO_interface.Infrastructure;
using Kursovaya_KPO_interface.Model.Interfaces;
using Kursovaya_KPO_interface.Model.Models;
using Kursovaya_KPO_interface.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Kursovaya_KPO_interface.ViewModel
{
    public class StartMenuViewModel : ViewModelBase
    {
       
        IUserService _userService;
        UserModel _currentUser;       
        string _enterResult;

        public static UserModel SelectedUser { get; set; }
        public UserModel CurrentUser
        {
            get
            {
                if (_currentUser == null)
                {
                    _currentUser = new UserModel
                    {
                        Login = "Логин",
                    };
                }
                return _currentUser;
            }
            set
            {
                _currentUser = value;
                OnPropertyChanged("CurrentUser");
            }
        }
        public string EnterResult 
        {
            get
            {
                if (_enterResult == null)
                {
                    _enterResult = "";
                }
                return _enterResult;
            }
            set
            {
                _enterResult = value;
                OnPropertyChanged("EnterResult");
            }
        }
        public static Uri StartMenuUri { get; set; }
        public static Uri MainMenuUri { get; set; }

        public StartMenuViewModel()
        {
            _userService = App.MyMainWindow.UserService;
            StartMenuUri = new Uri("View/StartMenu.xaml", UriKind.Relative);
        }

        #region EnterUser

        RelayCommand _enterUser;
        public ICommand EnterUser
        {
            get
            {
                if (_enterUser == null)
                    _enterUser = new RelayCommand(ExecuteEnterUserCommand, CanExecuteEnterUserCommand);
                return _enterUser;
            }
        }

        public void ExecuteEnterUserCommand(object parameter)
        {
            SelectedUser = _userService.GetUserByLogin(CurrentUser.Login);
            
            if(parameter is object[] array)
            {
                CurrentUser.Password = array[0].ToString();
                Navigator.Page = array[1] as Page;
            }

            if (SelectedUser != null)
            {
                if (SelectedUser.Password == CurrentUser.Password)
                {
                    if (MainMenuUri == null)
                        MainMenuUri = new Uri("View/MainMenu.xaml", UriKind.Relative);
                    Navigator.Page.NavigationService.Navigate(MainMenuUri);
                    EnterResult = "";
                }
                else { EnterResult = "Неверный пароль"; }

            }
            else { EnterResult = "Пользователь с таким логином не существует"; }

        }

        public bool CanExecuteEnterUserCommand(object parameter)
        {
            if (!string.IsNullOrEmpty(CurrentUser.Login) && CurrentUser.Login != "Логин")
            {
                return true;
            }
            return false;
        }
        #endregion

    }
}

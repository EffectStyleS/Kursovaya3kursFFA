﻿using Kursovaya_KPO_interface.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Kursovaya_KPO_interface.View
{
    /// <summary>
    /// Логика взаимодействия для Incomes.xaml
    /// </summary>
    public partial class Incomes : Page
    {
        private Uri _mainMenuUri;
        public Incomes()
        {
            InitializeComponent();
            _mainMenuUri = MainMenuViewModel.MainMenuUri;  //перенести в vm
        }

        private void IncomesButtonToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            if (_mainMenuUri == null)
                _mainMenuUri = new Uri("View/MainMenu.xaml", UriKind.Relative);
            NavigationService.Navigate(_mainMenuUri);
        }

    }
}

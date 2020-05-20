﻿using System;
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

namespace MarathonSkills2020.View.AdministratorPages
{
    /// <summary>
    /// Логика взаимодействия для MainPageAdministrator.xaml
    /// </summary>
    public partial class MainPageAdministrator : Page
    {
        public MainPageAdministrator()
        {
            InitializeComponent();
            DataContext = new ViewModel.AdministratorPages.MainPageAdministratorViewModel();
        }
    }
}

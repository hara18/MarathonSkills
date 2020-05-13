using MarathonSkills2020.View.MarathonInfo;
using MarathonSkills2020.View.Runner;
using MarathonSkills2020.View.Sponsor;
using System;
using System.Windows;
using System.Windows.Threading;

namespace MarathonSkills2020.View.MainWindowSystem
{
    /// <summary>
    /// Логика взаимодействия для WMainWindowSystem.xaml
    /// </summary>
    public partial class WMainWindowSystem : Window
    {

        public WMainWindowSystem()
        {
            InitializeComponent();
            DataContext = new ViewModel.MainWindowSystemViewModel.WMainWindowSystemViewModel();
            ViewModel.MainWindowSystemViewModel.WMainWindowSystemViewModel.CloseWindowMain = new Action(() => this.Close());
        }
    }
}

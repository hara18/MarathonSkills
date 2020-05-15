using MarathonSkills2020.Model;
using System;
using System.Collections.Generic;
using System.Data.Linq;
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
using System.Windows.Shapes;

namespace MarathonSkills2020.View.MainWindowSystem
{
    /// <summary>
    /// Логика взаимодействия для SecondMainWindowSystem.xaml
    /// </summary>
    public partial class SecondMainWindowSystem : Window
    {
        public SecondMainWindowSystem()
        {
            InitializeComponent();
        
        DataContext = new ViewModel.MainWindowSystemViewModel.WSecondMainWindowSystemViewModel();
        ViewModel.MainWindowSystemViewModel.WSecondMainWindowSystemViewModel.CloseWSecondMainWindow = new Action(() => this.Close());
    }


}
}

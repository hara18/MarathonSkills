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

namespace MarathonSkills2020.View.AdministratorPages
{
    /// <summary>
    /// Логика взаимодействия для InventoryPages.xaml
    /// </summary>
    public partial class InventoryPages : Page
    {
        public InventoryPages()
        {
            InitializeComponent();
            DataContext = new ViewModel.AdministratorPages.InventoryPageViewModel();
        }
    }
}

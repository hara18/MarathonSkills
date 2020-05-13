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

namespace MarathonSkills2020.View.MarathonInfo
{
    /// <summary>
    /// Логика взаимодействия для FindOutMoreInformation.xaml
    /// </summary>
    public partial class FindOutMoreInformation : Page
    {
        public FindOutMoreInformation()
        {
            InitializeComponent();
            DataContext = new ViewModel.MarathonInfo.FindOutMoreInformationViewModel();

        }
    }
}

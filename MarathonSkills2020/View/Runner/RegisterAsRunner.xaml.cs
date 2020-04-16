using MarathonSkills2020.View.LoginPage;
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
using System.Windows.Shapes;

namespace MarathonSkills2020.View.Runner
{
    /// <summary>
    /// Логика взаимодействия для RegisterAsRunner.xaml
    /// </summary>
    public partial class RegisterAsRunner : Window
    {
        public RegisterAsRunner()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PLoginPage pLoginPage = new PLoginPage();
            
        }
    }
}

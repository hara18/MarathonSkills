using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MarathonSkills2020.ViewModel.MainWindowSystemViewModel
{
    class WSecondMainWindowSystemViewModel : ViewModel.HelperViewModel.HelperViewModel
    {
        public static int NumberOfButtonPressed { get; set; }

        private Page currentPage;

        public Page CurrentPage
        {
            get => this.currentPage;
            set => this.Set<Page>(ref currentPage, value);
        }

        public WSecondMainWindowSystemViewModel()
        {
            switch (NumberOfButtonPressed)
            {
                case 1:
                    break;

                case 2:
                    break;

                case 3:
                    break;

                case 4:
                    CurrentPage = new View.LoginPage.PLoginPage();
                    break;
                default:
                    MessageBox.Show("Ошибка передачи параметров нажатой кнопки");
                    break;
            }
        }

    }
}

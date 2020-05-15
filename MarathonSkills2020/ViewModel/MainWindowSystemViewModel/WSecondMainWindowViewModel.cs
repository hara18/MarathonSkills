using MarathonSkills2020.ViewModel.HelperViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace MarathonSkills2020.ViewModel.MainWindowSystemViewModel
{
    class WSecondMainWindowSystemViewModel : ViewModel.HelperViewModel.HelperViewModel
    {

        /// <summary>
        /// значение данному свойству передается из класса WMainWindowSystemViewModel при нажатии на кнопку 
        /// </summary>
        public static int NumberOfButtonPressed { get; set; }

        /// <summary>
        /// сохраняет текущую страницу
        /// </summary>

        private Page currentPage;

        public Page CurrentPage
        {
            get => this.currentPage;
            set => this.Set<Page>(ref currentPage, value);
        }

        //свойство для смены заголовка окна
        private string title;
        public string Title
        {
            get => this.title;
            set => this.Set<string>(ref title, value);
        }

        //метод перехода между страницами и смены заголовка окна
        private void SetPages(Page page)
        {
            this.Title = page.Title;
            this.CurrentPage = page;

        }

        public WSecondMainWindowSystemViewModel()
        {

            //CurrentPage = new View.SponsorPages.SponsorRunnerPage();

            //присваиваем делегату метод перехода между страницами
            ViewModel.HelperViewModel.HelperViewModel.setPage = SetPages;


            switch (NumberOfButtonPressed)
            {
                case 1:
                    //вызываем метод который активирует делегат 
                    ViewModel.HelperViewModel.HelperViewModel.SetPage(new View.Runner.RegistrationForAnEvent());
                    break;
                case 2:
                    ViewModel.HelperViewModel.HelperViewModel.SetPage(new View.Sponsor.SponsorRunnerPage());
                    break;
                case 3:
                    ViewModel.HelperViewModel.HelperViewModel.SetPage(new View.MarathonInfo.FindOutMoreInformation());
                    break;
                case 4:
                    ViewModel.HelperViewModel.HelperViewModel.SetPage(new View.LoginPage.PLoginPage());
                    break;
                default:
                    MessageBox.Show("Ошибка передачи параметра нажатой кнопки");
                    break;
            }



        }


    }
}

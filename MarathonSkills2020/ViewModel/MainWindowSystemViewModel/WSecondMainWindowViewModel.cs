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
        public static int NumberOfButtonPressed { get; set; }

        public ICommand BackCommand { get; set; }
        public ICommand LogoutCommand { get; set; }

        public static Action CloseWSecondMainWindow { get; set; }


        private Page currentPage;

        public Page CurrentPage
        {
            get => this.currentPage;
            set => this.Set<Page>(ref currentPage, value);
        }

        private string title;
        public string Title
        {
            get => this.title;
            set => this.Set<string>(ref title, value);
        }

        private void SetPages(Page page)
        {
            this.Title = page.Title;
            this.CurrentPage = page;

        }
        public WSecondMainWindowSystemViewModel()
        {

            ViewModel.HelperViewModel.HelperViewModel.setPage = SetPages;


            switch (NumberOfButtonPressed)
            {
                case 1:
                    CurrentPage = new View.Runner.RegisterAsRunner();
                    break;
                case 2:
                    CurrentPage = new View.Sponsor.SponsorRunnerPage();
                    break;
                case 3:
                    CurrentPage = new View.MarathonInfo.FindOutMoreInformation();
                    break;
                case 4:
                    CurrentPage = new View.LoginPage.PLoginPage();
                    break;
                default:
                    MessageBox.Show("Ошибка передачи параметра нажатой кнопки");
                    break;
            }
            DateTimeStartMarathon = DateTime.ParseExact(DATEMARATHON, "dd/MM/yyyy", null);

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Tick += timerTick;
            dispatcherTimer.Start();


            this.LogoutCommand = new Command(LogoutCommandClick);
            this.BackCommand = new Command(BackCommandClick);
        }
        private string timeBeforeStart;
        public string TimeBeforeStart
        {
            get => this.timeBeforeStart;
            set => Set<string>(ref this.timeBeforeStart, value);
        }

        private const string DATEMARATHON = "29/06/2020"; //Задаем время для старта марафона
        private DateTime DateTimeStartMarathon;
        DispatcherTimer dispatcherTimer;

        private void timerTick(object sender, EventArgs e)
        {
            TimeSpan dateTimeBeforeMarathone = DateTimeStartMarathon.Subtract(DateTime.Now); //Вычитаем текущее время из времени начала марафона
            string daysBeforeMarathon = dateTimeBeforeMarathone.ToString("dd"); //Получаем дни
            string hoursBeforeMarathon = dateTimeBeforeMarathone.ToString("hh"); //Получаем часы
            string minutesBeforeMarathon = dateTimeBeforeMarathone.ToString("mm"); //Получаем минуты
            string seconds = dateTimeBeforeMarathone.ToString("ss"); //Получаем секунды
            TimeBeforeStart = $"{daysBeforeMarathon} дней {hoursBeforeMarathon} часов и {minutesBeforeMarathon} минут до старта марафона!"; //генерируем и присваиваем строку времени до старта

        }

        private void BackCommandClick(object obj)
        {
            this.OpenMainWindow(1);
        }

        private void OpenMainWindow(int numberOfButtonPressed)
        {
            ViewModel.MainWindowSystemViewModel.WSecondMainWindowSystemViewModel.NumberOfButtonPressed = numberOfButtonPressed;
            View.MainWindowSystem.WMainWindowSystem main = new View.MainWindowSystem.WMainWindowSystem();
            main.Show();
            CloseWSecondMainWindow();

        }



        private void LogoutCommandClick(object obj)
        {
            throw new NotImplementedException();
        }


    }
}

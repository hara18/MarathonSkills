using MarathonSkills2020.ViewModel.HelperViewModel;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace MarathonSkills2020.ViewModel.MainWindowSystemViewModel
{
    class WMainWindowSystemViewModel : ViewModel.HelperViewModel.HelperViewModel
    {
        public static Action CloseWindowMain { get; set; }
        public ICommand RunnerCommand { get; set; }
        public ICommand SponsorCommand { get; set; }
        public ICommand InformationCommand { get; set; }
        public ICommand LoginCommand { get; set; }



        private string timeBeforeStart;
        public string TimeBeforeStart
        {
            get => this.timeBeforeStart;
            set => Set<string>(ref this.timeBeforeStart, value);
        }
        public static int NumberOfButtonPressed { get; internal set; }

        private const string DATEMARATHON = "20/08/2020"; //Задаем время для старта марафона
        private DateTime DateTimeStartMarathon;
        DispatcherTimer dispatcherTimer;

        //выполняется при запуске класса
        public WMainWindowSystemViewModel()
        {
            this.RunnerCommand = new Command(RunnerCommandClick);
            this.SponsorCommand = new Command(SponsorCommandClick);
            this.InformationCommand = new Command(InformationCommandClick);
            this.LoginCommand = new Command(LoginCommandClick);

            DateTimeStartMarathon = DateTime.ParseExact(DATEMARATHON, "dd/MM/yyyy", null);

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Tick += timerTick;
            dispatcherTimer.Start();


        }

        //таймер отсчёта даты
        private void timerTick(object sender, EventArgs e)
        {
            TimeSpan dateTimeBeforeMarathone = DateTimeStartMarathon.Subtract(DateTime.Now); //Вычитаем текущее время из времени начала марафона
            string daysBeforeMarathon = dateTimeBeforeMarathone.ToString("dd"); //Получаем дни
            string hoursBeforeMarathon = dateTimeBeforeMarathone.ToString("hh"); //Получаем часы
            string minutesBeforeMarathon = dateTimeBeforeMarathone.ToString("mm"); //Получаем минуты
            string seconds = dateTimeBeforeMarathone.ToString("ss"); //Получаем секунды
            TimeBeforeStart = $"{daysBeforeMarathon} дней {hoursBeforeMarathon} часов и {minutesBeforeMarathon} минут до старта марафона!"; //генерируем и присваиваем строку времени до старта

        }

        //обработчики кнопок
        private void OpenSecondMainWindow(int numberOfButtonPressed)
        {
            ViewModel.MainWindowSystemViewModel.WSecondMainWindowSystemViewModel.NumberOfButtonPressed = numberOfButtonPressed;
            View.MainWindowSystem.SecondMainWindowSystem main = new View.MainWindowSystem.SecondMainWindowSystem();
            main.Show();
            CloseWindowMain();
        }
        private void LoginCommandClick(object obj)
        {
            this.OpenSecondMainWindow(4);
        }
        private void InformationCommandClick(object obj)
        {
            this.OpenSecondMainWindow(3);

        }
        private void SponsorCommandClick(object obj)
        {
            this.OpenSecondMainWindow(2);

        }
        private void RunnerCommandClick(object obj)
        {
            this.OpenSecondMainWindow(1);

        }
    }
}

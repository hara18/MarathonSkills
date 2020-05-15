using MarathonSkills2020.ViewModel.HelperViewModel;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace MarathonSkills2020.ViewModel.MainWindowSystemViewModel
{
    class WMainWindowSystemViewModel : ViewModel.HelperViewModel.HelperViewModel
    {

        /// <summary>
        /// Смотрим в интернете что такое делегаты 
        /// Данный делегат принимает в себя метод для закрытия окна
        /// </summary>
        public static Action CloseWindowMain { get; set; }

        /// <summary>
        /// Свойства связывающие кнопки с окном 
        /// </summary>
        public ICommand RunnerCommand { get; set; }
        public ICommand SponsorCommand { get; set; }
        public ICommand InformationCommand { get; set; }
        public ICommand LoginCommand { get; set; }



        //свойство которые подключено к окну

        private string timeBeforeStart;

        public string TimeBeforeStart
        {
            get => this.timeBeforeStart;
            set => Set<string>(ref this.timeBeforeStart, value);
        }

        private const string DATEMARATHON = "29/06/2020"; //задаем время для старта марафона

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

        private void timerTick(object sender, EventArgs e)
        {


            TimeSpan dateTimeBeforeMarathone = DateTimeStartMarathon.Subtract(DateTime.Now); //вычитаем текущее время из времени начала марафона
            string daysBeforeMaraton = dateTimeBeforeMarathone.ToString("dd");//получаем дни
            string hoursBeforeMaraton = dateTimeBeforeMarathone.ToString("hh");//получаем часы 
            string minutesBeforeMaraton = dateTimeBeforeMarathone.ToString("mm");//получаем минуты 
            string seconds = dateTimeBeforeMarathone.ToString("ss"); //получаем секунды
            TimeBeforeStart = $"{daysBeforeMaraton} дней {hoursBeforeMaraton} часов и {minutesBeforeMaraton} минут до старта марафона!"; //генерируем и присваиваем строку времени до старта
        }

        /// <summary>
        /// Создаем собственный метод, в который добавляем команды 
        /// Открытия нового окна
        /// Передача значения нажатой кнопки
        /// Закрытие текущего окна
        /// </summary>
        private void OpenSecondMainWindow(int numberOfButtonPressed)
        {
            ViewModel.MainWindowSystemViewModel.WSecondMainWindowSystemViewModel.NumberOfButtonPressed = numberOfButtonPressed;
            View.MainWindowSystem.SecondMainWindowSystem main = new View.MainWindowSystem.SecondMainWindowSystem();
            main.Show();
            CloseWindowMain();
        }

        //обработчики кнопок 
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

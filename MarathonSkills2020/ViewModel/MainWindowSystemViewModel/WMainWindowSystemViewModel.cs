using MarathonSkills2020.ViewModel.HelperViewModel;
using System;
using System.Windows;
using System.Windows.Input;

namespace MarathonSkills2020.ViewModel.MainWindowSystemViewModel
{
    class WMainWindowSystemViewModel : ViewModel.HelperViewModel.HelperViewModel
    {
        public static Action CloseWindowMain { get; set; }


    public ICommand RunnerCommand { get; set; }
    public ICommand SponserCommand { get; set; }
    public ICommand InformationCommand { get; set; }
    public ICommand LoginCommand { get; set; }

    public WMainWindowSystemViewModel()
    {
        this.RunnerCommand = new Command(RunnerCommandClick);
        this.SponserCommand = new Command(SponserCommandClick);
        this.InformationCommand = new Command(InformationCommandClick);
        this.LoginCommand = new Command(LoginCommandClick);
    }

    public void RunnerCommandClick(object obj)
    {
        MessageBox.Show("Бегун");
    }

    public void SponserCommandClick(object obj)
    {
        MessageBox.Show("Спонсор");
    }   

    public void InformationCommandClick(object obj)
    {
        MessageBox.Show("Информация");
    }

    public void LoginCommandClick(object obj)
    {
        this.OpenSecondMainWindow(4);
    }

    private void OpenSecondMainWindow(int numberOfButtonPressed)
    {
        WSecondMainWindowSystemViewModel.NumberOfButtonPressed = numberOfButtonPressed;
        View.MainWindowSystem.SecondMainWindowSystem main = new View.MainWindowSystem.SecondMainWindowSystem();

        main.Show();
        CloseWindowMain();
    }
}

}

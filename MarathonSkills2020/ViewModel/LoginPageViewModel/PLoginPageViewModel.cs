using System;
using MarathonSkills2020.ViewModel.HelperViewModel;
using System.Linq;
using System.Windows.Input;

namespace MarathonSkills2020.ViewModel.LoginPageViewModel
{
    class PLoginPageViewModel : HelperViewModel.HelperViewModel
    {
        private string email, password;

    public string Email
    {
        get => this.email;
        set => Set<string>(ref email, value);
    }

    public string Password
    {
        get => this.password;
        set => Set<string>(ref password, value);
    }

    public ICommand LoginCommand { get; set; }
    public ICommand BackCommand { get; set; }

    public PLoginPageViewModel()
    {
        this.LoginCommand = new Command(LoginCommandClick);
        this.BackCommand = new Command(BackCommandClick);
    }

    private void BackCommandClick(object obj)
    {
    }

    private void LoginCommandClick(object obj)
    {
        var user = base.context.User.Where(i => i.Email == this.Email && i.Password == this.Password);

        if (user.Count() > 0)
        {
            switch (Convert.ToChar(user.FirstOrDefault().RoleId))
            {
                case 'A':
                    base.MessageBoxInformation("Вы успешно вошли как администратор");
                    break;
                case 'C':
                    base.MessageBoxInformation("Вы успешно вошли как координатор");
                    break;
                case 'R':
                    base.MessageBoxInformation("Вы успешно вошли как бегун");
                    break;
            }
        }
        else
        {
            base.MessageBoxError("Неправильный логин или пароль");
        }
    }
}
}

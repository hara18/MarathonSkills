using System;
using MarathonSkills2020.ViewModel.HelperViewModel;
using System.Linq;
using System.Windows.Input;

namespace MarathonSkills2020.ViewModel.LoginPageViewModel
{
    class PLoginPageViewModel : HelperViewModel.HelperViewModel
    {

            public static Model.User User { get; set; }

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

            //Обработчики кнопок

            public ICommand LoginCommand { get; set; }

            public ICommand BackCommand { get; set; }



            public PLoginPageViewModel()
            {

                this.LoginCommand = new Command(LoginCommandClick);
                this.BackCommand = new Command(BackCommandClick);

            }


            private void BackCommandClick(object obj)
            {
                throw new NotImplementedException();
            }

            //Авторизация пользователя
            private void LoginCommandClick(object obj)
            {
                //Поиск пользователя с таким же именем и паролем
                var user = base.context.User.Where(i => i.Email == this.Email && i.Password == this.Password);

                //Если кол-во пользователей больше одного
                //то далее проверяется роль пользователя
                //в ином случае просим ввести логин и пароль повторно
                if (user.Count() > 0)
                {
                    User = user.FirstOrDefault();

                    if (Convert.ToChar(user.FirstOrDefault().RoleId) == 'A')
                    {
                        base.MessageBoxInformation("Вы успешно вошли как администратор");

                    }
                    else if (Convert.ToChar(user.FirstOrDefault().RoleId) == 'C')
                    {
                        base.MessageBoxInformation("Вы успешно вошли как координатор");

                    }
                    else if (Convert.ToChar(user.FirstOrDefault().RoleId) == 'R')
                    {
                        ViewModel.HelperViewModel.HelperViewModel.SetPage(new View.Runner.MainPageRunner());

                    }
                }
                else
                {
                    base.MessageBoxError("Неправильный логин или пароль");
                }

            }
        }
    }
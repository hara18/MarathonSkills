using MarathonSkills2020.ViewModel.HelperViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MarathonSkills2020.ViewModel.RunnerPagesViewModel
{
    class NewRunnerPageViewModel : HelperViewModel.HelperViewModel
    {

        #region Свойства
        private string email, password, repeatPassword, firstName, lastName, pathFile;

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
        public string RepeatPassword
        {
            get => this.repeatPassword;
            set => Set<string>(ref repeatPassword, value);
        }
        public string FirstName
        {
            get => this.firstName;
            set => Set<string>(ref firstName, value);

        }

        public string LastName
        {
            get => this.lastName;
            set => Set<string>(ref lastName, value);
        }
        public string PathFile
        {
            get => this.pathFile;
            set => Set<string>(ref pathFile, value);
        }

        private int genderSelectedIndex;
        public int GenderSelectedIndex
        {
            get => this.genderSelectedIndex;
            set => Set<int>(ref genderSelectedIndex, value);
        }

        public ICommand SelectImageCommand { get; set; }
        public ICommand RegistrationCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        private DateTime selectBithdate;

        public DateTime SelectBithdate
        {
            get => selectBithdate;
            set => Set<DateTime>(ref selectBithdate, value);
        }

        private List<Model.Country> listCountries;
        public List<Model.Country> ListCountries
        {
            get => this.listCountries;
            set => Set<List<Model.Country>>(ref listCountries, value);
        }

        private Model.Country selectedCountry;
        public Model.Country SelectedCountry
        {
            get => this.selectedCountry;
            set => Set<Model.Country>(ref selectedCountry, value);
        }


        #endregion 


        public NewRunnerPageViewModel()
        {
            try
            {
                this.SelectImageCommand = new Command(SelectImageCommandClick);
                this.RegistrationCommand = new Command(RegistrationCommandClick);
                this.CancelCommand = new Command(CancelCommandClick);
                this.SelectBithdate = DateTime.Now;

                this.ListCountries = this.context.Country.ToList();


            }
            catch (Exception ex)
            {
                this.MessageBoxError(ex);
            }
        }



        #region Обработчики кнопок 


        private void CancelCommandClick(object obj)
        {
            try
            {

            }
            catch (Exception ex)
            {
                this.MessageBoxError(ex);
            }
        }

        private void RegistrationCommandClick(object obj)
        {
            try
            {
                if (this.CheckFillFields() && this.CheckPassword(this.Password, this.RepeatPassword)
                    && this.CheckEmailAddress(this.Email) && this.CheckDateBirthDate(this.SelectBithdate))
                {
                    Classes.Images images = new Classes.Images();
                    string gender;
                    byte[] image = null;


                    if (string.IsNullOrWhiteSpace(this.PathFile))
                    {
                        image = images.ConvertImageToByte(this.PathFile);
                    }


                    if (this.GenderSelectedIndex == 0)
                    {
                        gender = "Male";

                    }
                    else
                    {
                        gender = "Female";
                    }

                    Model.User user = new Model.User()
                    {
                        Email = this.Email,
                        Password = this.Password,
                        FirstName = this.FirstName,
                        LastName = this.LastName,
                        RoleId = "R"
                    };

                    Model.Runner runner = new Model.Runner()
                    {
                        Email = this.Email,
                        Gender = gender,
                        DateOfBirth = this.SelectBithdate,
                        CountryCode = this.SelectedCountry.CountryCode,

                    };

                    context.User.Add(user);
                    context.Runner.Add(runner);


                    this.context.SaveChanges();

                    this.MessageBoxInformation("Бегун успешно добавлен");


                }
                else
                {
                    this.MessageBoxInformation("Бегун успешно добавлен");
                    return;

                }


            }
            catch (Exception ex)
            {
                this.MessageBoxError(ex);
            }
        }


        private void SelectImageCommandClick(object obj)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.FileName = "Image";
                openFileDialog.DefaultExt = ".png";
                openFileDialog.Filter = string.Empty;

                Nullable<bool> result = openFileDialog.ShowDialog();

                if (result == true)
                {
                    this.PathFile = openFileDialog.FileName;
                }
            }
            catch (Exception ex)
            {
                this.MessageBoxError(ex);
            }

        }


        #endregion

        #region Методы 

        /// <summary>
        /// Проверка пароля на соответствие требованиям
        /// </summary>
        /// <param name="password">пароль</param>
        /// <param name="repeatPassword">повтор пароля</param>
        /// <returns></returns>
        private bool CheckPassword(string password, string repeatPassword)
        {

            try
            {
                if (password.Length < 6)
                {
                    Console.WriteLine("Пароль должен содержать не менее 6 символов");

                    return false;
                }

                if (!Regex.IsMatch(password, @"[0-9]") ||
                    !Regex.IsMatch(password, @"[A-Z]") ||
                    !Regex.IsMatch(password, @"[!@#$%^]")
                    )
                {
                    Console.WriteLine("Пароль должен содержать минимум 1 цифру, 1 символ из верхнего регистра, состоять из латиницы и" +
                        "содержать по крайней мере один из следующих символов: ! @ # $ % ^");

                    return false;
                }

                if (password != repeatPassword)
                {
                    Console.WriteLine("Не совпадают");
                    return false;
                }

                return true;

            }
            catch (Exception ex)
            {
                this.MessageBoxError(ex);
                return false;
            }

        }

        /// <summary>
        /// проверка на заполнение полей
        /// </summary>
        /// <returns>результат проверки</returns>
        private bool CheckFillFields()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(this.Email) ||
                    string.IsNullOrWhiteSpace(this.Password) ||
                    string.IsNullOrWhiteSpace(this.RepeatPassword) ||
                    string.IsNullOrWhiteSpace(this.FirstName) ||
                    string.IsNullOrWhiteSpace(this.LastName)
                    )
                {
                    this.MessageBoxWarning("Все поля содержащие - *, должны быть заполнены");
                    return false;
                }

                if (GenderSelectedIndex < 0)
                {
                    this.MessageBoxWarning("Выберите пол");
                    return false;
                }
                if (this.SelectBithdate == null)
                {
                    this.MessageBoxWarning("Выберите дату");
                    return false;
                }

                if (this.SelectedCountry == null)
                {
                    this.MessageBoxWarning("Выберите страну");
                    return false;
                }

                return true;

            }
            catch (Exception ex)
            {
                this.MessageBoxError(ex);
                return false;
            }
        }


        /// <summary>
        /// Проверка корректости email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        private bool CheckEmailAddress(string email)
        {
            try
            {

                try
                {
                    if (email.EndsWith("."))
                    {

                        this.MessageBoxWarning("Неверный формат Email");
                        return false;
                    }

                    var mail = new System.Net.Mail.MailAddress(email);

                    if (mail.Address == email)
                    {
                        return true;
                    }
                    return false;
                }
                catch
                {
                    this.MessageBoxWarning("Неверный формат Email");
                    return false;
                }


            }
            catch (Exception ex)
            {
                this.MessageBoxError(ex);
                return false;
            }
        }

        /// <summary>
        /// Проверка на соответствие возрасту 
        /// </summary>
        /// <param name="birthdate"></param>
        /// <returns></returns>
        private bool CheckDateBirthDate(DateTime birthdate)
        {
            try
            {
                DateTime nowDate = DateTime.Today;
                int age = nowDate.Year - birthdate.Year;
                if (age >= 10)
                {

                    return true;
                }
                else
                {
                    this.MessageBoxWarning("Возраст бегуна должен быть не менее 10 лет");
                    return false;
                }

            }
            catch (Exception ex)
            {
                this.MessageBoxError(ex);
                return false;
            }
        }




        #endregion

    }
}

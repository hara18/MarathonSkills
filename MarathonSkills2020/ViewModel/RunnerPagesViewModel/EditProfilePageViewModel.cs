using MarathonSkills2020.ViewModel.HelperViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MarathonSkills2020.ViewModel.RunnerPagesViewModel
{
    class EditProfilePageViewModel : HelperViewModel.HelperViewModel
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
        public ICommand SaveCommand { get; set; }
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

        private Model.User user;

        public EditProfilePageViewModel()
        {
            this.SelectImageCommand = new Command(SelectImageCommandClick);
            this.SaveCommand = new Command(SaveCommandClick);
            this.CancelCommand = new Command(CancelCommandClick);

            //данные о бегуне

            user = ViewModel.LoginPageViewModel.PLoginPageViewModel.User;
            this.Email = this.user.Email;
            this.FirstName = this.user.FirstName;
            this.LastName = this.user.LastName;


        }

        private void CancelCommandClick(object obj)
        {

        }

        private void SaveCommandClick(object obj)
        {
            this.MessageBoxInformation("Данные о профиле успешно отредактированы");
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
    }
}

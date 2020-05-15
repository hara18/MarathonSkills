using MarathonSkills2020.ViewModel.HelperViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MarathonSkills2020.ViewModel.RunnerPagesViewModel
{
    class MainPageRunnerViewModel : HelperViewModel.HelperViewModel
    {

        public ICommand RegistrationOnMarathonCommand { get; set; }
        public ICommand EditProfileCommand { get; set; }
        public ICommand ContactsCommand { get; set; }
        public ICommand MyResultsCommand { get; set; }
        public ICommand MySponsorCommand { get; set; }


        public MainPageRunnerViewModel()
        {
            this.RegistrationOnMarathonCommand = new Command(RegistrationOnMarathonCommandClick);
            this.EditProfileCommand = new Command(EditProfileCommandClick);
            this.ContactsCommand = new Command(ContactsCommandClick);
            this.MyResultsCommand = new Command(MyResultsCommandClick);
            this.MySponsorCommand = new Command(MySponsorCommandClick);

        }

        private void MySponsorCommandClick(object obj)
        {

        }

        private void MyResultsCommandClick(object obj)
        {

        }

        private void ContactsCommandClick(object obj)
        {

        }

        private void EditProfileCommandClick(object obj)
        {
            SetPage(new View.Runner.EditProfilePage());
        }

        private void RegistrationOnMarathonCommandClick(object obj)
        {

        }
    }
}

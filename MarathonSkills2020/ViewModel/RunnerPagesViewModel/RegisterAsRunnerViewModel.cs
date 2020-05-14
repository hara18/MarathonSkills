using MarathonSkills2020.ViewModel.HelperViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MarathonSkills2020.ViewModel.RunnerPagesViewModel
{
    class RegisterAsRunnerViewModel
    {

        public ICommand LoginCommand { get; set; }
        public RegisterAsRunnerViewModel()
        {


            this.LoginCommand = new Command(LoginCommandClick);


        }
        private void LoginCommandClick(object obj)
        {


            ViewModel.HelperViewModel.HelperViewModel.SetPage(new View.Runner.RegistrationForAnEvent());

        }
    }
}

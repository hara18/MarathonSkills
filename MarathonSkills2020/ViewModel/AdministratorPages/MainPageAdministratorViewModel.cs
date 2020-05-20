using Eco.Persistence;
using MarathonSkills2020.Model;
using MarathonSkills2020.ViewModel.HelperViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MarathonSkills2020.ViewModel.AdministratorPages
{
    class MainPageAdministratorViewModel : HelperViewModel.HelperViewModel
    {

        public ICommand UsersCommand { get; set; }
        public ICommand OrganizationsCommand { get; set; }
        public ICommand VolontersCommand { get; set; }
        public ICommand InventoryCommand { get; set; }

        public MainPageAdministratorViewModel()
        {
            UsersCommand = new Command(UsersCommandClick);
            OrganizationsCommand = new Command(OrganizationsCommandClick);
            VolontersCommand = new Command(VolontersCommandClick);
            InventoryCommand = new Command(InventoryCommandClick);
        }

        private void UsersCommandClick (object obj)
        {

        }

        private void OrganizationsCommandClick(object obj)
        {

        }

        private void VolontersCommandClick(object obj)
        {

        }

        private void InventoryCommandClick(object obj)
        {
            SetPage(new View.AdministratorPages.InventoryPages());
        }
    }
}

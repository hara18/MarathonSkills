using MarathonSkills2020.ViewModel.HelperViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace MarathonSkills2020.ViewModel.AdministratorPages
{
    class InventoryPageViewModel : HelperViewModel.HelperViewModel
    {

        public ICommand PrintReportCommand { get; set; }

        public List<Model.User> ListInventory { get; set; }

        public InventoryPageViewModel()
        {
            PrintReportCommand = new Command(PrintReportCommandClick);
        }

        private void PrintReportCommandClick(object obj)
        {
            PrintDialog printDialog = new PrintDialog();

            printDialog.ShowDialog();

            ListInventory = this.context.User.ToList();
        }
    }
}

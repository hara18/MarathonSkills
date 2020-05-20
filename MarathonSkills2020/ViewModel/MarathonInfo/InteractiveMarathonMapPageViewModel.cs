using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MarathonSkills2020.ViewModel.HelperViewModel;

namespace MarathonSkills2020.ViewModel.MarathonInfo
{
    class InteractiveMarathonMapPageViewModel: HelperViewModel.HelperViewModel
    {
        public ICommand CommandHidden { get; set; }

        public Visibility VisibleInformation { get; set; }

        public InteractiveMarathonMapPageViewModel()
        {
            VisibleInformation = Visibility.Visible;

            CommandHidden = new Command(CommandHiddenClick);
        }

        private void CommandHiddenClick(object obj)
        {
            VisibleInformation = Visibility.Hidden;
        }
    }
}

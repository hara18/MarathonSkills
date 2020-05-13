using MarathonSkills2020.ViewModel.HelperViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MarathonSkills2020.ViewModel.SponsorRunnerPageViewModel
{
    class SponsorRunnerPageViewModel : HelperViewModel.HelperViewModel
    {

        public static int SumDonationStatic { get; set; }

        public static string NameRunnerStatic { get; set; }

        private string name;

        private int sumDonation;

        public string NameRunner

        {

            get => this.name;

            set => Set<string>(ref name, value);

        }

        public int SumDonation

        {

            get => this.sumDonation;

            set => Set<int>(ref sumDonation, value);

        }

        public ICommand PayCommand { get; set; }

        public ICommand CancelCommand { get; set; }

        public ICommand MinCommand { get; set; }

        public ICommand PlusCommand { get; set; }

        public SponsorRunnerPageViewModel()

        {

            this.SumDonation = 0;

            this.PayCommand = new Command(PayCommandClick);

            this.CancelCommand = new Command(CancelCommandClick);

            this.MinCommand = new Command(MinCommandClick);

            this.PlusCommand = new Command(PlusCommandClick);

        }


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

        private void PayCommandClick(object obj)

        {

            SumDonationStatic = this.SumDonation;

            NameRunnerStatic = this.NameRunner;

            ViewModel.HelperViewModel.HelperViewModel.SetPage(new View.Sponsor.SponsorshipConfirmationPage());

        }


        private void PlusCommandClick(object obj)

        {

            this.SumDonation += 10;

        }

        private void MinCommandClick(object obj)

        {

            this.SumDonation -= 10;

            if (this.SumDonation < 0)

            {

                this.SumDonation = 0;

            }

        }

    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarathonSkills2020.ViewModel.SponsorRunnerPageViewModel
{
    class SponsorShipConfirmationPageViewModel : HelperViewModel.HelperViewModel
    {

        private int sumDonation;

        public int SumDonation

        {

            get => this.sumDonation;

            set => Set<int>(ref sumDonation, value);

        }

        private string nameRunner;

        public string NameRunner

        {

            get => this.nameRunner;

            set => Set<string>(ref nameRunner, value);

        }

        public SponsorShipConfirmationPageViewModel()

        {

            this.SumDonation = ViewModel.SponsorRunnerPageViewModel.SponsorRunnerPageViewModel.SumDonationStatic;

            this.NameRunner = ViewModel.SponsorRunnerPageViewModel.SponsorRunnerPageViewModel.NameRunnerStatic;

        }

    }

}


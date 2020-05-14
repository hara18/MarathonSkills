using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MarathonSkills2020.ViewModel.RunnerPagesViewModel
{
    class RegistrationForAnEventViewModel : HelperViewModel.HelperViewModel
    {

        #region Свойства
        private bool fullMarathon, middleMarathon, smallMarathon,
            optionA, optionB, optionC;
        private int sum;

        public int Sum
        {
            get => this.sum;
            set => Set<int>(ref sum, value);
        }
        public bool FullMarathon
        {
            get
            {
                return fullMarathon;
            }
            set
            {

                Set<bool>(ref fullMarathon, value);
            }
        }

        public bool MiddleMarathon
        {
            get
            {

                return middleMarathon;
            }
            set => Set<bool>(ref middleMarathon, value);
        }

        public bool SmallMarathon
        {
            get
            {

                return smallMarathon;
            }
            set => Set<bool>(ref smallMarathon, value);
        }

        public bool OptionA
        {
            get => this.optionA;
            set => Set<bool>(ref optionA, value);
        }

        public bool OptionB
        {
            get => this.optionB;
            set => Set<bool>(ref optionB, value);
        }

        public bool OptionC
        {
            get => this.optionC;
            set => Set<bool>(ref optionC, value);
        }

        public ICommand CommandEnterReg { get; set; }

        public ICommand CommandRegister { get; set; }

        private int sumDonation;

        public int SumDonation
        {
            get => this.sumDonation;
            set => this.Set<int>(ref sumDonation, value);
        }

        #endregion 

        public RegistrationForAnEventViewModel()
        {
            FullMarathon = true;
            MiddleMarathon = false;
            SmallMarathon = false;

            sumDonation = 100;

            OptionC = true;

            this.CommandRegister = new HelperViewModel.Command(CommandRegisterClick);


            GenerateSum();

        }

        

        private void CommandRegisterClick(object obj)
        {
            MessageBoxInformation("Регистрация на марафон прошла успешно");
        }

        private void GenerateSum()
        {
            sum = 0;
            if (FullMarathon)
            {
                sum += 145;
            }
            else if (MiddleMarathon)
            {
                sum += 75;
            }
            else if (SmallMarathon)
            {
                sum += 20;
            }
            else if (OptionB)
            {
                sum += 20;
            }
            else if (OptionC)
            {
                sum += 45;
            }

            sum += SumDonation;

            sum += 45;

            this.Sum = sum;

        }






    }
}
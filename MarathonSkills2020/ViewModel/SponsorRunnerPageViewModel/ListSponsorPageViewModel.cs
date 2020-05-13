using MarathonSkills2020.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarathonSkills2020.ViewModel.SponsorRunnerPageViewModel
{
    class ListSponsorPageViewModel : ViewModel.HelperViewModel.HelperViewModel
    {

        public List<Sponsorship> ListSponsors { get; set; }


        public ListSponsorPageViewModel()
        {
            ListSponsors = context.Sponsorship.ToList();
        }
    }
}

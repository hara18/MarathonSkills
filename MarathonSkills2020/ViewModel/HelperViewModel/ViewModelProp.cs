using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MarathonSkills2020.ViewModel.HelperViewModel
{
    class ViewModelProp : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        protected void Set<T>(ref T field, T value, [CallerMemberName] string prop = "")
        {
            if (Equals(field, value))
                return;
            field = value;
            OnPropertyChanged(prop);
        }
    }
}

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace _3DVectors.Model
{
    #region ViewModelBase
    public class ViewModelBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] String propName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        #endregion INotifyPropertyChanged
    }
    #endregion ViewModelBase
}

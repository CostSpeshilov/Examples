using MvvmDemoApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MvvmDemoApp.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            Repository repository = new Repository();
            group = new GroupViewModel(repository.GetGroup(), this);
        }

        private ViewModelBase group;

        public ViewModelBase Content
        {
            get => group;
            set
            {
                if (group == value) return;
                group = value;
                OnPropertyChanged();
            }
        }        
    }
}

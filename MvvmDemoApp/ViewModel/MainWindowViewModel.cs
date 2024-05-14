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
            _content = new GroupViewModel(repository.GetGroup());
            _content.NavigateToRequested += _content_NavigateToRequested;
        }

        private void _content_NavigateToRequested(object? sender, ViewModelBase e)
        {
            Content = e;
            e.NavigateToRequested += _content_NavigateToRequested;
        }

        private ViewModelBase _content;

        public ViewModelBase Content
        {
            get => _content;
            set
            {
                if (_content == value) return;
                _content = value;
                OnPropertyChanged();
            }
        }
    }
}

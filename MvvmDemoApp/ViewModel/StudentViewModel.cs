using DemoApp;
using MvvmDemoApp.Model;
using System;
using System.Windows.Input;

namespace MvvmDemoApp.ViewModel
{
    public class StudentViewModel  : ViewModelBase
    {
        public string Name
        {
            get => student.Name;
            set
            {
                if (student.Name == value) return;
                student.Name = value;
                OnPropertyChanged();
            }
        }

        public string Surname
        {
            get => student.Surname;
            set
            {
                if (student.Surname == value) return;
                student.Surname = value;
                OnPropertyChanged();
            }
        }
        
        private Student student;

        public StudentViewModel(Student student)
        {
            this.student = student;
        }

        public string Birthday
        {
            get => student.Birthday.ToShortDateString();
            set
            {
                if (student.Birthday.ToShortDateString() == value) return;
                student.Birthday = DateTime.Parse(value);
                OnPropertyChanged();
            }
        }

        public ICommand ToGroup
            => new RelayCommand((_) => ToGroupImpl());

        private void ToGroupImpl()
        {
            NavigateTo(new GroupViewModel(student.Group));
        }
        

        public ICommand ChangeSurname
            => new RelayCommand((_) => ChangeSurnameImpl());

        private void ChangeSurnameImpl()
        {
            Surname += "s";
        }
    }
}
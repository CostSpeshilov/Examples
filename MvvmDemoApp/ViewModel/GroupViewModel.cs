using DemoApp;
using MvvmDemoApp.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace MvvmDemoApp.ViewModel
{
    public class GroupViewModel : ViewModelBase
    {
        private Group group;
        private readonly MainWindowViewModel mwVm;
        private ObservableCollection<StudentShortViewModel> students;
        private StudentShortViewModel selectedStudent;

        public GroupViewModel(Group _group,
            MainWindowViewModel mwVm)
        {
            this.group = _group;
            this.mwVm = mwVm;
            IEnumerable<StudentShortViewModel> studentsVMs =
                from student in _group.Students
                select new StudentShortViewModel(student);
            students = new ObservableCollection<StudentShortViewModel>(studentsVMs);
        }

        public string Name
        {
            get => group.Name;
            set
            {
                if (group.Name == value) return;
                group.Name = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<StudentShortViewModel> Students
        {
            get => students;
            set => students = value;
        }


        public ICommand ShowStudent
        {
            get
            {
                return new RelayCommand(
                    (_) => ShowStudentImpl(),
                    (_) => CanShowStudent());
            }
        }

        public StudentShortViewModel SelectedStudent
        {
            get => selectedStudent;
            set
            {
                if (selectedStudent == value) return;
                selectedStudent = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsVisible));
            }
        }

        private void ShowStudentImpl()
        {
            Student student = group.Students.First(x => x.Surname + x.Name[0] == selectedStudent.FIO);
            mwVm.Content = new StudentViewModel(student, mwVm);
        }

        private bool CanShowStudent()
        {
            return selectedStudent != null;
        }

        public bool IsVisible => CanShowStudent();
    }
}
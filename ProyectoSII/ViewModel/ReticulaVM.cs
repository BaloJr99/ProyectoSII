using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace ProyectoSII.ViewModel
{
    public class ReticulaVM: INotifyPropertyChanged
    {
        public List<Semester> Semesters { get; set; }

        public ReticulaVM()
        {
            Semesters = GetSemesters().OrderBy(s => s.Key).ToList();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private Semester _selectedSemester { get; set; }
        public Semester SelectedSemester
        {
            get { return _selectedSemester; }
            set
            {
                if(_selectedSemester != value)
                {
                    _selectedSemester = value;
                }
            }
        }

        public List<Semester> GetSemesters()
        {
            var semesters = new List<Semester>()
            {
                new Semester(){Key = 1, Value = "Semestre 1"},
                new Semester(){Key = 2, Value = "Semestre 2"},
                new Semester(){Key = 3, Value = "Semestre 3"},
                new Semester(){Key = 4, Value = "Semestre 4"},
                new Semester(){Key = 5, Value = "Semestre 5"},
                new Semester(){Key = 6, Value = "Semestre 6"},
                new Semester(){Key = 7, Value = "Semestre 7"},
                new Semester(){Key = 8, Value = "Semestre 8"},
                new Semester(){Key = 9, Value = "Semestre 9"},
                new Semester(){Key = 10, Value = "Semestre 10"},
                new Semester(){Key = 11, Value = "Semestre 11"},
                new Semester(){Key = 12, Value = "Semestre 12"},
            };

            return semesters;
        }
        
    }

    public class Semester
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }
}

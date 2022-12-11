using System;
using System.Collections.Generic;
using System.ComponentModel;
using OralHistory.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace OralHistory.ViewModels
{
    public class AlumniViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Alumni alumni;

        public AlumniViewModel()
        {
            alumni = new Alumni();
        }

        public string IsAlumni
        {
            get { return alumni.IsAlumni; }
            set
            {
                alumni.IsAlumni = value;
                OnPropertyChanged("IsAlumni");
            }
        }

        public string FirstName
        {
            get { return alumni.FirstName; }
            set
            {
                alumni.FirstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get { return alumni.LastName; }
            set
            {
                alumni.LastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public string MaidenName
        {
            get { return alumni.MaidenName; }
            set
            {
                alumni.MaidenName = value;
                OnPropertyChanged("MaidenName");
            }
        }

        private void OnPropertyChanged(string property)
        {
            // Notify any controls bound to the ViewModel that the property changed
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}

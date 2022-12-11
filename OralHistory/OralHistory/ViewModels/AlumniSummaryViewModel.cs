using OralHistory.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OralHistory.ViewModels
{
    public class AlumniSummaryViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private AlumniSummary alumniSummary;

        public Alumni alumni { get; set; }

        public AlumniSummaryViewModel()
        {
            this.alumniSummary = new AlumniSummary();

            alumni = new Alumni();
            // Create ViewModel
            var newSummary = new AlumniViewModel { IsAlumni = alumni.IsAlumni, FirstName = alumni.FirstName, LastName = alumni.LastName, MaidenName = alumni.MaidenName };
            newSummary.PropertyChanged += OnPropertyChanged;
            alumniSummary.alumni = newSummary.alumni;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(sender, e);
        }
    }
}

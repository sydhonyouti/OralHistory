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

        // ViewModel has instance to model
        private Alumni alumni;

        public Story story { get; set; }

        public AlumniViewModel()
        {
            this.alumni = new Alumni();

            story = new Story();
            // Create ViewModel for story
            var newStory = new StoryViewModel { Length = story.Length, Tags = story.Tags};
            newStory.PropertyChanged += OnPropertyChanged;
        }

        public string IsAlumni
        {
            get { return alumni.IsAlumni; }
            set
            {
                alumni.IsAlumni = value;
                OnPropertyChanged(this, new PropertyChangedEventArgs("IsAlumni"));
            }
        }

        public string FirstName
        {
            get { return alumni.FirstName; }
            set
            {
                alumni.FirstName = value;
                OnPropertyChanged(this, new PropertyChangedEventArgs("FirstName"));
            }
        }

        public string LastName
        {
            get { return alumni.LastName; }
            set
            {
                alumni.LastName = value;
                OnPropertyChanged(this, new PropertyChangedEventArgs("LastName"));
            }
        }

        public string MaidenName
        {
            get { return alumni.MaidenName; }
            set
            {
                alumni.MaidenName = value;
                OnPropertyChanged(this, new PropertyChangedEventArgs("MaidenName"));
            }
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // Theater name or MovieViewModel changed, so let UI know
            PropertyChanged?.Invoke(sender, e);
        }
    }
}

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

        public Story Story { get; set; }

        public AlumniViewModel()
        {
            this.alumni = new Alumni();

            Story = new Story();

            // Create ViewModels for each Story
            //foreach (var story in alumni.Story)
            //{
            //    var newMovie = new MovieViewModel { Title = movie.Title, Rating = movie.Rating };
            //    newMovie.PropertyChanged += OnPropertyChanged;
            //    Movies.Add(newMovie);
            //}
        }

        //public TheaterViewModel()
        //{
        //    this.theater = new Theater();

        //    Movies = new ObservableCollection<MovieViewModel>();

        //    // Create ViewModels for each Movie
        //    foreach (var movie in theater.Movies)
        //    {
        //        var newMovie = new MovieViewModel { Title = movie.Title, Rating = movie.Rating };
        //        newMovie.PropertyChanged += OnPropertyChanged;
        //        Movies.Add(newMovie);
        //    }
        //}

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

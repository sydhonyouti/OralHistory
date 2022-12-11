using OralHistory.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OralHistory.ViewModels
{
    public class StoryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // ViewModel has instance to Model
        private Story story;

        public StoryViewModel()
        {
            story = new Story();
        }

        // Public properties to expose to View (UI)
        public string Length
        {
            get
            {
                return story.Length;
            }
            set
            {
                story.Length = value;
                OnPropertyChanged("Length");
            }
        }

        public List<string> Tags
        {
            get { return story.Tags; }

            set
            {
                story.Tags = value;
                OnPropertyChanged("Tags");
            }

        }

        private void OnPropertyChanged(string property)
        {
            // Notify any controls bound to the ViewModel that the property changed
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

    }
}

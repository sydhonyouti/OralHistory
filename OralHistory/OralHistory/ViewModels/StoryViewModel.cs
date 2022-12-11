using OralHistory.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OralHistory.ViewModels
{
    public class StoryViewModel
    {
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
            }
        }

        public List<string> Tags
        {
            get { return story.Tags; }

            set
            {
                story.Tags = value;
            }

        }
    }
}

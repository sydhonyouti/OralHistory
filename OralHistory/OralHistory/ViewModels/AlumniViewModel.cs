using System;
using System.Collections.Generic;
using System.ComponentModel;
using OralHistory.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OralHistory.ViewModels
{
    public class AlumniViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // ViewModel has instance to model
        private Alumni alumni;

        public AlumniViewModel()
        {
            alumni = new Alumni();
        }

        // Public property to expose to the View

    }
}

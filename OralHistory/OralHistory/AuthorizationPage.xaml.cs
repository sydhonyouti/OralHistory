using OralHistory.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace OralHistory
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AuthorizationPage : Page
    {
        public AlumniViewModel Alumni { get; set; }
        public AlumniSummaryViewModel AlumniSummary { get; set; }

        public AuthorizationPage()
        {
            this.InitializeComponent();

            Alumni = new AlumniViewModel();
            AlumniSummary = new AlumniSummaryViewModel();


            // Locking the window resizing 
            var size = new Size(3000, 2000);
            ApplicationView.PreferredLaunchViewSize = size;
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            Window.Current.CoreWindow.SizeChanged += (s, e) =>
            {
                ApplicationView.GetForCurrentView().TryResizeView(size);
            };

        }

        private void Authorization_btn_Click(object sender, RoutedEventArgs e)
        {
            Alumni.FirstName = firstName_textBox.Text;

            Frame.Navigate(typeof(RecordingPage), Alumni.FirstName);
        }
    }

}


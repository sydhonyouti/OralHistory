using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
    public sealed partial class RequirementsPage : Page
    {
        public RequirementsPage()
        {
            this.InitializeComponent();

            // Locking the window resizing 
            var size = new Size(3000, 2000);
            ApplicationView.PreferredLaunchViewSize = size;
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            Window.Current.CoreWindow.SizeChanged += (s, e) =>
            {
                ApplicationView.GetForCurrentView().TryResizeView(size);
            };
        }

        // Continue button is disabled but once the last checkbox is clicked it will be enabled
        // and take the user to the next frame
        private void Continue_btn_req_Click(object sender, RoutedEventArgs e)
        {            
            Frame.Navigate(typeof(AuthorizationPage));
        }

        // The continue button will be enabled once the last checkbox is clicked
        private void historyBoothCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (historyBoothCheckBox.IsChecked == true && researchCheckBox.IsChecked == true)
            {
                Continue_btn_req.IsEnabled = true;
            }
            
        }

        // This is letting the user check the second box first and then the first
        private void researchCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (researchCheckBox.IsChecked == true && historyBoothCheckBox.IsChecked == true)
            {
                Continue_btn_req.IsEnabled = true;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class AdminLoginPage : Page
    {
        
        public AdminLoginPage()
        {
            this.InitializeComponent();
        }

        public bool checkUsername()
        {
            if (userNameTextBox.Text == string.Empty)
            {
                errorTitle.Visibility = Visibility;
                errorTitle.Text = "Please input a username";
                return false;
            }
            else
            {
                return true;
            }
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            bool canContinue = false;
            // Check to see if the user has the username textbox filled
            canContinue = checkUsername();
            if (canContinue)
            {
                Frame.Navigate(typeof(AdminMainPage));
            }
            
        }
    }
}

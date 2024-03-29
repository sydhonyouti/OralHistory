﻿using System;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace OralHistory
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
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

            NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        private void Continue_btn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RequirementsPage));
        }

        private void adminLockButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AdminLoginPage));
        }
    }
}

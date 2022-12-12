using OralHistory.Model;
using OralHistory.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Capture;
using Windows.Media.MediaProperties;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Core;
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
    public sealed partial class RecordingPage : Page
    {
        // Recording
        private MediaCapture mediaCapture;
        MediaCapture capture;
        InMemoryRandomAccessStream buffer;
        bool record;
        string filename;
        string audioFile = ".MP3";

        // Acess Viewmodels for Data Binding 
        public AlumniViewModel Alumni { get; set; }
        public AlumniSummaryViewModel AlumniSummary { get; set; }

        public RecordingPage()
        {
            this.InitializeComponent();
            //this._audioRecorder = new AudioRecorder();

            // Locking the window resizing 
            var size = new Size(3000, 2000);
            ApplicationView.PreferredLaunchViewSize = size;
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            Window.Current.CoreWindow.SizeChanged += (s, e) =>
            {
                ApplicationView.GetForCurrentView().TryResizeView(size);
            };

        }

        // Debug.WriteLine(ApplicationData.Current.LocalFolder.Path);
        // C:\Users\sydho\AppData\Local\Packages\f196cea9-9762-4cd8-b0ed-333f6a6ec8f4_ndpsv4rq6hezc\LocalState
        // Source: https://www.c-sharpcorner.com/UploadFile/2b876a/audio-recorder-in-windows-10-universal-windows-platform/

        private async Task<bool> RecordProcess()
        {
            /*---- xaml update ------*/
            Recording_State_Text.Text = "Recording...";

            stop_btn.IsEnabled = true;
            pause_btn.IsEnabled = true;
            resume_btn.IsEnabled = true;
            play_btn.IsEnabled = true;

            stop_btn.Opacity = 100;
            pause_btn.Opacity = 100;
            resume_btn.Opacity = 100;
            play_btn.Opacity = 100;
            /*-----------------------*/

            if (buffer != null)
            {
                buffer.Dispose();
            }
            buffer = new InMemoryRandomAccessStream();
            if (capture != null)
            {
                capture.Dispose();
            }
            try
            {
                MediaCaptureInitializationSettings settings = new MediaCaptureInitializationSettings
                {
                    StreamingCaptureMode = StreamingCaptureMode.Audio
                };
                capture = new MediaCapture();
                await capture.InitializeAsync(settings);
                capture.RecordLimitationExceeded += (MediaCapture sender) =>
                {
                    //Stop  
                    // await capture.StopRecordAsync();  
                    record = false;
                    throw new Exception("Record Limitation Exceeded ");
                };
                capture.Failed += (MediaCapture sender, MediaCaptureFailedEventArgs errorEventArgs) =>
                {
                    record = false;
                    throw new Exception(string.Format("Code: {0}. {1}", errorEventArgs.Code, errorEventArgs.Message));
                };
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.GetType() == typeof(UnauthorizedAccessException))
                {
                    throw ex.InnerException;
                }
                throw;
            }
            return true;
        }

        public async Task PlayRecordedAudio(CoreDispatcher UiDispatcher)
        {
            MediaElement playback = new MediaElement();
            IRandomAccessStream audio = buffer.CloneStream();

            if (audio == null)
                throw new ArgumentNullException("buffer");
            StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            if (!string.IsNullOrEmpty(filename))
            {
                StorageFile original = await storageFolder.GetFileAsync(filename);
                await original.DeleteAsync();
            }
            await UiDispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
            {
                StorageFile storageFile = await storageFolder.CreateFileAsync(audioFile, CreationCollisionOption.GenerateUniqueName);
                filename = storageFile.Name;
                using (IRandomAccessStream fileStream = await storageFile.OpenAsync(FileAccessMode.ReadWrite))
                {
                    await RandomAccessStream.CopyAndCloseAsync(audio.GetInputStreamAt(0), fileStream.GetOutputStreamAt(0));
                    await audio.FlushAsync();
                    audio.Dispose();
                }
                IRandomAccessStream stream = await storageFile.OpenAsync(FileAccessMode.Read);
                playback.SetSource(stream, storageFile.FileType);
                playback.Play();
            });
        }     

        private async void stopBtn_Click(object sender, RoutedEventArgs e)
        {
            Recording_State_Text.Text = "Stopped";
            await capture.StopRecordAsync();
            record = false;
        }

        private async void playBtn_Click(object sender, RoutedEventArgs e)
        {
            Recording_State_Text.Text = "Playing Recording";

            await PlayRecordedAudio(Dispatcher);
        }

        private async void recordButton_Click(object sender, RoutedEventArgs e)
        {
            if (record)
            {
                //already recored process  
            }
            else
            {
                await RecordProcess();
                await capture.StartRecordToStreamAsync(MediaEncodingProfile.CreateMp3(AudioEncodingQuality.Auto), buffer);
                if (record)
                {
                    throw new InvalidOperationException();
                }
                record = true;
            }
        }

        private async void pauseBtn_Click(object sender, RoutedEventArgs e)
        {
            Recording_State_Text.Text = "Paused";
            await capture.PauseRecordAsync(Windows.Media.Devices.MediaCapturePauseBehavior.RetainHardwareResources);
            record = false;
        }

        private async void resumeBtn_Click(object sender, RoutedEventArgs e)
        {
            Recording_State_Text.Text = "Recording...";
            await capture.ResumeRecordAsync();
            record = true;
        }
    }
}

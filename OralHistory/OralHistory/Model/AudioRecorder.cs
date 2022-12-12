using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Media.Capture;
using Windows.Media.MediaProperties;
using Windows.Storage;
using Windows.Storage.Streams;

namespace OralHistory.Model
{
    public class AudioRecorder
    {
        private MediaCapture _mediaCapture;
        LowLagMediaRecording _mediaRecording;
        private InMemoryRandomAccessStream _memoryBuffer;
        //AudioRecorder _audioRecorder;
        private string _fileName;

        public bool IsRecording { get; set; }

        public async void Record()
        {
            if (IsRecording)
            {
                throw new InvalidOperationException("Recording already in progress!");
            }
            MediaCaptureInitializationSettings settings =
              new MediaCaptureInitializationSettings
              {
                  StreamingCaptureMode = StreamingCaptureMode.Audio
              };
            _mediaCapture = new MediaCapture();
            await _mediaCapture.InitializeAsync(settings);
            await _mediaCapture.StartRecordToStreamAsync(MediaEncodingProfile.CreateMp3(AudioEncodingQuality.Auto), _memoryBuffer);
            IsRecording = true;
        }

        public async void StopRecording()
        {
            await _mediaCapture.StopRecordAsync();
            IsRecording = false;
            SaveAudioToFile();
        }

        private async void SaveAudioToFile()
        {
            IRandomAccessStream audioStream = _memoryBuffer.CloneStream();
            StorageFolder storageFolder = Package.Current.InstalledLocation;
            StorageFile storageFile = await storageFolder.CreateFileAsync(
            "story-recording", CreationCollisionOption.GenerateUniqueName);
            this._fileName = storageFile.Name;
            using (IRandomAccessStream fileStream =
            await storageFile.OpenAsync(FileAccessMode.ReadWrite))
            {
                await RandomAccessStream.CopyAndCloseAsync(
                audioStream.GetInputStreamAt(0), fileStream.GetOutputStreamAt(0));
                await audioStream.FlushAsync();
                audioStream.Dispose();
            }
        }
    }
}

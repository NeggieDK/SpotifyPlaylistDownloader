using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using SpotifyMusicDownloader;
using System;

namespace SpotifyDownloader
{
    public class MainWindow : Window
    {
        private readonly SpotifyPlayListConverter _spotifyConverter;
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            var cbAudioFromat = this.FindControl<ComboBox>("cbAudioFormat");
            cbAudioFromat.SelectedIndex = 0;
            var ntbThreads = this.FindControl<NumericUpDown>("ntbThreads");
            ntbThreads.Value = Environment.ProcessorCount > 4 ? Environment.ProcessorCount - 2 : Environment.ProcessorCount;
        }

        public async void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            var folderDialog = new OpenFolderDialog();
            var result = await folderDialog.ShowAsync(this);
            var tbOutputLocation = this.FindControl<TextBox>("tbOutputLocation");
            tbOutputLocation.Text = result;
        }

        public void btnDownload_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}


using Eggman_OS_Windows_10_Edition.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Eggman_OS_Windows_10_Edition
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Loginsetup : Page
    {
        DispatcherTimer logcreatetimer = new DispatcherTimer();

        public Loginsetup()
        {
            this.InitializeComponent();

            logcreatetimer.Tick += Logcreatetimer_Tick;
            logcreatetimer.Interval = new TimeSpan(100000);
        }

        private void userlbl_Tapped(object sender, TappedRoutedEventArgs e)
        {
            userlbl.Text = "There";
        }

        private void Passwordlbl_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Passwordlbl.Text = "is";
        }

        private void CPasswordlbl_Tapped(object sender, TappedRoutedEventArgs e)
        {
            CPasswordlbl.Text = "no";
        }

        private void hintlbl_Tapped(object sender, TappedRoutedEventArgs e)
        {
            hintlbl.Text = "hope!!!";
        }



        int count = 0;
        int falsecount = 0;
        private async void Logcreatetimer_Tick(object sender, object e)
        {
            switch (count)
            {
                case 0:
                    falsecount++;
                    if (falsecount >= 97)
                        count++;
                    falsecount++;
                    logcreateproc.Value = falsecount;

                    break;
                case 1:
                    falsecount--;
                    logcreateproc.Value = falsecount;
                    if (falsecount <= 42)
                        count++;
                    break;
                case 2:
                    falsecount++;
                    logcreateproc.Value = falsecount;
                    if (falsecount >= 70)
                        count++;
                    break;
                case 3:
                    falsecount--;
                    logcreateproc.Value = falsecount;
                    if (falsecount <= 9)
                        count++;
                    break;
                case 4:
                    falsecount++;
                    logcreateproc.Value = falsecount;
                    if (falsecount >= 30)
                        count++;
                    break;
                case 5:
                    falsecount--;
                    logcreateproc.Value = falsecount;
                    if (falsecount <= 3)
                        count++;
                    break;
                case 6:
                    falsecount++;
                    logcreateproc.Value = falsecount;
                    if (falsecount >= 78)
                        count++;
                    break;
                case 7:
                    falsecount--;
                    logcreateproc.Value = falsecount;
                    if (falsecount <= 65)
                        count++;
                    break;
                case 8:
                    falsecount++;
                    logcreateproc.Value = falsecount;
                    if (falsecount >= 87)
                        count++;
                    break;
                case 9:
                    falsecount--;
                    logcreateproc.Value = falsecount;
                    if (falsecount <= 47)
                        count++;
                    break;
                case 10:
                    
                    falsecount++;
                    logcreateproc.Value = falsecount;
                    if (falsecount >= 100)
                    {
                        logcreatetimer.Stop();

                        //Music folder
                        Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("audio");
                        Windows.Storage.StorageFile file = await folder.GetFileAsync("MLP-SunshineRemix.mp3");
                        var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                        await file.CopyAsync(Eggkernel.music, file.Name, Windows.Storage.NameCollisionOption.ReplaceExisting);


                        folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("audio");
                        file = await folder.GetFileAsync("KingSpartaX37 aka _Delta Brony_ - [Sonic Colors x MLP] Reach For The Elements of Harmony.mp3");
                        stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                        await file.CopyAsync(Eggkernel.music, file.Name, Windows.Storage.NameCollisionOption.ReplaceExisting);

                        //Videos Folder
                        folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("audio");
                        file = await folder.GetFileAsync("[003661].mpg");
                        stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                        await file.CopyAsync(Eggkernel.video, file.Name, Windows.Storage.NameCollisionOption.ReplaceExisting);


                        folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("audio");
                        file = await folder.GetFileAsync("Throws His Computer Out The Window.mp4");
                        stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                        await file.CopyAsync(Eggkernel.video, file.Name, Windows.Storage.NameCollisionOption.ReplaceExisting);

                        //Pictures Folder
                        folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("audio");
                        file = await folder.GetFileAsync("Dr__Eggman.jpg");
                        stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                        await file.CopyAsync(Eggkernel.pictures, file.Name, Windows.Storage.NameCollisionOption.ReplaceExisting);


                        folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("audio");
                        file = await folder.GetFileAsync("dr-eggman.jpg");
                        stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                        await file.CopyAsync(Eggkernel.pictures, file.Name, Windows.Storage.NameCollisionOption.ReplaceExisting);

                        Eggkernel.Changewindow(this, new Desktop_Envirnment());
                    }
                    break;
            }
        }

        private async void Logincreatebtn_TappedAsync(object sender, RoutedEventArgs e)
        {
            if (Passwordtxt.Text == CPasswordtxt.Text)
            {
                logcreateproc.Visibility = Visibility.Visible;
                logcreatetimer.Start();
                Eggkernel.username = Usernametxt.Text;
                Eggkernel.password = Passwordtxt.Text;
                Eggkernel.userpath = await Eggkernel.OSFolder.CreateFolderAsync(Eggkernel.username);
                Eggkernel.doc = await Eggkernel.userpath.CreateFolderAsync("Documents");
                Eggkernel.music = await Eggkernel.userpath.CreateFolderAsync("Music");
                Eggkernel.video = await Eggkernel.userpath.CreateFolderAsync("Video");
                Eggkernel.pictures = await Eggkernel.userpath.CreateFolderAsync("Pictures");
                Eggkernel.desktop = await Eggkernel.userpath.CreateFolderAsync("Desktop");

                Eggkernel.SaveGame(Usernametxt.Text, Passwordtxt.Text, Passhint.Text, loginautochk.IsChecked.Value, "Default", "Default", "Default", "Default", "Default", "Stretch Image");
            }
            else
            {
                await new MessageDialog("Password does not match.").ShowAsync();
            }
        }
    }
}

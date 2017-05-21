using Eggman_OS_Windows_10_Edition.Properties;
using System;
//using System.Collections.Generic;
using System.IO;
//using System.Linq;
//using System.Runtime.InteropServices.WindowsRuntime;
//using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Eggman_OS_Windows_10_Edition
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Install_Screen : Page
    {
        DispatcherTimer Installertime = new DispatcherTimer();

        public Install_Screen()
        {
            InitializeComponent();
            var rawpixelperview = Windows.Graphics.Display.DisplayInformation.GetForCurrentView().RawPixelsPerViewPixel;
            var Width = Window.Current.Bounds.Width * rawpixelperview;
            var Height = Window.Current.Bounds.Height * rawpixelperview;

            Installertime.Tick += Intsallertime_TickAsync;
            Installertime.Interval = new TimeSpan(100000);
            ApplicationView.PreferredLaunchViewSize = new Size(Width, Height);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.FullScreen;
            loadaudio();

        }

        async void loadaudio()
        {
            StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("audio");
            StorageFile file = await folder.GetFileAsync("\\[001918].wav");
            Windows.Storage.Streams.IRandomAccessStream stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
            installermusic.SetSource(stream, file.ContentType);
            installermusic.Play();
        }

        string holdtext = "Formating";
        bool installing = false;

        int count = 0;
        int formatcount = 1;
        private async void Intsallertime_TickAsync(object sender, object e)
        {
            if (installing)
            {
                count++;
                Installprog.Value = count;
                switch (count)
                {
                    case 1:
                        await Eggkernel.Createfolders();
                        Realinstall.Items.Add(Eggkernel.gamefolder.Path + " Created");


                        Realinstall.Items.Add(Eggkernel.gamefolder.Path + @"\Gamesave" + " Created");


                        Realinstall.Items.Add(Eggkernel.OSfolder.Path + " Created");


                        Realinstall.Items.Add(Eggkernel.eggsys32folder.Path + " Created");


                        Realinstall.Items.Add(Eggkernel.mediafolder.Path + " Created");


                        StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("audio");
                        StorageFile file = await folder.GetFileAsync("eggtime.wmv");
                        var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                        await file.CopyAsync(Eggkernel.mediafolder, "eggtime.wmv", NameCollisionOption.ReplaceExisting);
                        Realinstall.Items.Add("eggtime.wmv Created");


                        file = await folder.GetFileAsync("t.mp3");
                        stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                        await file.CopyAsync(Eggkernel.mediafolder, file.Name, NameCollisionOption.ReplaceExisting);
                        Realinstall.Items.Add("t.mp3 Created");

                        folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("audio");
                        file = await folder.GetFileAsync("windows 8 startup.mp3");
                        stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                        await file.CopyAsync(Eggkernel.mediafolder, file.Name, NameCollisionOption.ReplaceExisting);
                        Realinstall.Items.Add("windows 8 startup.mp3 Created");

                        folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("audio");
                        file = await folder.GetFileAsync("Throws His Computer Out The Window.mp4");
                        stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                        await file.CopyAsync(Eggkernel.mediafolder, file.Name, NameCollisionOption.ReplaceExisting);

                        break;
                    case 5:
                        Actionlbl.Text = "Installing Keyboard Driver";
                        Realinstall.Items.Add("Keybroad driver installed");
                        break;
                    case 10:
                        Actionlbl.Text = "Installing Mouse and Touch screen driver";
                        Realinstall.Items.Add("Give me a few seconds to find the driver");
                        break;
                    case 15:
                        Actionlbl.Text = "Mouse driver failed";
                        Realinstall.Items.Add("Touch screen driver was at least installed");
                        break;
                    case 20:
                        Actionlbl.Text = "Installing Video driver";

                        await Eggkernel.eggsys32folder.CreateFileAsync("graphics.EDF");
                        Realinstall.Items.Add("graphics.EDF Created");

                        break;
                    case 25:
                        Actionlbl.Text = "Installing start menu files";

                        Eggkernel.res = await Eggkernel.eggsys32folder.CreateFolderAsync("Resources");
                        folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("audio");
                        file = await folder.GetFileAsync("Nuclear Explosion 2.mp4");
                        await file.CopyAsync(Eggkernel.res, "Nuclear Explosion 2.mp4", NameCollisionOption.ReplaceExisting);
                        Realinstall.Items.Add("Nuclear Explosion 2.mp4 Created");
                        
                        break;
                    case 30:
                        Actionlbl.Text = "Installing car starter files";
                        Realinstall.Items.Add("Error, no files exist");
                        break;
                    case 35:
                        Actionlbl.Text = "Eating cookies";
                        Realinstall.Items.Add("Num Num Num");
                        break;
                    case 40:
                        Actionlbl.Text = "setting up desktop settings files";
                        Realinstall.Items.Add("Finished");
                        break;
                    case 45:
                        Actionlbl.Text = "Plotting Evil sce.... I mean, helping make a better world";
                        Realinstall.Items.Add("Not sure what this means.");
                        break;
                    case 50:
                        Actionlbl.Text = "Creating errors..... I mean attemping to repair errors";
                        Realinstall.Items.Add("What are you taking about? There are no errors.");
                        break;
                    case 55:
                        Actionlbl.Text = "Error ctea.... I mean Error Repair failed.";
                        Realinstall.Items.Add("What is going on there?");
                        break;
                    case 60:
                        Actionlbl.Text = "Installing 'Info has been enrypted' driver";
                        await Eggkernel.eggsys32folder.CreateFileAsync("Network.EDF");
                        Realinstall.Items.Add("'Info has been enrypted' driver Created. You could have said network driver.");
                        break;
                    case 65:
                        Actionlbl.Text = "Laughing min.... I mean almost done";
                        Realinstall.Items.Add("The installation was done already.");
                        break;
                    case 69:
                        count++;
                        break;
                    case 70:
                        Actionlbl.Text = "Setting up theme system";
                        Realinstall.Items.Add("Theme system is working.");
                        break;
                    case 75:
                        Actionlbl.Text = "Cooking Eggs";
                        Realinstall.Items.Add("The stove is broken, it is not possible to cook eggs at the moment.");
                        break;
                    case 80:
                        Actionlbl.Text = "Creating user paths";
                        Realinstall.Items.Add("I can't do that yet, the login settup needs to finish first.");
                        break;
                    case 85:
                        Actionlbl.Text = "Why did I make all these messages";
                        Realinstall.Items.Add("To inform the user?");
                        break;
                    case 90:
                        Actionlbl.Text = "Something else happening but ran out of ideas";
                        Realinstall.Items.Add("Nothing is happening. I'm am starting to dount you Eggm..... EggmanOS Mind Software.exe has been disabled.");
                        break;
                    case 95:
                        Actionlbl.Text = "Loading Login System Settup";
                        break;
                    case 100:
                        Installertime.Stop();
                        Properties.Eggkernel.Changewindow(this, new Loginsetup());
                        installermusic.Stop();
                        break;
                }
            }
            else
            {
                Installertime.Interval = new TimeSpan(100000);
                count++;
                Formattingbar.Value = count;
                if (count == 100)
                {
                    installing = true;
                    count = 0;
                    Formatpnl.Visibility = Visibility.Collapsed;
                    Realinstall.Visibility = Visibility.Visible;
                    Installertime.Interval = new TimeSpan(0, 0, 1);
                }
                switch (formatcount)
                {
                    case 1:
                        Formatlbl.Text = holdtext + ".  " + count + "%";
                        formatcount++;
                        break;
                    case 2:
                        Formatlbl.Text = holdtext + ".. " + count + "%";
                        formatcount++;
                        break;
                    case 3:
                        Formatlbl.Text = holdtext + "..." + count + "%";
                        formatcount++;
                        break;
                    case 4:
                        Formatlbl.Text = holdtext + "   " + count + "%";
                        formatcount = 1;
                        break;
                }
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Installertime.Start();
        }

        private void Formatlbl_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Formatlbl.Text = "";
        }
    }
}

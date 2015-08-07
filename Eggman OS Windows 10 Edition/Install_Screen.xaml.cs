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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Eggman_OS_Windows_10_Edition
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Install_Screen : Page
    {
        public Install_Screen()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Installertime.Enabled = true;
            if (!Directory.Exists(MainPage.gamefolder()))
            {
                Directory.CreateDirectory(Windows.Storage.StorageLibrary.GetLibraryAsync(Windows.Storage.KnownLibraryId.Documents) + @"\EggmanOS Directory");
                Directory.CreateDirectory(Windows.Storage.StorageLibrary.GetLibraryAsync(Windows.Storage.KnownLibraryId.Documents) + @"\EggmanOS Directory\Gamesave");
                File.Create(Windows.Storage.StorageLibrary.GetLibraryAsync(Windows.Storage.KnownLibraryId.Documents) + @"\EggmanOS Directory\Gamesave\Save.ETF");
            }
        }

        string holdtext = "Formating";
        bool installing = false;

        int count = 0;
        int formatcount = 1;
        private void Installer_Tick(object sender, EventArgs e)
        {
            if (installing)
            {
                count++;
                Installprog.Value = count;
                switch (count)
                {
                    case 5:
                        Actionlbl.Text = "Installing Keyboard Driver";
                        break;
                    case 10:
                        Actionlbl.Text = "Installing Mouse driver";
                        break;
                    case 15:
                        Actionlbl.Text = "Mouse driver failed";
                        break;
                    case 20:
                        Actionlbl.Text = "Installing Video driver";
                        break;
                    case 25:
                        Actionlbl.Text = "Installing start menu files";
                        break;
                    case 30:
                        Actionlbl.Text = "Installing car starter files";
                        break;
                    case 35:
                        Actionlbl.Text = "Eating cookies";
                        break;
                    case 40:
                        Actionlbl.Text = "setting up desktop settings files";
                        break;
                    case 45:
                        Actionlbl.Text = "Plotting Evil sce.... I mean, helping make a better world";
                        Installpic.Image = Properties.Resources.chao1;
                        break;
                    case 50:
                        Installpic.Image = null;
                        Actionlbl.Text = "Creating errors..... I mean attemping to repair errors";
                        break;
                    case 55:
                        Actionlbl.Text = "Error ctea.... I mean Error Repair failed.";
                        break;
                    case 60:
                        Actionlbl.Text = "Installing 'Info has been enrypted' driver";
                        break;
                    case 65:
                        Actionlbl.Text = "Laughing min.... I mean almost done";
                        break;
                    case 69:
                        count++;
                        break;
                    case 70:
                        Actionlbl.Text = "Setting up theme system";
                        break;
                    case 75:
                        Actionlbl.Text = "Cooking Eggs";
                        break;
                    case 80:
                        Actionlbl.Text = "Creating user paths";
                        break;
                    case 85:
                        Actionlbl.Text = "Why did I make all these messages";
                        break;
                    case 90:
                        Actionlbl.Text = "Something else happening but ran out of ideas";
                        break;
                    case 95:
                        Actionlbl.Text = "Loading Login System Settup";
                        break;
                    case 100:
                        Installer.Loginsettup.Show();
                        Close();
                        break;
                }
            }
            else
            {
                Installertime.Interval = 100;
                count++;
                Formattingbar.Value = count;
                if (count == 100)
                {
                    installing = true;
                    count = 0;
                    Formatpnl.Visible = false;
                    Installertime.Interval = 1000;
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

        private void Formatlbl_Click(object sender, EventArgs e)
        {
            Formatlbl.Text = "";
        }
    }
}

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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Eggman_OS_Windows_10_Edition
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Installer : Page
    {
        public static string gamefolder()
        {
            return Windows.Storage.StorageLibrary.GetLibraryAsync(Windows.Storage.KnownLibraryId.Documents) + @"\EggmanOS Directory";
        }

        public Installer()
        {
            this.InitializeComponent();
        }

        private void Agree_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog dialog = new MessageDialog("You have Agreed to the Terms and Conditions");
            dialog.ShowAsync();
            loadframe Installscreen = new loadframe();
            Install_Screen install = new Install_Screen();
            Installscreen.load(this, install);
        }

        private void notchoose_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog dialog = new MessageDialog("Thankyou for Accepting the agreement by not choosing. Best option ever.");
            dialog.ShowAsync();
            loadframe Installscreen = new loadframe();
            Install_Screen install = new Install_Screen();
            Installscreen.load(this, install);
        }

        private void Disagree_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog dialog = new MessageDialog("Thankyou for Accepting the agreement.");
            dialog.ShowAsync();
            loadframe Installscreen = new loadframe();
            Install_Screen install = new Install_Screen();
            Installscreen.load(this, install);
        }
    }
}

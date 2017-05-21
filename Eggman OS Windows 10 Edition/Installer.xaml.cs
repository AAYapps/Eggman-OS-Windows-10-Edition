using Eggman_OS_Windows_10_Edition.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Provider;
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
        public static async System.Threading.Tasks.Task gamecreate()
        {
            Eggkernel.gamefolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("EggmanOS Directory");
            Eggkernel.OSfolder = await Eggkernel.gamefolder.CreateFolderAsync("Eggman OS");
            Eggkernel.eggsys32folder = await Eggkernel.OSfolder.CreateFolderAsync("eggsys32\\");
            Eggkernel.mediafolder = await Eggkernel.OSfolder.CreateFolderAsync("media");
            StorageFolder gamesavef = await Eggkernel.gamefolder.CreateFolderAsync("Gamesave");
            StorageFile gamesave = await gamesavef.CreateFileAsync("GameSave.ETF", CreationCollisionOption.ReplaceExisting);

            /*if (Eggkernel.getsystemtype() == "Windows.IoT")
            {

            }
            else
            {
                FileSavePicker savePicker = new FileSavePicker();
                savePicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
                // Dropdown of file types the user can save the file as
                savePicker.FileTypeChoices.Add("Eggman OS save Game", new List<string>() { ".ETF" });
                // Default file name if the user does not type one in or select a file to replace
                savePicker.SuggestedFileName = "GameSave";
                StorageFile file = await savePicker.PickSaveFileAsync();
                if (file != null)
                {
                    // Prevent updates to the remote version of the file until we finish making changes and call CompleteUpdatesAsync.
                    CachedFileManager.DeferUpdates(file);
                    // write to file
                    await FileIO.WriteTextAsync(file, file.Name);
                    // Let Windows know that we're finished changing the file so the other app can update the remote version of the file.
                    // Completing updates may require Windows to ask for user input.
                    FileUpdateStatus status = await CachedFileManager.CompleteUpdatesAsync(file);
                    if (status == FileUpdateStatus.Complete)
                    {
                        // File was saved
                    }
                    else
                    {
                        // File was not saved
                    }
                }
                else
                {
                    // File Operation cancelled
                }
            }*/
        }

        public static async System.Threading.Tasks.Task gameload()
        {
            await Eggkernel.assignfolders();

            /*FileOpenPicker OpenPicker = new FileOpenPicker();
            OpenPicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            // Dropdown of file types the user can save the file as
            OpenPicker.FileTypeFilter.Add(".ETF");
            // Default file name if the user does not type one in or select a file to replace
            StorageFile file = await OpenPicker.PickSingleFileAsync();
            if (file != null)
            {
                // Prevent updates to the remote version of the file until we finish making changes and call CompleteUpdatesAsync.
                CachedFileManager.DeferUpdates(file);
                // read to file
                await FileIO.ReadTextAsync(file);
                // Let Windows know that we're finished reading the file.
                FileUpdateStatus status = await CachedFileManager.CompleteUpdatesAsync(file);
                if (status == FileUpdateStatus.Complete)
                {
                    // File was saved
                }
                else
                {
                    // File was not saved
                }
            }
            else
            {
                // File Operation cancelled
            }*/
        }

        public Installer()
        {
            this.InitializeComponent();

        }

        private async void Agree_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog dialog = new MessageDialog("You have Agreed to the Terms and Conditions on your" + Eggkernel.getsystemtype() + " device");
            try
            {
                //OK Button
                UICommand okBtn = new UICommand("OK");
                okBtn.Invoked = OkBtnClick;
                dialog.Commands.Add(okBtn);

                //Cancel Button
                UICommand cancelBtn = new UICommand("Cancel");
                cancelBtn.Invoked = CancelBtnClick;
                dialog.Commands.Add(cancelBtn);

                //Show message
                await dialog.ShowAsync();
                await gamecreate();
            }
            catch
            {

            }
            Eggkernel.Changewindow(this, new Install_Screen());
        }

        private void CancelBtnClick(IUICommand command)
        {

        }

        private void OkBtnClick(IUICommand command)
        {

        }

        private async void notchoose_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog dialog = new MessageDialog("Thankyou for Accepting the agreement by not choosing. Best option ever.");
            try
            {
                //OK Button
                UICommand okBtn = new UICommand("OK");
                okBtn.Invoked = OkBtnClick;
                dialog.Commands.Add(okBtn);

                //Cancel Button
                UICommand cancelBtn = new UICommand("Cancel");
                cancelBtn.Invoked = CancelBtnClick;
                dialog.Commands.Add(cancelBtn);

                //Show message
                await dialog.ShowAsync();
                await gamecreate();
            }
            catch
            {

            }
            Eggkernel.Changewindow(this, new Install_Screen());
        }

        private async void Disagree_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog dialog = new MessageDialog("Thankyou for Accepting the agreement.");
            try
            {
                //OK Button
                UICommand okBtn = new UICommand("OK");
                okBtn.Invoked = OkBtnClick;
                dialog.Commands.Add(okBtn);

                //Cancel Button
                UICommand cancelBtn = new UICommand("Cancel");
                cancelBtn.Invoked = CancelBtnClick;
                dialog.Commands.Add(cancelBtn);

                //Show message
                await dialog.ShowAsync();
                await gamecreate();
            }
            catch
            {

            }
            Eggkernel.Changewindow(this, new Install_Screen());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private async void LoadSave_Click(object sender, RoutedEventArgs e)
        {
            await gameload();
        }
    }
}

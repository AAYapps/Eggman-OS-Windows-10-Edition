using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Eggman_OS_Windows_10_Edition.Properties
{
    class Eggkernel
    {
        #region System varibles and void functions
        static string systemtype = Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily;
        public static bool guest_user = false;
        public static List<string> log = new List<string>();
        public static StorageFolder GameLocalData = ApplicationData.Current.LocalFolder;
        public static StorageFolder GameSaveFolder;
        public static StorageFolder GameFolder;
        public static StorageFolder OSFolder;
        public static StorageFolder Eggsys32Folder;
        public static StorageFolder Res;
        public static StorageFolder MediaFolder;
        async public static Task AssignFolders()
        {
            GameFolder = await GameLocalData.GetFolderAsync("EggmanOS Directory");
            GameSaveFolder = await GameFolder.GetFolderAsync("GameSave");
            OSFolder = await GameFolder.GetFolderAsync("Eggman OS");
            Eggsys32Folder = await OSFolder.GetFolderAsync("eggsys32");
            MediaFolder = await OSFolder.GetFolderAsync("media");
        }

        async public static Task Createfolders()
        {
            GameFolder = await GameLocalData.CreateFolderAsync("EggmanOS Directory", CreationCollisionOption.ReplaceExisting);
            GameSaveFolder = await GameFolder.CreateFolderAsync("GameSave", CreationCollisionOption.ReplaceExisting);
            OSFolder = await GameFolder.CreateFolderAsync("Eggman OS", CreationCollisionOption.ReplaceExisting);
            Eggsys32Folder = await OSFolder.CreateFolderAsync("eggsys32", CreationCollisionOption.ReplaceExisting);
            MediaFolder = await OSFolder.CreateFolderAsync("media", CreationCollisionOption.ReplaceExisting);
        }

        public static async Task MessageBox(string message)
        {
            MessageDialog dialog = new MessageDialog(message);
            try
            {
                //OK Button
                UICommand okBtn = new UICommand("OK");
                dialog.Commands.Add(okBtn);

                //Cancel Button
                UICommand cancelBtn = new UICommand("Cancel");
                dialog.Commands.Add(cancelBtn);

                //Show message
                await dialog.ShowAsync();
            }
            catch
            {

            }
        }

        public static async Task system_startAsync()
        {

            var buffer = await Windows.Storage.FileIO.ReadBufferAsync(await GameSaveFolder.GetFileAsync("GameSave.ETF"));

            using (var dataReader = Windows.Storage.Streams.DataReader.FromBuffer(buffer))
            {
                string lines = dataReader.ReadString(buffer.Length);
                string[] array = lines.Split("\n".ToCharArray());

                foreach (string line in array)
                {
                    if (line.Contains("User: "))
                    {
                        username = line.Replace("User: ", "");
                        userpath = await OSFolder.CreateFolderAsync(username.Trim(), CreationCollisionOption.OpenIfExists);
                        doc = await userpath.CreateFolderAsync("documents", CreationCollisionOption.OpenIfExists);
                        music = await userpath.CreateFolderAsync("music", CreationCollisionOption.OpenIfExists);
                        video = await userpath.CreateFolderAsync("video", CreationCollisionOption.OpenIfExists);
                        pictures = await userpath.CreateFolderAsync("pictures", CreationCollisionOption.OpenIfExists);
                        desktop = await userpath.CreateFolderAsync("desktop", CreationCollisionOption.OpenIfExists);
                    }
                    else if (line.Contains("Password: "))
                    {
                        password = line.Replace("Password: ", "");
                    }
                    else if (line.Contains("Passwordhint: "))
                    {
                        passwordhint = line.Replace("Passwordhint: ", "");
                    }
                    else if (line.Contains("Login Type: "))
                    {
                        if (line.Replace("Login Type: ", "") == "false")
                        {
                            Autologin = false;
                        }
                        else if (line.Replace("Login Type: ", "") == "true")
                        {
                            Autologin = true;
                        }
                    }
                    else if (line.Contains("Startup Sound: "))
                    {
                        if (line.Replace("Startup Sound: ", "").Contains("Default"))
                        {
                            StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("audio");
                            StorageFile file = await folder.GetFileAsync("eggman.wav");
                            startsound = file;
                        }
                        else
                        {
                            startsound = await StorageFile.GetFileFromPathAsync(line.Replace("Startup Sound: ", "").Trim());
                        }
                    }
                    else if (line.Contains("Error Sound: "))
                    {
                        if (line.Replace("Error Sound: ", "").Contains("Default"))
                        {
                            StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("audio");
                            StorageFile file = await folder.GetFileAsync("eggerr.wav");
                            errorsound = file;
                        }
                        else
                            errorsound = await StorageFile.GetFileFromPathAsync(line.Replace("Error Sound: ", ""));
                    }
                    else if (line.Contains("Exclamation Sound: "))
                    {
                        if (line.Replace("Exclamation Sound: ", "").Contains("Default"))
                        {
                            StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("audio");
                            StorageFile file = await folder.GetFileAsync("eggmansay.wav");
                            exclamationsound = file;
                        }
                        else
                            exclamationsound = await StorageFile.GetFileFromPathAsync(line.Replace("Exclamation Sound: ", ""));
                    }
                    else if (line.Contains("Welcome Sound: "))
                    {
                        if (line.Replace("Welcome Sound: ", "").Contains("Default"))
                        {
                            StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("audio");
                            StorageFile file = await folder.GetFileAsync("question.wav");
                            welcomesound = file;
                        }
                        else
                            welcomesound = await StorageFile.GetFileFromPathAsync(line.Replace("Welcome Sound: ", ""));
                    }
                    else if (line.Contains("backgroundpath: "))
                    {
                        if (line.Replace("backgroundpath: ", "").Contains("Default"))
                        {
                            StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("audio");
                            StorageFile file = await folder.GetFileAsync("dr-eggman.jpg");
                            background = file;
                        }
                        else
                            background = await StorageFile.GetFileFromPathAsync(line.Replace("backgroundpath: ", ""));
                    }
                    else if (line.Contains("imagesetting: "))
                    {
                        imagesetting = line.Replace("imagesetting: ", "");
                    }
                }
            }
            try
            {
                
            }
            catch (Exception e)
            {
                await new MessageDialog("An error occured when trying to load the save file with exception: " + 
                    e.Message + ". If this is just a permissions issue, then you can fix this error by changing the file permissions in location " + 
                    GameSaveFolder.ToString() + ". If the file does not exist or is currupt, then a new game save is required. " + Environment.NewLine + Environment.NewLine + 
                    "For fixing permissions" + Environment.NewLine + Environment.NewLine + "Step 1: Go to " + GameSaveFolder.ToString() + Environment.NewLine + "Step 2: Right click GameSave.EDF" + 
                    Environment.NewLine + "Step 3: when the menu pops up, choose the Properties option" + Environment.NewLine + "Step 4: In the properties window, choose the Security tab" + Environment.NewLine + 
                    "Step 5: Click the edit button. From there check the full control checkbox and theen click the apply and ok buttons." + Environment.NewLine + "If all goes well, then you can try loading the save again.").ShowAsync();
                Window.Current.Content = new Installer();
            }
        }
        public static void Changewindow(Page current, Page nextPage)
        {
            loadframe Installscreen = new loadframe();
            //nextPage install = new nextPage();
            Installscreen.load(current, nextPage);
        }
        public static StorageFolder userpath;
        public static StorageFolder doc;
        public static StorageFolder music;
        public static StorageFolder video;
        public static StorageFolder pictures;
        public static StorageFolder desktop;
        public static StorageFile startsound;
        public static StorageFile errorsound;
        public static StorageFile exclamationsound;
        public static StorageFile welcomesound;
        public static StorageFile background;
        public static string imagesetting;

        static public string tempuser = "";
        static public string username = "User";
        static public string password = "";
        static public string passwordhint = "";
        static public bool Autologin = false;
        #endregion

        public static string getsystemtype()
        {
            return systemtype;
        }


        public async static void SaveGame(string Usernametxt, string Passwordtxt
        , string Passhint, bool loginautochk
        , string ssound, string esound, string exsound, string wsound
        , string backgroundpath, string backgs)
        {
            try
            {
                Windows.Storage.StorageFile temp = await Eggkernel.GameSaveFolder.CreateFileAsync("GameSave.ETF", CreationCollisionOption.ReplaceExisting);

                string buffer = "User: " + Usernametxt + Environment.NewLine +
                    "Password: " + Passwordtxt + Environment.NewLine +
                    "Passwordhint: " + Passhint + Environment.NewLine +
                    "Login Type: " + loginautochk + Environment.NewLine + Environment.NewLine +
                    "Startup Sound: " + ssound + Environment.NewLine +
                    "Error Sound: " + esound + Environment.NewLine +
                    "Exclamation Sound: " + exsound + Environment.NewLine +
                    "Welcome Sound: " + wsound + Environment.NewLine + Environment.NewLine +
                    "backgroundpath: " + backgroundpath + Environment.NewLine +
                    "imagesetting: " + backgs;

                await Windows.Storage.FileIO.WriteTextAsync(temp, buffer);
            }
            catch (Exception f)
            {
                new Windows.UI.Popups.MessageDialog("Exception: " + f.Message);
            }
        }
    }
}

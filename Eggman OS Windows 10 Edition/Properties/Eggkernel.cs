using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Controls;

namespace Eggman_OS_Windows_10_Edition.Properties
{
    class Eggkernel
    {
        #region System varibles and void functions
        static string systemtype = Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily;
        public static bool guest_user = false;
        public static List<string> log = new List<string>();
        public static StorageFolder gamelocaldata = ApplicationData.Current.LocalFolder;
        public static StorageFolder gamefolder;
        public static StorageFolder OSfolder;
        public static StorageFolder eggsys32folder;
        public static StorageFolder res;
        public static StorageFolder mediafolder;
        async public static Task assignfolders()
        {
            gamefolder = await gamelocaldata.GetFolderAsync("EggmanOS Directory");
            OSfolder = await gamefolder.GetFolderAsync("Eggman OS");
            eggsys32folder = await OSfolder.GetFolderAsync("eggsys32");
            mediafolder = await OSfolder.GetFolderAsync("media");
        }
        async public static Task Createfolders()
        {
            gamefolder = await gamelocaldata.CreateFolderAsync("EggmanOS Directory", CreationCollisionOption.ReplaceExisting);
            OSfolder = await gamefolder.CreateFolderAsync("Eggman OS", CreationCollisionOption.ReplaceExisting);
            eggsys32folder = await OSfolder.CreateFolderAsync("eggsys32", CreationCollisionOption.ReplaceExisting);
            mediafolder = await OSfolder.CreateFolderAsync("media", CreationCollisionOption.ReplaceExisting);
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
        #endregion


        public static string getsystemtype()
        {
            return systemtype;
        }






    }
}

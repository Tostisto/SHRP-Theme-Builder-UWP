using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using System.IO;
using System.IO.Compression;
using System.Xml.Serialization;
using Windows.Storage;
using Windows.Storage.AccessCache;
using Windows.Storage.Pickers;
using System.Diagnostics;
using System.Threading;

using Logic.Generate_XML;

namespace Logic
{
    public class GenerateTheme
    {
        public async Task CopyThemeToUserDestination(string themeName)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;

            var folderPicker = new Windows.Storage.Pickers.FolderPicker();
            folderPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop;
            folderPicker.FileTypeFilter.Add("*");

            Windows.Storage.StorageFolder folder = await folderPicker.PickSingleFolderAsync();
            if (folder != null)
            {
                Windows.Storage.AccessCache.StorageApplicationPermissions.FutureAccessList.AddOrReplace("PickedFolderToken", folder);

                StorageFile file = await storageFolder.GetFileAsync($"data\\zip\\{themeName}.stheme");
                await file.CopyAsync(folder, $"{themeName}.stheme", NameCollisionOption.GenerateUniqueName);
            }
        }

        public async Task copyCustomSplash(StorageFile splashImage, bool checkSplashSelected)
        {
            if(checkSplashSelected)
            {
                Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;

                StorageFolder outFolder = await storageFolder.GetFolderAsync("data\\source\\res");

                await splashImage.CopyAsync(outFolder, "c_logo.png", NameCollisionOption.ReplaceExisting);
            }
        }

        public async Task CreateZipFile(string themeName)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFolder destinationfolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("data\\zip", CreationCollisionOption.OpenIfExists);

            StorageApplicationPermissions.FutureAccessList.AddOrReplace("PickedFolderToken", destinationfolder);

            await Task.Run(() =>
            {
                ZipFile.CreateFromDirectory($"{storageFolder.Path}\\data\\source", $"{destinationfolder.Path}\\{themeName}.stheme", CompressionLevel.NoCompression, false);
            });
        }

        public async void execute(Theme newTheme)
        {
            await Clean.prepareLocalStorage();

            newTheme.subBackgroundColor = SubBackGround.getSubBackGround(newTheme.backgroundColor);

            PrepareImages images = new PrepareImages();

            List<Task> tasks = new List<Task>()
            {
                images.setupBattery(newTheme.batteryIconStyle, newTheme.accentColor),
                images.applyColorBackground(newTheme.backgroundColor),
                images.applyNavbarStyle(newTheme.NavIconStyle, newTheme.NavbarColor),
                images.applyIconStyle(newTheme.DashIconStyle, newTheme.DashIconColor),
                images.applyAccRes(newTheme.accentColor),
                images.applyBgRes2(newTheme.backgroundColor),
                images.applyCustomDashBackgroundColor(newTheme.DashIconBGStyle, newTheme.ChooseCustomDashIconBGStyle, newTheme.CustomDashIconBGColor),
                Generate_xml.generateXML(newTheme)
            };

            await copyCustomSplash(newTheme.SplashImage, newTheme.splasImage_set);

            await Task.WhenAll(tasks);

            await images.copyDynamicIcons();

            await CreateZipFile(newTheme.Name);
            await CopyThemeToUserDestination(newTheme.Name);
            await Clean.cleanAllFiles();
        }
    }
}

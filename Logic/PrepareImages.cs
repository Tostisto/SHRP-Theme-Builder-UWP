using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Storage;

namespace Logic
{
    internal class PrepareImages
    {
        public async Task applyColorFolder(string folder, Windows.UI.Color color)
        {
            StorageFolder appInstalledFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;

            StorageFolder assets = await appInstalledFolder.GetFolderAsync($"Logic\\Assets\\{folder}");
            var files = await assets.GetFilesAsync();

            foreach (var file in files)
            {
                RecolorImage softwareBitmapTest = new RecolorImage();
                await softwareBitmapTest.recolor(file, color);
            }
        }

        public async Task setupBattery(string batteryStyle, Windows.UI.Color accentColor)
        {
            if (batteryStyle == "circle")
            {
                await applyColorFolder("battery\\circle", accentColor);
            }
            else
            {
                await applyColorFolder("battery\\default", accentColor);
            }
        }


        public async Task applyColorBackground(Windows.UI.Color color)
        {
            await applyColorFolder("bgRes", color);
        }

        public async Task applyNavbarStyle(string style, Windows.UI.Color color)
        {

            if (style == "Pie")
            {
                await applyColorFolder("nIco\\nt1", color);
            }
            else if (style == "Nxt-Bit")
            {
                await applyColorFolder("nIco\\nt2", color);
            }
            else if (style == "Samsung")
            {
                await applyColorFolder("nIco\\nt3", color);
            }
            else if (style == "Custom")
            {
                await applyColorFolder("nIco\\nt4", color);
            }
        }

        public async Task applyIconStyle(string style, Windows.UI.Color color)
        {
            if (style == "Default")
            {
                await applyColorFolder("dIco\\dt1", color);
            }
            else if (style == "Material")
            {
                await applyColorFolder("dIco\\dt2", color);
            }
            else if (style == "Plain")
            {
                await applyColorFolder("dIco\\dt3", color);
            }
            else
            {
                await applyColorFolder("dIco\\dt4", color);
            }
        }

        public async Task applyAccRes(Windows.UI.Color color)
        {
            await applyColorFolder("accRes", color);
        }

        public async Task applyBgRes2(Windows.UI.Color color)
        {
            await applyColorFolder("bgRes2", color);
        }


        public async Task applyCustomDashBackgroundColor(string style, string enable, Windows.UI.Color color)
        {
            if(enable == "1")
            {
                if (style == "Circle")
                {
                    await applyColorFolder("dBgType\\dbg1", color);
                }
                else if (style == "Square")
                {
                    await applyColorFolder("dBgType\\dbg2", color);
                }
                else if (style == "Rounded Square")
                {
                    await applyColorFolder("dBgType\\dbg3", color);
                }
                else
                {
                    await applyColorFolder("dBgType\\dbg4", color);
                }
            }
        }

        public async Task copyDynamicIcons()
        {
            StorageFolder appInstalledFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;

            StorageFolder assets = await appInstalledFolder.GetFolderAsync($"Logic\\Assets\\dynamic\\light");
            var files = await assets.GetFilesAsync();


            foreach (StorageFile file in files)
            {
                Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;

                StorageFolder destinationFolder = await storageFolder.GetFolderAsync("data\\source\\res");

                await file.CopyAsync(destinationFolder, file.Name ,NameCollisionOption.ReplaceExisting);
            }
        }

    }
}

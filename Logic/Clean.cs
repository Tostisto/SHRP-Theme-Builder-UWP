using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Logic
{
    internal class Clean
    {

        static public async Task prepareLocalStorage()
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;

            //Try remove data folder
            try
            {
                StorageFolder data = await storageFolder.GetFolderAsync("data");

                await data.DeleteAsync();

                await storageFolder.CreateFolderAsync("data");
            }
            catch
            {
                await storageFolder.CreateFolderAsync("data");
            }

            await storageFolder.CreateFolderAsync("data\\zip");

            await storageFolder.CreateFolderAsync("data\\source");

            await storageFolder.CreateFolderAsync("data\\source\\res");
        }

        public static async Task cleanAllFiles()
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;

            StorageFolder data = await storageFolder.GetFolderAsync("data");

            await data.DeleteAsync();
        }

    }
}

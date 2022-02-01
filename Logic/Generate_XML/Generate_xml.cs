using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Logic.Generate_XML
{
    internal class Generate_xml
    {
        public static async Task generateXML(Theme newTheme)
        {
            string theme = xmlTemplate.createXMLString(newTheme);

            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFolder destinationfolder = await storageFolder.CreateFolderAsync("data\\source\\dynamic", CreationCollisionOption.OpenIfExists);

            Windows.Storage.StorageFile xmlFile = await storageFolder.CreateFileAsync("data\\source\\dynamic\\themeData.xml");

            await Windows.Storage.FileIO.WriteTextAsync(xmlFile, theme);
        }
    }
}

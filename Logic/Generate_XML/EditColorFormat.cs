using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace Logic.Generate_XML
{
    public class EditColorFormat
    { 
        public static string removeFromColorAlpha(Color inputColor)
        {
            string outColor = inputColor.ToString().Remove(1, 2);
            return outColor;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using System.Xml;
using System.Xml.Serialization;
using Windows.Storage;

namespace Logic
{
    public class Theme
    {
        public string Name { get; set; } = "SHRP-Theme";
        public Color primaryColor { get; set; }
        public Color secondaryColor { get; set; }
        public Color accentColor { get; set; }
        public Color backgroundColor { get; set; }
        public Color subBackgroundColor { get; set; }
        public Color NavbarColor { get; set; }
        public Color dashboardTextColor { get; set; }
        public string batteryBarEnabled { get; set; }
        public string batteryIconEnabled { get; set; }
        public string batteryPercentageEnabled { get; set; }
        public string batteryIconStyle { get; set; } // Battery Icon style (default, circle)
        public string clockEnabled { get; set; } // Enable Clock
        public string centeredClockEnabled { get; set; } // Center Clock
        public string cpuTempEnabled { get; set; }
        public string roundedCornerEnabled { get; set; }
        public string navbarBackgroundEnabled { get; set; }
        public string dashboardSubTintEnabled { get; set; }
        public string dashboardTextColorEnabled { get; set; }

        // Dashboard custom backgroun color and style of background
        public string ChooseCustomDashIconBGStyle { get; set; } // Dash icon background check if is enabled (0,1)
        public Color CustomDashIconBGColor { get; set; } // Color of Dashboard icon background
        public string DashIconBGStyle { get; set; } // String name of Background style

        // Splash Image
        public StorageFile SplashImage { get; set; } // Image File
        public bool splasImage_set { get; set; } 

        public string DashIconStyle { get; set; }
        public Color DashIconColor { get; set; }
        public string NavIconStyle { get; set; }

        public string statusBarEnabled { get; set; }
    }
}

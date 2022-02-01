using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Generate_XML
{
    public class xmlTemplate
    {
        public static string createXMLString(Theme newTheme)
        {
            string xml =
$@"<?xml version=""1.0""?>
<recovery>
  <variables>
    <variable name=""primaryColor"" value=""{EditColorFormat.removeFromColorAlpha(newTheme.primaryColor)}""/>
    <variable name=""secondaryColor"" value=""{EditColorFormat.removeFromColorAlpha(newTheme.secondaryColor)}""/>
    <variable name=""accentColor"" value=""{EditColorFormat.removeFromColorAlpha(newTheme.accentColor)}""/>
    <variable name=""backgroundColor"" value=""{EditColorFormat.removeFromColorAlpha(newTheme.backgroundColor)}""/>
    <variable name=""subBackgroundColor"" value=""{EditColorFormat.removeFromColorAlpha(newTheme.subBackgroundColor)}""/>
    <variable name=""navbarColor"" value=""{EditColorFormat.removeFromColorAlpha(newTheme.NavbarColor)}""/>
    <variable name=""dashboardTextColor"" value=""{EditColorFormat.removeFromColorAlpha(newTheme.dashboardTextColor)}""/>
    <!--Toggles-->
    <variable name=""batteryBarEnabled"" value=""{newTheme.batteryBarEnabled}""/>
    <variable name=""statusBarEnabled"" value=""0""/>
    <variable name=""batteryIconEnabled"" value=""{newTheme.batteryIconEnabled}""/>
    <variable name=""batteryPercentageEnabled"" value=""{newTheme.batteryPercentageEnabled}""/>
    <variable name=""clockEnabled"" value=""{newTheme.clockEnabled}""/>
    <variable name=""centeredClockEnabled"" value=""{newTheme.centeredClockEnabled}""/>
    <variable name=""cpuTempEnabled"" value=""{newTheme.cpuTempEnabled}""/>
    <variable name=""roundedCornerEnabled"" value=""{newTheme.roundedCornerEnabled}""/>
    <variable name=""navbarBackgroundEnabled"" value=""{newTheme.navbarBackgroundEnabled}""/>
    <variable name=""dashboardSubTintEnabled"" value=""{newTheme.dashboardSubTintEnabled}""/>
    <variable name=""dashboardTextColorEnabled"" value=""{newTheme.dashboardTextColorEnabled}""/>
    <!--ComponentTypes-->
    <variable name=""navbarType"" value=""69""/>
    <variable name=""batteryType"" value=""69""/>
    <variable name=""dashboardIconType"" value=""69""/>
    <variable name=""roundedcornerType"" value=""69""/>
  </variables>
</recovery>";

            return xml;
        }
    }
}

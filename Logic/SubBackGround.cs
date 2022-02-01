using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace Logic
{
    internal class SubBackGround
    {
        public static bool isDark(Color color)
        {
            if (color.R > 180 || color.G > 180 || color.B > 180)
            {
                return false;
            }

            return true;
        }

        internal static Color getSubBackGround(Color background)
        {
            Color subBackground = new Color();
            subBackground = background;

            if(isDark(background))
            {
                subBackground.R += 18;
                subBackground.G += 18;
                subBackground.B += 18;
            }
            
            return subBackground;
        }
    }
}

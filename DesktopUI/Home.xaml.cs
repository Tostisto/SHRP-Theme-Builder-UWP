using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using Microsoft.Win32;
using System.Windows;
using Windows.UI;

using Logic;
using Windows.UI.Popups;
using System.Threading.Tasks;


namespace MyProject
{
    public sealed partial class Home : Page
    {
        public Theme newTheme = new Theme();

        public Home()
        {
            this.InitializeComponent();
        }

        private async void DisplayErrorDialog(string title, string content)
        {
            ContentDialog displayDialog = new ContentDialog
            {
                Title = title,
                Content = content,
                CloseButtonText = "Ok"
            };

            ContentDialogResult result = await displayDialog.ShowAsync();
        }

        private void showBatteryIcon_Checked(object sender, RoutedEventArgs e)
        {
            batteryStyle.Visibility = Visibility.Visible;
        }

        private void showBatteryIcon_Unchecked(object sender, RoutedEventArgs e)
        {
            batteryStyle.Visibility = Visibility.Collapsed;
        }

        private void checkedBatteryStyleDefault(object sender, RoutedEventArgs e)
        {
            newTheme.batteryIconStyle = "default";
        }

        private void checkedBatteryStyleCircle(object sender, RoutedEventArgs e)
        {
            newTheme.batteryIconStyle = "circle";
        }

        private async void selectCustomSplash_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".png");

            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                newTheme.splasImage_set = true;
                splashImageButton.Background = new SolidColorBrush(Color.FromArgb(255, 48, 179, 221));

                newTheme.SplashImage = file;
            }
            else
            {
                newTheme.splasImage_set = false;
                newTheme.SplashImage = null;
                splashImageButton.Background = null;
                DisplayErrorDialog("Faild select File", "You probably don't select image or selected incorect image format.");
            }
        }

        private void customDashIconBgStyleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            if (customDashIconBgStyleSwitch.IsOn == true)
            {
                customDashIconBgStyleSwitchValues.Visibility = Visibility.Visible;

                newTheme.ChooseCustomDashIconBGStyle = "1";
            }
            else
            {
                customDashIconBgStyleSwitchValues.Visibility = Visibility.Collapsed;

                newTheme.ChooseCustomDashIconBGStyle = "0";
            }
        }

        private void showBatteryPercentage_Checked(object sender, RoutedEventArgs e)
        {
            newTheme.batteryPercentageEnabled = "1";
        }

        private void showBatteryPercentage_Unchecked(object sender, RoutedEventArgs e)
        {
            newTheme.batteryPercentageEnabled = "0";
        }

        private void ShowCPUTemp_Checked(object sender, RoutedEventArgs e)
        {
            newTheme.cpuTempEnabled = "1";
        }

        private void ShowCPUTemp_Unchecked(object sender, RoutedEventArgs e)
        {
            newTheme.cpuTempEnabled = "0";
        }

        private void showBatteryBar_Checked(object sender, RoutedEventArgs e)
        {
            newTheme.batteryBarEnabled = "1";
        }

        private void showBatteryBar_Unchecked(object sender, RoutedEventArgs e)
        {
            newTheme.batteryBarEnabled = "0";
        }

        private void setRoundedCorners_Checked(object sender, RoutedEventArgs e)
        {
            newTheme.roundedCornerEnabled = "1";
        }

        private void setRoundedCorners_Unchecked(object sender, RoutedEventArgs e)
        {
            newTheme.roundedCornerEnabled = "0";
        }

        private void setNavbarBackground_Checked(object sender, RoutedEventArgs e)
        {
            newTheme.navbarBackgroundEnabled = "1";
        }

        private void setNavbarBackground_Unchecked(object sender, RoutedEventArgs e)
        {
            newTheme.navbarBackgroundEnabled = "0";
        }

        private void setDashBoardIconColor_Checked(object sender, RoutedEventArgs e)
        {
            newTheme.dashboardSubTintEnabled = "1";
        }

        private void setDashBoardIconColor_Unchecked(object sender, RoutedEventArgs e)
        {
            newTheme.dashboardSubTintEnabled = "0";
        }

        private void dashBoardTextColor_Checked(object sender, RoutedEventArgs e)
        {
            setDashBoardIconColor.Visibility = Visibility.Visible;
            newTheme.dashboardTextColorEnabled = "1";
        }

        private void dashBoardTextColor_Unchecked(object sender, RoutedEventArgs e)
        {
            setDashBoardIconColor.Visibility = Visibility.Collapsed;
            setDashBoardIconColor.IsChecked = false;
            newTheme.dashboardTextColorEnabled = "0";
        }

        // Button to generate theme
        private void CreateTheme_Click(object sender, RoutedEventArgs e)
        {

            // Set Theme name
            if (themeName.Text.Length > 0) { newTheme.Name = themeName.Text; }
            else { DisplayErrorDialog("Set theme name", "Theme name must be set"); }

            newTheme.backgroundColor = backgroundColorPicker.Color;
            newTheme.accentColor = accentColorPicker.Color;
            newTheme.primaryColor = textColorPicker.Color;
            newTheme.secondaryColor = secondaryTextColorPicker.Color;

            // Set default dashboard color color of accent
            if(newTheme.dashboardTextColorEnabled == "0")
            {
                newTheme.dashboardTextColor = accentColorPicker.Color;
            }
            else if(newTheme.dashboardTextColorEnabled == "1")
            {
                newTheme.dashboardTextColor = DashTextColorPicker.Color;
            }


            // DashBoard Icon Style
            try
            {
                newTheme.DashIconStyle = dashIconStyle.SelectedValue.ToString();
            }
            catch
            {
                DisplayErrorDialog("Dashboard Icon style", "For generate theme you need enter Icon Style");
            }
            newTheme.DashIconColor = dashIconColorPicker.Color;


            // NavBar Icon Style
            try
            {
                newTheme.NavIconStyle = navIconStyle.SelectedValue.ToString();
            }
            catch { DisplayErrorDialog("Nav-Bar Icon style", "For generate theme you need enter Icon Style"); }

            newTheme.NavbarColor = navIconColorPicker.Color;

            // Custom DashBoard Icon Color
            if (customDashIconBgStyleSwitch.IsOn == true)
            {
                newTheme.CustomDashIconBGColor = customDashIconColorPicker.Color;
                try
                {
                    newTheme.DashIconBGStyle = customDashIconBGStyle.SelectedValue.ToString();
                }
                catch
                {
                    DisplayErrorDialog("Select Icon Style", "For generate theme you need enter Icon Style");
                }
            }

            GenerateTheme generate = new GenerateTheme();

            generate.execute(newTheme);

        }

        private void customDashboradTextColorSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            if(customDashboradTextColorSwitch.IsOn == true)
            {
                customDashboardTextColor.Visibility = Visibility.Visible;
                newTheme.dashboardTextColorEnabled = "1";
            }
            else
            {
                customDashboardTextColor.Visibility = Visibility.Collapsed;
                newTheme.dashboardTextColorEnabled = "0";
            }
        }

        private void showClock_Checked(object sender, RoutedEventArgs e)
        {
            setCenterClock.Visibility = Visibility.Visible;
            newTheme.clockEnabled = "1";

        }

        private void showClock_Unchecked(object sender, RoutedEventArgs e)
        {
            setCenterClock.Visibility = Visibility.Collapsed;
            newTheme.clockEnabled = "0";
            newTheme.centeredClockEnabled = "0";
        }

        private void setCenterClock_Checked(object sender, RoutedEventArgs e)
        {
            newTheme.centeredClockEnabled = "1";
        }

        private void setCenterClock_Unchecked(object sender, RoutedEventArgs e)
        {
            newTheme.centeredClockEnabled = "0";
        }

        private void statusBarSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            if(statusBarSwitch.IsOn == true)
            {
                StatusBarSettings.Visibility = Visibility.Visible;
                newTheme.statusBarEnabled = "1";
            }
            else
            {
                newTheme.statusBarEnabled = "0";
                StatusBarSettings.Visibility = Visibility.Collapsed;
                showBatteryIcon.IsChecked = false;
                batteryStyle.SelectedIndex = 0;
                showBatteryPercentage.IsChecked = false;
                showClock.IsChecked = false;
                setCenterClock.IsChecked = false;
                ShowCPUTemp.IsChecked = false;
            }
        }
    }
}

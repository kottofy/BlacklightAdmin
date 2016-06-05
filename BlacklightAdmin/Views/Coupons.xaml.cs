using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace BlacklightAdmin.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Coupons : Page
    {
        public Coupons()
        {
            this.InitializeComponent();
        }

        public void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        public void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), "");
        }

        public void CouponButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Views.Coupons), "");
        }

        public void InspirationButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Views.Inspiration), "");
        }

        private void InsertCouponMessage_Click(object sender, RoutedEventArgs e)
        {
            var idrandom = Messaging.getID();

            CouponMessage msg = new CouponMessage
            {
                id = idrandom,
                coupon_content = couponTxt.Text
            };

            Messaging.InsertCouponMessage(msg);

            var m1 = new MessageDialog("Data Inserted: " + msg.coupon_content).ShowAsync();

            couponTxt.Text = "";
        }


        private async void RetriveCouponMessage_Click(object sender, RoutedEventArgs e)
        {

            List<CouponMessage> allMessages = await App.MobileService.GetTable<CouponMessage>().ToListAsync();

            string res = "";

            foreach (CouponMessage mess in allMessages)
            {
                res += "Message :" + mess.coupon_content + "\n\n";
            }

            var m1 = new MessageDialog(res).ShowAsync();

        }
    }
}

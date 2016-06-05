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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BlacklightAdmin.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Inspiration : Page
    {
        public Inspiration()
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


        private void InspirationButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Views.Inspiration), "");
        }

        private void InsertData_click(object sender, RoutedEventArgs e)
        {
            var idrandom = DateTime.Now.ToBinary().ToString() + messageTxt.Text;

            InspirationMessage msg = new InspirationMessage
            {
                id = idrandom,
                content = messageTxt.Text
            };

            Messaging.InsertInspirationMessage(msg);

            var m1 = new MessageDialog("Data Inserted: " + msg.content).ShowAsync();

            messageTxt.Text = "";
        }


        private async void Retrive_Click(object sender, RoutedEventArgs e)
        {
            //List<Message> allMessages = Messaging.RetrieveMessage();

            List<InspirationMessage> allMessages = await App.MobileService.GetTable<InspirationMessage>().ToListAsync();

            string res = "";

            foreach (InspirationMessage mess in allMessages)
            {
                res += "Message :" + mess.content + "\n\n";
            }

            var m1 = new MessageDialog(res).ShowAsync();
        }
    }
}

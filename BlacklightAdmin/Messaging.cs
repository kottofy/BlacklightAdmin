using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacklightAdmin
{
    public class Messaging
    {


        public static async void InsertChatMessage(ChatMessage message)
        {
            await App.MobileService.GetTable<ChatMessage>().InsertAsync(message);
        }

        public static async void InsertInspirationMessage(InspirationMessage message)
        {
            await App.MobileService.GetTable<InspirationMessage>().InsertAsync(message);
        }

        public static async void InsertCouponMessage(CouponMessage message)
        {
            await App.MobileService.GetTable<CouponMessage>().InsertAsync(message);
        }
    }
}

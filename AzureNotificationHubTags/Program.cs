using Microsoft.Azure.NotificationHubs;
using Nito.AsyncEx;
using System;
using System.Linq;

namespace AzureNotificationHubTags
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncContext.Run(() => MainAsync(args));
        }

        static async void MainAsync(string[] args)
        {
            NotificationHubClient hub = NotificationHubClient
                              .CreateClientFromConnectionString("<Notification Hub Namespace Connection String>", "<Notification hub name>");
            var list = await hub.GetAllRegistrationsAsync(1000);
            
            if (list.Count() > 0)
            {
                foreach (var item in list)
                {
                    Console.WriteLine(string.Join(",", item.Tags));
                }
            }
        }

    }
}

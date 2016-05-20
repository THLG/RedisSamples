using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    /// <summary>
    /// More info about Key space notifications http://redis.io/topics/notifications
    /// In this sample we have set KEA as the value for notify-keyspace-events property.
    /// </summary>
    class KeySpaceNotifications
    {
        public static void Run()
        {
            IDatabase cache = Helper.Connection.GetDatabase();
            ISubscriber subscriber = Helper.Connection.GetSubscriber();
            
            // Register notification callback
            subscriber.Subscribe("__keyspace@0__:*", (channel, value) =>
            {
                Console.WriteLine("Notification raised=" + value);
            });
            
            for (var i = 1; i < 20; i++)
            {
                var key = string.Concat("Key ", i);
                var value = string.Concat("value ", i);
                database.StringSet(key, value, TimeSpan.FromSeconds(10+i));
            }
            
            Console.ReadKey();
        }
    }
}

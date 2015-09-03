﻿using CommonProvider.Example;
using CommonProvider.Example.Providers;
using System;

namespace CommonProvider.Example
{
    class Program
    {
        static void Main()
        {
            SendSms();
        }

        private static void SendSms()
        {
            var providerManager = ProviderManagerFactory.Create();
            var smsProviders = providerManager.Providers.All<ISmsProvider>();

            var message = providerManager.Settings.Get<Message>("Message");

            foreach (ISmsProvider smsProvider in smsProviders)
            {
                var result = smsProvider.SendSms(message);
                Console.WriteLine(result);
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
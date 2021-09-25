using System;
using System.IO;
using System.Threading;

using Discord.Webhook;

namespace WebhookUploader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "discord webhook uploader made by somestuff";
            Console.Write("Enter WebhookUrl: ");
            string webhook = Console.ReadLine();

            DiscordWebhookClient client = new DiscordWebhookClient(webhook);
                new Thread(() => {
                    foreach (FileInfo file in new DirectoryInfo(Directory.GetCurrentDirectory() + "/Data/").GetFiles())
                    {
                        Console.WriteLine(file.Name);
                        client.SendFileAsync(Directory.GetCurrentDirectory() + "/Data/" + file.Name, null, false);

                        Thread.Sleep(5000);
                    }
                }).Start();
            Console.ReadLine();
        }
    }
}

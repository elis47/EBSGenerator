using System;
using Newtonsoft.Json;
using System.IO;

namespace EBSGenerator
{
    class Program
    {
        private const string _publicationFilePath = @"C:\Users\Elisa\Desktop\EBS\EBSGenerator\EBSGenerator\publication.json";
        private const string _subscriptionFilePath = @"C:\Users\Elisa\Desktop\EBS\EBSGenerator\EBSGenerator\subscription.json";

        static void Main()
        {
            var publications = new PublicationGenerator().Generate(new PublicationConfiguration(), 100);

            WriteInFile(JsonConvert.SerializeObject(publications), true);

            var subcriptions = new SubscriptionGenerator().Generate(new SubscriptionConfiguration(), 100);

            WriteInFile(JsonConvert.SerializeObject(subcriptions));
        }

        static string DisplayConfiguration(object pub)
        {
            return JsonConvert.SerializeObject(pub);
        }

        public static void WriteInFile(string message, bool isPublisher = false)
        {
            var path = isPublisher ? _publicationFilePath : _subscriptionFilePath;

            if (!File.Exists(path))
            {
                var createText = message + Environment.NewLine;

                File.WriteAllText(path, createText);
            }

            var appendText = message + Environment.NewLine;

            File.AppendAllText(path, appendText);

            var readText = File.ReadAllText(path);

            Console.WriteLine(readText);
        }
    }
}

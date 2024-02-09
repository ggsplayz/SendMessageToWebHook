using System;
using System.Net.Http;
using System.Text;
//
namespace MessageToWebHook
{
    public class Program
    {
        public static string WebHookUrl = "Def";
        public static string Message = "Def";
        static void Main(string[] args)
        {
            Console.Title = "Send a Message to a Discord WebHook";
            Console.Write($"Enter YOUR* Discord WebHook Url: ");
            WebHookUrl = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Warning!");
            Console.WriteLine(" ");
            Console.WriteLine("Using a WebHook for malicious purposes could result in a Discord Account Suspension.");
            Console.WriteLine("I am not responsible of any suspended account or damage produced by this tool.");
            Console.WriteLine(" ");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            MainApp();
        }

        public static void MainApp()
        {
            Console.Clear();
            Console.WriteLine("Send a Message to a Discord WebHook");
            Console.WriteLine(" ");
            while (true)
            {
                Console.Write("Message: ");
                Message = Console.ReadLine();
                SendMessageToDiscord(Message);
            }
            
        }

        private static void SendMessageToDiscord(string message)
        {
            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent($"{{\"content\":\"{message}\"}}", Encoding.UTF8, "application/json");
                var response = client.PostAsync(WebHookUrl, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("[STATUS] Message Sent.");
                }
                else
                {
                    Console.WriteLine("[STATUS] Message not Sent. " + response.StatusCode);
                }
            }
        }
    }
}

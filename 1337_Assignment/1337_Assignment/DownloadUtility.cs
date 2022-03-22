using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;


namespace _1337_Assignment
{
    public class DownloadUtility
    {
        public async void Run(string address, string localPath)
        {

            Task<string> requestPageTask = RequestPage(address);
            Console.WriteLine("Reading page...");
            requestPageTask.Wait();
            
            var urls = await GetUrls(requestPageTask.Result);

        }
        private async Task ConsoleLoading()
        {
            Console.Write('.');
            Thread.Sleep(500);

        }

        private static async Task DownloadFileAsync(string uri, string localPath)
        {
            try
            {
                using (var client = new WebClient())
                {
                    client.DownloadFileAsync(new Uri(uri), localPath);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        private async Task<List<string>> GetUrls(string content)
        {
            var urls = new List<string>();
            const string pattern = @"a href=""(?<link>.+?)""";

            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

            MatchCollection MC = regex.Matches(content);
            foreach (Match match in MC)
            {
                urls.Add(match.Groups["link"].ToString());
            }
            return urls;
        }
        private async Task<string> RequestPage(string uri)
        {
            using (var client = new HttpClient())
            {
                return await client.GetStringAsync(uri);
            }
        }

    }
    
}

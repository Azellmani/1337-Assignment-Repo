using System;

namespace _1337_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            string url, localPath; 
            Console.WriteLine("Enter a website");
            url = Console.ReadLine();
            Console.WriteLine("Enter localPath to download to");
            localPath = Console.ReadLine(); 
            */


            
            var util = new DownloadUtility();
            util.Run("https://tretton37.com/", @"C:\Users\andzam\Test"); 

        }


    }
}

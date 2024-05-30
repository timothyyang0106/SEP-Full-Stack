/* C# Assignment 01
    Introduction to C# and Data Types
    SEP Full Stack
    Timothy Yang
    May 28th, 2024
*/

/*
Write a program that parses an URL given in the following format:
[protocol]://[server]/[resource]
The parsing extracts its parts: protocol, server and resource.
The [server] part is mandatory.
The [protocol] and [resource] parts are optional.
https://www.apple.com/iphone
[protocol] = "https"
[server] = "www.apple.com"
[resource] = "iphone"
ftp://www.example.com/employee
[protocol] = "ftp"
[server] = "www.example.com"
[resource] = "employee"
https://google.com
[protocol] = "https"
[server] = "google.com"
[resource] = ""
www.apple.com
[protocol] = ""
[server] = "www.apple.com"
[resource] = ""
Explore the following Topics
Strings
Arrays
Using the StringBuilder
*/

using System;
using System.Text;

namespace URLParser
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read the input URL
            Console.WriteLine("Enter a URL:");
            string url = Console.ReadLine();

            // Parse the URL
            ParseURL(url, out string protocol, out string server, out string resource);

            // Print the results
            Console.WriteLine($"[protocol] = \"{protocol}\"");
            Console.WriteLine($"[server] = \"{server}\"");
            Console.WriteLine($"[resource] = \"{resource}\"");
        }

        static void ParseURL(string url, out string protocol, out string server, out string resource)
        {
            protocol = "";
            server = "";
            resource = "";

            int protocolEndIndex = url.IndexOf("://");
            int serverStartIndex = 0;

            if (protocolEndIndex != -1)
            {
                protocol = url.Substring(0, protocolEndIndex);
                serverStartIndex = protocolEndIndex + 3; // Skip "://"
            }

            int resourceStartIndex = url.IndexOf('/', serverStartIndex);

            if (resourceStartIndex != -1)
            {
                server = url.Substring(serverStartIndex, resourceStartIndex - serverStartIndex);
                resource = url.Substring(resourceStartIndex + 1);
            }
            else
            {
                server = url.Substring(serverStartIndex);
            }
        }
    }
}

using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreCertConsole
{
    [Verb("read", HelpText = "Read the Certificate Store(s).")]
    class ReadOptions
    {
        [Option("StoreLocation", HelpText = "StoreLocation to Read [CurrentUser]", Default ="CurrentUser")]
        public string StoreLocation { get; set; }
        [Option("StoreName", HelpText = "StoreName to Read [My]", Default="My")]
        public string StoreName { get; set; }
    }

    [Verb("list", HelpText = "List available Stores.")]
    class ListOptions
    {

    }

    [Verb("add", HelpText = "Add a certificate to the Store.")]
    class AddOptions
    {
        [Option("StoreLocation", HelpText = "StoreLocation [CurrentUser]", Default = "CurrentUser")]
        public string StoreLocation { get; set; }

        [Option("StoreName", HelpText = "StoreName [My]", Default = "My")]
        public string StoreName { get; set; }

        [Option("Path", HelpText = "Path")]
        public string Path { get; set; }

        [Option("StoreName", HelpText = "Base64")]
        public string Base64 { get; set; }

        [Option("Password", HelpText = "Password")]
        public string Password { get; set; }

        [Option("Thumbprint", HelpText = "Thumbprint")]
        public string Thumbprint { get; set; }
    }

    [Verb("remove", HelpText = "Removes a certificate from the Store.")]
    class RemoveOptions
    {
        [Option("StoreLocation", HelpText = "StoreLocation [CurrentUser]", Default = "CurrentUser")]
        public string StoreLocation { get; set; }
        
        [Option("StoreName", HelpText = "StoreName [My]", Default = "My")]
        public string StoreName { get; set; }

        [Option("Path", HelpText = "Path")]
        public string Path { get; set; }

        [Option("StoreName", HelpText = "Base64")]
        public string Base64 { get; set; }

        [Option("Password", HelpText = "Password")]
        public string Password { get; set; }

        [Option("Thumbprint", HelpText = "Thumbprint")]
        public string Thumbprint { get; set; }

    }

}

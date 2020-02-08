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

    [Verb("add", HelpText = "Add a certificate to the Store.")]
    class AddOptions
    {
        //[Option("StoreLocation", HelpText = "StoreLocation to Read[CurrentUser]", Default = "CurrentUser")]
        //public string StoreLocation { get; set; }

        //[Option("StoreName", HelpText = "StoreName to Read [My]", Default = "My")]
        //public string StoreName { get; set; }

    }

    [Verb("delete", HelpText = "Delete a certificate from the Store.")]
    class DeleteOptions
    {
        [Option("StoreLocation", HelpText = "StoreLocation to Read [CurrentUser]", Default = "CurrentUser")]
        public string StoreLocation { get; set; }
        
        [Option("StoreName", HelpText = "StoreName to Read [My]", Default = "My")]
        public string StoreName { get; set; }

    }

}

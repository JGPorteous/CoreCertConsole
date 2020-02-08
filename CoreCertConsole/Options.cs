using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreCertConsole
{
    [Verb("read", HelpText = "Read the Certificate Store(s).")]
    class ReadOptions
    {
        //read options here
            
    }
    [Verb("add", HelpText = "Add a certificate to the Store.")]
    class AddOptions
    {
        //add options here
    }
    [Verb("delete", HelpText = "Delete a certificate from the Store.")]
    class DeleteOptions
    {
        //delete options here
    }

}

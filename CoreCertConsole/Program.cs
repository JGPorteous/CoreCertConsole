using CommandLine;
using System;

namespace CoreCertConsole
{
    class Program
    {
        static int Main(string[] args)
        {
            return CommandLine.Parser.Default.ParseArguments<ReadOptions, AddOptions, DeleteOptions, ListOptions>(args)
                .MapResult(
                  (ReadOptions opts) => RunReadAndReturnExitCode(opts),
                  (AddOptions opts) => RunAddAndReturnExitCode(opts),
                  (DeleteOptions opts) => RunDeleteAndReturnExitCode(opts),
                  (ListOptions opts) => RunListAndReturnExitCode(opts),
                  errs => 1);
        }

        private static int RunListAndReturnExitCode(ListOptions opts)
        {
            CertStoreManager testRead = new CertStoreManager();
            testRead.ListStoreDetails();

            return 0;
        }

        private static int RunReadAndReturnExitCode(ReadOptions opts)
        {
            CertStoreManager testRead = new CertStoreManager(opts.StoreLocation, opts.StoreName);
            testRead.Run();

            return 0;
        }
        
        private static int RunDeleteAndReturnExitCode(DeleteOptions opts)
        {
            throw new NotImplementedException();
        }

        private static int RunAddAndReturnExitCode(AddOptions opts)
        {
            throw new NotImplementedException();
        }

       
    }
}

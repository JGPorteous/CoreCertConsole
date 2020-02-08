using CommandLine;
using System;

namespace CoreCertConsole
{
    class Program
    {
        static int Main(string[] args)
        {
            return CommandLine.Parser.Default.ParseArguments<ReadOptions, AddOptions, RemoveOptions, ListOptions>(args)
                .MapResult(
                  (ReadOptions opts) => RunReadAndReturnExitCode(opts),
                  (AddOptions opts) => RunAddAndReturnExitCode(opts),
                  (RemoveOptions opts) => RunRemoveAndReturnExitCode(opts),
                  (ListOptions opts) => RunListAndReturnExitCode(opts),
                  errs => 1);
        }

        private static int RunListAndReturnExitCode(ListOptions opts)
        {
            CertStoreManager certStoreManager = new CertStoreManager();
            certStoreManager.ListStoreDetails();

            return 0;
        }

        private static int RunReadAndReturnExitCode(ReadOptions opts)
        {
            CertStoreManager certStoreManager = new CertStoreManager(opts.StoreLocation, opts.StoreName);
            certStoreManager.Run();

            return 0;
        }
        
        private static int RunRemoveAndReturnExitCode(RemoveOptions opts)
        {
            CertStoreManager certStoreManager = new CertStoreManager(opts.StoreLocation, opts.StoreName);
            certStoreManager.RemoveCertificate(opts.Path, opts.Base64, opts.Password, opts.Thumbprint);

            return 0;
        }

        private static int RunAddAndReturnExitCode(AddOptions opts)
        {
            CertStoreManager certStoreManager = new CertStoreManager(opts.StoreLocation, opts.StoreName);
            certStoreManager.AddCertificate(opts.Path, opts.Base64, opts.Password, opts.Thumbprint);

            return 0;
        }
    }
}

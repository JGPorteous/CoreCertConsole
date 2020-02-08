using System;
using System.Security.Cryptography.X509Certificates;

namespace CoreCertConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Certificate Store Enqury!\n");
            foreach(StoreLocation storeLocation in (StoreLocation[])Enum.GetValues(typeof(StoreLocation)))
            {
                foreach (StoreName storeName in (StoreName[])Enum.GetValues(typeof(StoreName)))
                {
                    Console.WriteLine();
                    Console.WriteLine($"\\\\{storeLocation.ToString()}\\{storeName.ToString()}");

                    using (var store = new X509Store(storeName, storeLocation))
                    {
                        store.Open(OpenFlags.ReadOnly);
                        foreach (var cert in store.Certificates)
                        {
                            Console.WriteLine($"{cert.Subject.Substring(1,10)} : {cert.Thumbprint}");
                        }
                    }
                }
            }
        }
    }
}

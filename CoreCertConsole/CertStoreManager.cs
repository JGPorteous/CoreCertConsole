using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography.X509Certificates;

namespace CoreCertConsole
{
    public class CertStoreManager
    {
        StoreLocation storeLocation;
        StoreName storeName;

        public CertStoreManager()
        {
            this.storeLocation = StoreLocation.CurrentUser;
            this.storeName = StoreName.My;
        }
        public CertStoreManager(string storeLocation, string storeName)
        {
            if (!Enum.TryParse<StoreLocation>(storeLocation, out this.storeLocation))
                this.storeLocation = StoreLocation.CurrentUser;

            if (!Enum.TryParse<StoreName>(storeName, out this.storeName))
                this.storeName = StoreName.My;
        }

        public void Run()
        {
            using (var store = new X509Store(storeName, storeLocation))
            {
                store.Open(OpenFlags.ReadOnly);
                Console.WriteLine($"Store: \\\\{storeLocation.ToString()}\\{storeName.ToString()}");
                foreach (var cert in store.Certificates)
                {
                    Console.WriteLine($"{cert.Subject.Substring(1, 10)} : {cert.Thumbprint}");
                }
            }
        }

        public void RunAll()
        {
            Console.WriteLine("Certificate Store Enqury!\n");
            foreach (StoreLocation storeLocation in (StoreLocation[])Enum.GetValues(typeof(StoreLocation)))
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
                            Console.WriteLine($"{cert.Subject.Substring(1, 10)} : {cert.Thumbprint}");
                        }
                    }
                }
            }
        }

        public void ListStoreDetails()
        {
            Console.WriteLine("List Certificate Stores\n");
            foreach (StoreLocation storeLocation in (StoreLocation[])Enum.GetValues(typeof(StoreLocation)))
            {
                foreach (StoreName storeName in (StoreName[])Enum.GetValues(typeof(StoreName)))
                {
                    Console.WriteLine($"\\\\{storeLocation.ToString()}\\{storeName.ToString()}");
                }
            }
        }
    }
}

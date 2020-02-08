using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography.X509Certificates;

namespace CoreCertConsole
{
    public class CertStoreManager
    {
        readonly StoreLocation storeLocation;
        readonly StoreName storeName;
        private const int subjectLength = 20;

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
            using var store = new X509Store(storeName, storeLocation);
            store.Open(OpenFlags.ReadOnly);
            
            Console.WriteLine($"Store: \\\\{storeLocation.ToString()}\\{storeName.ToString()}");
            
            foreach (var cert in store.Certificates)
            {
                Console.WriteLine($"{cert.Subject.Substring(1, subjectLength)} : {cert.Thumbprint}");
            }

            store.Close();
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

                    using var store = new X509Store(storeName, storeLocation);
                    store.Open(OpenFlags.ReadOnly);
                    foreach (var cert in store.Certificates)
                    {
                        Console.WriteLine($"{cert.Subject.Substring(1, subjectLength)} : {cert.Thumbprint}");
                    }
                    store.Close();
                }
            }
        }

        public void AddCertificate(string path, string base64, string password, string thumbprint)
        {
            X509Certificate2 cert = null;
            if (!string.IsNullOrEmpty(path))
            {
                Console.WriteLine($"Installing certificate from '{path}' to '{storeName}' certificate store (location: {storeLocation})...");

                cert = new X509Certificate2(
                    path,
                    password,
                    X509KeyStorageFlags.DefaultKeySet);
            }
            else if (!string.IsNullOrEmpty(base64))
            {
                Console.WriteLine($"Installing certificate from base 64 string to '{storeName}' certificate store (location: {storeLocation})...");

                var bytes = Convert.FromBase64String(base64);
                cert = new X509Certificate2(
                    bytes,
                    password,
                    X509KeyStorageFlags.DefaultKeySet);
            }

            if (cert == null)
            {
                throw new ArgumentNullException("Unable to create certificate from provided arguments.");
            }

            var store = new X509Store(storeName, storeLocation);
            store.Open(OpenFlags.ReadWrite);
            store.Add(cert);

            var certificates = store.Certificates.Find(X509FindType.FindByThumbprint, thumbprint, false);
            if (certificates.Count <= 0)
            {
                throw new ArgumentNullException("Unable to validate certificate was added to store.");
            }

            Console.WriteLine("Done.");
            store.Close();
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

        public void RemoveCertificate(string path, string base64, string password, string thumbprint)
        {
            X509Certificate2 cert = null;
            if (!string.IsNullOrEmpty(path))
            {
                Console.WriteLine($"Removing certificate from '{path}' from '{storeName}' certificate store (location: {storeLocation})...");
                cert = new X509Certificate2(
                    path,
                    password,
                    X509KeyStorageFlags.DefaultKeySet);
            }
            else if (!string.IsNullOrEmpty(base64))
            {
                Console.WriteLine($"Removing certificate from base 64 string from '{storeName}' certificate store (location: {storeLocation})...");
                var bytes = Convert.FromBase64String(base64);
                cert = new X509Certificate2(
                    bytes,
                    password,
                    X509KeyStorageFlags.DefaultKeySet);
            }

            if (cert == null)
            {
                throw new ArgumentNullException("Unable to remove certificate from provided arguments.");
            }

            var store = new X509Store(storeName, storeLocation);
            store.Open(OpenFlags.ReadWrite);
            store.Remove(cert);

            var certificates = store.Certificates.Find(X509FindType.FindByThumbprint, thumbprint, false);
            if (certificates.Count > 0)
            {
                throw new ArgumentNullException("Unable to validate certificate was removed from store.");
            }

            Console.WriteLine("Done.");

            store.Close();
        }
    }
}

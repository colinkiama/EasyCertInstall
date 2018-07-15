using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace EasyCertInstall
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                string filePath = args[0];
                bool doesFileExist = System.IO.File.Exists(filePath);
                if (doesFileExist)
                {
                    string fileExtension = filePath.Split('.')[1];
                    if (fileExtension == ".cer")
                    {
                        InstallCertFromCertFilePath(filePath);
                    }
                    else if (fileExtension == ".appx" || fileExtension == ".appxbundle")
                    {
                        InstallCertFromSignedPackage(filePath);
                    }
                }
                else if (Directory.Exists(args[0]))
                {
                    InstallCertFromDirectory(args[0]);
                }
            }
            
            else
            {
                string currentDirectory = Directory.GetCurrentDirectory();
                InstallCertFromDirectory(currentDirectory);
            }
            
            

            
           
            Console.ReadLine();
        }

        private static void InstallCertFromDirectory(string currentDirectory)
        {
            Console.WriteLine($"Current directory is: {currentDirectory}");
            var files = Directory.GetFiles(currentDirectory, "*.cer");


            if (files.Length > 0)
            {
                string certFileName = files.First();
                X509Certificate2 cert = new X509Certificate2(certFileName);
                using (X509Store store = new X509Store(StoreName.TrustedPeople, StoreLocation.LocalMachine))
                {
                    store.Open(OpenFlags.ReadWrite);
                    store.Add(cert);
                }
                Console.WriteLine($"{certFileName} has successfully been added to the certifcate store.");
                Console.WriteLine("You can now easily install the app by double clicking the .appx/.appxbundle file");
            }

            else
            {
                InstallCertFromSignedPackage();
            }


        }

        private static void InstallCertFromSignedPackage(string filePath)
        {
            PrintFilePath(filePath);
            X509Certificate certFromSignedPkg = X509Certificate.CreateFromSignedFile(filePath);
            X509Certificate2 cert = new X509Certificate2(certFromSignedPkg);
            using (X509Store store = new X509Store(StoreName.TrustedPeople, StoreLocation.LocalMachine))
            {
                store.Open(OpenFlags.ReadWrite);
                store.Add(cert);
            }
            Console.WriteLine($"Certificate for signed package: {filePath} has successfully been added to the certifcate store.");
            Console.WriteLine("You can now easily install the app by double clicking the .appx/.appxbundle file");
        }

        private static void InstallCertFromCertFilePath(string filePath)
        {
            PrintFilePath(filePath);
            X509Certificate2 cert = new X509Certificate2(filePath);
            using (X509Store store = new X509Store(StoreName.TrustedPeople, StoreLocation.LocalMachine))
            {
                store.Open(OpenFlags.ReadWrite);
                store.Add(cert);
            }
            Console.WriteLine($"{filePath} has successfully been added to the certifcate store.");
            Console.WriteLine("You can now easily install the app by double clicking the .appx/.appxbundle file");
        }

        private static void PrintFilePath(string filePath)
        {
            Console.WriteLine($"Current file path: {filePath}");
        }

        private static void InstallCertFromSignedPackage()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            var files = Directory.GetFiles(currentDirectory, "*.appxbundle");


            if (files.Length > 0)
            {
                string signedPackagePath = files.First();
                X509Certificate certFromSignedPkg = X509Certificate.CreateFromSignedFile(signedPackagePath);
                X509Certificate2 cert = new X509Certificate2(certFromSignedPkg);
                using (X509Store store = new X509Store(StoreName.TrustedPeople, StoreLocation.LocalMachine))
                {
                    store.Open(OpenFlags.ReadWrite);
                    store.Add(cert);
                }
                Console.WriteLine($"Certificate for signed package: {signedPackagePath} has successfully been added to the certifcate store.");
                Console.WriteLine("You can now easily install the app by double clicking the .appx/.appxbundle file");
            }

            else
            {
                files = Directory.GetFiles(currentDirectory, "*.appx");
                if (files.Length > 0)
                {
                    string signedPackagePath = files.First();
                    X509Certificate certFromSignedPkg = X509Certificate.CreateFromSignedFile(signedPackagePath);
                    X509Certificate2 cert = new X509Certificate2(certFromSignedPkg);
                    using (X509Store store = new X509Store(StoreName.TrustedPeople, StoreLocation.LocalMachine))
                    {
                        store.Open(OpenFlags.ReadWrite);
                        store.Add(cert);
                    }
                    Console.WriteLine($"Certificate for signed package: {signedPackagePath} has successfully been added to the certifcate store.");
                    Console.WriteLine("You can now easily install the app by double clicking the .appx/.appxbundle file");
                }
                else
                {

                    Console.WriteLine("Certificate file or signed package is not available in the current directory.");
                    Console.WriteLine("Please launch this program in the directory where the certifcate file or appx  you want to install is located");
                }
            }

        }
    }
}

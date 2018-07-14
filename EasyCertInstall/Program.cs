using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EasyCertInstall
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            Console.WriteLine($"Current directory is: {currentDirectory}");
            var files = Directory.GetFiles(currentDirectory,"*.cer");

            string certFileName = "";

            if (files.Count() > 0)
            {
                certFileName = files.First();
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
                Console.WriteLine("Certificate file is not available in the current directory.");
                Console.WriteLine("Please launch this program in the directory where the certifcate file you want to install is located");
            }

            Console.ReadLine();
        }
    }
}

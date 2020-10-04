using Microsoft.Win32;
using System;
using System.Management;

namespace InstalledSoftware
{
    class Program
    {
        static void Main(string[] args)
        {
            string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key))
            {
                foreach (string subkey_name in key.GetSubKeyNames())
                {
                    using (RegistryKey subkey = key.OpenSubKey(subkey_name))
                    {
                        Console.WriteLine(subkey.GetValue("DisplayName")?.ToString() + "\t"+ subkey.GetValue("Publisher") + "\t"+ subkey.GetValue("InstallDate"));
                    }
                }
            }

            //WqlObjectQuery wqlQuery = new WqlObjectQuery("SELECT Name,Version FROM Win32_Product");
            //ManagementObjectSearcher searcher = new ManagementObjectSearcher(wqlQuery);
            //foreach (ManagementObject row in searcher.Get())
            //{
            //    object name = row["Name"];
            //    object version = row["Version"];
            //    Console.WriteLine("Name: " + name + " - Version: " + version);
            //}

            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.Read();
        }
    }
}

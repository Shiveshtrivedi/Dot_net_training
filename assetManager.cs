using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asset_Management_System
{
    public class AssetManager
    {
        private List<Asset> assets = new List<Asset>();
        public void AddAsset(string name, string additionalInfo, string assetType)
        {
            Asset asset = null;
            switch (assetType.ToLower())
            {
                case "book":
                    asset = new Book(name, additionalInfo);
                    break;

                case "software":
                    asset = new SoftwareLicense(name, additionalInfo);
                    break;
                case "hardware":
                    asset = new Hardware(name, additionalInfo);
                    break;

                default:
                    Console.WriteLine("invalid asset type");
                    return;
            }
            assets.Add(asset);

        }

        public bool SearchAsset(string name, string assetType)
        {
            foreach (var asset in assets)
            {
                if (asset.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && asset.GetAssetType().Equals(assetType, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        public bool UpdateAsset(string oldName)
        {
            var assetToUpdate = assets.FirstOrDefault(a => a.Name.Equals(oldName, StringComparison.OrdinalIgnoreCase));

            if (assetToUpdate == null)
            {
                Console.WriteLine($"Asset with name '{oldName}' not found.");
                return false;
            }

            Console.WriteLine("Updating asset...");


            Console.Write("Enter new name ");
            string newName = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(newName))
            {
                assetToUpdate.Name = newName;
            }

            return true;


        }

        public void RemoveAsset(string Name)
        {
            var findAsset = assets.Find(a => a.Name == Name);
            if (findAsset != null)
            {
                assets.Remove(findAsset);
            }
            else
            {
                Console.WriteLine("please eneter correct asset");
            }
        }
        public void DisplayAsset()
        {
            Console.Write("in display asset");
            foreach (var asset in assets)
            {
                Console.WriteLine($"asset name is {asset.Name} asset type {asset.GetAssetType()} asset information is ");
                if (asset is Book book)
                {
                    Console.WriteLine($"  Author: {book.Author}");
                }
                else if (asset is SoftwareLicense software)
                {
                    Console.WriteLine($"  License Key: {software.LicenseKey}");
                }
                else if (asset is Hardware hardware)
                {
                    Console.WriteLine($"  Specifications: {hardware.Specification}");
                }
            }

        }
    }
}

// See https://aka.ms/new-console-template for more information
using Asset_Management_System;

Console.WriteLine("Hello, World!");


AssetManager assetManager = new AssetManager();

while (true)
{
    Console.WriteLine("1. Add an asset\r\n\r\n2. Search an asset\r\n\r\n3. Update an asset\r\n\r\n4. Delete an asset\r\n\r\n5. List of all available assets.\r\n\r\n6. Exit");
    var choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
            Console.WriteLine("Enter name , type and additional info");
            string name = Console.ReadLine();
            string type = Console.ReadLine();
            string additionalInfo = Console.ReadLine();
            assetManager.AddAsset(name, additionalInfo, type);
            break;
        case "2":
            Console.Write("Enter asset name to search: ");
            string searchName = Console.ReadLine();
            Console.Write("Enter asset type to search (Book/Software/Hardware): ");
            string searchType = Console.ReadLine();
            bool found = assetManager.SearchAsset(searchName, searchType);
            if (found)
            {
                Console.WriteLine("Asset found.");
            }
            else
            {
                Console.WriteLine("Asset not found.");
            }
            break;
        case "3":
            Console.WriteLine("enter the name of asset that you want to update");
            string oldName = Console.ReadLine();
            bool checkValueExist = assetManager.UpdateAsset(oldName);
            if (checkValueExist == false)
            {
                Console.WriteLine("element not found");
            }
            break;
        case "4":
            Console.WriteLine("enter the name of asset that you want to delete");
            string assetName = Console.ReadLine();
            assetManager.RemoveAsset(assetName);

            break;


        case "5":
            Console.WriteLine("list of assets are");
            assetManager.DisplayAsset();
            break;
        case "6":
            choice = Console.ReadLine();
            break;

        default:
            Console.WriteLine("enter valid case please !!!");
            break;
    }

}
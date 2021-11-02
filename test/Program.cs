using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Specialized;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            

            string imagePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Database\\images";

            List<dynamic> menuListSeed = new List<dynamic>();

            ListDictionary listWater = new ListDictionary();
            listWater.Add("description", "Fresh from the tap");
            listWater.Add("imageId", "water");
            listWater.Add("id", 0);
            listWater.Add("price", 1.99);
            listWater.Add("name", "Water");

            ListDictionary listWrap = new ListDictionary();
            listWrap.Add("description", "Chicken Wrap - Sandwich");
            listWrap.Add("imageId", "wrap");
            listWrap.Add("id", 1);
            listWrap.Add("price", 14.99);
            listWrap.Add("name", "Chicken Wrap");

            ListDictionary listStew = new ListDictionary();
            listStew.Add("description", "A slow cooked stew");
            listStew.Add("imageId", "stew");
            listStew.Add("id", 2);
            listStew.Add("price", 12.99);
            listStew.Add("name", "Stew");

            ListDictionary listSoup = new ListDictionary();
            listSoup.Add("description", "It looks good in the menu picture");
            listSoup.Add("imageId", "soup");
            listSoup.Add("id", 3);
            listSoup.Add("price", 4.99);
            listSoup.Add("name", "Tomato Soup");

            ListDictionary listSalad = new ListDictionary();
            listSalad.Add("description", "A green salad");
            listSalad.Add("imageId", "salad");
            listSalad.Add("id", 4);
            listSalad.Add("price", 4.99);
            listSalad.Add("name", "Salad");

            menuListSeed.Add(listWater);
            menuListSeed.Add(listWrap);
            menuListSeed.Add(listStew);
            menuListSeed.Add(listSoup);
            menuListSeed.Add(listSalad);

            foreach (var menuItem in menuListSeed)
            {
                Console.WriteLine(menuItem["imageId"]);
                string fileName = imagePath + "\\" + menuItem["imageId"] + ".jpg";
                
            }

           // PrepulateImages(menu_start_raw);
        }

        private static void PrepulateImages (string json)
        {
            string imagePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Database\\images";
            Console.WriteLine(imagePath);

            var ext = new List<string> { "jpg" };
            var imageFiles = Directory
                .EnumerateFiles(imagePath, "*.*", SearchOption.AllDirectories)
                .Where(s => ext.Contains(Path.GetExtension(s).TrimStart('.').ToLowerInvariant()));

            foreach (var image in imageFiles)
            {
                Console.WriteLine(image);
            }
        }
    }
}

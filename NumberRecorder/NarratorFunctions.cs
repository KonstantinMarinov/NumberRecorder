using EFGetStarted;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberRecorder
{
    public static class NarratorFunctions
    {
        public static void printIntroduction()
        {
            Console.WriteLine("Hi, this is a simple app.");
            Console.WriteLine("Use one of the following commands:");
            Console.WriteLine("1.Add a number to the database.");
            Console.WriteLine("2.Show all stored numbers.");
            Console.WriteLine("3.Clear the database.");
            Console.WriteLine("4.Show all menu options.");
            Console.WriteLine("5.Exit app.");
        }
        public static void printMenu()
        {
            Console.WriteLine("1.Add a number to the database.");
            Console.WriteLine("2.Show all stored numbers.");
            Console.WriteLine("3.Clear the database.");
            Console.WriteLine("4.Show all menu options.");
            Console.WriteLine("5.Exit app.");
        }
        public static void mainMenuLoop()
        {
            bool ongoing = true;
            NarratorFunctions.printIntroduction();
            var db = new BloggingContext();
            while (ongoing)

            {
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    Console.WriteLine("Write the number:");
                    string number = Console.ReadLine();
                    var dbNumber = new Blog { Number = number };
                    db.Add(dbNumber);
                    db.SaveChanges();
                    Console.WriteLine("The number has been added.");
                    NarratorFunctions.printMenu();

                }
                else if (choice == "2")
                {
                    int allInfo = db.Blogs.Count();
                    if (allInfo > 0)
                    {
                        Console.WriteLine("Here are all the numbers:");
                        db = new BloggingContext();
                        var allNumbers = db.Blogs.ToList();
                        foreach (var blog in allNumbers)
                        {
                            Console.WriteLine(blog.Number);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No information in the database.");
                    }
                    NarratorFunctions.printMenu();

                }
                else if (choice == "3")
                {
                    Console.WriteLine("Clearing database information.");
                    int allInfo = db.Blogs.Count();
                    for (int i = 0; i < allInfo; i++)
                    {
                        var blog = db.Blogs.OrderBy(b => b.Number).FirstOrDefault();
                        db.Remove(blog);
                        db.SaveChanges();
                    }
                    NarratorFunctions.printMenu();
                }
                else if (choice == "4")
                {
                    NarratorFunctions.printMenu();
                }
                else if (choice == "5")
                {
                    ongoing = false;
                }
            }
        }
    }
}

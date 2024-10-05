using System;
using System.Collections.Generic;

public class BabyDress
{
    public int Size { get; set; }
    public string Color { get; set; }
    public string Brand { get; set; }
    public double Price { get; set; }
}

public class BabyDressUtility
{
    // Adds a dress to the cart
    public void AddDressToCart(BabyDress dress)
    {
        Program.DressesCart.Add(dress);
    }

    // Removes a dress from the cart by brand
    public bool RemoveDressFromCart(string brand)
    {
        // Find the dress with the specified brand
        BabyDress dressToRemove = Program.DressesCart.Find(d => d.Brand == brand);

        // If dress is found, remove it
        if (dressToRemove != null)
        {
            Program.DressesCart.Remove(dressToRemove);
            return true;
        }
        return false;
    }
}

public class Program
{
    // List to hold the cart items (baby dresses)
    public static List<BabyDress> DressesCart { get; set; } = new List<BabyDress>();

    public static void Main(string[] args)
    {
        BabyDressUtility dressUtility = new BabyDressUtility();
        bool keepRunning = true;

        while (keepRunning)
        {
            // Display the menu options to the user
            Console.WriteLine("1. Add dress to cart");
            Console.WriteLine("2. Remove dress from cart");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Enter your choice");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    // Get dress details from the user
                    Console.WriteLine("Enter the dress size");
                    int size = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter the dress color");
                    string color = Console.ReadLine();

                    Console.WriteLine("Enter the dress brand");
                    string brand = Console.ReadLine();

                    Console.WriteLine("Enter the dress price");
                    double price = Convert.ToDouble(Console.ReadLine());

                    // Create a new dress object
                    BabyDress newDress = new BabyDress
                    {
                        Size = size,
                        Color = color,
                        Brand = brand,
                        Price = price
                    };

                    // Add the dress to the cart
                    dressUtility.AddDressToCart(newDress);

                    // Notify the user
                    Console.WriteLine("Successfully added to the dress cart");
                    break;

                case 2:
                    // Get the brand of the dress to remove
                    Console.WriteLine("Enter the dress brand to remove the dress from cart");
                    string brandToRemove = Console.ReadLine();

                    // Attempt to remove the dress
                    if (dressUtility.RemoveDressFromCart(brandToRemove))
                    {
                        // Notify success
                        Console.WriteLine("Successfully removed from the cart");
                    }
                    else
                    {
                        // Notify failure
                        Console.WriteLine("Dress not found in the cart");
                    }
                    break;

                case 3:
                    // Exit the program
                    Console.WriteLine("Thank you!");
                    keepRunning = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }
}


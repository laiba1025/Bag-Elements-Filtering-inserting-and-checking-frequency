using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Assignment;

public class Menu
{
    public static int menu()
    {
        Console.WriteLine("\nSelect your choice:");
        Console.WriteLine("0: Exit the menu");
        Console.WriteLine("1: Insert an Element");
        Console.WriteLine("2:   Remove an Element");
        Console.WriteLine("3: Max value of the Bag");
        Console.WriteLine("4: Frequency of an Element");
        Console.WriteLine("5: Print the Bag");
        Console.Write("Enter your choice: ");

        int choice;
        while (true)
        {
            try
            {
                choice = int.Parse(Console.ReadLine());
                if (choice < 0)
                {
                    throw new ArgumentOutOfRangeException("\n There is no such option in menu. Please choose the option from 0-5");
                }
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("\n Input is Incorrect. Please enter a correct integer.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Write("\nEnter your choice Again: ");
        }
        return choice;
    }


    public static void Main(string[] args)
    {
        Bag bag = new Bag();
        int choice;
        do
        {
            choice = menu();
            //Add an Element
            if (choice == 0)
            {
                break;
            }else if(choice == 1)
            {
                Console.Write("Enter element to insert: ");
                int elementInsert = int.Parse(Console.ReadLine());
                bag.InsertElement(elementInsert);
                bag.PrintBag();
            }
            //Remove an Element
            else if(choice == 2)
            {
                try
                {
                    Console.Write("Enter element to remove: ");
                    int elementRemove = int.Parse(Console.ReadLine());
                    bag.RemoveElement(elementRemove);
                    bag.PrintBag();
                }
                catch (FormatException e) {
                    Console.WriteLine(e.Message);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch(Bag.Elementnotfound) 
                {
                  Console.WriteLine("The element you want to remove is not in the bag. The bag elements are listed below: ");
                    bag.PrintBag();
                }
            }
            //GetLargest Value from Bag
            else if(choice == 3)
            {
                try
                {
                    Console.WriteLine($"The Max value from Bag is: {bag.GetLargest()}");
                }
                catch (Bag.EmptybagException)
                {
                    Console.WriteLine("\n No element in the bag, The bag is Empty");
                }
            }
            //Find the frequency of Element
            else if (choice == 4)
            {
                try
                {
                    Console.Write("Enter element to find frequency: ");
                    int elementFrequency = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Frequency of {elementFrequency}: {bag.GetFrequency(elementFrequency)}");
                }
                catch (Bag.Elementnotfound)
                {
                    Console.WriteLine("The bag is empty. Insert an element.");
                }
                catch (ArgumentException n)
                {
                    Console.WriteLine(n.Message);
                }
            }
            //Print the Bag
            else if (choice == 5)
            {
                try
                {
                    bag.PrintBag();
                }
                catch (InvalidOperationException a) {
                    Console.WriteLine(a.Message);
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        } while (choice != 0);
    }
}
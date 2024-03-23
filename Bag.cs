using System;
using System.Collections.Generic;

namespace Assignment

{
   
    public class Bag
    { 
        public class EmptybagException : Exception { }
        public class Elementnotfound : Exception { }

        private List<Element> bag_values;
        private int max_value;

        public Bag()
        {
            bag_values = new List<Element>();
            max_value = int.MinValue;
        }
        // Method for inserting an element
        public void InsertElement(int element)
        {
            bool isFound = false;
            for (int i = 0; i < bag_values.Count; i++)
            {
                if (bag_values[i].elem == element)
                {
                    bag_values[i].freq++;
                    isFound = true;
                }
            }

            if (!isFound)
            {
                Element elem = new Element(element);
                bag_values.Add(elem);
                //bag_values.Add(new Element(element));
            }

            if (element > max_value)
                max_value = element;
        }
        // Method for Removing an element
        public void RemoveElement(int element)
        {
            bool elem_Found = false;
            if (bag_values.Count == 0)
            {
                throw new InvalidOperationException("The bag is Empty");
            }
            for (int i = 0; i < bag_values.Count; i++)
            {
                if (bag_values[i].elem == element)
                {
                    if (bag_values[i].freq == 1)
                    {
                        bag_values.RemoveAt(i);
                    }
                    else
                        bag_values[i].freq--;
                    elem_Found = true;
                    break;
                }
            } if (!elem_Found)
            {
                throw new Elementnotfound();
            }
        }
        // Method to Get the Frequency of an Element
        public int GetFrequency(int element)
        {   
            //bool is_Found = false;
            if (bag_values.Count == 0)
            {
                throw new Elementnotfound();
            }
            for(int i = 0; i < bag_values.Count; i++)
            {
                if (bag_values[i].elem == element)
                {
                    //is_Found = true;
                    return bag_values[i].freq;
                }
            }

            /*foreach (Element e in bag_values)
            {
                if (e.elem == element)
                {   
                    is_Found = true;
                    return e.freq;
                }
            }
            
            if (!is_Found)
            {
                throw new ArgumentException($"Element {element} is not found in the bag");
            }*/
            throw new ArgumentException($"Element {element} is not found in the bag");
            //return 0;
        }
        // Method to get the Largest Element from the Bag 
        public int GetLargest()
        {
            if (max_value == int.MinValue)
            {
                throw new EmptybagException();
            }
            return max_value;
        }
        // Method for Printing the Bag
        public void PrintBag()
        {
            if (bag_values.Count == 0)
            {
                throw new InvalidOperationException("There is not Element in the bag. The bag is empty");
            } 
            foreach (Element item in bag_values)
            {
                Console.WriteLine($"Element: {item.elem}, Frequency: {item.freq}");
            }
        }
        private class Element
        {
            public int elem { get; }
            public int freq { get; set; }

            public Element(int elem)
            {
                this.elem = elem;
                freq = 1;
            }
        }
    }
}
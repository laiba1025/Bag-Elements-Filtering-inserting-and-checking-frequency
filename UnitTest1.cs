using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment;
using System.Security.Cryptography.X509Certificates;

namespace BagTest
{
    [TestClass]
    public class BagTests
    {
        [TestMethod]
        public void TestMenuInput_ValidChoice()
        {
            // Arrrangement
            string input = "3\n"; 
            int expectedChoice = 3;

            
            using (StringReader sr = new StringReader(input))
            {
                Console.SetIn(sr); 
                int actualChoice = Menu.menu();
                Assert.AreEqual(expectedChoice, actualChoice);
            }
        }
       // BagTests for InsertElement Method
        [TestMethod]
        public void TestInsert_New()
        {
            Bag bag = new Bag();

            bag.InsertElement(5);

            Assert.AreEqual(1, bag.GetFrequency(5));

            Assert.AreEqual(5, bag.GetLargest());
        }

        [TestMethod]
        public void TestInsert_Existing() { 
            Bag bag = new Bag();

            bag.InsertElement(5);
            bag.InsertElement(5);
            Assert.AreEqual(2, bag.GetFrequency(5));
        }
        // BagTests For Remove Element Method
        [TestMethod]
        public void TestRemove_Existing_Element() { 
            Bag bag = new Bag();
            bag.InsertElement(15);
            bag.InsertElement(15);
            bag.InsertElement(15);
            bag.RemoveElement(15);

            Assert.AreEqual(2, bag.GetFrequency(15));
        
        }
        [TestMethod]
        public void TestRemoveElement_EmptyBag()
        {
            Bag bag = new Bag();
            bag.InsertElement(10);
            Assert.ThrowsException<Bag.Elementnotfound>(() => bag.RemoveElement(5));
        }
        // BagTests For GetFrequency Method
        [TestMethod]
        public void TestFrequency_EmptyBag() 
        {
            Bag bag = new Bag();
            Assert.ThrowsException<Bag.Elementnotfound>(() => bag.GetFrequency(2));
        }

        [TestMethod]
        public void TestFrequency_Elements() {
            Bag bag = new Bag();
            bag.InsertElement(1);
            bag.InsertElement(1);
            bag.InsertElement(8);
            Assert.AreEqual(2, bag.GetFrequency(1));
            Assert.AreEqual(1, bag.GetFrequency(8));
        }
        // BagTests For GetLargest Method
        [TestMethod]
        public void LargestElement_EmptyBag() {
            Bag bag = new Bag();
            Assert.ThrowsException<Bag.EmptybagException>(() => bag.GetLargest());
        }
        [TestMethod]
        public void LargestElement_NonEmptyBag() {
            Bag bag = new Bag();
            bag.InsertElement(1);
            bag.InsertElement(8);
            bag.InsertElement(7);
            Assert.AreEqual(8, bag.GetLargest());
        }
        // BagTests for Print Method
        [TestMethod]
        public void PrintELement_EmptyBag() {
            Bag bag = new Bag();
            Assert.ThrowsException<InvalidOperationException>(() => bag.PrintBag());
        }
        [TestMethod]
        public void PrintElement_BagElements() { 
            Bag bag = new Bag();
            bag.InsertElement(11);
            bag.InsertElement(4);
            bag.InsertElement(4);
            bag.InsertElement(13);
            Assert.AreEqual(1, bag.GetFrequency(11));
        }


       
    }
}
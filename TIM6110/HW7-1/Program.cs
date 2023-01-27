// Program.cs
// 
// A program to demonstrate the related BST class
//
// NCU.edu
// School of Business & Technology Management
// TIM6110
//
// Author: Patrick Swafford
// Date: 12 Feb 2023

using System;
using System.IO;
using System.Text;

namespace HW7_1 {
    public class Program {
        public static void Main(String [] args) {
            // Get filename from user
            Console.Write("Enter filename: ");
            String file = Console.ReadLine();

            // Instantiates new BST object
            BST tree = new BST();

            try {
                // Read in each line of the input file. 
                String [] lines = File.ReadAllLines(file);
                
                // Iterates through each line of the input file
                foreach (String line in lines) {

                    // Each line could potentially have multiple words.
                    // Thus the split function is used  to get each individual word
                    String [] words = line.Split(' ');

                    // Iterate through each word
                    foreach(String word in words) {
                        
                        // Add each word to the BST
                        tree.insert(word);
                    }
                }

                // Print to console the tree inorder, preorder, and postorder
                Console.WriteLine("Inorder");
                tree.inorder();

                Console.WriteLine("Preorder");           
                tree.preorder();

                Console.WriteLine("Postorder");
                tree.postorder();

            // Catches any errors related to filenames
            } catch (ArgumentException) {
                Console.Error.WriteLine("Invalid input error: Filename cannot be an empty string");
                return;
            } catch (FileNotFoundException) {
                Console.Error.WriteLine("Invalid input error: Filename {0} does not exist", file);
                return;
            }            
        }
    }
}
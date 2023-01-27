// MySearches.cs
// 
// A program to explore the runtime of various searching algorithms
//
// NCU.edu
// School of Business & Technology Management
// TIM6110
//
// Author: Patrick Swafford
// Date: 05 Feb 2023

using System;
using System.IO;
using System.Text;

namespace Week6_1 {
    class MySearch {
        public static int linearSearch(int [] arr, int key) {

            for (int i = 0; i < arr.Length; i++) {
                if (arr[i] == key) {
                    return i;
                }
            }

            return -1;
        }
        public static int binarySearch(int [] arr, int key) {            
            return binarySearch(arr, key, 0, arr.Length - 1);
        }
        private static int binarySearch(int [] arr, int key, int low, int high) {
            if (high >= low) {                
                int med = (low + high) / 2;

                if (key == arr[med])
                    return med;

                if (key < arr[med])
                    return binarySearch(arr, key, low, med - 1);

                if (key > arr[med])
                    return binarySearch(arr, key, low + 1, high);
            }
            return -1;

        }
        
        public static int linearSearch(String [] arr, String key) {            
            for (int i = 0; i < arr.Length; i++) {
                if (String.Compare(arr[i], key) == 0) {
                    return i;
                }
            }

            return -1;
        }
        public static int binarySearch(String [] arr, String key) {
            return binarySearch(arr, key, 0, arr.Length - 1);

        }
        private static int binarySearch(String [] arr, String key, int low, int high) {
            if (high >= low) {                
                int med = (low + high) / 2;
                //Console.WriteLine("{0} {1}", arr[med], key);
                if (String.Compare(arr[med], key) == 0)
                    return med;

                if (String.Compare(arr[med], key) > 0)
                    return binarySearch(arr, key, low, med - 1);

                if (String.Compare(arr[med], key) < 0)
                    return binarySearch(arr, key, low + 1, high);
            }

            return -1;
        }
        public static void Main(String [] args) {
            try {
                // variables in readable format              
                String file = args[0];
                String instruction = args[1];
                String token = args[2];
                
                // Read in file contents
                String [] fin = File.ReadAllLines(file);

                // Demonstrate Linear Search with an integer array
                if (String.Compare(instruction, "linear_int") == 0) {
                    // Convert string array into integer array
                    int [] arr = Array.ConvertAll(fin, int.Parse);

                    // convert token to an int
                    int key = int.Parse(token);

                    // Write to output the command
                    Console.WriteLine("Linear Search with an Integer array");

                    // Write a message telling the user the program is searching for the key
                    Console.WriteLine("Now searching for {0}", key);

                    // Obtain the index or -1 if key not found
                    int index = linearSearch(arr, key);

                    // Output results
                    if (index < 0) {
                        Console.WriteLine("The value {0} was not found", key);
                        return;
                    }
                    Console.WriteLine("The Value {0} was found at index: {1}", key, index);

                // Demonstrate Binary Search with an integer array
                } else if (String.Compare(instruction, "binary_int") == 0) {
                    // Convert string array into integer array
                    int [] arr = Array.ConvertAll(fin, int.Parse);

                    // Convert token to an int
                    int key = int.Parse(token);

                    // Binary search requires the array to be sorted
                    Array.Sort(arr);

                    // Write to output the command
                    Console.WriteLine("Binary Search with an Integer array");

                    // Write a message telling the user the program is searching for the key
                    Console.WriteLine("Now searching for {0}", key);

                    // Obtain the index or -1 if key not found
                    int index = binarySearch(arr, key);

                    // Output results
                    if (index < 0) {
                        Console.WriteLine("The value {0} was not found", key);
                        return;
                    }
                    Console.WriteLine("The Value {0} was found at index: {1}", key, index);

                // Demonstrate linear search with a string array
                } else if (String.Compare(instruction, "linear_string") == 0) {
                    // Write to output the command
                    Console.WriteLine("Linear Search with a String array");

                    // Write a message telling the user the program is searching for the key
                    Console.WriteLine("Now searching for {0}", token);

                    // Obtain the index or -1 if key not found
                    int index = linearSearch(fin, token);

                    // Output results
                    if (index < 0) {
                        Console.WriteLine("The value {0} was not found", token);
                        return;
                    }
                    Console.WriteLine("The Value {0} was found at index: {1}", token, index);

                // Demonstrate binary search with a string array
                } else if (String.Compare(instruction, "binary_string") == 0) {
                    // Sort the array lexicographically for a string search
                    Array.Sort(fin);

                    // Write to output the command
                    Console.WriteLine("Binary Search of a String array");

                    // Write a message telling the user the program is searching for the key
                    Console.WriteLine("Now searching for {0}", token);

                    // Obtain the index or -1 if key not found
                    int index = binarySearch(fin, token);

                    // Output results
                    if (index < 0) {
                        Console.WriteLine("The value {0} was not found", token);
                        return;
                    }
                    Console.WriteLine("The Value {0} was found at index: {1}", token, index);

                // Throw an error if invalid input
                } else {
                    throw new FormatException();         
                }

            // Exceptions: Self explanatory                
            } catch (IndexOutOfRangeException) {
                Console.Error.WriteLine("Error: Index Out Of Range");
            } catch (FileNotFoundException) {
                    Console.Error.WriteLine("Error: File not found");
            } catch (FormatException) {
                Console.Error.WriteLine("Error: Format Exception");
            } 

            return;
        }
    }
}

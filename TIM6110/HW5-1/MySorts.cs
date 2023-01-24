//
// MySorts.cs
// 
// A program to explore the runtime of various sorting algorithms
//
// NCU.edu
// School of Business & Technology Management
// TIM6110
//
// Author: Patrick Swafford
// Date: 29 January 2023

using System;

namespace week5_1 {
    class MySorts {
        public static void bubblesort(int [] arr) {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++) {
                for (int j = 0; j < n - i - 1; j++) {
                    if (arr[j] > arr[j + 1]) { 
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            return;
        }
        public static void bubblesort(String [] arr) {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++) {
                for (int j = 0; j < n - i - 1; j++) {
                    if (String.Compare(arr[j], arr[j + 1], true) > 0) {
                        String temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j +1] = temp;
                    } 
                }
            }
            return;
        }
        public static void quicksort(int [] arr) {
            quicksort(arr, 0, arr.Length - 1);
        }
        private static void quicksort(int [] arr, int low, int high) {
            if (low < high) {
                int q = partition(arr, low, high);
                quicksort(arr, low, q - 1);
                quicksort(arr, q + 1, high);
            }
            return;
        }
        private static int partition(int [] arr, int low, int high) {
            int x = arr[low];
            int i = low;
            int j = high;            
            while (arr[j] > x) {
                j--;
            }            
            while (arr[i] < x - 1) {
                i++;
            }
            if (i < j) {
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            } 

            return j;
        }
        public static void quicksort(String [] arr) {
            quicksort (arr, 0, arr.Length - 1);
            return;
        }
        private static void quicksort(String [] arr, int low, int high) {
            if (low < high) {
                int q = partition(arr, low, high);
                quicksort(arr, low, q - 1);
                quicksort(arr, q + 1, high);
            }
            return;
        }
        private static int partition(String [] arr, int low, int high) {
            String x = arr[low];
            int i = low;
            int j = high;
            
            while (String.Compare(arr[j], x, true) > 0) {
                j--;
            }
            while (String.Compare(arr[i], x, true) < 0) {
                i++;
            }
            if (i < j) {
                String temp = arr[j];
                arr[j] = arr[i];
                arr[i] = temp;
            }
            return j;
        }
        public static void tostring(int [] arr) {
            foreach (int element in arr) {
                Console.Write("{0} ", element);
            }
            Console.Write("\n");
        }
        public static void tostring(String [] arr) {
            foreach (String element in arr) {
                Console.Write("{0} ", element);
            }
            Console.Write("\n");
        }
        public static void Main(String [] args) {
            try {
                int [] intarr = {8,6,7,5,3,0,9};
                String [] stringarr = {"I", "have", "a", "structured", "settlement", "and", "I", "need", "cash", "now"};
                switch (args[0]) {
                    case "0":
                        Console.WriteLine("Bubblesort on an integer array");
                        Console.Write("Unsorted: ");
                        tostring(intarr);
                        bubblesort(intarr);
                        Console.Write("Sorted: ");
                        tostring(intarr);
                        break;
                    case "1":
                        Console.WriteLine("Quicksort on an integer array");
                        Console.Write("Unsorted: ");
                        tostring(intarr);
                        quicksort(intarr);
                        Console.Write("Sorted: ");
                        tostring(intarr);
                        break;
                    case "2":
                        Console.WriteLine("Bubblesort on a String array");
                        Console.Write("Unsorted: ");
                        tostring(stringarr);
                        bubblesort(stringarr);
                        Console.Write("Sorted: ");
                        tostring(stringarr);
                        break;
                    case "3":    
                        Console.WriteLine("Quicksort on a String array");
                        Console.Write("Unsorted: ");
                        tostring(stringarr);
                        quicksort(stringarr);
                        Console.Write("Sorted: ");
                        tostring(stringarr);                    
                        break;
                    default:
                        throw new IndexOutOfRangeException();
                }               
            } catch (IndexOutOfRangeException) {
                Console.WriteLine("Invalid input");
                return;
            }
            
            
            
            
            
            
            
        }
    }
}
using System;

namespace Week6_1 {
    class GenerateTest {
        public static void Main(String [] args) {
            Random r = new Random();
            int [] arr = new int [1000];

            for (int i = 0; i < 1000; i++) {
                arr[i] =  r.Next(0, 10000);
            }

            Array.Sort(arr);

            for (int i = 0; i < 1000; i++) {
                Console.WriteLine(arr[i]);
            }
            return;
        }
    }
}
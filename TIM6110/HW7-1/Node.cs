// Node.cs
// 
// An implementation of the Node class. Used by the related BST class. Has a pointer
// pointing to the left child, and the right child, a string for the key, and a counter 
// to keep track of the number of times the key is encountered
//
// NCU.edu
// School of Business & Technology Management
// TIM6110
//
// Author: Patrick Swafford
// Date: 12 Feb 2023

using System;

namespace HW7_1 {
    class Node {
        // Class members
        private Node left;
        private Node right;
        private int count;
        private String key;

        // Constructors
        public Node () {
            this.left = null;
            this.right = null;
            this.count = 0;
            this.key = null;
        }

        public Node (String key) {
            this.left = null;
            this.right = null;
            this.count = 0;
            this.key = key;
        }

        // Getters
        public Node get_left() {
            return this.left;
        }

        public Node get_right() {
            return this.right;
        }

        public int get_count() {
            return this.count;
        }

        public String get_key() {
            return this.key;
        }

        // Setters
        public void set_left(Node left) {
            this.left = left;
        }

        public void set_right(Node right) {
            this.right = right;
        }

        public void set_count(int count) {
            this.count = count;
        }
        public void increment_count() {
            this.count += 1;
        }

        public void set_key(String key) {
            this.key = key;
        }
    }
}
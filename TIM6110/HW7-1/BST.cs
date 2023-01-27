// BST.cs
// 
// An implementation of the Binary Search Tree. Has insert, delete, search functionality
// and preorder, postorder, and inorder traversal functionality. The amount of times a 
// specific key is encountered is tracked.
//
// NCU.edu
// School of Business & Technology Management
// TIM6110
//
// Author: Patrick Swafford
// Date: 12 Feb 2023

using System;

namespace HW7_1 {
    class BST {
        // Class members
        private Node head;

        // Constructors
        public BST () {
            this.head = null;
        }

        public BST (String key) {
            this.head = new Node(key);
        }

        // Public Insert interface
        public void insert(String key) {
            this.head = insert(this.head, key);
        }

        // Private Insert implementation
        private static Node insert (Node current, String key) {

            // Base case. root being null means that the recursion has bottomed out
            if (current == null) {
                current = new Node(key);
                current.increment_count();
                return current;
            }

            // Put the result of the string compare test in a variable for code readability
            int test = String.Compare(key, current.get_key());

            // Key of new node is less than the key of the current node. Move on to the left child
            if (test < 0) {
                current.set_left(insert(current.get_left(), key));
                return current;
            }

            // Key of new node is greater than the key of the current node. Move on to the right child
            if (test > 0) {
                current.set_right(insert(current.get_right(), key));
                return current;
            }

            // key of new node is equal to key of the current node. Increment counter and return
            current.increment_count();
            return current;            
        }

        // Public Delete Interface
        public void delete(String key) {
            this.head = delete(this.head, key);
        }

        // Private auxiliary function to get the minimum value of a subtree
        private static Node get_min(Node min) {
            // If the left child is null, we've recursed far enough down
            if (min.get_left() == null) {
                return min;
            }

            // Keep going down
            return get_min(min.get_left());
        }

        // Private Delete Implementation
        private static Node delete (Node current, String key) {
            
            // Base case. root being null means the tree has been traversed and the key has not been
            // found. Therefore return.
            if (current == null) {
                return null;
            }

            // Result of String.compare stored in variable for readability
            int test = String.Compare(key, current.get_key());
            
            // Key to be deleted is less then the key of the current node. Move on to the left child
            if (test < 0) {
                current.set_left(delete(current.get_left(), key));

            // Key to be deleted is more than the key of the current node. Move on to the right child
            } else if (test > 0) {
                current.set_right(delete(current.get_right(), key));

            // Key to be deleted is equal to the key of the current node. We've found our target!
            } else {

                // The left child is null, therefore we can simply return the right child, thus
                // leaving current node orphaned
                if (current.get_left() == null) {
                    return current.get_right();

                // Same for right child. Right is null so return left
                } else if (current.get_right() == null) {
                    return current.get_left();
                }

                // Current has both a left child and a right child. Cannot simply orphan the current
                // node. Therefore, we shall get the smallest node that is larger than current, set
                // current to that value, update the counter, and delete min node whose identity
                // we just stole.
                Node min = get_min(current.get_right());
                current.set_key(min.get_key());
                current.set_count(min.get_count());
                current.set_right(delete(current.get_right(), current.get_key()));
            }
            return current;
        }

        // Public Search interface
        public Boolean search (String key) {
            return search(this.head, key) == null ? false : true;
        }

        // Private Search implementation
        private Node search (Node current, String key) {

            // Base case: if root is null, we've recursed all the way down and haven't found
            // the key. Return root
            if (current == null) {
                return null;
            }

            int test = String.Compare(key, current.get_key());

            // Base case: if the key is equal to the current's key, we've found our node. Return root
            if (test == 0) {
                return current;
            }

            // Haven't found the key yet. Recurse down
            if (test < 0) {
                return search(current.get_left(), key);
            }

            return search(current.get_right(), key);
        }

        // Public inorder interface
        public void inorder() {
            inorder(head);
            Console.WriteLine("");
        }

        // Private inorder implementation
        private void inorder(Node root) {
            if (root != null) {
                if (root == null) {
                    return;
                }
                inorder(root.get_left());
                Console.Write(root.get_key() + ":" + root.get_count() + " ");
                inorder(root.get_right());
            }
        }

        // Public preorder interface
        public void preorder() {
            preorder(head);
            Console.WriteLine("");
        }

        // Private preorder implementation
        private void preorder(Node root) {
            if (root == null) {
                return;
            }

            Console.Write(root.get_key() + ":" + root.get_count() + " ");
            preorder(root.get_left());
            preorder(root.get_right());
        }

        // Public postorder interface
        public void postorder() {
            postorder(head);
            Console.WriteLine("");
        }

        // Private postorder implementation
        private void postorder(Node root) {
            if (root == null) {
                return;
            }
            postorder(root.get_left());
            postorder(root.get_right());
            Console.Write(root.get_key() + ":" + root.get_count() + " ");
        }

        // Getters
        public Node get_head() {
            return this.head;
        }

        // Setters
        public void set_head(Node head) {
            this.head = head;
        }
    }
}
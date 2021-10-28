using System;

namespace ReversingALinkedList
{
    /// <summary>
    /// Good morning! Here's your coding interview problem for today.
    /// This problem was asked by Google.
    /// Given the head of a singly linked list, reverse it in-place.<br/>
    /// <b> Solution: 45min. 30sec. </b>
    /// </summary>
    class Solution
    {
        /// <summary>
        /// A set of integers to reverse
        /// </summary>
        static int[] set1 = { 0, 1, 2, 3, 4, 5 };

        /// <summary>
        /// A set of integers to reverse
        /// </summary>
        static int[] set2 = { 5, 4, 2, 10, 1, 0 };

        static void Main(string[] args)
        {
            Node<int> head1 = new Node<int>(set1[0], null);
            Node<int> head2 = new Node<int>(set2[0], null);

            Console.Write("Initial Head 1: ");
            Print(head1);
            Console.Write("Initial Head 2: ");
            Print(head2);
            Console.WriteLine("---------------------------------------");

            FillList(head1, set1);
            FillList(head2, set1);

            Console.Write("Initial List 1: ");
            Print(head1);
            Console.Write("Initial List 2: ");
            Print(head2);
            Console.WriteLine("---------------------------------------");

            Reverse(head1);
            Reverse(head2);

            Console.Write("Reversed List 1: ");
            Print(head1);
            Console.Write("Reversed List 2: ");
            Print(head2);
            Console.WriteLine("---------------------------------------");
        }

        /// <summary>
        /// Reverses a Linked List of <c>Nodes</c> given the list <paramref name="head"/>
        /// </summary>
        /// <param name="head">the front <c>Node</c> of the LinkedList</param>
        private static void Reverse(Node<int> head)
        {
            int pointer = 0;
            Node<int> current = head;

            while (current.next != null)
            {
                current = current.next;

                pointer++;
            }

            while (pointer != 0)
            {
                current = head;

                for (int i = 0; i < pointer; i++)
                {
                    int tempData = current.data;
                    current.data = current.next.data;
                    current.next.data = tempData;
                    current = current.next;
                }

                pointer--;
            }
        }

        /// <summary>
        /// Prints a Linked List to the Console given a <see cref="Node{T}"/> <paramref name="n"/>
        /// </summary>
        /// <remarks>
        /// <b>Output Format:</b> <i>[front.data | front.next.data] -> [front.next.data | front.next.next] -> ... [null]</i>
        /// </remarks>
        /// <param name="n">the <c>Node</c> to start printing values from</param>
        private static void Print(Node<int> n)
        {
            string output = "";
            string format = "[{0} | {1}]";
            string arrow = " -> ";

            while (n.next != null)
            {
                output += string.Format(format, n.data, n.next.data) + arrow;

                n = n.next;
            }

            output += string.Format(format, n.data, "null") + arrow + "[null]";

            Console.WriteLine(output);
        }

        /// <summary>
        /// Constructs a Linked List from a given array of integers by creating a 
        /// chain of <c>Nodes</c>
        /// </summary>
        /// <param name="n">the node to start chaining <c>Nodes</c> to</param>
        /// <param name="set">an array of integers to be turned into a Linked List of <c>Nodes</c></param>
        private static void FillList(Node<int> n, int[] set)
        {
            for (int i = 1; i < set.Length; i++)
            {
                n.next = new Node<int>(set[i], null);
                n = n.next;
            }
        }
    }

    /// <summary>
    /// A <c>Node</c> to be used in a LinkedList that stores data as well as a reference to the next <c>Node</c>
    /// </summary>
    /// <remarks>
    /// <i>
    /// The <c>Node</c> takes a data value to store as well as another <c>Node</c> to be stored as a
    /// reference to the next data value in the LinkedList
    /// </i>
    /// </remarks>
    public class Node<T>
    {
        /// <summary>
        /// A reference to the <see cref="Node"/> storing the next data value in the a LinkedList
        /// </summary>
        public Node<T> next;

        /// <summary>
        /// The data being stored by <see langword="this"/> <see cref="Node"/>
        /// </summary>
        public T data;

        /// <summary>
        /// Sets the data of <see langword="this"/> <c>Node</c> and the reference to the 
        /// <c>Node</c> storing the <paramref name="next"/> <c>Node</c> in the LinkedList
        /// </summary>
        /// <param name="data">the data being stored by <see langword="this"/> <see cref="Node"/></param>
        /// <param name="next">a reference to the <c>Node</c> storing the next <c>Node</c> in the LinkedList</param>
        public Node(T data, Node<T> next)
        {
            this.data = data;
            this.next = next;
        }
    }
}

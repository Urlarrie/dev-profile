using DataStructures;
using static DataStructures.LinkedList<int>;
using System;

namespace ReversingALinkedList
{
    /// <summary>
    /// Good morning! Here's your coding interview problem for today.
    /// This problem was asked by Google.
    /// Given the head of a singly linked list, reverse it in-place.<br/>
    /// <b> Solution: 45min. 30sec. </b>
    /// </summary>
    class Program
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
            Node head1 = new Node(set1[0], null);
            Node head2 = new Node(set2[0], null);

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
        /// Reverses a <see cref="DataStructures.LinkedList{int}"/> given the list <paramref name="head"/>
        /// </summary>
        /// <param name="head">the front <see cref="Node"/> of the LinkedList</param>
        private static void Reverse(Node head)
        {
            int pointer = 0;
            Node current = head;

            while(current.next != null)
            {
                current = current.next;

                pointer++;
            }

            while(pointer != 0)
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
        /// Prints a <see cref="LinkedList{T}"/> to the Console given a <see cref="LinkedList{int}.Node"/> <paramref name="n"/>
        /// </summary>
        /// <remarks>
        /// <b>Output Format:</b> <i>[front.data | front.next.data] -> [front.next.data | front.next.next] -> ... [null]</i>
        /// </remarks>
        /// <param name="n">the <see cref="LinkedList{int}.Node"/> to start printing values from</param>
        private static void Print(Node n)
        {
            string output = "";
            string format = "[{0} | {1}]";
            string arrow = " -> ";

            while(n.next != null)
            {
                output += string.Format(format, n.data, n.next.data) + arrow;

                n = n.next;
            }

            output += string.Format(format, n.data, "null") + arrow + "[null]";

            Console.WriteLine(output);
        }

        /// <summary>
        /// Constructs new <see cref="LinkedList{int}.Node">Nodes</see> from a given array of integers and 
        /// chains them to the given <see cref="LinkedList{int}.Node"/> <paramref name="n"/> to form a LinkedList
        /// </summary>
        /// <param name="n">the node to start chaining <see cref="Node">Nodes</see> to</param>
        /// <param name="set">an array of integers to be turned into <see cref="LinkedList{int}.Node">Nodes</see> of a LinkedList</param>
        private static void FillList(Node n, int[] set)
        {
            for(int i = 1; i < set.Length; i++)
            {
                n.next = new Node(set[i], null);
                n = n.next;
            }
        }
    }
}

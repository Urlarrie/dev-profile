using System;

/// <summary>
/// Contains SingularlyLinkedList, DoublyLinkedList, and CircularlyLinkedList
/// </summary>
namespace DataStructures.Lists
{
    /// <summary>
    /// This is a Generic Linked List that you can add to, delete from, and print.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The public members of this <c>LinkedList</c> are <see cref="AddFront(T)"/>, <see cref="Add(T)"/>, <see cref="Add(int, T)"/>,
    /// <see cref="RemoveFront"/>, <see cref="RemoveBack"/>, <see cref="Remove(int)"/>, and <see cref="Print"/>.
    /// </para>
    /// <para>
    /// This <c>LinkedList</c> with each data element being stored in a <see cref="Node">Node</see> where each <see cref="Node">Node</see> stores
    /// the a reference to the next <see cref="Node"> Node </see> in the <c>LinkedList</c> as well as the data itself.
    /// </para>
    /// </remarks>
    /// <typeparam name="T"> The type stored in this Linked List </typeparam>
    public class LinkedList<T>
    {
        /// <summary>
        /// The <see cref="Node"/> at the front of the list.
        /// </summary>
        Node front;

        /// <summary>
        /// The number of elements stored in the list.
        /// </summary>
        int size;

        /// <summary>
        /// Constructs a <c>LinkedList</c> by setting the starting node to <see langword="null"/> and the size of the list to 0.
        /// </summary>
        public LinkedList()
        {
            front = null;
            size = 0;
        }

        /// <summary>
        /// Returns the size of the list.
        /// </summary>
        /// <returns> the number of elements in the list as an <see langword="int"/></returns>
        public int Size()
        {
            return size;
        }

        /// <summary>
        /// Returns the head <see cref="LinkedList"/> of the list
        /// </summary>
        /// <returns>returns the head <see cref="Node"/> of the list</returns>
        public Node GetFront()
        {
            return GetNode(0);
        }

        /// <summary>
        /// Returns an element from the list using a given <see langword="int"/>.
        /// </summary>
        /// <param name="index"> the index of the requested element in the <see cref="LinkedList{T}"/></param>
        /// <returns>the data of the element stored at the given <paramref name="index"/></returns>
        /// <exception cref="IndexOutOfRangeException">Thrown if the <paramref name="index"/> is less than 
        /// zero or equal to or greater than the size of the <see cref="LinkedList{T}"/></exception>
        public T Get(int index)
        {
            return GetNode(index).data;
        }

        /// <summary>
        /// Returns the <see cref="Node"/> at the <paramref name="index"/> in the list
        /// </summary>
        /// <param name="index">the position of the <see cref="Node"/> in the <see cref="LinkedList{T}"/></param>
        /// <returns>the <see cref="Node"/> at a given <paramref name="index"/> in the list</returns>
        private Node GetNode(int index)
        {
            Node node = front;

            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Index + " + index + " could not be accessed as the list is a 0-based index of size " + size);
            }

            for (int i = 0; i < index; i++)
            {
                node = node.next;
            }

            return node;
        }

        /// <summary>
        /// Adds an element to the end of the list.
        /// </summary>
        /// <remarks>
        /// If the front of the list is <see langword="null"/>, the given element is set to the starting node. Otherwise,
        /// a pointer iterates through the array until it reaches the last <see cref="Node"> Node </see>(the node with a <see langword="null"/>
        /// next value) and sets a newly constructed <see cref="Node"> Node</see>(<paramref name="element"/>,
        /// <see langword = "null"/>) to the next value of the last <see cref="Node"> Node </see> int the list. 
        /// Increments the size of the list by one.
        /// </remarks>
        /// <param name="element"> the element to be added to the <see cref="LinkedList{T}"/></param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="element"/> is <see langword="null"/></exception>
        public void Add(T element)
        {
            if(element == null)
            {
                throw new ArgumentNullException("Linked List cannot contain null values.");
            }

            if (front == null)
            {
                AddFront(element);
            }
            else
            {
                Add(size, element);
            }
        }

        /// <summary>
        /// Adds an <paramref name="element"/> to the list at a given <paramref name="index"/>
        /// </summary>
        /// <param name="index">the index at which to store a given <paramref name="element"/> in the <see cref="LinkedList{T}"/></param>
        /// <param name="element">the data to store at a given <paramref name="index"/> in the <see cref="LinkedList{T}"/></param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="element"/> is <see langword="null"/></exception>
        /// <exception cref="IndexOutOfRangeException">Thrown if <paramref name="index"/> is less than 0 or greater than or equal to the
        /// size of the <see cref="LinkedList{T}"/></exception>
        public void Add(int index, T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("Linked List cannot contain null values.");
            }

            if (index < 0 || index > size)
            {
                throw new ArgumentException("The requested index was outside of the range of the list. Must be between 0 inclusive and " +
                    + size + " exclusive.");
            }

            if (index == 0)
            {
                front = new Node(element, front);
            }
            else
            {
                Node nodeBeforeIndex = GetNode(index - 1);

                nodeBeforeIndex.next = new Node(element, nodeBeforeIndex.next);
            }

            size++;
        }

        /// <summary>
        /// Adds an <paramref name="element"/> to the front of the list
        /// </summary>
        /// <param name="element">the data to be stored at the front of the <see cref="LinkedList{T}"/></param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="element"/> is <see langword="null"/></exception>
        public void AddFront(T element)
        {
            Add(0, element);
        }

        /// <summary>
        /// Removes an element from the list and returns the removed data
        /// </summary>
        /// <param name="index">the index of the <see cref="LinkedList{T}"/> to remove</param>
        /// <returns>the data removed from the list</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown if <paramref name="data"/> is <see langword="null"></exception>
        public T Remove(int index)
        {
            T returnData = default(T);

            if(index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("The requested index was outside of the range of the list. Must be between 0 inclusive and " +
                    + size + " exclusive");
            }

            if (index == 0)
            {
                returnData = front.data;
                front = front.next;
            }
            else
            {

                Node nodeBefore = GetNode(index - 1);

                returnData = nodeBefore.next.data;

                if (nodeBefore.next.next != null)
                {
                    nodeBefore.next = nodeBefore.next.next;
                }
                else
                {
                    nodeBefore.next = null;
                }
            }

            size--;

            return returnData;
        }

        /// <summary>
        /// Removes an element from the front of the list
        /// </summary>
        /// <returns>the removed element from the front of the list</returns>
        /// <exception cref="InvalidOperationException">Thrown if the list is empty</exception>
        public T RemoveFront()
        {
            if (size == 0)
            {
                throw new InvalidOperationException("There is nothing to remove from the front of the list.");
            }

            return Remove(0);
        }

        /// <summary>
        /// Removes an element from the back of the list
        /// </summary>
        /// <returns>the removed element from the back of the list</returns>
        /// <exception cref="InvalidOperationException">Thrown if the list is empty</exception>
        public T RemoveBack()
        {
            if (size == 0)
            {
                throw new InvalidOperationException("There is nothing to remove from the back of the list.");
            }

            return Remove(size - 1);
        }

        /// <summary>
        /// Prints this data structure as a <see langword="string"/>
        /// </summary>
        /// <remarks>
        /// <b>Format:</b> [front.data | front.next.data] -> [front.next.data | front.next.next.data] -> ...
        /// </remarks>
        public void Print()
        {
            string format = "[{0} | {1}]";
            string arrow = " -> ";
            string listAsString = "";

            for(int i = 0; i < size; i++)
            {
                if(i == size - 1)
                {
                    listAsString += String.Format(format, Get(i), "null") + arrow + "[null]";

                    break;
                }

                listAsString += String.Format(format, Get(i), Get(i + 1)) + arrow;
            }

            Console.Write(listAsString);
        }

        /// <summary>
        /// Returns this list as a comma separated list of values
        /// </summary>
        /// <returns>returns this list as a comma separated <see langword="string"/> of the values in the list</returns>
        public override string ToString()
        {
            String listAsString = "";
            
            for(int i = 0; i < size; i++)
            {
                if(i == size - 1)
                {
                    listAsString += Get(i);

                    break;
                }

                listAsString += Get(i) + ", ";
            }

            return listAsString;
        }

        /// <summary>
        /// Updates the element stored at a given <paramref name="index"/> to a new value
        /// </summary>
        /// <param name="index">the index of the element to update in the <see cref="LinkedList{T}"/></param>
        /// <param name="newValue">the element to replace the current element at
        /// a given <paramref name="index"/> in the <see cref="LinkedList{T}"/></param>
        /// <exception cref="IndexOutOfRangeException">Thrown if the <paramref name="index"/> if less than 0 or greater than the size of the list</exception>
        /// <exception cref="ArgumentNullException">Thrown if the <paramref name="newValue"/> is null</exception>
        public void Update(int index, T newValue)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("The requested index was outside of the range of the list. Must be between 0 inclusive and " +
                    +size + " exclusive");
            }

            if (newValue == null)
            {
                throw new ArgumentNullException("You cannot add null values to this LinkedList.");
            }

            Add(index, newValue);
            Remove(index + 1);
        }

        /// <summary>
        /// An inner data class to be used in a <see cref="LinkedList{T}"/> that stores data 
        /// as well as a reference to other data
        /// </summary>
        /// <remarks>
        /// The <b>Node</b> takes a data value to store as well as another Node to be stored as a
        /// reference to the next data value in the <see cref="LinkedList{T}"/>
        /// </remarks>
        public class Node
        {
            /// <summary>
            /// A reference to the <see cref="Node"/> storing the next data value in the <see cref="LinkedList{T}"/>
            /// </summary>
            public Node next;

            /// <summary>
            /// The data being stored by <see langword="this"/> <see cref="Node"/>
            /// </summary>
            public T data;

            /// <summary>
            /// Sets the data of <see langword="this"/> <see cref="Node"/> and the reference to the 
            /// <see cref="Node"/> storing the next data value in the <see cref="LinkedList{T}"/>
            /// </summary>
            /// <param name="data">the data being stored by <see langword="this"/> <see cref="Node"/></param>
            /// <param name="next">a reference to the <see cref="Node"/> storing the next data value in the <see cref="LinkedList{T}"/></param>
            public Node(T data, Node next)
            {
                this.data = data;
                this.next = next;
            }
        }
    }

    /// <summary>
    /// Displays the functions of the <see cref="LinkedList{T}"/>
    /// </summary>
    /// <remarks>
    /// <b>Functions Displayed</b>: Add <i>front, back, at index</i>; Remove <i>front, back, by value</i>; and Print
    /// </remarks>
    class DisplayOperations
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();

            list.Add(1);
            list.Add(2);
            list.Add(4);

            Console.WriteLine("LinkedList output format: [front.data | front.next.data] -> [front.next.data | front.next.next.data] -> ...");
            Console.WriteLine("\n");

            Console.Write("Starting List: ");
            list.Print();
            Console.WriteLine("\n");

            list.AddFront(0);

            Console.Write("Added 0 to Front: ");
            list.Print();
            Console.WriteLine("\n");

            list.Add(5);

            Console.Write("Added 5 to Back: ");
            list.Print();
            Console.WriteLine("\n");

            list.Add(2, 3);

            Console.Write("Added 3 to Index 2: ");
            list.Print();
            Console.WriteLine("\n");

            int frontRemoved = list.RemoveFront();

            Console.Write("Removed " + frontRemoved + " from the front: ");
            list.Print();
            Console.WriteLine("\n");

            int backRemoved = list.RemoveBack();

            Console.Write("Removed " + backRemoved + " from the back: ");
            list.Print();
            Console.WriteLine("\n");

            int valueRemoved = list.Remove(3);

            Console.Write("Removed " + valueRemoved + " from 3: ");
            list.Print();
            Console.WriteLine("\n");

            Console.Write("Printing:");
            list.Print();
            Console.WriteLine("\n");

            list.Update(2, 10);
            Console.Write("Updating the element at 2 to 10: ");
            list.Print();
        }
    }
}

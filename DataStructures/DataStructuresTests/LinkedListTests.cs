using System;
using Xunit;
using DataStructures.Lists;

namespace DataStructuresTests
{
    /// <summary>
    /// Test class for testing the <see cref="LinkedList{T}"/> data structure
    /// </summary>
    public class LinkedListTests
    {
        /// <summary>
        /// Holds a <see cref="LinkedList{T}]"/> to test with
        /// </summary>
        LinkedList<int> list = new LinkedList<int>();

        /// <summary>
        /// Test values for the <paramref name="list"/>
        /// </summary>
        int[] values = { 0, 1, 2, 3, 4, 5 };

        /// <summary>
        /// Tests that a <see cref="LinkedList{T}"/> is constructed empty
        /// </summary>
        [Fact]
        public void LinkedListTest()
        {
            Assert.Equal(0, list.Size());
        }

        /// <summary>
        /// Tests that a <see cref="LinkedList{T}"/> can add values at an index, to the front, and to the back of the list
        /// </summary>
        [Fact]
        public void AddTest()
        {
            for (int i = 0; i < values.Length; i++)
            {
                list.Add(values[i]);
            }

            list.AddFront(6);

            Assert.Equal(6, list.Get(0));
            Assert.Equal(7, list.Size());

            list.Add(2, 7);

            Assert.Equal(7, list.Get(2));
            Assert.Equal(8, list.Size());
            Assert.Equal(0, list.Get(1));
            Assert.Equal(1, list.Get(3));
        }

        /// <summary>
        /// Tests that a <see cref="LinkedList{T}"/> can get values at an index
        /// </summary>
        [Fact]
        public void GetTest()
        {
            for (int i = 0; i < values.Length; i++)
            {
                list.Add(values[i]);
                Assert.Equal(i + 1, list.Size());
            }

            for (int i = 0; i < values.Length; i++)
            {
                Assert.Equal(i, list.Get(i));
            }
        }

        /// <summary>
        /// Tests that a <see cref="LinkedList{T}"/> can remove values by index, from the front, and from teh back
        /// </summary>
        [Fact]
        public void RemoveTest()
        {
            for (int i = 0; i < values.Length; i++)
            {
                list.Add(values[i]);
            }

            Assert.Equal(2, list.Remove(2));
            Assert.Equal(5, list.Size());
            Assert.Equal(3, list.Get(2));
            Assert.Equal(5, list.Get(4));
            Assert.Equal(5, list.RemoveBack());
            Assert.Equal(4, list.Size());
            Assert.Equal(0, list.RemoveFront());
            Assert.Equal(3, list.Size());
        }

        /// <summary>
        /// Tests that a <see cref="LinkedList{T}"/> can update values by index
        /// </summary>
        [Fact]
        public void UpdateTest()
        {
            for (int i = 0; i < values.Length; i++)
            {
                list.Add(values[i]);
            }

            list.Update(0, 8);
            Assert.Equal(8, list.Get(0));
            Assert.Equal(1, list.Get(1));

            list.Update(list.Size() - 1, 0);
            Assert.Equal(0, list.Get(list.Size() - 1));
            Assert.Equal(4, list.Get(list.Size() - 2));

            list.Update(3, 4);
            Assert.Equal(4, list.Get(3));
            Assert.Equal(4, list.Get(4));
            Assert.Equal(2, list.Get(2));
        }

        /// <summary>
        /// Tests thata a <see cref="LinkedList{T}"/> returns a String in the format a comma separated format
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            for (int i = 0; i < values.Length; i++)
            {
                list.Add(values[i]);
            }

            string listAsString = list.ToString();

            Assert.Equal("0, 1, 2, 3, 4, 5", listAsString);
        }
    }
}

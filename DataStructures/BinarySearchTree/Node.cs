using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Trees.Node
{
    /// <summary>
    /// Node for a BinarySearchTree
    /// </summary>
    class BinaryNode<T>
    {
        /// <summary>
        /// The value being stored at <see langword="this"/> <c>BinaryNode</c>
        /// </summary>
        private T _data;

        /// <summary>
        /// Property for publicly getting and privately setting this BinaryNode's data
        /// </summary>
        /// <exception cref="ArgumentNullException">thrown the value is null</exception>
        public T Data
        {
            get => _data;

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("A Binary Node cannot store a null data value");
                }

                _data = value;
            }
        }

        /// <summary>
        /// Gets and sets the left BinaryNode for this BinaryNode
        /// </summary>
        public BinaryNode<T> Left  {get; set;}

        /// <summary>
        /// Gets and sets the right BinaryNode for this BinaryNode
        /// </summary>
        public BinaryNode<T> Right { get; set; }

        /// <summary>
        /// Constructs a <c>BinaryNode</c> for a <see cref="BinarySearchTree"/> that stores a given
        /// <paramref name="data"/> and <br/> sets <see langword="this"/> <c>BinaryNode's</c> <paramref name="left"/>
        /// and <paramref name="right"/> <c>BinaryNodes</c>
        /// </summary>
        /// <remarks>
        /// <i>
        /// While a <c>BinaryNode</c> can have <see langword="null"/> values for either the <paramref name="left"/> or <paramref name="right"/> <br/>
        /// nodes, attempting to set a <see langword="null"/> <paramref name="data"/> value will throw an <see cref="ArgumentNullException"/>
        /// </i>
        /// </remarks>
        /// <param name="data">the data being stored at <see langword="this"/> <see cref="BinaryNode{T}"/></param>
        /// <param name="left">the left <c>BinaryNode</c> of <see langword="this"/> <c>BinaryNode</c></param>
        /// <param name="right">the right <c>BinaryNode</c> of <see langword="this"/> <c>BinaryNode</c></param>
        public BinaryNode(T data, BinaryNode<T> left, BinaryNode<T> right)
        {
            if(data == null)
            {
                throw new ArgumentNullException("A BinaryNode cannot store a null data value");
            }

            Data = data;
            Left = left;
            Right = right;
        }
    }
}

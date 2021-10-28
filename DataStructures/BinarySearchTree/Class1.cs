using System;
using System.Collections.Generic;
using System.Text;

using DataStructures.Trees.Node;

/// <summary>
/// Contains the BinarySearchTree data structure
/// </summary>
namespace DataStructures.Trees
{
    /// <summary>
    /// 
    /// </summary>
    class BinarySearchTree<T>
    {
        /// <summary>
        /// Gets and sets a root to a BinarySearchTree
        /// </summary>
        public BinaryNode<T> Root {get; set;}

        /// <summary>
        /// Constructs a <c>BinarySearchTree</c> with a given <paramref name="root"/>
        /// </summary>
        /// <param name="root">the starting point for <see langword="this"/> <c>BinarySearchTree</c></param>
        public BinarySearchTree(BinaryNode<T> root = null)
        {
            Root = root;
        }
    }
}

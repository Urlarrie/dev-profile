using System;

/// <summary>
/// Data Structures being used in DailyCodingProblem2
/// </summary>
namespace DailyCodingProblem2.DataStructure
{
    /// <summary>
    /// A Node to be used in a binary tree
    /// </summary>
    /// <remarks>
    /// A <c>TreeNode</c> can be initialized to have two <see langword="null"/> values for left and right <c>TreeNodes</c> respectively, 
    /// but attempting to construct a <c>TreeNode</c> with <br/> a <see langword="null"/> <c>data</c> value will throw an <see cref="ArgumentNullException"/>
    /// </remarks>
    public class TreeNode<T>
    {
        /// <summary>
        /// The data being stored at <see langword="this"/> <c>TreeNode</c>
        /// </summary>
        public T data;

        /// <summary>
        /// The left <c>TreeNode</c> from <see langword="this"/> <c>TreeNode</c>
        /// </summary>
        public TreeNode<T> left;

        /// <summary>
        /// The right <see cref="TreeNode{T}"/> from <see langword="this"/> <c>TreeNode</c>
        /// </summary>
        public TreeNode<T> right;

        /// <summary>
        /// Constructs a node of a BinaryTree with a <paramref name="left"/> and <paramref name="right"/> <c>TreeNode</c> storing a 
        /// a given <paramref name="data"/>
        /// </summary>
        /// <param name="data">The value being stored at <see langword="this"/> <see cref="TreeNode{T}"/></param>
        /// <param name="left">The left <see cref="TreeNode{T}"/> to <see langword="this"/> TreeNode</param>
        /// <param name="right">The right <see cref="TreeNode{T}"/> to <see langword="this"/> TreeNode</param>
        public TreeNode(T data, TreeNode<T> left, TreeNode<T> right)
        {
            if(data == null)
            {
                throw new ArgumentNullException("A TreeNode cannot be constructed with null data");
            }

            this.data = data;
            this.left = left;
            this.right = right;
        }
    }
}

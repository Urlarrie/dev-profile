using DailyCodingProblem2.DataStructure;
using System.Text;
using System;

/// <summary>
/// Good morning! Here's your coding interview problem for today.
/// This problem was asked by Google.
/// Given the root to a binary tree, implement serialize(root), which serializes the tree into a string, 
/// and deserialize(s), which deserializes the string back into the tree.
/// </summary>
namespace DailyCodingProblem2
{
    /// <summary>
    /// Demonstrates the solution to the problem
    /// </summary>
    class Solution
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder("root");

            TreeNode<int> root1 = new TreeNode<int>(0, null, null);

            TreeNode<int> leaf3 = new TreeNode<int>(3, null, null);
            TreeNode<int> leaf4 = new TreeNode<int>(4, null, null);
            TreeNode<int> leaf1 = new TreeNode<int>(1, leaf3, null);
            TreeNode<int> leaf2 = new TreeNode<int>(2, null, leaf4);
            TreeNode<int> root2 = new TreeNode<int>(0, leaf1, leaf2);

            Console.WriteLine(Serialize(root1, sb));

            Console.WriteLine("---------------------------------");
            sb.Clear();
            sb.Append("root");

            Console.WriteLine(Serialize(root2, sb));
        }

        /// <summary>
        /// Returns the Binary Tree from a given root as a String
        /// </summary>
        /// <param name="root">the starting point of the Binary TRee</param>
        /// <returns>Returns a <see langword="string"/> representation of a Binary Tree</returns>
        /// <param name="sb">a <see cref="StringBuilder"/> to construct a <see langword="string"/> with</param>
        public static string Serialize(TreeNode<int> root, StringBuilder sb)
        {
            sb.Append($"[{root.data}]");

            if (root.left != null)
            {
                sb.Append(".left").Append(Serialize(root.left, sb)).Append(".NULL-\n");
            }

            if(root.right != null)
            {
                sb.Append(".right").Append(Serialize(root.right, sb)).Append(".NULL--\n\n");
            }

            return sb.ToString();
        }
    }
}

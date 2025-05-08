/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    private int maxSum=0;
    public int MaxSumBST(TreeNode root) {
         Traverse(root);
        return maxSum;
    }

    private (bool isBST, int minVal, int maxVal, int sumVal) Traverse(TreeNode node) {
        if (node == null) {
            // An empty tree is a BST with sum 0.
            // We set minVal=+∞ and maxVal=-∞ so any parent node.val
            // will satisfy node.val > left.maxVal and node.val < right.minVal.
            return (true, int.MaxValue, int.MinValue, 0);
        }

        // Recurse left and right
        var left  = Traverse(node.left);
        var right = Traverse(node.right);

        // Check BST property at this node
        if (left.isBST && right.isBST
            && node.val > left.maxVal
            && node.val < right.minVal)
        {
            int subtreeSum = left.sumVal + right.sumVal + node.val;
            // Update global maximum
            maxSum = Math.Max(maxSum, subtreeSum);

            // Compute new min/max for the parent
            int minVal = Math.Min(left.minVal, node.val);
            int maxVal = Math.Max(right.maxVal, node.val);

            return (true, minVal, maxVal, subtreeSum);
        }
        else {
            // Not a BST: sumVal won't be used by parent
            return (false, 0, 0, 0);
        }
    }
}
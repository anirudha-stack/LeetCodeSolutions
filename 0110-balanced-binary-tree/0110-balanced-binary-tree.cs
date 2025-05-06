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
    public bool IsBalanced(TreeNode root) {
        return computeHeight(root) == -1 ? false:true;
    }

    public int computeHeight(TreeNode node){
        if(node ==null){
            return 0;
        }

         // Check left subtree
        int leftHeight = computeHeight(node.left);
        if (leftHeight == -1) 
            return -1;               // left subtree is unbalanced

        // Check right subtree
        int rightHeight = computeHeight(node.right);
        if (rightHeight == -1) 
            return -1;               // right subtree is unbalanced

        // If current node is unbalanced, propagate -1
        if (Math.Abs(leftHeight - rightHeight) > 1)
            return -1;

        // Otherwise return height
        return Math.Max(leftHeight, rightHeight) + 1;
    }
}
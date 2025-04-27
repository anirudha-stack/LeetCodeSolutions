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
    private int _diameter = 0;
    public int DiameterOfBinaryTree(TreeNode root) {
       ComputeHeight(root);
        return _diameter;
    }
    
    // Returns the height of the subtree, and updates _diameter = max(_diameter, leftHeight + rightHeight)
    private int ComputeHeight(TreeNode node) {
        if (node == null) 
            return 0;
        
        int leftH  = ComputeHeight(node.left);
        int rightH = ComputeHeight(node.right);
        
        // At this node, the longest path through it is leftH + rightH
        _diameter = Math.Max(_diameter, leftH + rightH);
        
        // Height of this node is max of subtrees + 1
        return Math.Max(leftH, rightH) + 1;
    }
}
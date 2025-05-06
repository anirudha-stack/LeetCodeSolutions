/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        // Base case: if we hit the end or one of the targets, return it.
        if (root == null || root == p || root == q)
            return root;

        // Recurse on left and right
        TreeNode left = LowestCommonAncestor(root.left, p, q);
        TreeNode right = LowestCommonAncestor(root.right, p, q);

        // If both sides returned a non-null, this node is their split point
        if (left != null && right != null)
            return root;

        // Otherwise whichever side is non-null is the answer
        return left ?? right;
    }
}
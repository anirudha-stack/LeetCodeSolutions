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
     public IList<int> InorderTraversal(TreeNode root) {
        var result = new List<int>();
        Traverse(root, result);
        return result;
    }

    private void Traverse(TreeNode node, List<int> result) {
        if (node == null) 
            return;
        // 1) traverse left subtree
        Traverse(node.left, result);
        // 2) visit this node
        result.Add(node.val);
        // 3) traverse right subtree
        Traverse(node.right, result);
    }
}
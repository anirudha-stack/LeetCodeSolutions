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
    public bool FindTarget(TreeNode root, int k) {
 var seen = new HashSet<int>();
        return Dfs(root, k, seen);
    }

    private bool Dfs(TreeNode node, int k, HashSet<int> seen) {
        if (node == null) 
            return false;

        // If we've already seen the complement, we're done
        if (seen.Contains(k - node.val)) 
            return true;

        // Otherwise record this value
        seen.Add(node.val);

        // Recurse left or right
        return Dfs(node.left,  k, seen) 
            || Dfs(node.right, k, seen);
    }
}
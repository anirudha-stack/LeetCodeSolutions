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
    public bool IsSameTree(TreeNode p, TreeNode q) {
        return checker(p,q);

    }
    public bool checker(TreeNode p, TreeNode q) {
     if (p == null && q == null) 
            return true;
        // 2) One null, one not → not identical
        if (p == null || q == null) 
            return false;
        // 3) Mismatch in value → not identical
        if (p.val != q.val) 
            return false;
        // 4) Values match → must also match both subtrees
        return checker(p.left, q.left) 
            && checker(p.right, q.right);

    }



}
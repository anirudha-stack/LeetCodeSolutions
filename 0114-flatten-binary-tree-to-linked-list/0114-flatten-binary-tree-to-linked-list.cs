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
    private TreeNode prev = null;
    public void Flatten(TreeNode root) {
        if(root == null){
            return ;
        }

         Flatten(root.right);
         
         Flatten(root.left);
        
         root.right = prev;
         root.left = null;

         prev = root;


    }
}
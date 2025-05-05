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
    public TreeNode SearchBST(TreeNode root, int val) {
        
        TreeNode runner = root;

        while(runner!= null){

            if(runner.val == val){
                return runner;
            }

            if(runner.val > val){
                runner = runner.left;
            }
            else{
                runner = runner.right;
            }
        }

        return null;
    }
}
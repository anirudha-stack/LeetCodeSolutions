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
        
        return solver(root, p, q);

    }

    public TreeNode solver(TreeNode node, TreeNode p, TreeNode q){
        if( node.val > p.val && node.val < q.val  || node.val < p.val && node.val > q.val || node == null){
            return node;
        }
        else if(node == p){
            return p;
        }
        else if(node == q){
            return q;
        }

        if(node.val > p.val && node.val > q.val){
            node = node.left;
        }

        else if(node.val < p.val && node.val < q.val) {
            node = node.right;
        }

        

       return solver(node, p, q);
    }
}
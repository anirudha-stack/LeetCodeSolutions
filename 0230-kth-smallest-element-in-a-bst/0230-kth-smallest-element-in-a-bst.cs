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
    public int KthSmallest(TreeNode root, int k) {
        PriorityQueue<int,int> queue = new PriorityQueue<int,int>();
        
            solver(root,k,queue);

            return queue.Peek();


    }

    public void solver(TreeNode node, int k ,  PriorityQueue<int,int> queue){

            if(node == null){
                return;
            }

            if(queue.Count<k){
                queue.Enqueue(node.val,-node.val);
            }
            else if(node.val<queue.Peek()){
                queue.Dequeue();
                 queue.Enqueue(node.val,-node.val);
            }

            solver(node.left,k,queue);

            solver(node.right,k,queue);
    }

}
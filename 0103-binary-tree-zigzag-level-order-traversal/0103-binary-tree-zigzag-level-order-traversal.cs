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
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
       var answer = new List<IList<int>>();
        if (root == null) 
            return answer;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        bool leftToRight = true;

        while (queue.Count > 0) {
            int size = queue.Count;
            var level = new List<int>(size);

            for (int i = 0; i < size; i++) {
                var node = queue.Dequeue();

                // Depending on direction, either append or insert at front
                if (leftToRight)
                    level.Add(node.val);
                else
                    level.Insert(0, node.val);

                if (node.left  != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }

            answer.Add(level);
            leftToRight = !leftToRight;  // flip direction
        }

        return answer;
    }
    
}
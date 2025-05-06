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
    public int WidthOfBinaryTree(TreeNode root) {
         if (root == null) 
            return 0;

        // We'll do a standard BFS, storing (node, index) pairs.
        // Indexing convention: imagine the root at index=0;
        // then for any node at index i:
        //   left child  → 2*i
        //   right child → 2*i + 1
        //
        // At each level we record:
        //   firstIndex = index of the first node in the queue
        //   lastIndex  = index of the last node we dequeue
        // width = lastIndex - firstIndex + 1

        var q = new Queue<(TreeNode node, long idx)>();
        q.Enqueue((root, 0L));
        long maxWidth = 0;

        while (q.Count > 0)
        {
            int levelSize = q.Count;
            // The very first element at this level:
            long firstIndex = q.Peek().idx;
            long lastIndex  = firstIndex; // will update as we go

            for (int i = 0; i < levelSize; i++)
            {
                var (node, idx) = q.Dequeue();
                // Normalize idx so that it always starts from 0 for this level
                long relativeIdx = idx - firstIndex;

                // Capture the last index at this level
                if (i == levelSize - 1)
                    lastIndex = relativeIdx;

                // Enqueue children with the complete-tree indexing,
                // but using relativeIdx to keep numbers small
                if (node.left != null)
                    q.Enqueue((node.left, 2 * relativeIdx));
                if (node.right != null)
                    q.Enqueue((node.right, 2 * relativeIdx + 1));
            }

            // width of this level = lastIndex – 0 + 1
            maxWidth = Math.Max(maxWidth, lastIndex + 1);
        }

        return (int)maxWidth;
    }

}
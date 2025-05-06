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
    public IList<int> BoundaryOfBinaryTree(TreeNode root) {
         var res = new List<int>();
        if (root == null) return res;

        // 1) Root (if not a leaf)
        if (!IsLeaf(root)) 
            res.Add(root.val);

        // 2) Left boundary (excluding leaves)
        AddLeftBoundary(root.left, res);

        // 3) All leaves (left-to-right)
        AddLeaves(root, res);

        // 4) Right boundary (excluding leaves), added in reverse
        var rightBoundary = new List<int>();
        AddRightBoundary(root.right, rightBoundary);
        rightBoundary.Reverse();
        res.AddRange(rightBoundary);

        return res;
    }

    private bool IsLeaf(TreeNode node) {
        return node != null && node.left == null && node.right == null;
    }

    private void AddLeftBoundary(TreeNode node, List<int> res) {
        while (node != null) {
            if (!IsLeaf(node))
                res.Add(node.val);
            // prefer going left; if no left, go right
            node = (node.left != null) ? node.left : node.right;
        }
    }

    private void AddRightBoundary(TreeNode node, List<int> res) {
        while (node != null) {
            if (!IsLeaf(node))
                res.Add(node.val);
            // prefer going right; if no right, go left
            node = (node.right != null) ? node.right : node.left;
        }
    }

    private void AddLeaves(TreeNode node, List<int> res) {
        if (node == null) return;
        if (IsLeaf(node)) {
            res.Add(node.val);
        } else {
            AddLeaves(node.left, res);
            AddLeaves(node.right, res);
        }
    }

}
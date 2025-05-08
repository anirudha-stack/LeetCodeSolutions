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
public class BSTIterator {

    private  int counter;
    private readonly List<int> inorder;
    public BSTIterator(TreeNode root) {
        inorder = new List<int>();
        counter = 0;
        generateInOrder(inorder,root);
    }
    
    public int Next() {
        int answer = inorder[counter];
        counter++;
        return answer;
    }
    
    public bool HasNext() {
        if(counter<inorder.Count){
            return true;
        }
        else{
            return false;
        }
    }

    private void generateInOrder(List<int> answer,TreeNode node){
        if(node == null){
            return;
        }

        generateInOrder(answer,node.left);
        answer.Add(node.val);
        generateInOrder(answer,node.right);

    }
}

/**
 * Your BSTIterator object will be instantiated and called as such:
 * BSTIterator obj = new BSTIterator(root);
 * int param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */
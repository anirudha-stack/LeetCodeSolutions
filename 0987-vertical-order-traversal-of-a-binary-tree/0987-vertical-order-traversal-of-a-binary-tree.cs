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

    public class NodeLevel{
        public TreeNode node;
        public int level;
    }

    public IList<IList<int>> VerticalTraversal(TreeNode root) {
        List<IList<int>> answer = new List<IList<int>>();
         SortedDictionary<int,List<int>> map = new  SortedDictionary<int,List<int>>();
         Queue<NodeLevel> queue = new Queue<NodeLevel>();

         if(root == null) return answer;
         NodeLevel rootNode = new NodeLevel();
         rootNode.node = root;
         rootNode.level = 0;

         queue.Enqueue(rootNode);

         solver(answer,queue,map);

         return answer;

    }

    public void solver (List<IList<int>> answer,Queue<NodeLevel> queue, SortedDictionary<int,List<int>> map ){
        Console.WriteLine($"{queue.Count}");
        if(queue.Count == 0 ){

          
                  
                var cols = map.Keys.OrderBy(c => c);
            foreach (int c in cols) {
                map[c].Sort();          // sort each column’s list
                answer.Add(map[c]);
            }
            
            
            return ;
        }

       var nodeLevel = queue.Dequeue();
        TreeNode currentNode = nodeLevel.node;
        int level = nodeLevel.level;

        if (!map.ContainsKey(level))
            map[level] = new List<int>();
        map[level].Add(currentNode.val);
        




        if(currentNode.left != null){
            NodeLevel left = new NodeLevel();
            left.node = currentNode.left;
            left.level = level-1;
            queue.Enqueue(left);
            
        }
        if(currentNode.right != null){
            NodeLevel right = new NodeLevel();
            right.node = currentNode.right;
            right.level = level+1;
            queue.Enqueue(right);
        }


        solver(answer,queue,map);

    }
}
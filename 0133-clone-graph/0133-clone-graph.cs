/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    public Node CloneGraph(Node node) {
        if (node == null) return null;

        // Step 1: map original node → cloned node
        Dictionary<Node, Node> cloneMap = new Dictionary<Node, Node>();

        // Step 2: create a queue for BFS
        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(node);

        // Step 3: clone the first node
        cloneMap[node] = new Node(node.val);

        // Step 4: BFS traversal
        while (queue.Count > 0) {
            Node current = queue.Dequeue();

            foreach (var neighbor in current.neighbors) {
                // If neighbor not cloned yet, clone and enqueue
                if (!cloneMap.ContainsKey(neighbor)) {
                    cloneMap[neighbor] = new Node(neighbor.val);
                    queue.Enqueue(neighbor);
                }

                // Connect the clone of current to the clone of neighbor
                cloneMap[current].neighbors.Add(cloneMap[neighbor]);
            }
        }

        // Return the clone of the starting node
        return cloneMap[node];
     }
}
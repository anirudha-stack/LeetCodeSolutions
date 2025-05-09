public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
      // 1. Build graph (adjacency list)
        List<int>[] graph = new List<int>[numCourses];
        for (int i = 0; i < numCourses; i++)
            graph[i] = new List<int>();

        foreach (var prereq in prerequisites) {
            int course = prereq[0];
            int prereqCourse = prereq[1];
            graph[prereqCourse].Add(course);
        }

        // 2. Visited states:
        // 0 = unvisited, 1 = visiting, 2 = visited
        int[] visited = new int[numCourses];

        // 3. DFS on all nodes
        for (int i = 0; i < numCourses; i++) {
            if (HasCycle(graph, visited, i))
                return false;
        }

        return true;
    }

    private bool HasCycle(List<int>[] graph, int[] visited, int node) {
        if (visited[node] == 1)
            return true;  // cycle found
        if (visited[node] == 2)
            return false; // already checked, no cycle

        visited[node] = 1;  // mark as visiting

        foreach (var neighbor in graph[node]) {
            if (HasCycle(graph, visited, neighbor))
                return true;
        }

        visited[node] = 2;  // mark as done
        return false;
    }
}
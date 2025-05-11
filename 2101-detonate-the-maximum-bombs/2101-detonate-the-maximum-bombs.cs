public class Solution {
    public int MaximumDetonation(int[][] bombs) {
       int n = bombs.Length;
		List<int>[] graph = new List<int>[n];

		for(int i=0;i<n;i++){
graph[i] = new List<int>();
}

for(int i=0;i<n;i++){
	long x1 = bombs[i][0]; long y1= bombs[i][1]; long r1 = bombs[i][2];
	for(int j=0;j<n;j++){

long x2 = bombs[j][0]; long y2= bombs[j][1]; long r2 = bombs[j][2];

long dx = x1 - x2;
long dy = y1 - y2;
long distSq = dx * dx + dy * dy;
if (distSq <= r1 * r1) {
    graph[i].Add(j);
}
		


	}
}

int maxFire = 0;
for(int i=0;i<n;i++){
	int currentFire = BFS(i,graph);
	maxFire = Math.Max(maxFire,currentFire);
}

		return maxFire;
		

}






public int BFS(int start, List<int>[] graph){
		int fire = 1;
bool[] visited = new bool[graph.Length];
Array.Fill(visited,false);

	Queue<int> queue = new();
	queue.Enqueue(start);
	visited[start] = true;

	while(queue.Count > 0){
		var node = queue.Dequeue();
		foreach(var neighbour in graph[node]){
			if(!visited[neighbour]){
			fire++;

			visited[neighbour] = true;
			queue.Enqueue(neighbour);
}
}
}

return fire;

    }
}
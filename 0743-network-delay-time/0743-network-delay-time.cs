public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {
       
        int[] dist = new int[n+1];
        for(int i=1;i<=n;i++){
            dist[i] = Int32.MaxValue;
        }
        dist[k] = 0;

        Dictionary<int,List<(int,int)>> graph = new Dictionary<int,List<(int,int)>>();

        foreach(var time in times){
            int u = time[0];
            int v = time[1];
            int w = time[2];

            if (!graph.ContainsKey(u))
                    graph[u] = new List<(int, int)>();

            graph[u].Add((v, w));
        }


        PriorityQueue<int,int> queue = new PriorityQueue<int,int>();
        queue.Enqueue(k,0);

        while(queue.TryDequeue(out int start, out int incoming_cost)){
            
            //var (start,incoming_cost) = queue.Dequeue();
            if (incoming_cost > dist[start]) continue;

            if (!graph.ContainsKey(start)) continue;            // no outgoing edges
            foreach (var (v, w) in graph[start])
            {
                if (dist[start] + w < dist[v])
                {
                    dist[v] = dist[start] + w;
                    queue.Enqueue(v, dist[v]);
                }
            }   


        }

        int ans = 0;
        for (int i = 1; i <= n; i++)
        {
            if (dist[i] == Int32.MaxValue) return -1;
            ans = Math.Max(ans, dist[i]);
        }
        return ans;
        


    }



}
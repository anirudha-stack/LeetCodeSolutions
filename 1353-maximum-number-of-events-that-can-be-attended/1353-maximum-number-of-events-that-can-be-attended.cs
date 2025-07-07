public class Solution {
    public int MaxEvents(int[][] events) {
      int n = events.Length;
        int maxDay = 0;
        foreach (var e in events) {
            maxDay = Math.Max(maxDay, e[1]);
        }

        var pq = new PriorityQueue<int, int>();
        Array.Sort(events, (a, b) => a[0] - b[0]);
        int ans = 0;
        for (int i = 1, j = 0; i <= maxDay; i++) {
            while (j < n && events[j][0] <= i) {
                pq.Enqueue(events[j][1], events[j][1]);
                j++;
            }
            while (pq.Count > 0 && pq.Peek() < i) {
                pq.Dequeue();
            }
            if (pq.Count > 0) {
                pq.Dequeue();
                ans++;
            }
        }

        return ans;   
    }
}
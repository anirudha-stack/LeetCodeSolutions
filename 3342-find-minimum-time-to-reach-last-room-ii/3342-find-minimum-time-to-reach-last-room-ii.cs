using System;
using System.Collections.Generic;

public class Solution {
    public int MinTimeToReach(int[][] moveTime) {
        int n = moveTime.Length, m = moveTime[0].Length;
        // dist[x,y,p] = best-known arrival time at (x,y) when
        // the next move cost-parity is p (0 → 1s next, 1 → 2s next)
        var dist = new long[n, m, 2];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                dist[i, j, 0] = dist[i, j, 1] = long.MaxValue;

        // start at (0,0) with parity=0 (first move costs 1s), time=0
        dist[0, 0, 0] = 0;
        var pq = new PriorityQueue<(int x, int y, int p, long t), long>();
        pq.Enqueue((0, 0, 0, 0), 0L);

        int[] dx = { 1, -1, 0, 0 };
        int[] dy = { 0, 0, 1, -1 };

        while (pq.Count > 0) {
            var (x, y, parity, curT) = pq.Dequeue();
            // stale entry?
            if (curT != dist[x, y, parity]) 
                continue;
            // reached goal?
            if (x == n - 1 && y == m - 1) 
                return (int)curT;

            // relax all four neighbors
            for (int d = 0; d < 4; d++) {
                int nx = x + dx[d], ny = y + dy[d];
                if (nx < 0 || nx >= n || ny < 0 || ny >= m) 
                    continue;

                // wait until the neighbor is allowed
                long depart = Math.Max(curT, moveTime[nx][ny]);
                // cost depends on parity
                long moveCost = (parity == 0 ? 1 : 2);
                long arrive   = depart + moveCost;
                int  nextP    = parity ^ 1;

                if (arrive < dist[nx, ny, nextP]) {
                    dist[nx, ny, nextP] = arrive;
                    pq.Enqueue((nx, ny, nextP, arrive), arrive);
                }
            }
        }

        // fully connected grid ⇒ should never happen
        return -1;
    }
}

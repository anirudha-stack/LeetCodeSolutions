public class Solution
{
    

    public int MaxRemoval(int[] nums, int[][] queries) {
     int n = nums.Length, q = queries.Length;
        
        // 1) bucket query ends by their start index
        var qEnd = new List<List<int>>(n);
        for (int i = 0; i < n; i++)
            qEnd.Add(new List<int>());
        foreach (var query in queries)
            qEnd[query[0]].Add(query[1]);
        
        // 2) max‐heap of end indices via PriorityQueue with negative priority
        var pq = new PriorityQueue<int,int>();
        
        // cntQ[k+1] will track how many “decrements” should be applied when we pass index k
        var cntQ = new int[n + 1];
        int dec = 0;   // total decrements applied up to current i
        
        for (int i = 0; i < n; i++)
        {
            // apply any scheduled decrements at i
            dec += cntQ[i];
            
            // add all intervals starting at i
            foreach (int end in qEnd[i])
                pq.Enqueue(end, -end);
            
            int needed = nums[i];
            // while we haven't applied enough decrements to zero nums[i]
            while (needed > dec && pq.Count > 0)
            {
                // peek the interval with the largest end
                pq.TryPeek(out int bestEnd, out _);
                if (bestEnd < i)
                    break;   // no remaining interval covers i
                
                // pick it
                int k = pq.Dequeue();
                // schedule one more decrement at position k+1
                cntQ[k + 1]--;
                dec++;
            }
            
            // if we still haven't covered i enough times, it's impossible
            if (needed > dec)
                return -1;
        }
        
        // whatever remains in pq never got used → removable count
        return pq.Count;
    }
}

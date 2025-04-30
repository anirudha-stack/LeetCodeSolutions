public class Solution {
    public int MinMeetingRooms(int[][] intervals) {
        if (intervals == null || intervals.Length == 0)
            return 0;
        
        // 1. Sort by start time
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
        
        // 2. Min-heap of end times
        var pq = new PriorityQueue<int, int>();
        
        // 3. Start with the first meeting’s end
        pq.Enqueue(intervals[0][1], intervals[0][1]);
        
        // 4. Process the rest
        for (int i = 1; i < intervals.Length; i++) {
            int start = intervals[i][0];
            int end   = intervals[i][1];
            
            // If the earliest room frees up before this meeting starts,
            // reuse it (pop the smallest end time).
            if (pq.Peek() <= start) {
                pq.Dequeue();
            }
            
            // Allocate the room (either reused or new) by pushing this end time
            pq.Enqueue(end, end);
        }
        
        // 5. The heap size is the max rooms in use at once
        return pq.Count;

    }
}
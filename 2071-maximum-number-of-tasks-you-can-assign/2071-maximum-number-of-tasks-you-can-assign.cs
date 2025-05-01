public class Solution {
    public int MaxTaskAssign(int[] tasks, int[] workers, int pills, int strength) {
       Array.Sort(tasks);
        Array.Sort(workers);
        int n = tasks.Length, m = workers.Length;

        int left = 1, 
            right = Math.Min(n, m), 
            ans = 0;

        // Binary‐search on k = how many tasks we try to assign
        while (left <= right) {
            int mid = left + (right - left) / 2;
            if (CanAssign(tasks, workers, pills, strength, mid)) {
                ans = mid;        // mid tasks is possible
                left = mid + 1;   // try more
            } else {
                right = mid - 1;  // too many, try fewer
            }
        }

        return ans;
    }

    private bool CanAssign(
        int[] tasks,
        int[] workers,
        int pills,
        int strength,
        int k
    ) {
        int m = workers.Length;

        // Build a multiset of the k strongest workers
        var ws = new SortedList<int,int>();
        for (int i = m - k; i < m; i++) {
            int w = workers[i];
            if (ws.ContainsKey(w)) ws[w]++;
            else               ws[w] = 1;
        }

        var keys = ws.Keys;  // sorted list of strengths

        // Try to assign the k hardest tasks first
        for (int ti = k - 1; ti >= 0; ti--) {
            int need = tasks[ti];

            // 1) can the strongest worker do it unaided?
            int strongest = keys[keys.Count - 1];
            if (strongest >= need) {
                Decrease(ws, strongest);
            }
            else {
                // 2) else try to use a pill on the weakest worker that can reach it
                if (pills == 0) return false;

                int target = need - strength;
                int idx = CeilIndex(keys, target);
                if (idx < 0) return false;

                Decrease(ws, keys[idx]);
                pills--;
            }
        }

        return true;
    }

    // helper to decrement or remove from the multiset
    private void Decrease(SortedList<int,int> ws, int key) {
        if (--ws[key] == 0) ws.Remove(key);
    }

    // binary-search for smallest index i with keys[i] >= target
    // returns -1 if none found
    private int CeilIndex(IList<int> keys, int target) {
        int lo = 0, hi = keys.Count - 1, ans = -1;
        while (lo <= hi) {
            int mid = lo + (hi - lo) / 2;
            if (keys[mid] >= target) {
                ans = mid;
                hi  = mid - 1;
            } else {
                lo = mid + 1;
            }
        }
        return ans;
    }
}
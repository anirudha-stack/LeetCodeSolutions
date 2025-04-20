public class Solution {
    public int NumRabbits(int[] answers) {
        
          int total = 0;
        var rabbits = new Dictionary<int,int>();

        foreach (var ans in answers) {
            rabbits[ans] = rabbits.GetValueOrDefault(ans) + 1;
        }

     
       foreach (var kv in rabbits) {
            int ans   = kv.Key;
            int count = kv.Value;
            int groupSize = ans + 1;

            // Number of full groups needed (round up)
            int groups = (count + groupSize - 1) / groupSize;

            total += groups * groupSize;
        }

        return total;
    }
}
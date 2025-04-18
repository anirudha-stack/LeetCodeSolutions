public class Solution {
    public int[][] Merge(int[][] intervals) {
        Array.Sort(intervals, (a, b) => {
            int cmp = a[0].CompareTo(b[0]);
            return cmp != 0 ? cmp : a[1].CompareTo(b[1]);
        });
        int m = intervals.Length;
        List<(int,int)> output = new List<(int,int)>();
        int start =0;
        int end = 0;
        for(int i=0;i<m;i++){
            
            start = intervals[i][0];
            end = intervals[i][1];
          
            if(output.Count != 0){
                 var lastEntry = output[output.Count - 1];
                 if(end <= lastEntry.Item2){
                    continue;
                 }
            }

            for( int j=i+1;j<m;j++){
                if(intervals[j][0] <= end ){
                    end = Math.Max(end,intervals[j][1]);
                }
                else{
                    break;
                }
            }
            //Console.WriteLine($"{start},{end}");
            output.Add((start,end));
           
        }



        return output
    .Select(t => new int[] { t.Item1, t.Item2 })
    .ToArray();
    }
}
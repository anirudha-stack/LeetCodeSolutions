public class Solution {
    public int[] RearrangeArray(int[] nums) {
               List<int> positives = new List<int>();
        List<int> negatives = new List<int>(); 
        List<int> answer = new List<int>();

        foreach (var num in nums) {
            if (num > 0) {
                positives.Add(num);
            } else {
                negatives.Add(num);
            }
        }

        int size = Math.Min(positives.Count, negatives.Count);

        for (int i = 0; i < size; i++) {
            answer.Add(positives[i]);
            answer.Add(negatives[i]);
        }


        for (int i = size; i < positives.Count; i++) answer.Add(positives[i]);
        for (int i = size; i < negatives.Count; i++) answer.Add(negatives[i]);

        return answer.ToArray();
    }
}
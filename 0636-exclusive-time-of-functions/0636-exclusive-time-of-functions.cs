public class Solution {
    public int[] ExclusiveTime(int n, IList<string> logs) {
        var result = new int[n];
        var stack = new Stack<int>(); // Stack of function ids
        int prevTime = 0;

        foreach (string log in logs) {
            var parts = log.Split(':');
            int id = int.Parse(parts[0]);
            string type = parts[1];
            int time = int.Parse(parts[2]);

            if (type == "start") {
                if (stack.Count > 0) {
                    result[stack.Peek()] += time - prevTime;
                }
                stack.Push(id);
                prevTime = time;
            } else { // type == "end"
                result[stack.Pop()] += time - prevTime + 1;
                prevTime = time + 1;
            }
        }

        return result;

    }
}
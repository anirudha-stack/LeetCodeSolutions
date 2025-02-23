public class Solution {
    public int[] CycleLengthQueries(int n, int[][] queries) {
        List<int> answer = new List<int>();
        foreach(var query in queries){
            int startPoint = query[0];
            int endPoint = query[1];
            List<int> leftPoints = new List<int>();
            List<int> rightPoints = new List<int>();
            int traversal = 0;

            while(startPoint >=1){
                leftPoints.Add(startPoint);
                startPoint = startPoint/2;
            }
            while(endPoint >=1){
                rightPoints.Add(endPoint);
                endPoint = endPoint/2;
            }

            var commonElement = leftPoints.Intersect(rightPoints);
        
            int commonValue = commonElement.First();
            traversal = leftPoints.IndexOf(commonValue) + rightPoints.IndexOf(commonValue)+1;
            
            answer.Add(traversal);
        }

        return answer.ToArray();

    }
}
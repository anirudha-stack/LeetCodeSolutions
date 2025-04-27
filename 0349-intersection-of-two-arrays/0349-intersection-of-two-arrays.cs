public class Solution {
    public int[] Intersection(int[] nums1, int[] nums2) {
        HashSet<int> map1 = new HashSet<int>(nums1);
        HashSet<int> map2 = new HashSet<int>(nums2);

        List<int> answer = new List<int>();

        if(map1.Count < map2.Count){

        foreach(var num in map2){
            if(map1.Contains(num)){
                answer.Add(num);
            }
        }
        }
        else{
             foreach(var num in map1){
            if(map2.Contains(num)){
                answer.Add(num);
            }
        }
        }


        return answer.ToArray();
    
    }
}
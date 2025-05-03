public class Solution {
    public int MinDominoRotations(int[] tops, int[] bottoms) {

        int top = 1;
        int bott = 1;
        int answer = 0;

        while(top <= tops.Length-1 && bott <= bottoms.Length-1){
            
            Console.WriteLine($"{tops[top]} -> {bottoms[bott]}");

            if(tops[top] == bottoms[bott-1] && tops[top] != tops[top-1] && tops[top] != bottoms[bott]){
                Console.WriteLine($"swapping {tops[top]} -> {bottoms[bott]}");

                int temp = tops[top];
                tops[top] = bottoms[bott];
                bottoms[bott] = temp;
                top++;
                bott++;
                answer++;
                
            }
            else if(bottoms[bott] == tops[top-1] && bottoms[bott]!= bottoms[bott-1]&& tops[top] != bottoms[bott]){
                Console.WriteLine($"swapping {tops[top]} -> {bottoms[bott]}");

                int temp = tops[top];
                tops[top] = bottoms[bott];
                bottoms[bott] = temp;
                top++;
                bott++;
                answer++;
            }

            else{
                Console.WriteLine($"No swap required");

                top++;
                bott++;
            }

        }
        Console.WriteLine(string.Join(", ",tops));
                Console.WriteLine(string.Join(", ",bottoms));

        bool topMatch = false;
        bool bottomMatch = false;
        for(int i=1;i<tops.Length;i++){
           if( tops[i] == tops[i-1]){
            topMatch = true;
           }
           else{
            topMatch = false;
            break;
           }
        }
        for(int i=1;i<tops.Length;i++){

            if( bottoms[i] == bottoms[i-1]){
            bottomMatch = true;
           }
           else{
            bottomMatch = false;
            break;
           }
        }
        Console.WriteLine($"{topMatch} and {bottomMatch}");
        if(topMatch == false && bottomMatch == false) answer = -1;

        return answer;

    }
}
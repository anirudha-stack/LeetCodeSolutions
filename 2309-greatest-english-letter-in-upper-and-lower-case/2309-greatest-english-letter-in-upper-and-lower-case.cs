public class Solution {
    public string GreatestLetter(string s) {
        GC.Collect();

        char greatest ='\0';
       for(int i=0;i<s.Length;i++){
        for(int j=i+1;j<s.Length;j++){
            //Console.WriteLine($"Comparing {s[i]} and {s[j]}");
                if((Char.ToLower(s[i]) == Char.ToLower(s[j])) && Math.Abs(s[j]-s[i])==32 && 
                 Char.ToUpper(s[i]) > greatest
                 ){
                        greatest = Char.ToUpper(s[i]);
                       // Console.WriteLine($"Greatest is  {s[j]}");
            
                }
        }

       }

        
        if(greatest =='\0') return string.Empty;
       return Convert.ToString(greatest);
    }
}
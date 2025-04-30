public class Solution {
    public string ApplySubstitutions(IList<IList<string>> replacements, string text) {
        
        Dictionary<string,string> map = new  Dictionary<string,string>();

        foreach(var replacement in replacements){

            map.Add(replacement[0],replacement[1]);
        }


       

        while(text.Contains('%')){
             StringBuilder sb = new StringBuilder();
            string[] templates = text.Split('%');

        foreach(var ph in templates){
            if(ph == "") continue;
            if(map.ContainsKey(ph)){
            sb.Append(map[ph]);
            }
            else{
                sb.Append(ph);
            }
           
        }
        text =  sb.ToString();
        }
        return text;

    }
}
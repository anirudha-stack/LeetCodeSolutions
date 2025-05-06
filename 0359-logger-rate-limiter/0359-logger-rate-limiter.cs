public class Logger {
    private readonly Dictionary<string,int> occ;
    public Logger() {
        occ = new Dictionary<string,int>();
    }
    
    public bool ShouldPrintMessage(int timestamp, string message) {
        if(occ.ContainsKey(message)){
            if(timestamp >= occ[message]){
                occ[message] = 10+timestamp;
                return true;
            }
            else{

                return false;
            }
        }
        else{
            occ.Add(message,10+timestamp);
            return true;
        }
    }
}

/**
 * Your Logger object will be instantiated and called as such:
 * Logger obj = new Logger();
 * bool param_1 = obj.ShouldPrintMessage(timestamp,message);
 */
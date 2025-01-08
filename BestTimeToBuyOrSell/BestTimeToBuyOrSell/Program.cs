using System;
class Program
{
    static void Main()
    {
        int[] prices = { 7, 1, 5, 3, 6, 4 , 1,2,3,4};
        Console.WriteLine("Prices: " + string.Join(", ", prices));

        int output = MaxProfit2(prices);

        Console.WriteLine("Output: " + output);



    }
    public static int MaxProfit(int[] prices)
    {
        int TotalProfit = 0;
        int higherPrice = 0;
        int lowerPrice = 0;
        int todaysPrice = 0;

        int[] stockBought = new int[prices.Length];
       
       


        for(int i = 0;i< prices.Length; i++)
        {
            todaysPrice = prices[i];
            int maxProfit = 0;
            for (int j = i; j < prices.Length-1; j++)
            {
                higherPrice = prices[j + 1];

                if (higherPrice > todaysPrice && (higherPrice - todaysPrice)>maxProfit && stockBought[j+1] == 0)
                {
                   

                    Console.WriteLine("Buy at: " + todaysPrice + " || Sell at : " + higherPrice + " || profit : " + (higherPrice - todaysPrice));
                    
                    maxProfit = higherPrice - todaysPrice;
                    stockBought[j+1] = 1;


                }
                else
                {
                    break;
                }

            }
            TotalProfit += maxProfit;
        }


        return TotalProfit;
    }


    public static int MaxProfit2(int[] prices)
    {
        int maxProfit = 0;

        for (int i = 1; i<prices.Length; i++)
        {
            if (prices[i] > prices[i - 1])
            {
                
                maxProfit += prices[i] - prices[i - 1];
            }
        }

        return maxProfit;
    }
}
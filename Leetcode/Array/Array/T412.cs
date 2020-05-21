using System;
using System.Collections.Generic;

namespace Array
{
    public class T412
    {
        public void Test()
        {
            var result = new List<string>();
        
            for(var i = 1; i <= 15; i++)
            {
                if(i % 3 == 0 && i % 5 == 0){
                    result.Add("FizzBuzz");
                }
                else if(i % 3 == 0){
                    result.Add("Fizz");
                }
                else if(i % 5 == 0){
                    result.Add("Buzz");
                }
                else{
                    result.Add(i.ToString());
                }
            }

            Console.WriteLine(result);
        }
    }
}
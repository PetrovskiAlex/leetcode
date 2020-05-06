using NUnit.Framework;

namespace Array
{
    public class T977
    {
        [TestCase(new []{-4,-1,0,3,10}, new []{0,1,9,16,100})]
        public void Test(int[] input, int[] output)
        {
            for (var i = 0; i < input.Length; i++)
            {
                input[i] = input[i] * input[i];
            }
            
            System.Array.Sort(input);
        }
    }
}
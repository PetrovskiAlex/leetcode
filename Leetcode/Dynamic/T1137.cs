namespace Dynamic
{
    public class T1137
    {
        
        
        int GetFib(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            if (n == 2) return 1;

            var previous = 1;
            var subPrevious = 0;

            var result = previous + subPrevious;
            for (var i = 2; i <= n; i++)
            {
                result = previous + subPrevious;
                subPrevious = previous;
                previous = result;
            }

            return result;
        }
    }
}
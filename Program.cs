namespace StringtoInteger_atoi_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution.MyAtoi("+-12"));

            Console.ReadKey();
        }
    }


    public static class Solution
    {
        public static int MyAtoi(string s)
        {
            s = s.ToLower();
            var lsString = s.Select(x => x.ToString());
            var alpha = new List<string>()
            {
               "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o","p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "+" };
            bool isChar = false;
            bool isNumber = false;
            var tempString = string.Empty;
            var delimiter = ".";
            var isDelimiter = false;
            foreach (var item in lsString)
            {
                if(delimiter ==item)
                {
                    isDelimiter = true;
                }
                isChar = alpha.Contains(item);

                if (isChar && !isNumber)
                {
                    return 0;
                }

                if (item == "-" && !isDelimiter)
                {
                    tempString = $"{tempString}{item}";
                }

                if (long.TryParse(item, out long result) && !isDelimiter)
                {
                    isNumber = true;
                    tempString = $"{tempString}{item}";
                }
            }

            if(string.IsNullOrEmpty(tempString))
            {
                return 0;
            }
            long d = Convert.ToInt64(tempString);

            if (d > int.MaxValue)
            {
                return int.MaxValue;
            }

            if (d < int.MinValue)
            {
                return int.MinValue;
            }

            if (!int.TryParse(tempString, out int res))
            {
                return 0;
            }


            return Convert.ToInt32(tempString);
        }
    }
}
namespace Program
{
    public static class Program
    {
        public static void Main()
        {
            string[] input = File.ReadAllText("input.txt").Trim().Split(',');
            List<int> intput = new List<int>();
            int highest = int.MinValue, lowest = int.MaxValue;
            foreach (string i in input)
            {
                int ni = int.Parse(i);
                intput.Add(ni);
                if (ni > highest)
                    highest = ni;
                else if (lowest > ni)
                    lowest = ni;
            }
            int lowestFuelCost = int.MaxValue, pos = 0; ;
            for (int i = lowest; i < highest; i++)
            {
                int total = 0;

                foreach (var item in intput)
                {
                    for (int j = 1; j <= Math.Abs(item - i); j++)
                        total += j;
                }
                if (total < lowestFuelCost)
                {
                    lowestFuelCost = total;
                    pos = i;
                }
            }
            Console.WriteLine($"{lowestFuelCost} : {pos}");
        }
    }
}
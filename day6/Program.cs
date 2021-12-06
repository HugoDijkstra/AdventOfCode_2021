namespace Program
{
    public static class Program
    {
        public static void Main()
        {
            List<ulong> fishes = new List<ulong>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            List<ulong> fishes1 = new();
            string[] input = File.ReadAllLines("input.txt")[0].Split(',');
            foreach (var inp in input)
            {
                fishes[int.Parse(inp)]++;
                fishes1.Add(ulong.Parse(inp));
            }
            Console.WriteLine(fishes.Count);

            for (int i = 0; i < 256; i++)
            {
                List<ulong> nextDay = new List<ulong>();
                for (int j = 1; j <= 8; j++)
                {
                    nextDay.Add(fishes[j]);
                }
                nextDay[6] += fishes[0];
                nextDay.Add(fishes[0]);
                fishes = nextDay;
                Console.WriteLine($"At day {i + 1} there were {fishes.Sum<ulong>(item =>{ return (double)item;})} Lanternfish");
               
               
                //Old way took 16GB of ram after 170 days

                // List<int> newFish = new();
                // for (int fish = 0; fish < fishes1.Count; fish++)
                // {
                //     if (fishes1[fish] == 0)
                //     {
                //         fishes1[fish] = 6;
                //         // Console.WriteLine($"Fish {fish} gave birth to {fishes.Count + newFish.Count}");
                //         newFish.Add(8);
                //     }
                //     else
                //     {
                //         fishes1[fish]--;
                //     }
                // }
                // fishes1.AddRange(newFish);
                // Console.WriteLine($"At day {i + 1} there were {fishes1.Count} Lanternfish1");

            }

            Console.WriteLine(fishes[0]);
        }
    }
}
using System;

namespace Program
{
    public static class Program
    {
        public static void Main()
        {
            string[] input = File.ReadAllLines("input.txt");
            int x = 0,a = 0, d = 0;
            foreach (var command in input)
            {
                if (string.IsNullOrEmpty(command))
                    continue;
                string[] form = command.Split(" ");
                switch (form[0])
                {
                    case "forward": int val = int.Parse(form[1]); x += val; d+= a*val;  break;
                    case "up": a -= int.Parse(form[1]); break;
                    case "down": a += int.Parse(form[1]); break;
                }
            }

            Console.WriteLine(x);
            Console.WriteLine(d);
            Console.WriteLine(x*d);
        }
    }
}
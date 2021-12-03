using System;
using System.IO;

namespace day1
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            string[] distance = File.ReadAllLines("input.txt");
            Console.WriteLine(MoreThenLast(0,0,0,distance));
        }

        public static int MoreThenLast(int index, int lastSum, int result,string[] distances)
        {
            int sum = 0;
            if(distances.Length < index + 3)return result;
            for(int i = index; i < index + 3;i++) sum += int.Parse(distances[i]);
            if(sum > lastSum && lastSum != 0) result++;
            return MoreThenLast(index + 1,sum, result,distances);
        }
    }
}
namespace Program
{
    public static class Program
    {
        class Display
        {
            public char top, botom, topLeft, topRight, middle, bottomLeft, BottomRight;
        }

        // A not in B
        public static char notIn(string a, string b)
        {
            foreach (var c in a)
            {
                if (!b.Contains(c))
                    return c;
            }
            return '\0';
        }

        public static int difference(string a, string b)
        {
            int dif = 0;
            foreach (var c in a)
            {
                if (!b.Contains(c))
                {
                    dif++;
                }
            }
            return dif;
        }
        public static void Main()
        {
            string[] input = File.ReadAllLines("input.txt");
            int unique = 0;
            int total = 0;
            foreach (var inp in input)
            {
                if (string.IsNullOrEmpty(inp))
                    continue;

                string[] split = inp.Split('|');
                List<string> segments = new(split[0].Split(' '));
                string[] usedInput = split[1].Split(' ');
                Display display = new Display();
                SortedList<int, string> numbers = new();

                //Get known
                for (int i = 0; i < segments.Count; i++)
                {
                    if (segments[i].Length == 7)
                    {
                        numbers.Add(8, segments[i]);
                    }
                    else if (segments[i].Length == 2)
                    {
                        numbers.Add(1, segments[i]);
                    }
                    else if (segments[i].Length == 4)
                    {
                        numbers.Add(4, segments[i]);
                    }
                    else if (segments[i].Length == 3)
                    {
                        numbers.Add(7, segments[i]);
                    }
                    else
                    {
                        continue;
                    }
                    segments.RemoveAt(i);
                    i--;
                }

                foreach (var seg in segments)
                {
                    if (seg.Length == 5)
                    {
                        char c = notIn(numbers[1], seg);
                        if (c == '\0')
                        {
                            numbers.Add(3, seg);
                        }
                    }
                }
                segments.Remove(numbers[3]);
                //Set top
                char t = notIn(numbers[7], numbers[1]);
                Console.WriteLine(t);
                display.top = t;

                foreach (var seg in segments)
                {
                    if (seg.Length == 6)
                    {
                        char c = notIn(numbers[3], seg);
                        if (c == '\0')
                        {
                            numbers.Add(9, seg);
                            break;
                        }
                    }
                }
                segments.Remove(numbers[9]);
                foreach (var seg in segments)
                {
                    if (seg.Length == 6)
                    {
                        char c = notIn(numbers[4], seg);
                        if (c != '\0')
                        {
                            c = notIn(numbers[1], seg);
                            if (c != '\0')
                            {
                                numbers.Add(6, seg);
                                break;
                            }
                        }
                    }
                }
                segments.Remove(numbers[6]);
                foreach (var seg in segments)
                {
                    if (seg.Length == 6)
                    {
                        numbers.Add(0, seg);
                    }
                }
                segments.Remove(numbers[0]);

                foreach (var seg in segments)
                {
                    if (seg.Length == 5)
                    {
                        char c = notIn(seg, numbers[6]);
                        if (c == '\0')
                        {
                            numbers.Add(5,seg);
                        }
                    }
                }
                segments.Remove(numbers[5]);
                foreach (var seg in segments)
                {
                    if (seg.Length == 5)
                    {
                        char c = notIn(seg, numbers[6]);
                        if (c != '\0')
                        {
                            numbers.Add(2,seg);
                        }
                    }
                }
                segments.Remove(numbers[2]);
                int times = 1000;
                foreach (var part in usedInput)
                {
                    string sorted = string.Concat(part.OrderBy(c=>c));
                    for(int i = 0; i < numbers.Count;i++)
                    {
                        string num = string.Concat( numbers[i].OrderBy(c=>c));
                        if(sorted ==  num)
                        {
                            total += i*times;
                            Console.WriteLine(i);
                            times /= 10;
                        }
                    }
                }
            }
            Console.WriteLine(total);
        }
    }
}
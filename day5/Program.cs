namespace Program
{
    public static class Program
    {
        public static void Main()
        {
            string[] input = File.ReadAllLines("input.txt");
            List<Vector2> points = new List<Vector2>();
            List<Vector2> overlaps = new List<Vector2>();
            foreach (var line in input)
            {
                if (string.IsNullOrEmpty(line))
                    continue;
                Console.WriteLine($"Checking {line}");
                string[] split = line.Split(" -> ");
                Vector2 a = new(split[0]), b = new(split[1]);
                if (a.x == b.x)
                {
                    for (int y = (a.y < b.y) ? a.y : b.y; (a.y < b.y) ? (y <= b.y) : (y <= a.y); y++)
                    {
                        //Console.WriteLine($"Creating line ({a.x},{y}) {{{a}}} -> {{{b}}} ");

                        Vector2 point = new Vector2(a.x, y);
                        if (points.Contains(point))
                        {
                            if (!overlaps.Contains(point))
                                overlaps.Add(point);
                            continue;
                        }
                        points.Add(point);
                    }
                }
                else if (a.y == b.y)
                {
                    for (int x = (a.x < b.x) ? a.x : b.x; (a.x < b.x) ? (x <= b.x) : (x <= a.x); x++)
                    {
                        Vector2 point = new Vector2(x, a.y);

                        if (points.Contains(point))
                        {
                            if (!overlaps.Contains(point))
                                overlaps.Add(point);
                            continue;
                        }
                        points.Add(point);
                    }
                }
                else 
                {
                    int it = 0;
                    Vector2 startPoint = (a.x < b.x) ? a : b, endPoint = startPoint == a ? b : a;
                    if (points.Contains(startPoint))
                    {
                        if (!overlaps.Contains(startPoint))
                            overlaps.Add(startPoint);
                    }
                    else
                        points.Add(startPoint);

                    while (!startPoint.Equals(endPoint))
                    {
                        startPoint = Vector2.stepTowards(startPoint, endPoint);
                        //Console.WriteLine($"Creating line (startPoint) {{{startPoint}}} -> {{{endPoint}}} ");
                        if (points.Contains(startPoint))
                        {
                            if (!overlaps.Contains(startPoint))
                                overlaps.Add(startPoint);
                            continue;
                        }
                        points.Add(startPoint);
                    }
                }
            }
            Console.WriteLine($"{points.Count} | {overlaps.Count} ");

        }

        public class Vector2 : IEquatable<Vector2>
        {
            public int x, y;
            public Vector2(int _x, int _y)
            {
                x = _x;
                y = _y;
            }

            public Vector2(string coor)
            {
                string[] split = coor.Split(',');
                x = int.Parse(split[0]);
                y = int.Parse(split[1]);
            }

            public static Vector2 stepTowards(Vector2 current, Vector2 endPoint)
            {
                if (current == endPoint)
                    return endPoint;
                return new Vector2(current.x < endPoint.x ? current.x + 1 : current.x - 1, current.y < endPoint.y ? current.y + 1 : current.y - 1);


            }

            public override string ToString()
            {
                return $"({x},{y})";
            }


            public bool Equals(Vector2 other)
            {
                // Would still want to check for null etc. first.
                return this.x == other.x && this.y == other.y;
            }
        }
    }
}
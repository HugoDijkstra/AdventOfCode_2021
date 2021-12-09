namespace Program
{
    public static class Program
    {
        public static void Main()
        {
            string input = File.ReadAllText("input.txt").Trim();
            List<List<int>> allHeights = new();
            int totalDanger = 0;
            List<int> curList = new();
            allHeights.Add(curList);
            List<List<Vector2>> basins = new();
            foreach (char c in input)
            {
                //stupid hack
                if (c == '\n')
                {
                    curList = new();
                    allHeights.Add(curList);
                    continue;
                }
                string s = c + "";
                curList.Add(int.Parse(s));
            }

            for (int i = 0; i < allHeights.Count - 0; i++)
            {
                for (int j = 0; j < allHeights[i].Count; j++)
                {
                    if (allHeights[i][j] != 9 && allHeights[i][j] != -1)
                    {
                        //Use fill algorithm
                        List<Vector2> basin = findAllConnectedPositions(ref allHeights, new Vector2() { x = i, y = j });
                        basins.Add(basin);
                    }
                }
                // Part 1
                // for (int j = 0; j < allHeights[i].Count; j++)
                // {
                //     if (i == 0 || allHeights[i - 1][j] > allHeights[i][j])
                //         if (i == allHeights.Count - 1 || allHeights[i + 1][j] > allHeights[i][j])
                //             if (j == 0 || allHeights[i][j - 1] > allHeights[i][j])
                //                 if (j == allHeights[i].Count - 1 || allHeights[i][j + 1] > allHeights[i][j])
                //                 {
                //                     totalDanger += allHeights[i][j] + 1;
                //                 }
                // }
            }
            for (int i = 0; i < allHeights.Count - 0; i++)
            {
                for (int j = 0; j < allHeights[i].Count; j++)
                    Console.Write(allHeights[i][j] == 9 ? 9 : 0);
                Console.Write('\n');
            }

            basins.Sort(delegate (List<Vector2> a, List<Vector2> b)
            {
                if (a.Count == b.Count) return 0;
                return a.Count > b.Count ? -1:1;

            });

            Console.WriteLine(basins[0].Count * basins[1].Count * basins[2].Count);
        }

        public static List<Vector2> findAllConnectedPositions(ref List<List<int>> allHeights, Vector2 startPos)
        {
            List<Vector2> ret = new();
            ret.Add(startPos);
            allHeights[startPos.x][startPos.y] = -1;
            if (startPos.x != 0)
            {
                if (allHeights[startPos.x - 1][startPos.y] != 9
                && allHeights[startPos.x - 1][startPos.y] != -1)
                    ret.AddRange(findAllConnectedPositions(ref allHeights, new Vector2() { x = startPos.x - 1, y = startPos.y }));
            }
            if (startPos.x <= allHeights.Count - 2)
            {
                if (allHeights[startPos.x + 1][startPos.y] != 9
                && allHeights[startPos.x + 1][startPos.y] != -1)
                    ret.AddRange(findAllConnectedPositions(ref allHeights, new Vector2() { x = startPos.x + 1, y = startPos.y }));
            }
            if (startPos.y != 0)
            {
                if (allHeights[startPos.x][startPos.y - 1] != 9
                && allHeights[startPos.x][startPos.y - 1] != -1)
                    ret.AddRange(findAllConnectedPositions(ref allHeights, new Vector2() { x = startPos.x, y = startPos.y - 1 }));
            }
            if (startPos.y <= allHeights[startPos.x].Count - 2)
            {
                if (allHeights[startPos.x][startPos.y + 1] != 9
                && allHeights[startPos.x][startPos.y + 1] != -1)
                    ret.AddRange(findAllConnectedPositions(ref allHeights, new Vector2() { x = startPos.x, y = startPos.y + 1 }));
            }
            return ret;
        }
        public class Vector2 : IEquatable<Vector2>
        {
            public int x, y;

            public bool Equals(Vector2? other)
            {
                return other != null && x == other.x && y == other.y;
            }
        }
    }
}
namespace Program
{
    public static class Program
    {
        public static void Main()
        {
            string[] inputs = File.ReadAllLines("input.txt");
            string[] number = inputs[0].Split(',');

            List<BingoBoard> boards = new();

            for (int i = 2; i < inputs.Length; i += 6)
            {
                if (string.IsNullOrEmpty(inputs[i])) continue;
                int[,] board = new int[5, 5];
                for (int j = 0; j < 5; j++)
                {
                    string[] numbers = inputs[i + j].Trim().Replace("  ", " ").Split(' ');
                    for (int k = 0; k < 5; k++)
                    {
                        board[j, k] = int.Parse(numbers[k]);
                    }
                }
                BingoBoard b = new BingoBoard(board);
                boards.Add(b);
            }
            foreach (var n in number)
            {
                for (int i = 0; i < boards.Count; i++)
                {
                    BingoBoard b = boards[i];
                    if (b.StripeOff(int.Parse(n)))
                    {
                        boards.Remove(b);
                        i--;
                    }
                }

            }
            foreach (var b in boards)
            {

            }

        }
    }
    public class BingoBoard
    {
        private int[,] board;
        private bool[,] bingo;
        public BingoBoard(int[,] _board)
        {
            bingo = new bool[5, 5];
            for (int x = 0; x < 5; x++)
                for (int y = 0; y < 5; y++)
                    bingo[x, y] = false;
            this.board = _board;
        }

        public bool StripeOff(int num)
        {
            bool won = false;
            bool found = false;
            for (int x = 0; x < 5 && !found; x++)
            {

                for (int y = 0; y < 5; y++)
                {
                    if (board[x, y] == num)
                    {
                        bingo[x, y] = true;
                        found = true;
                        break;
                    }
                }

            }

            for (int x = 0; x < 5 && !won; x++)
            {
                int horizontal = 0;
                int vertical = 0;
                for (int y = 0; y < 5 && !won; y++)
                {
                    if (bingo[x, y]) horizontal++;
                    if (bingo[y, x]) vertical++;
                }
                if (horizontal == 5 || vertical == 5)
                    won = true;
            }

            if (won)
            {
                int retNum = 0;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (!bingo[i, j])
                        {
                            retNum += board[i, j];
                        }
                    }
                }
                Console.WriteLine($"{retNum} | {num} | {retNum * num}");
                return true;
            }
            return won;
        }

        public override string ToString()
        {
            string ret = "";
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    ret += (bingo[x, y] ? "x" : "o") + ",";
                }
                ret += '\n';
            }
            return ret;
        }
    }
}
using System;

namespace Program
{
    public static class Program
    {
        public static void Main()
        {

            //First
            if (false)
            {
                string output = "";
                string invOutput = "";
                string[] input = File.ReadAllLines("input.txt");
                for (int i = 0; i < 12; i++)
                {
                    int onesFound = 0;
                    foreach (var line in input)
                    {
                        if (string.IsNullOrEmpty(line)) continue;
                        if (line[i] == '1')
                        {
                            onesFound++;
                        }
                    }
                    output += onesFound > (input.Length / 2) ? "1" : "0";
                    invOutput += onesFound < (input.Length / 2) ? "1" : "0";
                }

                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine(Convert.ToInt32(invOutput, 2) * Convert.ToInt32(output, 2));
            }
            else
            {
                List<string> workingData = new(File.ReadAllLines("input.txt")), invertedWorkingData = new (workingData);
                for (int i = 0; i < 12; i++)
                {
                    List<string> ones = new(), zeros = new();
                    foreach (var line in workingData)
                    {
                        if (string.IsNullOrEmpty(line)) continue;
                        if (line[i] == '1')
                        {
                            ones.Add(line);
                        }
                        else
                        {
                            zeros.Add(line);
                        }
                    }
                    workingData = zeros.Count > ones.Count ? zeros : ones;
                }
                for (int i = 0; i < 12; i++)
                {
                    List<string> ones = new(), zeros = new();
                    foreach (var line in invertedWorkingData)
                    {
                        if (string.IsNullOrEmpty(line)) continue;
                        if (line[i] == '1')
                        {
                            ones.Add(line);
                        }
                        else
                        {
                            zeros.Add(line);
                        }
                    }
                    invertedWorkingData = zeros.Count > ones.Count ? ones : zeros;
                    if(invertedWorkingData.Count == 1)
                    break;
                }
                 Console.WriteLine(workingData[0] + " " + invertedWorkingData[0]);

                Console.WriteLine(Convert.ToInt32(workingData[0],2)* Convert.ToInt32(invertedWorkingData[0],2));
            }
        }

    }
}
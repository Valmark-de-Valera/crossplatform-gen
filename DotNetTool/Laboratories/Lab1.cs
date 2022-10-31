using System;
using DotNetTool.Utils;

namespace DotNetTool.Laboratories
{
    public class Lab1 : ILab
    {
        ulong[,] mem = new ulong[64, 64];

        private readonly FileRepository FileRepository;

        public Lab1(FileRepository fileRep)
        {   
            this.FileRepository = fileRep;
        }

        ulong Check(int i, int j)
        {
            if (i <= 0 || j <= 0) return 1;
            return (mem[i - 1, j] > 0 ? mem[i - 1, j] : mem[i - 1, j] = Check(i - 1, j)) +
                   (mem[i, j - 1] > 0 ? mem[i, j - 1] : mem[i, j - 1] = Check(i, j - 1));
        }

        public void Main()
        {
            string[] lines =
            {
                "25:12", "20:25", "25:23"
            };
            FileRepository.CreateInputFile(lines);
            List<string> inputData = FileRepository.ReadFromInput().ToList();
            List<string> outputData = new List<string>(inputData.Count);
            foreach (var row in inputData)
            {
                int i, j;
                i = int.Parse(row.Split(":")[0] ?? throw new InvalidDataException("Wrong input row. Should be '25:12' as example"));
                j = int.Parse(row.Split(":")[1] ?? throw new InvalidDataException("Wrong input row. Should be '25:12' as example"));
                if (i < j) (i, j) = (j, i);
                string result = Check(i - 1, j).ToString();
                Console.WriteLine(result);
                outputData.Add(result);
            }
            FileRepository.WriteToOutput(outputData.ToArray());
        }
    }
}


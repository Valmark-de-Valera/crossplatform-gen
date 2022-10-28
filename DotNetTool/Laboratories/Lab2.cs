using System;
using DotNetTool.Utils;

namespace DotNetTool.Laboratories
{
    public class Lab2 : ILab
    {

        private readonly FileRepository FileRepository;

        public Lab2(FileRepository fileRep)
        {
            this.FileRepository = fileRep;
        }

        public void Main()
        {
            FileRepository.CreateInputFile();
            List<string> inputData = FileRepository.ReadFromInput().ToList();
            string inputStr = string.Join(" ", inputData);
            List<string> inputArr = inputStr.Split(" ").ToList();
            string tempVar = inputArr[0];
            var h = int.Parse(tempVar);
            string tempVar2 = inputArr[1];
            var w = int.Parse(tempVar2);
            string tempVar3 = inputArr[2];
            var n = int.Parse(tempVar3);

            inputArr = inputArr.Skip(3).ToList();
            var inputIndex = 0;
            List<List<int>> lst = new List<List<int>>(Enumerable.Range(1, h + 1).Select(_ => new List<int>(Enumerable.Range(1, w + 1).Select(_ => 0))));
            for (int i = 1; i <= h; i++)
            {
                for (int j = 1; j <= w; j++)
                {
                    string tempVar4 = inputArr[inputIndex++];
                    lst[i][j] = int.Parse(tempVar4);
                    lst[i][j] += lst[i][j - 1] + lst[i - 1][j] - lst[i - 1][j - 1];
                }
            }

            inputArr = inputArr.Skip(inputIndex).ToList();
            inputIndex = 0;
            for (int i = 0; i < n; i++)
            {
                var x1 = int.Parse(inputArr[inputIndex++]);
                var y1 = int.Parse(inputArr[inputIndex++]);
                var x2 = int.Parse(inputArr[inputIndex++]);
                var y2 = int.Parse(inputArr[inputIndex++]);
                var result = $"{lst[x2][y2] - lst[x2][y1 - 1] - lst[x1 - 1][y2] + lst[x1 - 1][y1 - 1]:D}\n";
                Console.Write(result);
                FileRepository.WriteToOutput(new[] { result });
            }
        }
    }
}


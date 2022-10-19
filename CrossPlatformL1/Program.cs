using System.Text;

namespace CrossPlatformL1;

class FileRepository
{
    private readonly string _inputFileName;
    private readonly string _outputFileName;
    public FileRepository(string inputFileName = "dataIn.txt", string outputFileName = "dataOut.txt")
    {
        _outputFileName = outputFileName;
        _inputFileName = inputFileName;
    }

    public void CreateInputFile()
    {
        if (File.Exists(this._inputFileName))
        {
            File.Delete(this._inputFileName);
        }
        string[] lines =
        {
            "25:12", "20:25", "25:23"
        };
        File.WriteAllLines(this._inputFileName, lines); ;
    }

    public string[] ReadFromInput()
    {
        return File.ReadAllLines(this._inputFileName, Encoding.UTF8);
    }
    public string[] ReadFromOutput()
    {
        return File.ReadAllLines(this._outputFileName, Encoding.UTF8);
    }
    public void WriteToOutput(string[] data)
    {
        File.WriteAllLines(this._outputFileName, data);
    }
}

static class Program
{
    static ulong[,] mem = new ulong[64, 64];
    
    private static readonly FileRepository FileRepository = new FileRepository();
    static ulong Check(int i, int j)
    {
        if (i <= 0 || j <= 0) return 1;
        return (mem[i - 1, j] > 0 ? mem[i - 1, j] : mem[i - 1, j] = Check(i - 1, j)) +
               (mem[i, j - 1] > 0 ? mem[i, j - 1] : mem[i, j - 1] = Check(i, j - 1));
    }
    
    static void Main()
    {
        FileRepository.CreateInputFile();
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
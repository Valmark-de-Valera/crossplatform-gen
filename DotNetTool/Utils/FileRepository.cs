using System;
using System.Text;

namespace DotNetTool.Utils
{
    public class FileRepository
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
}


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

        public void CreateInputFile(string[] inputLines)
        {
            if (File.Exists(this._inputFileName))
            {
                File.Delete(this._inputFileName);
            }
           
            File.WriteAllLines(this._inputFileName, inputLines); ;
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


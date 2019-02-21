using System;
using System.IO;
using Newtonsoft.Json;

namespace HelloWorldTest.ConsoleWrite
{
    public class ConsoleWriter : IConsoleWriter
    {
        bool _writeToConsole;
        IWriteHelper ConsoleWriteHelper;
        public ConsoleWriter(IWriteHelper consoleWriteHelper = null)
        {
            ConsoleWriteHelper = consoleWriteHelper ?? new ConsoleWriteHelper();
            var displayInformation = ReadInConfigFile();
            if (!displayInformation.IsConsole)
            {
                throw new NotImplementedException();
            }

            _writeToConsole = true;
        }

        private DisplayInformation ReadInConfigFile()
        {
            try
            {
                const string filePath = "/configfile.json";
                if (File.Exists(filePath))
                {
                    var file = File.Open(filePath, FileMode.Open);
                    var streamReader = new StreamReader(file);
                    var contents = streamReader.ReadLine();
                    var displayInformation = JsonConvert.DeserializeObject<DisplayInformation>(contents);
                    return displayInformation;
                }
            }
            catch
            {
                //I know this isn't a good coding practice, but I'm doing it here because making it more complicate for this example doesn't make sense.
            }
            return new DisplayInformation();
        }

        public void WriteStatement(string statementToWrite)
        {
            if (_writeToConsole)
            {
                WriteStatementToConsole(statementToWrite);
            }
            else
            {
                WriteStatementToScreen(statementToWrite);
            }
        }

        private void WriteStatementToConsole(string statementToWrite)
        {
            ConsoleWriteHelper.Write(statementToWrite);
        }
        private void WriteStatementToScreen(string statementToWrite)
        {
            throw new NotImplementedException();
        }

    }
}
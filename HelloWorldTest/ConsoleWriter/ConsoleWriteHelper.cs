using System;
namespace HelloWorldTest.ConsoleWrite
{
    public class ConsoleWriteHelper : IWriteHelper
    {
        public void Write(string statement) => Console.WriteLine(statement);
    }
}

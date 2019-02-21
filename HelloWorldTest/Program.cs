using System;
using HelloWorldTest.ConsoleWrite;
using Moq;
using NUnit.Framework;

namespace HelloWorldTest
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            IConsoleWriter consoleWriter = new ConsoleWriter();
            const string statementToWrite = "Hello World!";
            consoleWriter.WriteStatement(statementToWrite);

        }
    }
}

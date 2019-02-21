using System;
using NUnit.Framework;
using Moq;
using HelloWorldTest.ConsoleWrite;

namespace HelloWorldTest.Tests
{
    public class ConsoleWriterTests
    {
        public ConsoleWriterTests()
        {
        }

        [Test]
        public void When_StatementIsPassed_Should_WriteToConsole()
        {
            //Given
            const string WriteThis = "write_this";
            var success = false;
            var consoleWriteHelper = new Mock<IWriteHelper>();
            consoleWriteHelper.Setup(x => x.Write(WriteThis)).Callback((() => { success = true; }));
            var consoleWriter = new ConsoleWriter(consoleWriteHelper.Object);
            //When
            consoleWriter.WriteStatement(WriteThis);
            //Then
            Assert.IsTrue(success);
        }
    }
}

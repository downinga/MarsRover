using Moq;
using MarsRover.Utilities;

namespace MarsRover.Tests
{

    public class InputFileParserTests
    {
        [Fact]
        public void ParsesValidStream()
        {
            Mock<TextReader> mockStreamReader = new Mock<TextReader>(MockBehavior.Strict);
            mockStreamReader.Setup(mock => mock.Close());
            mockStreamReader.SetupSequence(mock => mock.ReadLine())
                .Returns("50 20")
                .Returns("")
                .Returns("2 3 N")
                .Returns("LRF")
                .Returns("")
                .Returns("2 23 N")
                .Returns("LRRRRF")
                .Returns((string?)null);            

            InputFileParser inputFileParser = new InputFileParser(mockStreamReader.Object);

            var (map, instructions) = inputFileParser.parse();

            Assert.Equal(50, map.maxX);
            Assert.Equal(20, map.maxY);

            Assert.Equal(2, instructions.Count());
            
            var (robotLocation1, robotInstruction1) = instructions.First();
            Assert.Equal("2 3 N", robotLocation1.ToString());
            Assert.Equal("LRF", String.Join("",robotInstruction1));

            var (robotLocation2, robotInstruction2) = instructions.Skip(1).First();
            Assert.Equal("2 23 N", robotLocation2.ToString());
            Assert.Equal("LRRRRF", String.Join("",robotInstruction2));
        }

        [Fact]
        public void ThrowErrorIfNoRobotsInInputFile()
        {
            Mock<TextReader> mockStreamReader = new Mock<TextReader>(MockBehavior.Strict);
            mockStreamReader.Setup(mock => mock.Close());
            mockStreamReader.SetupSequence(mock => mock.ReadLine())
                .Returns("50 20")
                .Returns("")
                .Returns((string?)null);            

            InputFileParser inputFileParser = new InputFileParser(mockStreamReader.Object);

            Action act = () => inputFileParser.parse();

            ArgumentException exception = Assert.Throws<ArgumentException>(act);

            Assert.Equal("No robots in input file.", exception.Message);
        }

        [Fact]
        public void ThrowErrorIfRobotInstructionMissing()
        {
            Mock<TextReader> mockStreamReader = new Mock<TextReader>(MockBehavior.Strict);
            mockStreamReader.Setup(mock => mock.Close());
            mockStreamReader.SetupSequence(mock => mock.ReadLine())
                .Returns("50 20")
                .Returns("")
                .Returns("2 3 N")
                .Returns((string?)null);            

            InputFileParser inputFileParser = new InputFileParser(mockStreamReader.Object);

            Action act = () => inputFileParser.parse();

            ArgumentException exception = Assert.Throws<ArgumentException>(act);

            Assert.Equal("No robot instructions provided.", exception.Message);
        }

        [Fact]
        public void ThrowErrorIfMapSizeIsMissing()
        {
            Mock<TextReader> mockStreamReader = new Mock<TextReader>(MockBehavior.Strict);
            mockStreamReader.Setup(mock => mock.Close());
            mockStreamReader.SetupSequence(mock => mock.ReadLine())
                .Returns((string?)null);            

            InputFileParser inputFileParser = new InputFileParser(mockStreamReader.Object);

            Action act = () => inputFileParser.parse();

            ArgumentException exception = Assert.Throws<ArgumentException>(act);

            Assert.Equal("No map coordinates provided.", exception.Message);
        }

        [Fact]
        public void ThrowErrorIfUnrecognisedDirection()
        {
            Mock<TextReader> mockStreamReader = new Mock<TextReader>(MockBehavior.Strict);
            mockStreamReader.Setup(mock => mock.Close());
            mockStreamReader.SetupSequence(mock => mock.ReadLine())
                .Returns("50 20")
                .Returns("")
                .Returns("2 3 Z")
                .Returns("LRF")
                .Returns((string?)null);            

            InputFileParser inputFileParser = new InputFileParser(mockStreamReader.Object);

            Action act = () => inputFileParser.parse();

            ArgumentException exception = Assert.Throws<ArgumentException>(act);

            Assert.Equal("Unable to parse robot location.", exception.Message);
        }

        [Fact]
        public void ThrowErrorIfUnrecognisedInstruction()
        {
            Mock<TextReader> mockStreamReader = new Mock<TextReader>(MockBehavior.Strict);
            mockStreamReader.Setup(mock => mock.Close());
            mockStreamReader.SetupSequence(mock => mock.ReadLine())
                .Returns("50 20")
                .Returns("")
                .Returns("2 3 E")
                .Returns("LRSF")
                .Returns((string?)null);            

            InputFileParser inputFileParser = new InputFileParser(mockStreamReader.Object);

            Action act = () => inputFileParser.parse();

            ArgumentException exception = Assert.Throws<ArgumentException>(act);

            Assert.Equal("Unable to parse robot instructions.", exception.Message);
        }
    }
}


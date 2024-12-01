using MarsRover.Utilities;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                throw new ArgumentOutOfRangeException("Incorrect number of arguments provided, please provide location of input file as argument only.");
            }

            StreamReader fileReader = new StreamReader(args[0]);
            InputFileParser validator = new InputFileParser(fileReader);

            var (map, instructions) = validator.parse();
        }
    }
}
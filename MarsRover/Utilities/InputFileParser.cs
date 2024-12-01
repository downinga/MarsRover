using MarsRover.Entities;

namespace MarsRover.Utilities
{
    public class InputFileParser
    {
        private readonly TextReader _streamReader;
        public InputFileParser(TextReader streamReader) 
        {
            this._streamReader = streamReader;
        }
        public (MarsMap, IDictionary<RobotLocation,IList<RobotInstruction>>) parse()
        {
            String? mapCoords = _streamReader.ReadLine();
            MarsMap map = this._parseMapCoords(mapCoords);

            IDictionary<RobotLocation, IList<RobotInstruction>> instructionSet = new Dictionary<RobotLocation, IList<RobotInstruction>>();
            String? line = _streamReader.ReadLine();

            while (line != null) {
                if (String.IsNullOrEmpty(line)) 
                {
                    line = _streamReader.ReadLine();
                    continue;
                }

                RobotLocation robotLocation = this._parseRobotLocation(line);
                String? rawRobotInstructions = _streamReader.ReadLine();
                IList<RobotInstruction> robotInstructions = this._parseRobotInstructions(rawRobotInstructions);
                instructionSet.Add(robotLocation,robotInstructions);

                line = _streamReader.ReadLine();
            }

            _streamReader.Close();

            if (instructionSet.Count() == 0) {
                throw new ArgumentException("No robots in input file.");
            }

            return (map, instructionSet);
        }
        private MarsMap _parseMapCoords(string? input) {
            if (String.IsNullOrEmpty(input)) 
            {
                throw new ArgumentException("No map coordinates provided.");
            }

            try 
            {
                string[] mapCoords = input.Split(' ');
                int mapX = Int32.Parse(mapCoords[0]);
                int mapY = Int32.Parse(mapCoords[1]);
                return new MarsMap(mapX, mapY);
            }
            catch {
                throw new ArgumentException("Map coords not in correct format, please check input.");
            }
        }

        private RobotLocation _parseRobotLocation(string? input) 
        {
            if (String.IsNullOrEmpty(input)) 
            {
                throw new ArgumentException("No robot location provided.");
            }

            try 
            {
                string[] rawRobotPosition = input.Split(" ");
                int robotX = Int32.Parse(rawRobotPosition[0]);
                int robotY = Int32.Parse(rawRobotPosition[1]);
                RobotDirection robotDirection = Enum.Parse<RobotDirection>(rawRobotPosition[2]);

                return new RobotLocation(robotX, robotY, robotDirection);
            }
            catch
            {
                throw new ArgumentException("Unable to parse robot location.");
            }
        }

        private IList<RobotInstruction> _parseRobotInstructions(string? input)
        {
            if (String.IsNullOrEmpty(input)) 
            {
                throw new ArgumentException("No robot instructions provided.");
            }

            try 
            {
                return input.Select(character => Enum.Parse<RobotInstruction>(character.ToString())).ToList();
            }
            catch
            {
                throw new ArgumentException("Unable to parse robot instructions.");
            }
        }
    }

}

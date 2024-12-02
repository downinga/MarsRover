
# Mars Rover 

## Description
The following repo contains a .NET 9 project for determining the position of robots on a fictitious 2 dimensional Mars.

## Approach

I approached the problem by first working out how to parse the file into appropriate objects which could be mutated/acted upon. This lead to 3 main entities being derived:
- `MarsMap`
- `RobotLocation`
- `List<RobotInstruction>`

I then decided to work out how to create an extensible "instruction set" using the enum `RobotInstruction`. I decided upon creating a dictionary of instructions which mapped to a strategy of how to translate a `RobotLocation` object using a common `IInstructionStrategy` interface. This meant I could easily extend/change the "instruction set" at a later date.

The `ControlStation` class would then use this "instruction set" to move a robot with a set of instructions and return the final position of the robot which could later be streamed to a file.

## Repository structure
The `MarsRover` project has the following structure and contents
- `Program.cs` - entrypoint into the program which initialises resources and orchestrates underlying classes.
- `ControlStation.cs` - orchestrates moving of robots and determining their final position
- `Instructions/` - contains the classes used for moving the robot's location which implement a common interface.
- `Entities/` - contains the classes and enums which live within the domain of the `MarsRover` project.
- `Utilities/` - contains the input file parser.

## Unit testing
This repository uses XUnit and Moq packagesfor unit testing. The unit tests live within the `MarsRover.Tests` project

To run the project tests run the following command from the root directory.
```code
dotnet test MarsRover.Tests/
```

## Running the program
To run the project on your local machine run the following command from root directory:

```code
dotnet run --project MarsRover/MarsRover.csproj -- {PATH_TO_INPUT_FILE}
```

`{PATH_TO_INPUT_FILE}` is to be `.txt` file with the following format:
- First line contains space separated maximum coordinates for the surface of Mars (e.g.`20 20`) followed by a line of white space
- The remaining input consists of a sequence of robot positions and instructions (two lines per robot). 
  - A position consists of two integers specifying the initial coordinates of the robot and an orientation (`N`, `S`, `E`, `W`), all separated by whitespace on one line. 
  - A robot instruction is a string of the letters `L`, `R`, and `F` on one line. 
  - Each set of robot positions and instructions are separated by a blank line.

```code
20 20

4 2 N
RFRFRF

2 4 E
LFLFLF
```

The output of the above command will be found in the root directory under `output.txt`, the contents of this file will include the final positions of the robot inputs and an indication as to whether the robot got lost (e.g. `4 1 W LOST`).
```code
4 1 W
1 4 S
```
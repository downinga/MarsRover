
# Mars Rover 

The following repo contains a .NET 9 project for determining the position of robots on a fictitious 2 dimensional Mars.

### Running the program
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

2 4 L
LFLFLF
```

The output of the above command will be found in the root directory under `output.txt`, the contents of this file will include the final positions of the robot inputs and an indication as to whether the robot got lost.
```code
1 1 E
3 3 N LOST
2 3 S
```

### Unit testing
This project uses XUnit and Moq packagesfor unit testing.

To run the project tests run the following command from the root directory.
```code
dotnet test MarsRover.Tests/
```
using Project.ConsoleApp.Classes;

var instanceOne = VoteMachine.Instance;
Console.WriteLine(instanceOne);

var instanceTwo = VoteMachine.Instance;
Console.WriteLine(instanceTwo);

Console.ReadKey();
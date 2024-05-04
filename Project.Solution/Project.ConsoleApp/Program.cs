using Project.ConsoleApp.Classes;

IEnumerable<int> numbers = Enumerable.Range(0, 10);

Parallel.ForEach(numbers, i =>
{
    VoteMachine instance = VoteMachine.Instance;
    instance.RegisterVote();
});

Console.WriteLine(VoteMachine.Instance.TotalVotes);


Console.ReadKey();
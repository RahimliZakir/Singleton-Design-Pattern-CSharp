using Project.ConsoleApp.Classes;

// 1) Singleton with thread 'lock'.
IEnumerable<int> range = Enumerable.Range(1, 10);

Parallel.ForEach(range, i =>
{
    VoteMachine vm = VoteMachine.Instance;
    vm.RegisterVote();
});

Console.WriteLine($"Total Votes: {VoteMachine.Instance.TotalVotes}");

// 2) Singleton with Static Constructor & Lazy Loading.
// Static Constructor Message will shown only one time.
VoteMachine instanceOne = VoteMachine.Instance;
Console.WriteLine(instanceOne);

VoteMachine instanceTwo = VoteMachine.Instance;
Console.WriteLine(instanceTwo);

Console.ReadKey();
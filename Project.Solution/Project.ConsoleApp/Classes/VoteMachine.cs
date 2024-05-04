using System.Runtime.ConstrainedExecution;

namespace Project.ConsoleApp.Classes;

// 1) Without Static Constructor (Thread-safe)
//public class VoteMachine
//{
//    private VoteMachine() { }

//    private static VoteMachine _instance = null;

//    private int _totalVotes = 0;

//    private static readonly object lockObj = new object();

//    public static VoteMachine Instance
//    {
//        get
//        {
//            if (_instance == null)
//            {
//                lock (lockObj)
//                {
//                    if (_instance == null)
//                    {
//                        _instance = new VoteMachine();
//                    }
//                }
//            }

//            return _instance;
//        }
//    }

//    public void RegisterVote()
//    {
//        _totalVotes += 1;
//        Console.WriteLine("Registered Vote #" + _totalVotes);
//    }

//    public int TotalVotes
//    {
//        get
//        {
//            return _totalVotes;
//        }
//    }
//}

// 2) With Static Constructor. (Thread-safe)
// You can create a singleton class by using the static constructor.
// The static constructor runs only once per app domain when any static member of a class is accessed.
public class VoteMachine
{
    static VoteMachine() { }

    private VoteMachine() { }

    // !!! The class creates an instance as soon as we access any static property or method.
    // !!! If there are multiple static properties or methods for some reason then an instance will be created immediately even if we don't intend to use it.
    // !!! We need lazy instantiation that will create instances only when necessary.
    //private static readonly VoteMachine _instance = new VoteMachine();
    // We will use Lazy<T> to create an instance only when needed.
    private static readonly Lazy<VoteMachine> _instance = new Lazy<VoteMachine>(() => new VoteMachine());
    private int _totalVotes = 0;

    public static VoteMachine Instance
    {
        get
        {
            return _instance.Value;
        }
    }

    public void RegisterVote()
    {
        _totalVotes += 1;
        Console.WriteLine("Registered Vote #" + _totalVotes);
    }

    public int TotalVotes
    {
        get
        {
            return _totalVotes;
        }
    }
}
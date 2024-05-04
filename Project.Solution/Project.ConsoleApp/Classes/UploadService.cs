namespace Project.ConsoleApp.Classes;
// 1st Way: Create 'private' field, then return this with method.
class UploadService
{
    // We set the constructor 'private',for not creating instances of this class.
    private UploadService() { }

    private static UploadService _instance;

    // Thread-safe Locking. (Not-Parallel)
    private static readonly object _lock = new object();

    public static UploadService Instance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new UploadService();
                }
            }
        }

        return _instance;
    }
}

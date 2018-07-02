using System.Security.Principal;

namespace TestableDokan.MockableDokan
{
    public interface IDokanFileInfoWrapper
    {
        object Context { get; set; }
        int ProcessId { get; }
        bool IsDirectory { get; set; }
        bool DeleteOnClose { get; set; }
        bool PagingIo { get; }
        bool SynchronousIo { get; }
        bool NoCache { get; }
        bool WriteToEndOfFile { get; }
        WindowsIdentity GetRequestor();
        bool TryResetTimeout(int milliseconds);
    }
}

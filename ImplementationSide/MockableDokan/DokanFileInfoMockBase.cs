using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using DokanNet;

namespace TestableDokan.MockableDokan
{
    /// <summary>
    /// The base class that PassthruDokanBase (and the test class MockableDFI) derive from.
    /// </summary>
    /// <remarks>Mirrors the public interface of DokanNet.DokanFileInfo.</remarks>
    public abstract class DokanFileInfoMockBase : IDokanFileInfoWrapper
    {
        public abstract object Context { get; set; }
        public abstract int ProcessId { get; }
        public abstract bool IsDirectory { get; set; }
        public abstract bool DeleteOnClose { get; set; }
        public abstract bool PagingIo { get; }
        public abstract bool SynchronousIo { get; }
        public abstract bool NoCache { get; }
        public abstract bool WriteToEndOfFile { get; }

        public abstract WindowsIdentity GetRequestor();
        public abstract bool TryResetTimeout(int milliseconds);

        public static implicit operator DokanFileInfoMockBase(DokanFileInfo value)
            => new PassthruDFI(value);
        
    }
}

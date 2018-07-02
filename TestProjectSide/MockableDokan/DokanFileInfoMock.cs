using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace TestableDokan.TestProjectSide.MockableDokan
{
    /// <summary>
    /// An implementation of <see cref="TestableDokan.MockableDokan.IDokanFileInfoWrapper"/> with
    /// parameters which can be set for ease of mocking.
    /// </summary>
    public class DokanFileInfoMock : TestableDokan.MockableDokan.DokanFileInfoMockBase
    {
        public override object Context
        {
            get; set;
        }

        public override int ProcessId => System.Diagnostics.Process.GetCurrentProcess().Id;

        public override bool IsDirectory
        {
            get; set;
        }

        public override bool DeleteOnClose
        {
            get; set;
        }

        bool _pagingIo;
        internal void SetPagingIo(bool value) => _pagingIo = value;
        public override bool PagingIo => _pagingIo;

        bool _synchronousIo;
        internal void SetSynchronousIo(bool value) => _synchronousIo = value;
        public override bool SynchronousIo => _synchronousIo;

        bool _noCache;
        internal void SetNoCache(bool value) => _noCache = value;
        public override bool NoCache => _noCache;

        bool _writeToEndOfFile;
        internal void SetWriteToEndOfFile(bool value) => _writeToEndOfFile = value;

        public override bool WriteToEndOfFile => _writeToEndOfFile;

        public WindowsIdentity Id
        {
            get; private set;
        }
        public override WindowsIdentity GetRequestor() => Id;

        internal void SetRequestor(WindowsIdentity Id)
            => this.Id = Id;

        internal bool ResetTimeoutReturn
        {
            get; set;
        }

        public override bool TryResetTimeout(int milliseconds) => ResetTimeoutReturn;
    }
}

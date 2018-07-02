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
    /// An IDokanFileInterface that passes all actions to its underlying DokanFileInfo.
    /// </summary>
    class PassthruDFI : DokanFileInfoMockBase
    {

        /// <summary>
        /// Cannot construct PassthruDFI with no DokanFileInfo.
        /// </summary>
        private PassthruDFI() { }

        /// <summary>
        /// Construct a PassthruDFI with a DokanFileInfo to pass all actions to.
        /// </summary>
        /// <param name="DFI">The DokanFileInfo to wrap as an IDokanFileInterface.</param>
        public PassthruDFI(DokanFileInfo DFI)
        {
            this.DFI = DFI;
        }

        public DokanFileInfo DFI
        {
            get;
            private set;
        }

        /// <summary>
        /// The user-set context object (may be anything).
        /// </summary>
        public override object Context
        {
            get => DFI?.Context??null;
            set
            {
                if (null != DFI)
                {
                    DFI.Context = value;
                }
            }
        }

        /// <summary>
        /// The process ID that requested this filesystem action.
        /// </summary>
        public override int ProcessId => DFI?.ProcessId??-1;

        /// <summary>
        /// Indicates that this is acting on a directory.
        /// </summary>
        public override bool IsDirectory
        {
            get => DFI?.IsDirectory ?? false;
            set
            {
                if (null != DFI)
                {
                    DFI.IsDirectory = value;
                }
            }
        }

        /// <summary>
        /// Indicates that the file should be deleted when all handles open to it are closed.
        /// </summary>
        public override bool DeleteOnClose
        {
            get => DFI?.DeleteOnClose ?? false;
            set
            {
                if (null != DFI) {
                    DFI.DeleteOnClose = value;
                }
            }
        }

        /// <summary>
        /// Indicates that the file has been memory-mapped.
        /// </summary>
        public override bool PagingIo => DFI?.PagingIo??false;

        /// <summary>
        /// All I/O to this file causes the requesting process to wait until the action is complete.
        /// </summary>
        public override bool SynchronousIo => DFI?.SynchronousIo??false;

        /// <summary>
        /// The calling process has requested that the filesystem ignore all cache, and always access
        /// the file data directly.
        /// </summary>
        public override bool NoCache => DFI?.NoCache??false;

        /// <summary>
        /// The file was opened with an append-only mode.
        /// </summary>
        public override bool WriteToEndOfFile => DFI?.WriteToEndOfFile??false;

        /// <summary>
        /// Obtain a WindowsIdentity from the calling process's security token.
        /// </summary>
        /// <returns>The WindowsIdentity constructed from the calling process's identity.</returns>
        public override WindowsIdentity GetRequestor()
        {
            return DFI?.GetRequestor()??null;
        }

        /// <summary>
        /// Attempt to reset Dokan's timeout to show that we're still working on the request.
        /// </summary>
        /// <param name="milliseconds">The number of milliseconds to add to the time-out timer.</param>
        /// <returns>true if the reset was successful.</returns>
        public override bool TryResetTimeout(int milliseconds)
        {
            return DFI?.TryResetTimeout(milliseconds)??false;
        }
    }
}

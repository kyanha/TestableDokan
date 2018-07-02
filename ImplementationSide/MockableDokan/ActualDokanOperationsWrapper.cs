using System;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using DokanNet;

namespace TestableDokan.MockableDokan
{
    /// <summary>
    /// The actual DokanNet.IDokanOperations that gets passed to DokanMain (probably through .Mount()).
    /// </summary>
    /// <remarks>
    /// The only thing this class does is adapt an <see cref="IMockableDokanOperations"/> to Dokan's
    /// <see cref="IDokanOperations"/> interface.  Everything is kept as a very thin, transparent wrapper.
    /// This class is constructed with an implementation that follows the interface defined in
    /// <see cref="IMockableDokanOperations"/>, which itself mirrors <see cref="IDokanOperations"/>
    /// in all respects except for the type of the context object passed to it (no longer a
    /// <see cref="DokanFileInfo"/>, but now an <see cref="IDokanFileInfoWrapper"/>).
    /// </remarks>
    class ActualDokanOperationsWrapper : IDokanOperations
    {
        readonly private IMockableDokanOperations implementation = null;

        /// <summary>
        /// Construction requires an IMockableDokanWrapper constructor.
        /// </summary>
        private ActualDokanOperationsWrapper() { }

        /// <summary>
        /// Constructs an instance, using the IMockableDokanWrapper passed as the implementation.
        /// </summary>
        /// <param name="implementation">The IMockableDokanWrapper that provides the implementation for DokanNet's functions.</param>
        public ActualDokanOperationsWrapper(IMockableDokanOperations implementation)
        {
            this.implementation = implementation;
        }

        public void Cleanup(string fileName, DokanFileInfo info)
        {
            implementation.Cleanup(fileName, new PassthruDFI(info));
        }

        public void CloseFile(string fileName, DokanFileInfo info)
        {
            implementation.CloseFile(fileName, new PassthruDFI(info));
        }

        public NtStatus CreateFile(string fileName, DokanNet.FileAccess access, FileShare share, FileMode mode, FileOptions options, FileAttributes attributes, DokanFileInfo info)
        {
            return implementation.CreateFile(fileName, access, share, mode, options, attributes, new PassthruDFI(info));
        }

        public NtStatus DeleteDirectory(string fileName, DokanFileInfo info)
        {
            return implementation.DeleteDirectory(fileName, new PassthruDFI(info));
        }

        public NtStatus DeleteFile(string fileName, DokanFileInfo info)
        {
            return implementation.DeleteFile(fileName, new PassthruDFI(info));
        }

        public NtStatus FindFiles(string fileName, out IList<DokanNet.FileInformation> files, DokanFileInfo info)
        {
            return implementation.FindFiles(fileName, out files, new PassthruDFI(info));
        }

        public NtStatus FindFilesWithPattern(string fileName, string searchPattern, out IList<DokanNet.FileInformation> files, DokanFileInfo info)
        {
            return implementation.FindFilesWithPattern(fileName, searchPattern, out files, new PassthruDFI(info));
        }

        public NtStatus FindStreams(string fileName, out IList<DokanNet.FileInformation> streams, DokanFileInfo info)
        {
            return implementation.FindStreams(fileName, out streams, new PassthruDFI(info));
        }

        public NtStatus FlushFileBuffers(string fileName, DokanFileInfo info)
        {
            return implementation.FlushFileBuffers(fileName, new PassthruDFI(info));
        }

        public NtStatus GetDiskFreeSpace(out long freeBytesAvailable, out long totalNumberOfBytes, out long totalNumberOfFreeBytes, DokanFileInfo info)
        {
            return implementation.GetDiskFreeSpace(out freeBytesAvailable, out totalNumberOfBytes, out totalNumberOfFreeBytes, new PassthruDFI(info));
        }

        public NtStatus GetFileInformation(string fileName, out DokanNet.FileInformation fileInfo, DokanFileInfo info)
        {
            return implementation.GetFileInformation(fileName, out fileInfo, new PassthruDFI(info));
        }

        public NtStatus GetFileSecurity(string fileName, out FileSystemSecurity security, AccessControlSections sections, DokanFileInfo info)
        {
            return implementation.GetFileSecurity(fileName, out security, sections, new PassthruDFI(info));
        }

        public NtStatus GetVolumeInformation(out string volumeLabel, out FileSystemFeatures features, out string fileSystemName, DokanFileInfo info)
        {
            return implementation.GetVolumeInformation(out volumeLabel, out features, out fileSystemName, new PassthruDFI(info));
        }

        public NtStatus LockFile(string fileName, long offset, long length, DokanFileInfo info)
        {
            return implementation.LockFile(fileName, offset, length, new PassthruDFI(info));
        }

        public NtStatus Mounted(DokanFileInfo info)
        {
            return implementation.Mounted(new PassthruDFI(info));
        }

        public NtStatus MoveFile(string oldName, string newName, bool replace, DokanFileInfo info)
        {
            return implementation.MoveFile(oldName, newName, replace, new PassthruDFI(info));
        }

        public NtStatus ReadFile(string fileName, byte[] buffer, out int bytesRead, long offset, DokanFileInfo info)
        {
            return implementation.ReadFile(fileName, buffer, out bytesRead, offset, new PassthruDFI(info));
        }

        public NtStatus SetAllocationSize(string fileName, long length, DokanFileInfo info)
        {
            return implementation.SetAllocationSize(fileName, length, new PassthruDFI(info));
        }

        public NtStatus SetEndOfFile(string fileName, long length, DokanFileInfo info)
        {
            return implementation.SetEndOfFile(fileName, length, new PassthruDFI(info));
        }

        public NtStatus SetFileAttributes(string fileName, FileAttributes attributes, DokanFileInfo info)
        {
            return implementation.SetFileAttributes(fileName, attributes, new PassthruDFI(info));
        }

        public NtStatus SetFileSecurity(string fileName, FileSystemSecurity security, AccessControlSections sections, DokanFileInfo info)
        {
            return implementation.SetFileSecurity(fileName, security, sections, new PassthruDFI(info));
        }

        public NtStatus SetFileTime(string fileName, DateTime? creationTime, DateTime? lastAccessTime, DateTime? lastWriteTime, DokanFileInfo info)
        {
            return implementation.SetFileTime(fileName, creationTime, lastAccessTime, lastWriteTime, new PassthruDFI(info));
        }

        public NtStatus UnlockFile(string fileName, long offset, long length, DokanFileInfo info)
        {
            return implementation.UnlockFile(fileName, offset, length, new PassthruDFI(info));
        }

        public NtStatus Unmounted(DokanFileInfo info)
        {
            return implementation.Unmounted(new PassthruDFI(info));
        }

        public NtStatus WriteFile(string fileName, byte[] buffer, out int bytesWritten, long offset, DokanFileInfo info)
        {
            return implementation.WriteFile(fileName, buffer, out bytesWritten, offset, new PassthruDFI(info));
        }
    }
}

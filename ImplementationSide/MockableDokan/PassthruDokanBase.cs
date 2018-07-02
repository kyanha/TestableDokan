using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using DokanNet;
using TestableDokan.MockableDokan;

namespace TestableDokan.MockableDokan
{
    abstract class PassthruDokanBase : IMockableDokanOperations
    {
        virtual public void Cleanup(string fileName, IDokanFileInfoWrapper info)
        {
            throw new NotImplementedException();
        }

        virtual public void CloseFile(string fileName, IDokanFileInfoWrapper info)
        {
            throw new NotImplementedException();
        }

        virtual public NtStatus CreateFile(string fileName, DokanNet.FileAccess access, FileShare share, FileMode mode, FileOptions options, FileAttributes attributes, IDokanFileInfoWrapper info)
        {
            throw new NotImplementedException();
        }

        virtual public NtStatus DeleteDirectory(string fileName, IDokanFileInfoWrapper info)
        {
            throw new NotImplementedException();
        }

        virtual public NtStatus DeleteFile(string fileName, IDokanFileInfoWrapper info)
        {
            throw new NotImplementedException();
        }

        virtual public NtStatus FindFiles(string fileName, out IList<DokanNet.FileInformation> files, IDokanFileInfoWrapper info)
        {
            throw new NotImplementedException();
        }

        virtual public NtStatus FindFilesWithPattern(string fileName, string searchPattern, out IList<DokanNet.FileInformation> files, IDokanFileInfoWrapper info)
        {
            throw new NotImplementedException();
        }

        virtual public NtStatus FindStreams(string fileName, out IList<DokanNet.FileInformation> streams, IDokanFileInfoWrapper info)
        {
            throw new NotImplementedException();
        }

        virtual public NtStatus FlushFileBuffers(string fileName, IDokanFileInfoWrapper info)
        {
            throw new NotImplementedException();
        }

        virtual public NtStatus GetDiskFreeSpace(out long freeBytesAvailable, out long totalNumberOfBytes, out long totalNumberOfFreeBytes, IDokanFileInfoWrapper info)
        {
            throw new NotImplementedException();
        }

        virtual public NtStatus GetFileInformation(string fileName, out DokanNet.FileInformation fileInfo, IDokanFileInfoWrapper info)
        {
            throw new NotImplementedException();
        }

        virtual public NtStatus GetFileSecurity(string fileName, out FileSystemSecurity security, AccessControlSections sections, IDokanFileInfoWrapper info)
        {
            throw new NotImplementedException();
        }

        virtual public NtStatus GetVolumeInformation(out string volumeLabel, out FileSystemFeatures features, out string fileSystemName, IDokanFileInfoWrapper info)
        {
            throw new NotImplementedException();
        }

        virtual public NtStatus LockFile(string fileName, long offset, long length, IDokanFileInfoWrapper info)
        {
            throw new NotImplementedException();
        }

        virtual public NtStatus Mounted(IDokanFileInfoWrapper info)
        {
            throw new NotImplementedException();
        }

        virtual public NtStatus MoveFile(string oldName, string newName, bool replace, IDokanFileInfoWrapper info)
        {
            throw new NotImplementedException();
        }

        virtual public NtStatus ReadFile(string fileName, byte[] buffer, out int bytesRead, long offset, IDokanFileInfoWrapper info)
        {
            throw new NotImplementedException();
        }

        virtual public NtStatus SetAllocationSize(string fileName, long length, IDokanFileInfoWrapper info)
        {
            throw new NotImplementedException();
        }

        virtual public NtStatus SetEndOfFile(string fileName, long length, IDokanFileInfoWrapper info)
        {
            throw new NotImplementedException();
        }

        virtual public NtStatus SetFileAttributes(string fileName, FileAttributes attributes, IDokanFileInfoWrapper info)
        {
            throw new NotImplementedException();
        }

        virtual public NtStatus SetFileSecurity(string fileName, FileSystemSecurity security, AccessControlSections sections, IDokanFileInfoWrapper info)
        {
            throw new NotImplementedException();
        }

        virtual public NtStatus SetFileTime(string fileName, DateTime? creationTime, DateTime? lastAccessTime, DateTime? lastWriteTime, IDokanFileInfoWrapper info)
        {
            throw new NotImplementedException();
        }

        virtual public NtStatus UnlockFile(string fileName, long offset, long length, IDokanFileInfoWrapper info)
        {
            throw new NotImplementedException();
        }

        virtual public NtStatus Unmounted(IDokanFileInfoWrapper info)
        {
            throw new NotImplementedException();
        }

        virtual public NtStatus WriteFile(string fileName, byte[] buffer, out int bytesWritten, long offset, IDokanFileInfoWrapper info)
        {
            throw new NotImplementedException();
        }
    }
}

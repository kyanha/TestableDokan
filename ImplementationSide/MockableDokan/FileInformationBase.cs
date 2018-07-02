using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestableDokan.MockableDokan
{
    [DebuggerDisplay("M) {FileName}, {Length}, {CreationTime}, {LastWriteTime}, {LastAccessTime}, {Attributes}")]
    abstract public class FileInformationBase : IFileInformation
    {
        #region Static members (mostly, the char[] that contains the characters not acceptable in a filename)
        static char[] badname = InitBadNames();

        static char[] InitBadNames()
        {
            char[] bad = new char[40];
            int i = 0;
            while(i < 32)
            {
                bad[i] = (char)i++;
            }
            foreach (char c in @"<>""/|?*")
            {
                bad[i++] = c;
            }
            return bad;
        }
        #endregion
        string _fileName;
        virtual public string FileName
        {
            get => _fileName;
            set
            {
                // Need to do more in here, like verify the name is a well-formed path in the mount.
                // (That's something a derived class can do, before it calls `base.FileName = value`.)
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(@"FileName cannot be empty");
                }
                if (value[0] != '\\')
                {
                    throw new ArgumentException(@"FileName must begin with \");
                }
                if (value.Length > 32768)
                {
                    throw new ArgumentException(@"Argument too long");
                }
                if (-1 != value.IndexOfAny(badname))
                {
                    throw new ArgumentException(@"Unacceptable character in FileName");
                }
                _fileName = value;
            }
        }
        virtual public FileAttributes Attributes
        {
            get; set;
        }
        DateTime _creationTime = DateTime.UtcNow;
        virtual public DateTime? CreationTime
        {
            get => _creationTime;
            set => _creationTime = value ?? _creationTime;
        }
        DateTime _lastAccessTime = DateTime.UtcNow;
        virtual public DateTime? LastAccessTime
        {
            get => _lastAccessTime;
            set => _lastAccessTime = value ?? _lastAccessTime;
        }
        DateTime _lastWriteTime = DateTime.UtcNow;
        virtual public DateTime? LastWriteTime
        {
            get => _lastWriteTime;
            set => _lastWriteTime = value ?? _lastWriteTime;
        }
        abstract public long Length
        {
            get; set;
        }
        #region Discretionary access control (ACLs)
        private string _owner;
        virtual public string Owner
        {
            get => _owner;
            set
            {
                _owner = value;
                // This is in SDDL form, which is @"O:[sid]", and must be verified/rejected.
                throw new NotImplementedException();
            }
        }
        private string _group;
        virtual public string Group
        {
            get => _group;
            set
            {
                _group = value;
                // This is in SDDL form, which is @"G:[sid]", and must be verified/rejected.
                throw new NotImplementedException();
            }
        }
        private string _dacl;
        virtual public string Dacl
        {
            get => _dacl;
            set
            {
                _dacl = value;
                // This needs to verify the form of the SDDL, or else reject it.
                // Form is @"D:sacl_flags(string_ace1)(string_ace2)...(string_aceN)"
                throw new NotImplementedException();
            }
        }
        private string _sacl;
        virtual public string Sacl
        {
            get => _sacl;
            set
            {
                _sacl = value;
                // This needs to verify the form of the SDDL, or else reject it.
                // Form is @"S:sacl_flags(string_ace1)(string_ace2)...(string_aceN)"
                throw new NotImplementedException();
            }
        }
        #endregion
        protected FileInformationBase() => Attributes = FileAttributes.Normal;
    }
}

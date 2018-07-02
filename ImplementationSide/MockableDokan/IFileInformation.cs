using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestableDokan.MockableDokan
{
    public interface IFileInformation
    {
        /// <summary>
        /// Gets or sets the name of the file or directory.
        /// </summary>
        string FileName { get; set; }

        /// <summary>
        /// Gets or sets the <c><see cref="FileAttributes"/></c> for the file or directory.
        /// </summary>
        FileAttributes Attributes { get; set; }

        /// <summary>
        /// Gets or sets the creation time of the file or directory.
        /// If equal to <c>null</c>, the value will not be set or the file has no creation time.
        /// </summary>
        DateTime? CreationTime { get; set; }

        /// <summary>
        /// Gets or sets the last access time of the file or directory.
        /// If equal to <c>null</c>, the value will not be set or the file has no last access time.
        /// </summary>
        DateTime? LastAccessTime { get; set; }

        /// <summary>
        /// Gets or sets the last write time of the file or directory.
        /// If equal to <c>null</c>, the value will not be set or the file has no last write time.
        /// </summary>
        DateTime? LastWriteTime { get; set; }

        /// <summary>
        /// Gets or sets the length of the file.
        /// </summary>
        long Length { get; set; }

        /// <summary>
        /// Gets or sets the Discretionary Access Control List, in SDDL form.
        /// </summary>
        string Dacl { get; set; }

        /// <summary>
        /// Gets or sets the System Access Control List, in SDDL form.
        /// </summary>
        string Sacl { get; set; }

        /// <summary>
        /// Gets or sets the owner (CREATOR OWNER) of the file, in SID form.
        /// </summary>
        string Owner { get; set; }

        /// <summary>
        /// Gets or sets the primary group (CREATOR GROUP) of the file, in SID form.
        /// </summary>
        string Group { get; set; }
    }
}

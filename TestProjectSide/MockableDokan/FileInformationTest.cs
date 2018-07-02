using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestableDokan.MockableDokan;

namespace TestableDokan.Tests.A.MockableDokan
{
    [TestClass]
    public class FileInformationTest
    {
        FileInformation fi;

        [TestInitialize]
        public void InitializeTest()
        {
            fi = new FileInformation { FileName = @"\" };
        }

        #region FileName
        [TestMethod]
        public void FileNameCannotBeNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => fi.FileName = null);
        }
        [TestMethod]
        public void FileNameCannotBeEmpty()
        {
            Assert.ThrowsException<ArgumentException>(() => fi.FileName = string.Empty);
        }
        [TestMethod]
        public void FileNameMustStartWithBackslash()
        {
            Assert.ThrowsException<ArgumentException>(() => fi.FileName = @"non-backslashstring");
        }
        [TestMethod]
        public void FileNameIsAccepted()
        {
            fi.FileName = @"\whatever.man";
            Assert.AreSame(@"\whatever.man", fi.FileName);
        }
        [TestMethod]
        public void FileNameInSubpathIsAccepted()
        {
            fi.FileName = @"\wherever\you\are\I\will\find\you.man";
            Assert.AreSame(@"\wherever\you\are\I\will\find\you.man", fi.FileName);
        }
        [TestMethod]
        public void FileNameRejectsInvalidCharacters()
        {
            Assert.ThrowsException<ArgumentException>(() => fi.FileName = @"\wherever\I<think\you\are\I\will\find\you.man");
            Assert.ThrowsException<ArgumentException>(() => fi.FileName = @"\so\can\I>come\kick\your\rear");
            // The documentation says that ':' is not allowed in filenames, but named stream syntax uses it.
            // So, no Assert.ThrowsException<ArgumentException>(() => fi.FileName = @"\This\is\an\example\of\a\named.txt:stream:$DATA").
            Assert.ThrowsException<ArgumentException>(() => fi.FileName = @"\and\I\try\Oh\my\""God""\do\I\try");
            Assert.ThrowsException<ArgumentException>(() => fi.FileName = @"\twenty\nine\or\six/to\four");
            Assert.ThrowsException<ArgumentException>(() => fi.FileName = @"\and|this|is|almost|how|I|want|to|store|directories");
            Assert.ThrowsException<ArgumentException>(() => fi.FileName = @"\does\he\love\me?\I\want\to\know");
            Assert.ThrowsException<ArgumentException>(() => fi.FileName = @"\It's\in\his\*kiss*\thats\where\it\is");
            Assert.ThrowsException<ArgumentException>(() => fi.FileName = "\\the\\name\\is\0\\neo");
            Assert.ThrowsException<ArgumentException>(() => fi.FileName = "\\I\\want\\this\\filename\\to\\ring\\your\\\007BEL");
        }
        [TestMethod]
        public void LongFilenamesAreRejected()
        {
            StringBuilder obuild = new StringBuilder();
            char[] array = new char[256];
            obuild.Append(@"\");
            for (int i = 0; i<1000; i++)
            {
                for (int j = 0; j<256; j++)
                {
                    array[j] = 'a';
                }
                obuild.Append(new string(array));
                obuild.Append(@"\");
            }
            obuild.Append(array);
            string s = obuild.ToString().Substring(0,32769);
            Assert.ThrowsException<ArgumentException>(() => fi.FileName = s);
        }

        [TestMethod]
        public void ShortEnoughFilenamesAreAccepted()
        {
            StringBuilder obuild = new StringBuilder();
            char[] array = new char[256];
            obuild.Append(System.IO.Path.DirectorySeparatorChar);
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    array[j] = 'a';
                }
                obuild.Append(new string(array));
                obuild.Append(System.IO.Path.DirectorySeparatorChar);
            }
            obuild.Append(array);
            string s = obuild.ToString().Substring(0, 32768);
            fi.FileName = s;
        }
        #endregion
    }
}

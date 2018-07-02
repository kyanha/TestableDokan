# ImplementationSide README

This is an example of the type of wrapper around Dokan-dotnet which is
necessary to support test-driven development.  Most of the classes in
`ImplementationSide` are useful for filesystem implementations.  There
is an additional class in `TestProjectSide` which is useful for mocking
a Dokany-generated parameter which is not easily mocked for test-driven
development.

---

`TestableDokan.MockableDokan.ActualDokanOperationsWrapper` is the
class that you instantiate to pass directly to Dokan's .Mount routines.  You
instantiate it by passing to its constructor an object which derives from 
`TestableDokan.MockableDokan.PassthruDokanBase`.

`TestableDokan.MockableDokan.DokanFileInfoMockBase` is the base class
which acts like `DokanNet.DokanFileInfo`.  It derives from
`IDokanFileInfoWrapper`, which is the interface that
`DokanNet.DokanFileInfo` should have derived from in the first place.

`TestableDokan.MockableDokan.FileInformation` exists primarily to ensure
that tests which need to manipulate the file length of a directory entry can
do so appropriately.  It derives from `FileInformationBase`, which itself
implements `IFileInformation`.

`TestableDokan.MockableDokan.IFileInformation` is an interface which
exposes all of the aspects of filesystem metadata which are visible to the
filename and file metadata access routines: FileName, FileAttributes,
CreationTime, LastAccessTime, LastWriteTime, Length, Dacl, Sacl, Owner, and
primary Group.

`TestableDokan.MockableDokan.IMockableDokanOperations` is the
mockable version of `DokanNet.IDokanOperations`, and mirrors its API,
except that instead of the final parameters of the methods taking
`DokanFileInfo` objects, they take objects which implement
`IDokanFileInfoWrapper`.  `PassthruDokanBase` implements this interface.

`TestableDokan.MockableDokan.PassthruDFI` is a class which is
constructed with a `DokanNet.DokanFileInfo`, and which forwards all of its
calls to the `DokanFileInfo` it was constructed with.  Objects of this
class are created automatically by `ActualDokanOperationsWrapper`, which
then forwards them to the methods of the subclass of `PassthruDokanBase`
which actually implement the filesystem.

`TestableDokan.MockableDokan.PassthruDokanBase` is the base class which
implements `IMockableDokanOperations`.  All of its methods are virtual,
and all of them need to be overridden with actual implementations.  If one
of these methods doesn't get overridden, it will throw a
`NotImplementedException` when it is invoked by the Dokany driver.


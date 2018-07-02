# TestProjectSide README

This is the companion to `ImplementationSide`, which contains classes
designed to make it easy to test implementations which use the classes and
interfaces from there.

---

`TestableDokan.TestProjectSide.MockableDokan.DokanFileInfoMock` is
a fully-mockable version of `DokanNet.DokanFileInfo`, which derives from
`TestableDokan.ImplementationSide.DokanFileInfoMockBase` and thus
implements `TestableDokan.ImplementationSide.IFileInformation`.  Due
to an inability to add `set` properties on `get`-only properties declared
in interfaces, it was necessary in some circumstances to provide
`SetProperty(bool value)` methods to alter the values that the `get`-only
properties will return.

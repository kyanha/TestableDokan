# TestableDokan solution README

This is a quick project I slapped together to show how to build a mockable,
testable framework around Dokan-dotnet.  There are two projects in here,
`ImplementationSide` and `TestProjectSide`.  You are encouraged to take
these classes and put them in your own projects.

These classes are for Dokan-dotnet 1.1.0.3, not the latest available verison.
There was an API change in v1.1.1.1 which requires a bit of patching to bring
this to that version's requirements [specifically, a parameter added to a
method in `DokanNet.IDokanOperations`].

Your implementation project should have a reference to DokanNet.  Your test
project should have a reference to your implementation project.

`TestProjectSide\MockableDokan\FileInformationTest.cs` is written to
the MSTestV2 API.  You can use other test APIs, but if you do you will have
to either drop that test or modify it to use your chosen test API.

I hope you find this helpful.

-kyanha@github, 2018-07-01
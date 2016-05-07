namespace NUnit3Tests

module NUnit =
    open NUnit.Framework

    // F# doesn't generate TestFixture attribute for you
    // Looks like NUnit doesn't actually require it
    [<Test>]
    let firstTest() = Assert.AreEqual("this", "this")

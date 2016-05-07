namespace Tests

module NUnit =
    open NUnit.Framework

    // F# doesn't generate TestFixture attribute for you
    // Looks like NUnit doesn't actually require it
    [<Test>]
    let firstTest() = Assert.AreEqual(0, 0)



//type Class1() = 
//    member this.X = "F#"

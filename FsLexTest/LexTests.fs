namespace FsLexTest

module LexTests =
    open NUnit.Framework
    open Microsoft.FSharp.Text.Lexing 

    // F# doesn't generate TestFixture attribute for you
    // Looks like NUnit doesn't actually require it
    [<Test>]
    let scanTest() =
        let x = "   
            SELECT x, y, z   
            FROM t1   
            LEFT JOIN t2   
            INNER JOIN t3 ON t3.ID = t2.ID   
            WHERE x = 50 AND y = 20   
            ORDER BY x ASC, y DESC, z   
"  
        let lexbuf = LexBuffer<char>.FromString x

       
        let tokenInfSeq = Seq.initInfinite (fun _ -> SqlLexer.tokenize lexbuf)
        let tokenSeq = tokenInfSeq |> Seq.takeWhile(fun t -> t <> Parser.EOF)

        let tokenList = List.ofSeq tokenSeq



        ()

    //let firstTest() = Assert.AreEqual("this", "this")
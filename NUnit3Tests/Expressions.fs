namespace NUnit3Tests

module Expressions =
    open NUnit.Framework
    open System.Linq.Expressions
    open System
    //open Microsoft.FSharp.Quotations


    type Expr = 
        static member Quote<'a, 'b>(e:Expression<System.Func<'a,'b>>) = e
        static member Compile<'a, 'b>(e:Expression<System.Func<'a,'b>>) =
            let compiled = e.Compile()
            fun x -> compiled.Invoke(x)


    let compile<'a, 'b>(e:Expression<System.Func<'a,'b>>) =
        let compiled = e.Compile()
        compiled.Invoke

    let useFn f x =
        Console.Out.WriteLine("Using x")
        f x


    [<Test>]
    let makeImplicitExpression() =
        let two = 2
        let expr = Expr.Quote(fun x -> x * two) 

        let compiled = expr.Compile()
        // compiled is a System.Func, and compiled.Invoke(4) is what
        // C#'s compiled(4) compiled down to.  The generated expression
        // code is called through one function pointer
        Assert.AreEqual(8, compiled.Invoke(4))

    [<Test>]
    let makeImplicitFun() =
        // Not inlined in release mode
        let compiled = Expr.Compile(fun x -> x * 3)

        // Not inlined in release mode
        //let compiled = compile (Expr.Quote(fun x->x * 3))

        // compiled, an F# function, is not inlined here.
        // The generated expression code is therefore called through
        // two function pointers
        Assert.AreEqual(12, (compiled 4))

    [<Test>]
    let useImplicitExpression() =
        let expr = Expr.Quote(fun x->x*2)

        let compiled = expr.Compile()

        // In release mode, useFn and compiled.Invoke are both inlined here.
        // The generated expresssion code is therefore called through
        // only one function pointer.
        let result = useFn compiled.Invoke 3
        Assert.AreEqual(6, result)





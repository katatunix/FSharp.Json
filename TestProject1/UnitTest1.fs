module TestProject1

open NUnit.Framework
open FSharp.Json

[<SetUp>]
let Setup () =
    ()

[<Test>]
let ``test serialize`` () =
    let x : Map<string, obj> =
        Map [
            "apple", null
            "banana", [null;box 1;box 2;box 3;()]
        ]
    x|>NbJson.serialize|>printfn"%s"

[<Test>]
let ``test deserialize`` () =
    let x : Map<string,obj> =
        """ {"apple":null,"banana":[null,1,2,3,null,true,false,{"nghia":null}]} """
        |> NbJson.deserialize
    printfn "%A" x

[<Test>]
let ``test deserialize option`` () =
    let x : {| apple: string option  |} =
        """ {"apple":null} """
        |> NbJson.deserialize
    printfn "%A" x

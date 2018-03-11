module GetNumberFromString

open System
open Xunit

// https://www.codewars.com/kata/get-number-from-string/train/fsharp

let getNumberFromString (s:string) = 
    s.ToCharArray()
    |> Seq.filter (fun c -> c |> Char.IsNumber)
    |> Seq.map string
    |> Seq.reduce (sprintf "%s%s")
    |> Int32.Parse

[<Fact>]
let testCase() =
    Assert.Equal(1, getNumberFromString "1");
    Assert.Equal(123, getNumberFromString "123");
    Assert.Equal(7, getNumberFromString "this is number: 7");
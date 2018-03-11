module Tests

open System
open Xunit
open System.Data.SqlTypes

// https://www.codewars.com/kata/to-square-root-or-not-to-square-root/train/fsharp

let squareOrSquareRoot (array:int[]) = 
    let remaidner x = x % 1.0 
    let isZero x = x = 0.0
    let isPerfectSquare = Math.Sqrt >> remaidner >> isZero

    let fn x = 
        if x |> float |> isPerfectSquare 
        then x |> float |> Math.Sqrt |> int
        else x * x
    array |> Array.map fn

[<Fact>]
let ``My test`` () =
    let a = [| 2; 9; 3; 49; 4; 1 |]
    let b = (squareOrSquareRoot [| 4; 3; 9; 7; 2; 1 |] )
    Assert.Equal<Collections.Generic.IEnumerable<int>>(a,b)
    //Assert.Equal(a, b)
    //Assert.Equal([| 10; 10201; 25; 25; 1; 1 |], squareOrSquareRoot [| 100; 101; 5; 5; 1; 1 |] )
    //Assert.Equal([| 1; 4; 9; 2; 25; 36 |], squareOrSquareRoot [| 1; 2; 3; 4; 5; 6 |] )  
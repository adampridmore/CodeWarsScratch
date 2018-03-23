module FakeBinary

open Xunit
open System

// https://www.codewars.com/kata/fake-binary/train/fsharp
let fakeBin (x:string) = 
    let convert i = if i < 5.0 then '0' else '1'

    x.ToCharArray()
    |> Seq.map (Char.GetNumericValue >> convert)
    |> string

[<Fact>]
let suite =
    Assert.Equal("01011110001100111", fakeBin "45385593107843568" )
    Assert.Equal("101000111101101", fakeBin "509321967506747" )
    Assert.Equal("011011110000101010000011011", fakeBin "366058562030849490134388085" )
module FsTests
open Xunit
open FsUnit.Xunit

let add x y = x + y

[<Fact>]
let TrueIsTrue() =
    true |> should equal true

[<Fact>]
let AddShouldWorkForSimpleExample() =
    add 1 1 |> should equal 2

[<Fact>]
let ``Add should work for simple example``() =
    add 1 1 |> should equal 2


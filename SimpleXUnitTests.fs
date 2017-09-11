module Tests
open Xunit // <-- don't forget to include this (it does not happen automatically in VS Code using Arch Linux!)

// You might have to restart VS Code after adding XUnit to the *.fsproj file so that the error squigglies are removed.

let add x y = x + y

[<Fact>]
let TrueIsTrue() =
    Assert.True(true)

[<Fact>]
let AddShouldWorkForSimpleExample() =
    Assert.Equal(add 1 1, 2)


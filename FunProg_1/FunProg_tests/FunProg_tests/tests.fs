module Tests

open Xunit
open task15
open task16

[<Fact>]
let ``task20RecursionSolution should find sum of 100!`` () =
    let result = solution15 20 20
    Assert.Equal(137846528820I, result)

[<Fact>]
let ``task20SequenceSolution should find sum of 100!`` () =
    let result = solution16_1
    Assert.Equal(1366, result)

[<Fact>]
let ``task20ModuleSolution should find sum of 300!`` () =
    let result = solution16_2 2I 1000
    Assert.Equal(1366, result)

[<Fact>]
let ``task11Loop should find maximum prod of 4 numbers in the same direction`` () =
    let result = solution16_3 2I 1000
    Assert.Equal(1366, result)

[<Fact>]
let ``task11Rec should find maximum prod of 4 numbers in the same direction`` () =
    let result = solution16_4 1000
    Assert.Equal(1366, result)
module Tests


open Expecto
open miniscaffold_test_local_paket

[<Tests>]
let tests =
  testList "samples" [
    testCase "Say nothing" <| fun _ ->
      let subject = Say.nothing ()
      Expect.equal subject () "Not an absolute unit"
    testCase "Say hello all" <| fun _ ->
      let subject = Say.hello "all"
      Expect.equal subject "Hello all" "You didn't say hello"
  ]

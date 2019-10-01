namespace miniscaffold_test_local_paket

module Say =
    let nothing name =
        name |> ignore

    let hello name =
        sprintf "Hello %s" name


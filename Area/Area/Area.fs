module Area

[<EntryPoint>]
let main argv =
    match argv with
    | [|"basic"|] -> Prompt.basic
    | _ -> Prompt.simple

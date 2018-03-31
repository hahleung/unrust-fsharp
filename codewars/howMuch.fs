let howMuch (m:int) (n:int) : string list list =
    let validBoat fortuneGuess = (fortuneGuess - 2) % 7 = 0
    let validCar fortuneGuess = (fortuneGuess - 1) % 9 = 0

    let fortuneResponse fortune = sprintf "M: %i" fortune
    let boatResponse fortune = sprintf "B: %i" ((fortune - 2) / 7)
    let carResponse fortune = sprintf "C: %i" ((fortune - 1) / 9)
    let responseSet fortune = [fortuneResponse fortune; boatResponse fortune; carResponse fortune]

    seq { for x in m .. n do if validCar x && validBoat x then yield responseSet x } |> Seq.toList

let howmuch (m:int) (n:int) : string list list =
    match m <= n with
    | true -> howMuch m n
    | false -> howMuch n m

printf "%A" (howmuch 0 200)
printf "%A" (howmuch 9950 10000)
printf "%A" (howmuch 10000 9950)

// With pure List module and without pattern matching:
// let howmuch m n =
//     [(min m n)..(max m n)]
//     |> List.filter (fun x -> x % 9 = 1 && x % 7 = 2)
//     |> List.map (fun m -> [sprintf "M: %i" m; sprintf "B: %i" (m / 7); sprintf "C: %i" (m / 9)])

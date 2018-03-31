let squareRoot x =
    let isCloseEnough guess =
        let acceptableVariance = x / 100.0
        [ x - acceptableVariance < guess * guess ; guess * guess < x + acceptableVariance ]
        |> Seq.forall id

    let nextGuess y =
        (y + (x/y)) / 2.0

    let rec guessFn lastGuess =
        let closeEnough = isCloseEnough lastGuess
        match closeEnough with
        | true -> lastGuess
        | false -> lastGuess |> nextGuess |> guessFn

    guessFn 1.0

squareRoot 4.0

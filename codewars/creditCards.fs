open System

let validate (creditCardNumbers:string) =
    let numbers =
        creditCardNumbers.Replace(" ", "")
        |> Seq.map (Convert.ToString >> int)
    let creditCardLength = Seq.length numbers
    let indexes = seq { 0..creditCardLength }
    let isLuhnRuleEven = creditCardLength % 2 = 0

    let luhnTransform (index:int) (number:int) (luhnRule:bool) : int =
        let isCurrentPositionEven = index % 2 = 0
        match (isCurrentPositionEven = luhnRule) with
        | true ->
            match number * 2 with
            | x when x > 9 -> x - 9
            | _ -> number * 2
        | false -> number

    let luhnSum =
        Seq.zip indexes numbers
        |> Seq.sumBy (fun (i, x) -> luhnTransform i x isLuhnRuleEven)
    luhnSum % 10 = 0

let result = validate "12345"
printfn "%A" result

// Best answer on the net:
// let validate (str:string) =
//   str
//   |> Seq.filter System.Char.IsDigit
//   |> Seq.map (fun c -> int c - int '0')
//   |> Seq.rev
//   |> Seq.map2 (*) (Seq.initInfinite (fun i -> 1 + i % 2))
//   |> Seq.sumBy (fun x -> if x < 10 then x else x - 9)
//   |> (fun x -> x % 10 = 0)

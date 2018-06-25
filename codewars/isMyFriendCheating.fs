// module Tests = begin
//     open Fuchu
//     let testing n expectedOutput = 
//         Assert.Equal("", expectedOutput, removNb n)
//     let suite =
//         testList "removNb" [
//             testCase "Basic tests" <| (fun _ ->
//                 testing 26L  [(15L,21L);(21L,15L)]
//                 testing 100L  []
//                 testing 37L  [(21L,31L);(31L,21L)]
//                 testing 101L  [(55L,91L);(91L,55L)]               
//             );
//         ]
// end

// Too slow:
// let rec comb n l = 
//     match n, l with
//     | 0, _ -> [[]]
//     | _, [] -> []
//     | k, (x::xs) -> List.map ((@) [x]) (comb (k-1) xs) @ comb k xs

// let l = List.init 10000 id
// comb 2 l

let removNb (n: int64) =
    let list : list<int64> = [int64 1..n]
    let sum = n * (n + int64 1) / int64 2

    let getOpposite' (n : int64) (someSum : int64) (firstNumber : int64) =
        let opposite = (someSum - firstNumber) / (firstNumber + int64 1)
        match opposite with
        | opposite when opposite < n -> Some opposite
        | _ -> None
    let getOpposite = getOpposite' n sum
    let getAcceptance (number : int64) (oppositeNumber : int64) : bool =
        sum = number * oppositeNumber + number + oppositeNumber

    let rec getPairs list result =
        match list with
        | [] -> result
        | number :: restList ->
            let oppositeNumberOption = getOpposite number
            let newResult =
                match oppositeNumberOption with
                | None -> result
                | Some oppositeNumber ->
                    match getAcceptance number oppositeNumber with
                    | true -> List.append result [(number, oppositeNumber)]
                    | false -> result
            getPairs restList newResult
    getPairs list []

removNb 26L |> printf "%A"
removNb 100L |> printf "%A"
removNb 37L |> printf "%A"
removNb 10001L |> printf "%A"

// Solution on the web...
// let removNb n =
//     if n <= 3L
//     then []
//     else
//     [
//         let sum = n * (n + 1L) / 2L
//         for i = n / 2L to n do
//             let q, r = System.Math.DivRem(sum - i, i + 1L)
//             if r = 0L && q <> i then
//                 yield i, q
//     ]

// let removNb (n: int64) =
//   let sum = 1L + n * (n + 1L) / 2L
//   [1L..n+1L]
//   |> List.filter (fun i -> sum % i = 0L && sum / i <= n + 1L)
//   |> List.map (fun i -> (i - 1L, sum / i - 1L))

// John and his wife Ann have decided to go to Codewars.
// On day 0 Ann will do one kata and John - he wants to know how it is working - 0.
// Let us call a(n) the number of katas done by Ann at day n we have a(0) = 1 and in the same manner j(0) = 0.
// They have chosen the following rules:
// On day n the number of katas done by Ann should be n minus the number of katas done by John at day t, t being equal to the number of katas done by Ann herself at day n - 1.
// On day n the number of katas done by John should be n minus the number of katas done by Ann at day t, t being equal to the number of katas done by John himself at day n - 1.
// Whoops! I think they need to lay out a little clearer exactly what there're getting themselves into!
// Could you write:
// 1) two functions ann and john (parameter n) giving the list of the numbers of katas Ann and John should take on each day from day 0 to day n - 1 (n days - see first example below)?
// 2) The total number of katas taken by ann (function sum_ann(n)) and john (function sum_john(n)) from day 0 (inclusive) to day n (exclusive)?
// The functions in 1) are not tested in Fortran and not tested in Shell.
// Examples:
// john(11) -->  [0, 0, 1, 2, 2, 3, 4, 4, 5, 6, 6]
// ann(6)   -->  [1, 1, 2, 2, 3, 3]
// sum_john(75) -->  1720
// sum_ann(150) -->  6930
// Shell Note:
// sumJohnAndAnn has two parameters:
// first one : n (number of days, $1)
// second one : which($2) ->
// 1 for getting John's sum
// 2 for getting Ann's sum.
// See "Sample Tests".
// Note:
// Keep an eye on performance.

// Accumlator as Seq (too slow)
// let getSuite (n: int) =
//     let seed = (0, 1, 0)
//     let getStats ((n, oldAnn, oldJohn), suite) number =
//         let (_, aj, _) = suite |> Seq.find (fun (n, _, _) -> n = oldJohn)
//         let j = number - aj

//         let updatedSuite = Seq.append [|(number, 0, j)|] suite
//         let (_, _, ja) = updatedSuite |> Seq.find (fun (n, _, _) -> n = oldAnn)
//         let a = number - ja

//         let stat = (number, a, j)
//         (stat, Seq.append suite [|stat|])
//     Seq.fold getStats (seed, seq [seed]) (seq {1..n-1})

let getSuite (n : int) =
    let seed = (1, 0)
    let getStats ((oldAnn : int, oldJohn : int), suite : Map<int, (int * int)>) number =
        let (aj, _) = suite.[oldJohn]
        let j = number - aj

        let updatedSuite = suite.Add(number, (0, j))
        let (_, ja) = updatedSuite.[oldAnn]
        let a = number - ja

        let stat = (a, j)
        (stat, suite.Add(number, stat))
    let (_, stats) = Seq.fold getStats (seed, Map.empty.Add(0, seed)) (seq {1..n-1})
    stats |> Map.toList |> List.map (fun (_k, v) -> v)

let john(n : int) = getSuite(n) |> List.map (fun (_ann, john) -> john)
let ann(n : int) = getSuite(n) |> List.map (fun (ann, _john) -> ann)

let sumJohn(n) = john(n) |> List.sum
let sumAnn(n) = ann(n) |> List.sum

getSuite 3 |> printfn "%A"
john 11 |> printfn "%A"
ann 11 |> printfn "%A"
sumJohn 75 |> printfn "%A"
sumAnn 150 |> printfn "%A"

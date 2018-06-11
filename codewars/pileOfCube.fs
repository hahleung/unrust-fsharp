// Your task is to construct a building which will be a pile of n cubes. The cube at the bottom will have a volume of n^3, the cube above will have volume of (n-1)^3 and so on until the top which will have a volume of 1^3.

// You are given the total volume m of the building. Being given m can you find the number n of cubes you will have to build?

// The parameter of the function findNb (find_nb, find-nb, findNb) will be an integer m and you have to return the integer n such as n^3 + (n-1)^3 + ... + 1^3 = m if such a n exists or -1 if there is no such n.

// Examples:
// findNb(1071225) --> 45
// findNb(91716553919377) --> -1

let findNb (m : uint64) : int =
    let rec doFindNb (m : uint64) (n : int) =
        match m with
        | m when m < 0UL -> -1
        | m when m = 0UL -> n - 1
        | _ -> doFindNb (m - System.Convert.ToUInt64(pown n 3)) (n + 1)
    doFindNb m 0

findNb(1071225UL) |> printfn "%A" // 45
findNb(4183059834009UL) |> printfn "%A" // 2022
findNb(91716553919377UL) |> printfn "%A" // -1

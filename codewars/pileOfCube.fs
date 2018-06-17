// Your task is to construct a building which will be a pile of n cubes. The cube at the bottom will have a volume of n^3, the cube above will have volume of (n-1)^3 and so on until the top which will have a volume of 1^3.

// You are given the total volume m of the building. Being given m can you find the number n of cubes you will have to build?

// The parameter of the function findNb (find_nb, find-nb, findNb) will be an integer m and you have to return the integer n such as n^3 + (n-1)^3 + ... + 1^3 = m if such a n exists or -1 if there is no such n.

// Examples:
// findNb(1071225) --> 45
// findNb(91716553919377) --> -1

let findNb (buildingVolume : uint64) : int =
    let rec doFindNb (buildingVolume : bigint) (n : int) =
        match buildingVolume with
        | buildingVolume when buildingVolume < bigint 0 -> -1
        | buildingVolume when buildingVolume = bigint 0 -> n - 1
        | _ ->
            let squareVolume = bigint (float n ** float 3)
            doFindNb (buildingVolume - squareVolume) (n + 1)
    doFindNb (bigint buildingVolume) 0

findNb(1071225UL) |> printfn "%A" // 45
findNb(4183059834009UL) |> printfn "%A" // 2022
findNb(91716553919377UL) |> printfn "%A" // -1
// pown 1291 3 is leading to an overflow in F#

// Mathematical solution on the web:
// let findNb(n: uint64): int =
//     let kk = uint64(floor (sqrt(sqrt(4.0 * (float n)))))
//     if (4UL * n = kk * kk * (kk + 1UL) * (kk + 1UL)) then
//         int kk
//     else
//         -1

let powersOfTwo (n:int) : int list =
    seq { for x in 0 .. n -> x }
    |> Seq.map(fun x -> pown 2 x)
    |> Seq.toList

powersOfTwo 4

// Or list comprehension:
// let powersOfTwo n = [for i in 0..n -> pown 2 i]

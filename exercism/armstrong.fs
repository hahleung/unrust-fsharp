let isArmstrong (number:int) =
    let numberString = string number
    let armstrongPower = String.length numberString

    let armstrongSum (number:char) =
        let inline charToInt c = int c - int '0'
        pown (charToInt number) armstrongPower

    let armstrongReflection =
        numberString.ToCharArray()
        |> List.ofArray
        |> List.sumBy armstrongSum

    armstrongReflection = number

// Test cases:
// isArmstrong 123 // false
// isArmstrong 153 // true

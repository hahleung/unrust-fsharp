// The rgb() method is incomplete. Complete the method so that passing in RGB decimal values will result in a hexadecimal representation being returned. The valid decimal values for RGB are 0 - 255. Any (r,g,b) argument values that fall out of that range should be rounded to the closest valid value.
// The following are examples of expected output values:
// rgb 255  255  255 // returns FFFFFF
// rgb 255  255  300 // returns FFFFFF
// rgb 0 0 0 // returns 000000
// rgb 148  0  211 // returns 9400D3

let hexTable = "0123456789ABCDEF"
let hexBase = hexTable.Length

let rec decToHex (decimalValue : int) (hexValue : string) : string =
    let hexTableIndex = decimalValue % hexBase
    let newHexValue =
        [hexTable.[hexTableIndex].ToString(); hexValue]
        |> String.concat ""
    let restDecimalValue = decimalValue / hexBase
    match restDecimalValue with
    | 0 -> newHexValue
    | _ -> decToHex restDecimalValue newHexValue

let decToHex' (decimalValue : int) : string =
    let hexValue =
        match decimalValue with
        | decimalValue when decimalValue < 0 -> (decToHex 0 "")
        | decimalValue when decimalValue > 255 -> (decToHex 255 "")
        | _ -> (decToHex decimalValue "")
    hexValue.PadLeft(2, '0')

let rgb r g b =
    [decToHex' r; decToHex' g; decToHex' b]
    |> String.concat ""

// // Test cases
// Assert.Equal("", "FFFFFF", rgb 255 255 255)
// Assert.Equal("", "FFFFFF", rgb 255 255 300)
// Assert.Equal("", "000000", rgb 0 0 0)
// Assert.Equal("", "9400D3", rgb 148 0 211)
// Assert.Equal("", "9400D3", rgb 148 -20 211)
// Assert.Equal("", "90C3D4", rgb 144 195 212)
// Assert.Equal("", "D4350C", rgb 212 53 12)


// Found on the net...

// let rgb r g b =
//     [r;g;b]
//     |> Seq.map (min 255 >> max 0)
//     |> Seq.reduce (fun state item -> state * 256 + item)
//     |> sprintf "%06x"
//     |> fun p -> p.ToUpper()

// let rgb r g b =
//   let getRgbValue = max 0 >> min 255
//   sprintf "%02X%02X%02X" (getRgbValue r) (getRgbValue g) (getRgbValue b)

// let rgb r g b =
//   let toHex v =
//     System.Math.Max(0, System.Math.Min(255, v)) |> sprintf "%02X"
//   (r |> toHex) + (g |> toHex) + (b |> toHex)



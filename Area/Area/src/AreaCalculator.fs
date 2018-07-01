module AreaCalculator

[<Measure>] type ft
[<Measure>] type m

let FeetToMetersFactor = 0.09290304<m^2/ft^2>
let NumberOfDecimals = 3

let roundMeasure<[<Measure>] 'unit> (unroundedMeasure : float<'unit>) : float<'unit> =
    System.Math.Round (decimal unroundedMeasure, NumberOfDecimals)
    |> float
    |> Microsoft.FSharp.Core.LanguagePrimitives.FloatWithMeasure

let feet (measure : string) : float<ft> =
    match System.Double.TryParse(measure) with
    | true, floatValue -> floatValue * 1.0<ft>
    | _ -> raise (System.ArgumentException("Only numbers bro."))
    // | _ -> invalidArg "measure" (sprintf "'%s' is not a number!" measure)

let getArea (length : float<ft>) (width : float<ft>) : float<ft^2> =
    roundMeasure (length * width)

let convertToSquareMeters (area : float<ft^2>) : float<m^2>=
    roundMeasure (area * FeetToMetersFactor)

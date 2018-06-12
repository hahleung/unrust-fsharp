// In John's car the GPS records every s seconds the distance travelled from an origin (distances are measured in an arbitrary but consistent unit). For example, below is part of a record with s = 15:
// x = [0.0, 0.19, 0.5, 0.75, 1.0, 1.25, 1.5, 1.75, 2.0, 2.25]
// The sections are:
// 0.0-0.19, 0.19-0.5, 0.5-0.75, 0.75-1.0, 1.0-1.25, 1.25-1.50, 1.5-1.75, 1.75-2.0, 2.0-2.25
// We can calculate John's average hourly speed on every section and we get:
// [45.6, 74.4, 60.0, 60.0, 60.0, 60.0, 60.0, 60.0, 60.0]
// Given s and x the task is to return as an integer the *floor* of the maximum average speed per hour obtained on the sections of x. If x length is less than or equal to 1 return 0 since the car didn't move.
// #Example: with the above data your function gps(x, s)should return 74
// Note
// With floats it can happen that results depends on the operations order. To calculate hourly speed you can use:
// (3600 * delta_distance) / s.

let gps (s : int) (distances : list<double>) =
    let getLocalAverageSpeed (newPoint : double) (lastPoint : double) =
        (double 3600) * (newPoint - lastPoint) / double s

    let addLocalSpeed (newPoint : double) (lastPoint : double) (speeds : list<double>) =
        let localAverageSpeed = getLocalAverageSpeed newPoint lastPoint
        // System.Console.WriteLine(localAverageSpeed)
        // (averageSpeed * double pointsCount + localAverageSpeed) / double (pointsCount + 1)
        localAverageSpeed :: speeds

    let rec doGps (list : list<double>) (lastPoint : double) (speeds : list<double>) =
        match list with
        | head :: tail ->
            let newAverageSpeed = addLocalSpeed head lastPoint speeds
            doGps tail head newAverageSpeed
        | [] -> speeds |> List.max |> int

    match distances with
    | [] -> 0
    | distances when List.length distances = 1 -> 0
    | initialPoint :: records -> doGps records initialPoint []

// let x1 : list<double> = [0.0; 0.19; 0.5; 0.75; 1.0; 1.25; 1.5; 1.75; 2.0; 2.25]
// let s1 = 15
// gps s1 x1 // 74

// let x2 = [0.0; 0.23; 0.46; 0.69; 0.92; 1.15; 1.38; 1.61]
// let s2 = 20
// gps s2 x2 // 41

// let x3 = [0.0; 0.11; 0.22; 0.33; 0.44; 0.65; 1.08; 1.26; 1.68; 1.89; 2.1; 2.31; 2.52; 3.25]
// let s3 = 12
// gps s3 x3 // 219

// gps 12 []
// gps 12 [5.5]

// Best answer:
// let rec gps (s: int) (l: list<double>): int =
//     match l with
//     | [] -> 0
//     | _ :: [] -> 0
//     | a :: b :: x -> max (int((b - a) * 3600.0 / double(s))) (gps s (b :: x))

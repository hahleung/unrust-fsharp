open System

let rec getBounces (acc : int) (window : float) (bounce : float) (height : float) : int =
  match height with
  | h when h < window -> acc
  | _ -> getBounces (acc + 2) window bounce (height * bounce)

let bouncingBall (initialHeight : float) (bounce : float) (window : float) : int =
  Console.WriteLine [initialHeight; bounce; window]
  match (initialHeight, bounce) with
  | (hi, b) when hi <= window || b <= 0.0 || b >= 1.0 -> -1
  | _ ->
    let bounces = getBounces 0 (float window) (float bounce) (float initialHeight)
    match bounces with
      | 0 -> -1
      | _ -> bounces - 1

// Test cases:
// bouncingBall 3.0 0.66 1.5 // 3
// bouncingBall 30.0 0.66 1.5 // 15
// bouncingBall 30.0 0.75 1.5 // 21
// bouncingBall 330.0 0.4 10.0 // 7
// bouncingBall 40.0 0.4 10.0 // 3
// bouncingBall 10.0 0.6 10.0 // -1
// bouncingBall 40.0 1.0 10.0 // -1
// bouncingBall 5.0 0.0 1.5 // -1

// One shorter solution, which is itself recursive (not tail-recursive though):
// let rec bouncingBall (h: float) (bounce: float) (window: float) =
//   if h > 0.0 && 0.0 < bounce && bounce < 1.0 && window < h then 2 + bouncingBall (h * bounce) bounce window
//   else -1

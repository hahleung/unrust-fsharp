open System.Text.RegularExpressions

let takeLast (n : int) (postcode : string) : string =
    postcode |> Seq.skip (Seq.length postcode - n) |> System.String.Concat
let dropLast (n : int) (postcode : string) : string =
    postcode |> Seq.take (Seq.length postcode - n) |> System.String.Concat

let parseBlockPostcode (postcode : string) : string list =
    postcode
    |> takeLast 3
    |> Regex("[0-9][A-Z]{2}").Match
    |> fun regex ->
      match regex.Success with
      | true -> [postcode |> dropLast 3; regex.Value]
      | false -> [postcode; ""]

let parse (postcode:string) : string list =
    let outward::inward = postcode.Trim().ToUpper().Split([|' '|]) |> List.ofArray
    match inward with
    | [] -> parseBlockPostcode outward
    | _ -> [outward; inward |> String.concat ""]

parse "se16 5qq" = ["SE16"; "5QQ"] |> printf "%b\n"
parse "se16 5 qq" = ["SE16"; "5QQ"] |> printf "%b\n"
parse "se16 5" = ["SE16"; "5"] |> printf "%b\n"
parse "se16 5 q" = ["SE16"; "5Q"] |> printf "%b\n"
parse "se165qq" = ["SE16"; "5QQ"] |> printf "%b\n"
parse " se165qq " = ["SE16"; "5QQ"] |> printf "%b\n"
parse "se16" = ["SE16"; ""] |> printf "%b\n"
// This one is a user mistake, not covered:
parse "se165" = ["SE165"; ""] |> printf "%b\n"
// This one is a user mistake, not covered:
parse "se1 6 5 qq" = ["SE1"; "65QQ"] |> printf "%b\n"

// let x::y = ("few efwe".Split [|' '|]) |> List.ofArray
// let u = ["few";"ewa"] |> String.concat ""

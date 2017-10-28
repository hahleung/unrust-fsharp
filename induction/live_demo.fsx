// PARTIAL FUNCTION APPLICATION / DEPENDENCY INJECTION
// the add function
let x = 1
let add a b = a + b

let addAlways10 x = add 10 x
let addAlways40 = add 40

addAlways10 3 
addAlways40 2 

// DISCRIMINATED UNION TYPE
// the Tabber type
type Tabber =
    | AppServices of string
    | Android of int
    | Both of string

let david = Both("David")

let gimmeYourName tabber =
    match tabber with
    | Both(s) -> printf "it's %s" s
    | _ -> printf "meeeeeeeeeeh"

// OPTIONAL TYPE
// the Dude record
type Dude = { Name: string; Age: int}
let sasha = { Name = "Sasha"; Age = 28}
let meh = { Name = "Meh"; Age = 39}

let isItSasha dude = 
    match dude.Name with 
    | "Sasha" -> Some(printf "it's him!")
    | _ -> None

isItSasha sasha
isItSasha meh

// FUNCTIONAL PIPES
// the list of integers, Seq library
// transformational style
let a = [
    1
    2
    6
    3
]

Seq.filter (fun x -> (x % 2) = 0) a

a 
|> Seq.filter (fun x -> (x % 2) = 0) 
|> Seq.sumBy (fun x -> x + 42) 



// dependency injection / partial function application
let add a b = a + b
let alwaysAdd10 x = add 10 x
let alwaysAdd10bis = add 10
alwaysAdd10 2
alwaysAdd10bis 2

// discriminated union type
type Tabber =
    | AppServices of string
    | Android of int
    | Both of string * int

let alex = AppServices "Alex"
let voicu = Android 1
let david = Both("David", 2)

let something tabber =
    match tabber with
    | AppServices(name) -> printf "the name of the dude is %s" name
    | Android(age) -> printf "huh %f" (float age)
    | Both(name, age) -> printf "huh only David I guess? %f %s" (float age) name
    | _ -> printf "who's that?"

something voicu
something alex
something david

// optional type
type Dude = { Name: string; Age: int}
let peter = { Name = "Peter"; Age = 23 }

let isItPeter name = 
    match name with
    | "Peter" -> Some("it's peeettteerrr") 
    | _ -> None
let isItPeterBis aDude = 
    match aDude.Name with
    | "Peter" -> Some("it's peeettteerrr") 
    | _ -> None

isItPeter "Peter"
isItPeterBis peter

// Functional pipes
let someNumbers = [
    1
    2
    3
    6
]

Seq.length someNumbers
Seq.sum someNumbers
Seq.map (fun x -> (x % 2) = 0) someNumbers
Seq.filter (fun x -> (x % 2) = 0) someNumbers

someNumbers
|> Seq.filter (fun x -> (x % 2) = 0)
|> Seq.map (fun x -> x + 4)
|> Seq.sum

someNumbers
|> Seq.filter (fun x -> (x % 2) = 0)
|> Seq.sumBy (fun x -> x + 4)

someNumbers
|> Seq.map (fun y -> y)
|> Seq.average
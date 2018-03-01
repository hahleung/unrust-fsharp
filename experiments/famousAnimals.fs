let data = [("Cats",4);
            ("Dogs",5);
            ("Mice",3);
            ("Dolphins",5);
            ("Elephants",2)]

let (famousAnimals, _) =
    let getMax (famous, maxCount) (name, count) =
        match count with
        | c when c = maxCount -> (name :: famous, maxCount)
        | c when c > maxCount -> ([name], count)
        | _  -> (famous, maxCount)
    List.fold getMax (List.empty, 0) data

List.iter (fun elem -> printf "%s " elem) famousAnimals

let seqData = seq data
let (famousAnimals', _) =
    let getMax (famous, maxCount) (name, count) =
        match count with
        | c when c = maxCount -> (Seq.append famous [|name|], maxCount)
        | c when c > maxCount -> (seq [name], count)
        | _  -> (famous, maxCount)
    Seq.fold getMax (Seq.empty, 0) seqData

let x = Seq.iter (fun elem -> printf "%s \n" elem) famousAnimals'
let y = String.concat "\n" famousAnimals'

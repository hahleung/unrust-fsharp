module Prompt

let basic : int =
    System.Console.Write("What is the length of the room in feet? ")
    let length = System.Console.ReadLine() |> AreaCalculator.feet

    System.Console.Write("What is the width of the room in feet? ")
    let width = System.Console.ReadLine() |> AreaCalculator.feet

    System.Console.Write("You entered dimensions of {0} feet by {1} feet.", length, width)

    let areaInSquareFeet = AreaCalculator.getArea length width
    let areaInSquareMeters = AreaCalculator.convertToSquareMeters areaInSquareFeet
    System.Console.Write("\nThe area is:")
    System.Console.Write("\n\t{0} square feet", areaInSquareFeet)
    System.Console.Write("\n\t{0} square meters", areaInSquareMeters)
    System.Console.Write("\n")
    0

let simple : int =
    System.Console.Write("Which unit do you want to use (feet/meter)? ")
    let unitOfMeasure = System.Console.ReadLine()
    System.Console.Write("Okay, let's go for {0}!", unitOfMeasure)
    0

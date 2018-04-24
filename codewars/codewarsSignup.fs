// John and his wife Ann have decided to go to Codewars.
// On day 0 Ann will do one kata and John - he wants to know how it is working - 0.
// Let us call a(n) the number of katas done by Ann at day n we have a(0) = 1 and in the same manner j(0) = 0.
// They have chosen the following rules:
// On day n the number of katas done by Ann should be n minus the number of katas done by John at day t, t being equal to the number of katas done by Ann herself at day n - 1.
// On day n the number of katas done by John should be n minus the number of katas done by Ann at day t, t being equal to the number of katas done by John himself at day n - 1.
// Whoops! I think they need to lay out a little clearer exactly what there're getting themselves into!
// Could you write:
// 1) two functions ann and john (parameter n) giving the list of the numbers of katas Ann and John should take on each day from day 0 to day n - 1 (n days - see first example below)?
// 2) The total number of katas taken by ann (function sum_ann(n)) and john (function sum_john(n)) from day 0 (inclusive) to day n (exclusive)?
// The functions in 1) are not tested in Fortran and not tested in Shell.
// Examples:
// john(11) -->  [0, 0, 1, 2, 2, 3, 4, 4, 5, 6, 6]
// ann(6) -->  [1, 1, 2, 2, 3, 3]
// sum_john(75) -->  1720
// sum_ann(150) -->  6930
// Shell Note:
// sumJohnAndAnn has two parameters:
// first one : n (number of days, $1)
// second one : which($2) ->
// 1 for getting John's sum
// 2 for getting Ann's sum.
// See "Sample Tests".
// Note:
// Keep an eye on performance.

let john(n) = n
let ann(n) = n

let sumJohn(n) = n
let sumAnn(n) = n


// module Tests = begin
//     open Fuchu
//     let testAnn n expectedOutput = 
//         Assert.Equal("", expectedOutput, ann(n))
//     let testJohn n expectedOutput = 
//         Assert.Equal("", expectedOutput, john(n))
//     let testSumJohn n expectedOutput = 
//         Assert.Equal("", expectedOutput, sumJohn(n))
//     let testSumAnn n expectedOutput = 
//         Assert.Equal("", expectedOutput, sumAnn(n))
//     let suite =
//         testList "johnann kata" [
//             testCase "should return the result for ann" <| (fun _ ->
//                 testAnn 6  [1; 1; 2; 2; 3; 3]
//                 testAnn 15 [1; 1; 2; 2; 3; 3; 4; 5; 5; 6; 6; 7; 8; 8; 9]
//             );
//             testCase "should return the result for john" <| (fun _ ->
//                 testJohn 11 [0; 0; 1; 2; 2; 3; 4; 4; 5; 6; 6]
//                 testJohn 14 [0; 0; 1; 2; 2; 3; 4; 4; 5; 6; 6; 7; 7; 8]
//             );
//             testCase "should return the result for sumJohn" <| (fun _ ->
//                 testSumJohn 75 1720
//                 testSumJohn 78  1861
//             );
//             testCase "should return the result for sumAnn" <| (fun _ ->
//                 testSumAnn 115 4070
//                 testSumAnn 150 6930
//             );
//         ]
// end

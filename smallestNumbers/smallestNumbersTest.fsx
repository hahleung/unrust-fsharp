module Tests = begin
    open Fuchu

    let suite =
        testList "Kata Tests" [
            testCase "Basic tests" <| (fun _ ->
                Assert.Equal("Example", 13L, sumTwoSmallestNumbers [|5L; 8L; 12L; 19L; 22L|] )
                Assert.Equal("Example", 6L, sumTwoSmallestNumbers [|15L; 28L; 4L; 2L; 43L|] )
                Assert.Equal("Example", 10L, sumTwoSmallestNumbers [|3L; 87L; 45L; 12L; 7L|]  )
                Assert.Equal("Example", 24L, sumTwoSmallestNumbers [|23L; 71L; 33L; 82L; 1L|] )
                Assert.Equal("Example", 16L, sumTwoSmallestNumbers [|52L; 76L; 14L; 12L; 4L|] )
            );
        ]
end
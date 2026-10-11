/*
Rules: E15-6-2-1-parameter-array-single-dimension
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: reject
Mutate: params int[,] values
Into: params int[] values
Csc: CS0225
*/
class Holder { public void Touch(params int[,] values) { } }
class Program { static void Main() { } }

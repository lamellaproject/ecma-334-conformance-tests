/*
Rules: E15-6-2-1-params-must-be-last
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: reject
Mutate: params int[] values, int count
Into: int[] values, int count
Csc: CS0231
*/
class Holder { public void Touch(params int[] values, int count) { } }
class Program { static void Main() { } }

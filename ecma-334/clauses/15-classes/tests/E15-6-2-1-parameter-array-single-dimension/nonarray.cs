/*
Rules: E15-6-2-1-parameter-array-single-dimension
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: reject
Mutate: params int value
Into: params int[] value
*/
class Holder { public void Touch(params int value) { } }
class Program { static void Main() { } }

/*
Rules: E15-6-2-1-params-no-default
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: reject
Mutate: params int[] values = null
Into: params int[] values
Csc: CS1751
*/
class Holder { public void Touch(params int[] values = null) { } }
class Program { static void Main() { } }

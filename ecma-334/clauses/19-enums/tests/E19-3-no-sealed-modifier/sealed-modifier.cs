/*
Rules: E19-3-no-sealed-modifier
Authority: ECMA-334 7th ed 19.3
Version: 7.3
Expected: reject
Mutate: sealed enum Code
Into: enum Code
*/
sealed enum Code { Mark }
class Program { static void Main() { } }

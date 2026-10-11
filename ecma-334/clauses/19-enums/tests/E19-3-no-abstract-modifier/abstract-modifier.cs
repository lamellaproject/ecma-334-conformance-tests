/*
Rules: E19-3-no-abstract-modifier
Authority: ECMA-334 7th ed 19.3
Version: 7.3
Expected: reject
Mutate: abstract enum Code
Into: enum Code
*/
abstract enum Code { Mark }
class Program { static void Main() { } }

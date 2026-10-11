/*
Rules: E19-3-no-derivation
Authority: ECMA-334 7th ed 19.3
Version: 7.3
Expected: reject
Mutate: class Child : Code
Into: class Child : object
*/
enum Code { Mark }
class Child : Code { }
class Program { static void Main() { } }

/*
Rules: E15-3-1-static-constructor-name
Authority: ECMA-334 7th ed 15.3.1
Version: 7.3
Expected: reject
Mutate: static Other() { }
Into: static Meter() { }
*/
class Meter { static Other() { } }
class Program { static void Main() { } }

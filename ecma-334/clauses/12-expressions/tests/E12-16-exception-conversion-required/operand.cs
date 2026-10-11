/*
Rules: E12-16-exception-conversion-required
Authority: ECMA-334 7th ed 12.16
Version: 7.3
Expected: reject
Mutate: throw new Value()
Into: throw new System.Exception()
*/
class Value { }
class Program { static int Run(bool condition) { return condition ? throw new Value() : 3; } static void Main() { } }

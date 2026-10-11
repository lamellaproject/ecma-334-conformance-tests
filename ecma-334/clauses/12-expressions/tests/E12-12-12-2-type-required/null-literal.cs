/*
Rules: E12-12-12-2-type-required
Authority: ECMA-334 7th ed 12.12.12.2
Version: 7.3
Expected: reject
Mutate: null is var value
Into: (object)null is var value
*/
class Program { static void Main() { bool b = null is var value; } }

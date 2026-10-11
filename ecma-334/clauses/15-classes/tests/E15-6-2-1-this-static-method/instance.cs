/*
Rules: E15-6-2-1-this-static-method; E15-6-2-1-this-static-class
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: reject
Mutate: this int value
Into: int value
*/
// An instance extension also fails the containing-static-class condition; the constraints are related.
class Holder { public int Read(this int value) { return value; } }
class Program { static void Main() { } }

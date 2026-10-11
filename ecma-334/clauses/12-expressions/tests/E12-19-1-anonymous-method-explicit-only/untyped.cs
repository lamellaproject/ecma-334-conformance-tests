/*
Rules: E12-19-1-anonymous-method-explicit-only
Authority: ECMA-334 7th ed 12.19.1
Version: 7.3
Expected: reject
Mutate: delegate(value)
Into: delegate(int value)
*/
delegate int Transform(int item);
class Program { static void Main() { Transform function = delegate(value) { return value; }; } }

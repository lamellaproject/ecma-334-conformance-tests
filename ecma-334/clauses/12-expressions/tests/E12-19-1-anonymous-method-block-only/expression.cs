/*
Rules: E12-19-1-anonymous-method-block-only
Authority: ECMA-334 7th ed 12.19.1
Version: 7.3
Expected: reject
Mutate: delegate(int value) value + 61
Into: delegate(int value) { return value + 61; }
*/
delegate int Transform(int item);
class Program { static void Main() { Transform function = delegate(int value) value + 61; } }

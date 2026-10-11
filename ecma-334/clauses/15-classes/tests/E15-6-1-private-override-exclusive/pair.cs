/*
Rules: E15-6-1-private-override-exclusive
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: private override int Read()
Into: protected override int Read()
Csc: CS0621
*/
class Parent { protected virtual int Read() { return 1; } }
class Holder : Parent { private override int Read() { return 29; } }
class Program { static void Main() { } }

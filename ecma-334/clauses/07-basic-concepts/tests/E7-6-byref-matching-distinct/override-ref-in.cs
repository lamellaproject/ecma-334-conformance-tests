/*
Rules: E7-6-byref-matching-distinct
Authority: ECMA-334 7th ed 7.6
Version: 7.3
Expected: reject
Mutate: override int Read(in int value)
Into: override int Read(ref int value)
*/
class Root { public virtual int Read(ref int value) { return value; } }
class Branch : Root { public override int Read(in int value) { return value; } }
class Program { static void Main() { } }
